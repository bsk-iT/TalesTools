using System;
using System.Windows.Forms;
using System.Windows.Input;
using System.Collections.Generic;
using _4RTools.Model;
using _4RTools.Utils;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;

namespace _4RTools.Forms
{
    public partial class MacroSwitchForm : Form, IObserver
    {
        public static int TOTAL_MACRO_LANES = 10;

        // Controles criados em runtime para não mexer no Designer
        private ComboBox comboBoxSwitchCount;
        private Label labelSwitchCount;

        // Layout defaults
        private const int RIGHT_MARGIN = 24;         // margem direita do formulário
        private const int SHIFT_FROM_RIGHT = 10;    // quanto deslocar para a esquerda a partir da borda direita (aproxima do groupbox)
        private const int TOP_OFFSET = 15;
        private const int CONTROL_SPACING = 8;

        public MacroSwitchForm(Subject subject)
        {
            subject.Attach(this);
            InitializeComponent();

            // Garantir que nenhum GroupBox de switch seja visível por padrão
            HideAllMacroGroups();

            ConfigureMacroLanes();

            // Inicializa combo dinamicamente e aplica visibilidade
            InitializeSwitchCountCombo();

            // Posiciona na lateral direita (próximo ao groupbox) e garante reposicionamento em resize
            PositionSwitchControls();
            this.Resize += (s, e) => PositionSwitchControls();

            // Por padrão não mostrar nenhum GroupBox (redundante mas seguro)
            UpdateVisibleLanes(0);
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    // Preenche dados do perfil nos controles (mesmo que invisíveis)
                    UpdateUi();

                    // Garante que nada apareça automaticamente ao trocar de perfil.
                    // O usuário deve escolher explicitamente quantos switches deseja ver.
                    if (comboBoxSwitchCount != null)
                    {
                        comboBoxSwitchCount.SelectedIndex = 0; // "0" == nenhum visível
                        UpdateVisibleLanes(0);
                    }
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().MacroSwitch.Start();
                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().MacroSwitch.Stop();
                    break;
            }
        }

        private void HideAllMacroGroups()
        {
            for (int i = 1; i <= TOTAL_MACRO_LANES; i++)
            {
                try
                {
                    var found = this.Controls.Find("chainGroup" + i, true);
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
                Control[] groupControls = this.Controls.Find("chainGroup" + id, true);
                if (groupControls == null || groupControls.Length == 0) return;

                GroupBox group = (GroupBox)groupControls[0];
                ChainConfig exist = ProfileSingleton.GetCurrent().MacroSwitch.chainConfigs.Find(config => config.id == id);
                if (exist == null)
                {
                    ProfileSingleton.GetCurrent().MacroSwitch.chainConfigs.Add(new ChainConfig(id, Key.None));
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().MacroSwitch);
                }
                ChainConfig chainConfig = new ChainConfig(ProfileSingleton.GetCurrent().MacroSwitch.chainConfigs[id - 1]);
                FormUtils.ResetForm(group);

                List<string> names = new List<string>(chainConfig.macroEntries.Keys);
                foreach (string cbName in names)
                {
                    Control[] controls = group.Controls.Find(cbName, true); // Keys
                    if (controls.Length > 0)
                    {
                        TextBox textBox = controls[0] as TextBox;
                        if (textBox != null)
                            textBox.Text = chainConfig.macroEntries[cbName].key == Key.None ? "" : chainConfig.macroEntries[cbName].key.ToString();
                    }

                    Control[] d = group.Controls.Find($"{cbName}delay", true); // Delays
                    if (d.Length > 0)
                    {
                        NumericUpDown delayInput = d[0] as NumericUpDown;
                        if (delayInput != null)
                            delayInput.Value = chainConfig.macroEntries[cbName].delay;
                    }

                    Control[] c = group.Controls.Find($"{cbName}click", true); // Clicks
                    if (c.Length > 0)
                    {
                        CheckBox checkInput = c[0] as CheckBox;
                        if (checkInput != null)
                            checkInput.Checked = chainConfig.macroEntries[cbName].hasClick;
                    }
                }
            }
            catch (Exception ex)
            {
                var exc = ex;
            }
        }

        private void OnTextChange(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox)sender;
                int chainID = Int16.Parse(textBox.Parent.Name.Split(new[] { "chainGroup" }, StringSplitOptions.None)[1]);
                GroupBox group = (GroupBox)this.Controls.Find("chainGroup" + chainID, true)[0];
                ChainConfig chainConfig = ProfileSingleton.GetCurrent().MacroSwitch.chainConfigs.Find(config => config.id == chainID);

