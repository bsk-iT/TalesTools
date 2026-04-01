using System;
using _4RTools.Model;
using _4RTools.Utils;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using System.Drawing;
using System.Linq;

namespace _4RTools.Forms
{
    public partial class MacroSongForm : Form, IObserver
    {
        public static int TOTAL_MACRO_LANES_FOR_SONGS = 8;

        // Controles para selecionar quantas lanes mostrar
        private ComboBox comboBoxMacroCount;
        private Label labelMacroCount;

        // Layout defaults
        private const int RIGHT_MARGIN = 24;
        private const int SHIFT_FROM_RIGHT = 10;
        private const int TOP_OFFSET = 15;
        private const int CONTROL_SPACING = 8;

        public MacroSongForm(Subject subject)
        {
            subject.Attach(this);
            InitializeComponent();

            // Garantir que nenhum painel/macro esteja visível por padrão
            HideAllMacroGroups();

            configureMacroLanes();

            // Inicializa combo dinamicamente (0 = nenhum)
            InitializeMacroCountCombo();

            // Posiciona controles e ajusta ao redimensionar
            PositionMacroControls();
            this.Resize += (s, e) => PositionMacroControls();

            // Segurança: garantir nenhum visível
            UpdateVisibleLanes(0);
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    // carrega os dados (permanece oculto até o usuário escolher)
                    updateUi();

                    if (comboBoxMacroCount != null)
                    {
                        comboBoxMacroCount.SelectedIndex = 0; // "0" == nenhum visível
                        UpdateVisibleLanes(0);
                    }
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().SongMacro.Start();
                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().SongMacro.Stop();
                    break;
            }
        }

        private void HideAllMacroGroups()
        {
            for (int i = 1; i <= TOTAL_MACRO_LANES_FOR_SONGS; i++)
            {
                try
                {
                    var found = this.Controls.Find("panelMacro" + i, true);
                    if (found.Length > 0 && found[0] is GroupBox g)
                    {
                        g.Visible = false;
                    }
                }
                catch { }
            }
        }

        private void UpdatePanelData(int id)
        {
            try
            {
                Macro songMacro = ProfileSingleton.GetCurrent().SongMacro;
                GroupBox p = (GroupBox)this.Controls.Find("panelMacro" + id, true)[0];
                ChainConfig chainConfig = new ChainConfig(songMacro.chainConfigs[id - 1]);

                // Desvincula eventos
                DisconnectPanelEvents(p);

                FormUtils.ResetForm(p);

                //Update Trigger Macro Value
                Control[] c = p.Controls.Find("inTriggerMacro" + chainConfig.id, true);
                if (c.Length > 0)
                {
                    TextBox textBox = (TextBox)c[0];
                    // ═══════════════════════════════════════════════════════════
                    // MOSTRA VAZIO SE FOR Key.None
                    // ═══════════════════════════════════════════════════════════
                    textBox.Text = (chainConfig.trigger != Key.None)
                        ? chainConfig.trigger.ToString()
                        : "";
                }

                //Update Dagger Value
                Control[] cDagger = p.Controls.Find("inDaggerMacro" + chainConfig.id, true);
                if (cDagger.Length > 0)
                {
                    TextBox textBox = (TextBox)cDagger[0];
                    textBox.Text = (chainConfig.daggerKey != Key.None)
                        ? chainConfig.daggerKey.ToString()
                        : "";
                }

                //Update Instrument Value
                Control[] cInstrument = p.Controls.Find("inInstrumentMacro" + chainConfig.id, true);
                if (cInstrument.Length > 0)
                {
                    TextBox textBox = (TextBox)cInstrument[0];
                    textBox.Text = (chainConfig.instrumentKey != Key.None)
                        ? chainConfig.instrumentKey.ToString()
                        : "";
                }

                List<string> names = new List<string>(chainConfig.macroEntries.Keys);
                foreach (string cbName in names)
                {
                    Control[] controls = p.Controls.Find(cbName, true);
                    if (controls.Length > 0)
                    {
                        TextBox textBox = (TextBox)controls[0];
                        Key entryKey = chainConfig.macroEntries[cbName].key;
                        textBox.Text = (entryKey != Key.None)
                            ? entryKey.ToString()
                            : "";
                    }
                }

                //Update Delay Macro Value
                Control[] d = p.Controls.Find("delayMac" + chainConfig.id, true);
                if (d.Length > 0)
                {
                    NumericUpDown delayInput = (NumericUpDown)d[0];
                    delayInput.Value = chainConfig.delay;
                }

                // Reconecta eventos
                ReconnectPanelEvents(p);
            }
            catch { }
        }