                Key key = Key.None;
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    key = (Key)Enum.Parse(typeof(Key), textBox.Text.ToString());
                }

                NumericUpDown delayInput = (NumericUpDown)group.Controls.Find($"{textBox.Name}delay", true)[0];
                chainConfig.macroEntries[textBox.Name] = new MacroKey(key, decimal.ToInt16(delayInput.Value));

                bool isFirstInput = Regex.IsMatch(textBox.Name, $"in1mac{chainID}");
                if (isFirstInput) { chainConfig.trigger = key; }

                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().MacroSwitch);
            }
            catch (Exception)
            {
                // em caso de erro (parse etc), tenta definir como Key.None para evitar inconsistências
                try
                {
                    TextBox textBox = (TextBox)sender;
                    int chainID = Int16.Parse(textBox.Parent.Name.Split(new[] { "chainGroup" }, StringSplitOptions.None)[1]);
                    ChainConfig chainConfig = ProfileSingleton.GetCurrent().MacroSwitch.chainConfigs.Find(config => config.id == chainID);
                    chainConfig.macroEntries[textBox.Name] = new MacroKey(Key.None, 50);
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().MacroSwitch);
                }
                catch { }
            }
        }

        private void OnDelayChange(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown delayInput = (NumericUpDown)sender;
                int chainID = Int16.Parse(delayInput.Parent.Name.Split(new[] { "chainGroup" }, StringSplitOptions.None)[1]);
                ChainConfig chainConfig = ProfileSingleton.GetCurrent().MacroSwitch.chainConfigs.Find(config => config.id == chainID);

                String cbName = delayInput.Name.Split(new[] { "delay" }, StringSplitOptions.None)[0];
                if (chainConfig.macroEntries.ContainsKey(cbName))
                {
                    chainConfig.macroEntries[cbName].delay = decimal.ToInt16(delayInput.Value);
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().MacroSwitch);
                }
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
        }

        private void onCheckClickChange(object sender, EventArgs e)
        {
            try
            {
                CheckBox checkInput = (CheckBox)sender;
                int chainID = Int16.Parse(checkInput.Parent.Name.Split(new[] { "chainGroup" }, StringSplitOptions.None)[1]);
                ChainConfig chainConfig = ProfileSingleton.GetCurrent().MacroSwitch.chainConfigs.Find(config => config.id == chainID);

                String cbName = checkInput.Name.Split(new[] { "click" }, StringSplitOptions.None)[0];
                if (chainConfig.macroEntries.ContainsKey(cbName))
                {
                    chainConfig.macroEntries[cbName].hasClick = checkInput.Checked;
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().MacroSwitch);
                }
            }
            catch { }
        }

        private void UpdateUi()
        {
            for (int i = 1; i <= TOTAL_MACRO_LANES; i++)
            {
                UpdatePanelData(i);
            }
        }

        private void ConfigureMacroLanes()
        {
            for (int i = 1; i <= TOTAL_MACRO_LANES; i++)
            {
                InitializeLane(i);
            }
        }

        private void InitializeLane(int id)
        {
            try
            {
                Control[] found = this.Controls.Find("chainGroup" + id, true);
                if (found.Length == 0) return;

                GroupBox p = (GroupBox)found[0];
                foreach (Control control in p.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;
                        textBox.KeyDown -= FormUtils.OnKeyDown;
                        textBox.KeyPress -= FormUtils.OnKeyPress;
                        textBox.TextChanged -= OnTextChange;

                        textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
                        textBox.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
                        textBox.TextChanged += new EventHandler(this.OnTextChange);
                    }

                    if (control is NumericUpDown)
                    {
                        NumericUpDown delayInput = (NumericUpDown)control;
                        delayInput.ValueChanged -= OnDelayChange;
                        delayInput.ValueChanged += new System.EventHandler(this.OnDelayChange);
                    }

                    if (control is CheckBox)
                    {
                        CheckBox checkInput = (CheckBox)control;
                        checkInput.CheckedChanged -= onCheckClickChange;
                        checkInput.CheckedChanged += new System.EventHandler(this.onCheckClickChange);
                    }
                }
            }
            catch { }
        }

        private void chainGroup2_Enter(object sender, EventArgs e)
        {

        }

        private void InitializeSwitchCountCombo()
        {
            // Criar label
            labelSwitchCount = new Label
            {
                Text = "SWITCHES:",
                ForeColor = Color.White,
                AutoSize = true,
                Font = this.Font
            };

            // Criar ComboBox
            comboBoxSwitchCount = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(20, 20, 20),
                ForeColor = Color.White,
                Size = new Size(60, 24)
            };
            comboBoxSwitchCount.SelectedIndexChanged += comboBoxSwitchCount_SelectedIndexChanged;

            // Popular opções 0..TOTAL_MACRO_LANES (0 = nenhum visível)
            comboBoxSwitchCount.Items.Clear();
            comboBoxSwitchCount.Items.Add("0");
            for (int i = 1; i <= TOTAL_MACRO_LANES; i++)
            {
                comboBoxSwitchCount.Items.Add(i.ToString());
            }

            // Adicionar controles ao formulário (após designer)
            this.Controls.Add(labelSwitchCount);
            this.Controls.Add(comboBoxSwitchCount);

            // usar âncoras para manter posicionamento relativo em resize (direita)
            labelSwitchCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxSwitchCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Selecionar valor padrão = 0 (nenhum groupbox visível)
            comboBoxSwitchCount.SelectedIndex = 0;
        }

        // posiciona os controles na lateral direita, porém deslocados um pouco para a esquerda
        private void PositionSwitchControls()
        {
            if (comboBoxSwitchCount == null || labelSwitchCount == null) return;

            int spacing = CONTROL_SPACING;
            int comboW = comboBoxSwitchCount.Width;
            int labelW = labelSwitchCount.Width;

            // calcular ponto mais à direita disponível e deslocar para esquerda SHIFT_FROM_RIGHT
            int rightEdge = this.ClientSize.Width - RIGHT_MARGIN - SHIFT_FROM_RIGHT;
            // posição do combo (combo estará à direita do label)
            int comboX = Math.Max(10, rightEdge - comboW);
            int labelX = comboX - spacing - labelW;
            int y = TOP_OFFSET;

            labelSwitchCount.Location = new Point(labelX, y + (comboBoxSwitchCount.Height / 2) - (labelSwitchCount.Height / 2));
            comboBoxSwitchCount.Location = new Point(comboX, y);
        }

        private int GetSelectedSwitchCount()
        {
            int count = 0;
            if (comboBoxSwitchCount != null && comboBoxSwitchCount.SelectedItem != null)
            {
                int.TryParse(comboBoxSwitchCount.SelectedItem.ToString(), out count);
            }
            return Math.Max(0, Math.Min(TOTAL_MACRO_LANES, count));
        }

        private void comboBoxSwitchCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = GetSelectedSwitchCount();
            UpdateVisibleLanes(count);
        }

        private void UpdateVisibleLanes(int count)
        {
            for (int i = 1; i <= TOTAL_MACRO_LANES; i++)
            {
                try
                {
                    Control[] found = this.Controls.Find("chainGroup" + i, true);
                    if (found.Length > 0 && found[0] is GroupBox)
                    {
                        GroupBox group = (GroupBox)found[0];
                        group.Visible = (i <= count && count > 0);
                        // NÃO alteramos a posição do GroupBox — mantemos layout do Designer.
                    }
                }
                catch { /* ignorar */ }
            }

            // reajusta posição do combo/label
            PositionSwitchControls();
        }

        // Retorna o índice mais alto de switch que possui configuração no profile (trigger != Key.None ou entradas)
        private int GetConfiguredSwitchCountFromProfile()
        {
            try
            {
                var macro = ProfileSingleton.GetCurrent().MacroSwitch;
                if (macro == null || macro.chainConfigs == null || macro.chainConfigs.Count == 0) return 0;

                int maxConfigured = 0;
                foreach (var cfg in macro.chainConfigs)
                {
                    bool hasTrigger = cfg.trigger != Key.None;
                    bool hasEntries = cfg.macroEntries != null && cfg.macroEntries.Any(kvp =>
                    {
                        var mk = kvp.Value;
                        // considera configurado se key diferente de Key.None ou delay diferente do padrão ou click ativado
                        return mk != null && (mk.key != Key.None || mk.delay != 50 || mk.hasClick);
                    });

                    if (hasTrigger || hasEntries)
                    {
                        if (cfg.id > maxConfigured) maxConfigured = cfg.id;
                    }
                }
                return maxConfigured;
            }
            catch
            {
                return 0;
            }
        }
    }
}