        // ═══════════════════════════════════════════════════════════
        // MÉTODOS AUXILIARES PARA GERENCIAR EVENTOS
        // ═══════════════════════════════════════════════════════════

        private void DisconnectPanelEvents(GroupBox panel)
        {
            try
            {
                foreach (Control c in panel.Controls)
                {
                    if (c is TextBox textBox)
                    {
                        textBox.TextChanged -= this.onTextChange;
                    }
                    else if (c is NumericUpDown numericUpDown)
                    {
                        numericUpDown.ValueChanged -= this.onDelayChange;
                    }
                    else if (c is Button button)
                    {
                        button.Click -= this.onReset;
                    }
                }
            }
            catch { }
        }

        private void ReconnectPanelEvents(GroupBox panel)
        {
            try
            {
                foreach (Control c in panel.Controls)
                {
                    if (c is TextBox textBox)
                    {
                        textBox.TextChanged += this.onTextChange;
                    }
                    else if (c is NumericUpDown numericUpDown)
                    {
                        numericUpDown.ValueChanged += this.onDelayChange;
                    }
                    else if (c is Button button)
                    {
                        button.Click += this.onReset;
                    }
                }
            }
            catch { }
        }

        private void onTextChange(object sender, EventArgs e)
        {
            try
            {
                Macro SongMacro = ProfileSingleton.GetCurrent().SongMacro;
                TextBox textBox = (TextBox)sender;

                // ═══════════════════════════════════════════════════════════
                // TRATA TEXTBOX VAZIO - Define como Key.None
                // ═══════════════════════════════════════════════════════════
                Key key = Key.None;

                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    key = (Key)Enum.Parse(typeof(Key), textBox.Text.ToString());
                }

                if (textBox.Tag != null)
                {
                    //Could be Trigger, Dagger or Instrument input
                    string[] inputTag = textBox.Tag.ToString().Split(new[] { ":" }, StringSplitOptions.None);
                    int macroid = short.Parse(inputTag[0]);
                    string type = inputTag[1];
                    ChainConfig chainConfig = ProfileSingleton.GetCurrent().SongMacro.chainConfigs.Find(config => config.id == macroid);

                    switch (type)
                    {
                        case "Dagger":
                            chainConfig.daggerKey = key;
                            break;
                        case "Instrument":
                            chainConfig.instrumentKey = key;
                            break;
                        case "Trigger":
                            chainConfig.trigger = key;
                            break;
                    }
                }
                else
                {
                    int macroID = short.Parse(textBox.Name.Split(new[] { "mac" }, StringSplitOptions.None)[1]);
                    ChainConfig chainConfig = SongMacro.chainConfigs.Find(songMacro => songMacro.id == macroID);
                    if (chainConfig == null)
                    {
                        SongMacro.chainConfigs.Add(new ChainConfig(macroID, Key.None));
                        chainConfig = SongMacro.chainConfigs.Find(songMacro => songMacro.id == macroID);
                    }
                    chainConfig.macroEntries[textBox.Name] = new MacroKey(key, chainConfig.delay);
                }

                ProfileSingleton.SetConfiguration(SongMacro);
            }
            catch { }
        }

        private void onDelayChange(object sender, EventArgs e)
        {
            Macro SongMacro = ProfileSingleton.GetCurrent().SongMacro;
            NumericUpDown delayInput = (NumericUpDown)sender;
            int macroID = Int16.Parse(delayInput.Name.Split(new[] { "delayMac" }, StringSplitOptions.None)[1]);
            ChainConfig chainConfig = SongMacro.chainConfigs.Find(songMacro => songMacro.id == macroID);

            chainConfig.delay = decimal.ToInt16(delayInput.Value);

            List<string> names = new List<string>(chainConfig.macroEntries.Keys);
            foreach (string cbName in names)
            {
                chainConfig.macroEntries[cbName].delay = chainConfig.delay;
            }
            ProfileSingleton.SetConfiguration(SongMacro);
        }

        private void onReset(object sender, EventArgs e)
        {
            Macro SongMacro = ProfileSingleton.GetCurrent().SongMacro;
            Button delayInput = (Button)sender;
            int btnResetID = Int16.Parse(delayInput.Name.Split(new[] { "btnResMac" }, StringSplitOptions.None)[1]);
            ProfileSingleton.SetConfiguration(SongMacro);
            this.UpdatePanelData(btnResetID);
        }


        private void updateUi()
        {
            for (int i = 1; i <= TOTAL_MACRO_LANES_FOR_SONGS; i++)
            {
                UpdatePanelData(i);
            }
        }

        private void configureMacroLanes()
        {
            for (int i = 1; i <= TOTAL_MACRO_LANES_FOR_SONGS; i++)
            {
                initializeLane(i);
            }
        }

        private void initializeLane(int id)
        {
            try
            {
                GroupBox p = (GroupBox)this.Controls.Find("panelMacro" + id, true)[0];
                foreach (Control c in p.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox textBox = (TextBox)c;
                        textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
                        textBox.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
                        textBox.TextChanged += new EventHandler(this.onTextChange);
                    }

                    if (c is Button)
                    {
                        Button resetButton = (Button)c;
                        resetButton.Click += new EventHandler(this.onReset);
                    }

                    if (c is NumericUpDown)
                    {
                        NumericUpDown numericUpDown = (NumericUpDown)c;
                        numericUpDown.ValueChanged += new EventHandler(this.onDelayChange);
                    }
                }
            }
            catch { }
        }

        // --- NOVAS FUNÇÕES: Combo + lógica para mostrar/hide dos macro panels ---

        private void InitializeMacroCountCombo()
        {
            // Label
            labelMacroCount = new Label
            {
                Text = "MACROS:",
                ForeColor = Color.White,
                AutoSize = true,
                Font = this.Font
            };

            // ComboBox (0 = nenhum visível)
            comboBoxMacroCount = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(20, 20, 20),
                ForeColor = Color.White,
                Size = new Size(60, 24)
            };
            comboBoxMacroCount.SelectedIndexChanged += comboBoxMacroCount_SelectedIndexChanged;

            comboBoxMacroCount.Items.Clear();
            comboBoxMacroCount.Items.Add("0");
            for (int i = 1; i <= TOTAL_MACRO_LANES_FOR_SONGS; i++)
            {
                comboBoxMacroCount.Items.Add(i.ToString());
            }

            this.Controls.Add(labelMacroCount);
            this.Controls.Add(comboBoxMacroCount);

            // posicionamento relativo à direita
            labelMacroCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxMacroCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // padrão = 0 (nenhum)
            comboBoxMacroCount.SelectedIndex = 0;
        }

        private void PositionMacroControls()
        {
            if (comboBoxMacroCount == null || labelMacroCount == null) return;

            int spacing = CONTROL_SPACING;
            int comboW = comboBoxMacroCount.Width;
            int labelW = labelMacroCount.Width;

            int rightEdge = this.ClientSize.Width - RIGHT_MARGIN - SHIFT_FROM_RIGHT;
            int comboX = Math.Max(10, rightEdge - comboW);
            int labelX = comboX - spacing - labelW;
            int y = TOP_OFFSET;

            labelMacroCount.Location = new Point(labelX, y + (comboBoxMacroCount.Height / 2) - (labelMacroCount.Height / 2));
            comboBoxMacroCount.Location = new Point(comboX, y);
        }

        private int GetSelectedMacroCount()
        {
            int count = 0;
            if (comboBoxMacroCount != null && comboBoxMacroCount.SelectedItem != null)
            {
                int.TryParse(comboBoxMacroCount.SelectedItem.ToString(), out count);
            }
            return Math.Max(0, Math.Min(TOTAL_MACRO_LANES_FOR_SONGS, count));
        }

        private void comboBoxMacroCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = GetSelectedMacroCount();
            UpdateVisibleLanes(count);
        }

        private void UpdateVisibleLanes(int count)
        {
            for (int i = 1; i <= TOTAL_MACRO_LANES_FOR_SONGS; i++)
            {
                try
                {
                    Control[] found = this.Controls.Find("panelMacro" + i, true);
                    if (found.Length > 0 && found[0] is GroupBox)
                    {
                        GroupBox group = (GroupBox)found[0];
                        group.Visible = (i <= count && count > 0);
                    }
                }
                catch { }
            }

            PositionMacroControls();
        }
    }
}