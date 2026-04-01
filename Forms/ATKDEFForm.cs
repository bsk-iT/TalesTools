using System;
using System.Collections.Generic;
using System.Windows.Forms;
using _4RTools.Utils;
using _4RTools.Model;
using System.Windows.Input;
using System.Drawing;
using System.Linq;

namespace _4RTools.Forms
{
    public partial class ATKDEFForm : Form, IObserver
    {
        public static int TOTAL_ATKDEF_LANES = 8;
        public static int TOTAL_EQUIPS = 6;

        // Controles para mostrar/ocultar lanes dinamicamente
        private ComboBox comboBoxEquipCount;
        private Label labelEquipCount;

        // Layout defaults (ajustáveis)
        private const int RIGHT_MARGIN = 24;
        private const int SHIFT_FROM_RIGHT = 10;
        private const int TOP_OFFSET = 15;
        private const int CONTROL_SPACING = 8;

        public ATKDEFForm(Subject subject)
        {
            subject.Attach(this);
            InitializeComponent();

            // Garantir que nenhum GroupBox de equipamento seja visível por padrão
            HideAllEquipGroups();

            // Registra eventos e handlers
            SetupInputs();

            // Inicializa combo dinamicamente (0 = nenhum)
            InitializeEquipCountCombo();

            // Posiciona controles de seleção e ajusta no resize
            PositionEquipControls();
            this.Resize += (s, e) => PositionEquipControls();

            // Por padrão não mostrar nenhum GroupBox
            UpdateVisibleLanes(0);
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    // Preenche os dados do perfil (controles podem estar invisíveis)
                    UpdateUi();

                    // Não mostrar automaticamente: manter em 0 até o usuário escolher
                    if (comboBoxEquipCount != null)
                    {
                        comboBoxEquipCount.SelectedIndex = 0; // "0" == nenhum visível
                        UpdateVisibleLanes(0);
                    }
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().AtkDefMode.Start();
                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().AtkDefMode.Stop();
                    break;
            }
        }

        private void HideAllEquipGroups()
        {
            for (int i = 1; i <= TOTAL_ATKDEF_LANES; i++)
            {
                try
                {
                    var found = this.Controls.Find("equipGroup" + i, true);
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
                GroupBox group = (GroupBox)this.Controls.Find("equipGroup" + id, true)[0];
                EquipConfig exist = ProfileSingleton.GetCurrent().AtkDefMode.equipConfigs.Find(config => config.id == id);
                if (exist == null)
                {
                    ProfileSingleton.GetCurrent().AtkDefMode.equipConfigs.Add(new EquipConfig(id, Key.None));
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AtkDefMode);
                }
                EquipConfig equipConfig = new EquipConfig(ProfileSingleton.GetCurrent().AtkDefMode.equipConfigs[id - 1]);
                FormUtils.ResetForm(group);

                Control[] cKey = group.Controls.Find("in" + id + "SpammerKey", true);
                if (cKey.Length > 0)
                {
                    TextBox textBox = (TextBox)cKey[0];
                    textBox.Text = equipConfig.keySpammer.ToString();
                }

                Control[] cSpammerDelay = group.Controls.Find("in" + id + "SpammerDelay", true);
                if (cSpammerDelay.Length > 0)
                {
                    NumericUpDown numeric = (NumericUpDown)cSpammerDelay[0];
                    numeric.Value = equipConfig.ahkDelay;
                }

                Control[] cSwitchDelay = group.Controls.Find("in" + id + "SwitchDelay", true);
                if (cSwitchDelay.Length > 0)
                {
                    NumericUpDown numeric = (NumericUpDown)cSwitchDelay[0];
                    numeric.Value = equipConfig.switchDelay;
                }

                Control[] cSpammerClick = group.Controls.Find("in" + id + "SpammerClick", true);
                if (cSpammerClick.Length > 0)
                {
                    CheckBox checkBox = (CheckBox)cSpammerClick[0];
                    checkBox.Checked = equipConfig.keySpammerWithClick;
                }

                Dictionary<string, Key> atkKeys = new Dictionary<string, Key>(equipConfig.atkKeys);
                Dictionary<string, Key> defKeys = new Dictionary<string, Key>(equipConfig.defKeys);

                for (int i = 1; i <= TOTAL_EQUIPS; i++)
                {
                    Control[] equipDef = group.Controls.Find("in" + id + "Def" + i, true);
                    TextBox tbDef = (TextBox)equipDef[0];
                    tbDef.Text = defKeys.ContainsKey(tbDef.Name) ? defKeys[tbDef.Name].ToString() : Keys.None.ToString();

                    Control[] equipAtk = group.Controls.Find("in" + id + "Atk" + i, true);
                    TextBox tbAtk = (TextBox)equipAtk[0];
                    tbAtk.Text = atkKeys.ContainsKey(tbAtk.Name) ? atkKeys[tbAtk.Name].ToString() : Keys.None.ToString();
                }
            }
            catch (Exception ex)
            {
                var exc = ex;
            }
            ;
        }

        private void UpdateUi()
        {
            for (int i = 1; i <= TOTAL_ATKDEF_LANES; i++)
            {
                UpdatePanelData(i);
            }
        }

        private void onDelayChange(object sender, EventArgs e)
        {
            NumericUpDown delayInput = (NumericUpDown)sender;

            string[] inputTag = delayInput.Tag.ToString().Split(new[] { ":" }, StringSplitOptions.None);
            int id = short.Parse(inputTag[0]);
            string type = inputTag[1];
            EquipConfig equipConfig = ProfileSingleton.GetCurrent().AtkDefMode.equipConfigs.Find(config => config.id == id);

            if (type == "spammerDelay")
            {
                //Spammer Delay Change
                equipConfig.ahkDelay = decimal.ToInt16(delayInput.Value);
            }
            else
            {
                //Switch Delay Change
                equipConfig.switchDelay = decimal.ToInt16(delayInput.Value);
            }

            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AtkDefMode);
        }

        private void onTextChange(object sender, EventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            Key key = (Key)Enum.Parse(typeof(Key), textBox.Text.ToString());

            string[] inputTag = textBox.Tag.ToString().Split(new[] { ":" }, StringSplitOptions.None);
            int id = short.Parse(inputTag[0]);
            string type = inputTag[1];
            EquipConfig equipConfig = ProfileSingleton.GetCurrent().AtkDefMode.equipConfigs.Find(config => config.id == id);

            if (type.Equals("spammerKey"))
            {
                equipConfig.keySpammer = key;
            }
            else
            {
                type = inputTag[1].Remove(inputTag[1].Length - 1).ToUpper();
                ProfileSingleton.GetCurrent().AtkDefMode.AddSwitchItem(id, textBox.Name, key, type);
            }
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AtkDefMode);

        }

        private void ChkBox_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox checkBox = (CheckBox)sender;

            string[] inputTag = checkBox.Tag.ToString().Split(new[] { ":" }, StringSplitOptions.None);
            int id = short.Parse(inputTag[0]);

            EquipConfig equipConfig = ProfileSingleton.GetCurrent().AtkDefMode.equipConfigs.Find(config => config.id == id);
            equipConfig.keySpammerWithClick = checkBox.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AtkDefMode);
        }

        public void SetupInputs()
        {
            try
            {
                foreach (Control c in FormUtils.GetAll(this, typeof(TextBox)))
                {
                    if (c is TextBox)
                    {
                        TextBox textBox = (TextBox)c;
                        textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
                        textBox.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
                        textBox.TextChanged += new EventHandler(this.onTextChange);
                    }

                }

                foreach (Control c in FormUtils.GetAll(this, typeof(NumericUpDown)))
                {
                    if (c is NumericUpDown)
                    {
                        NumericUpDown numericUpDown = (NumericUpDown)c;
                        numericUpDown.ValueChanged += new EventHandler(this.onDelayChange);
                    }

                }

                foreach (Control c in FormUtils.GetAll(this, typeof(CheckBox)))
                {
                    if (c is CheckBox)
                    {
                        CheckBox numericUpDown = (CheckBox)c;
                        numericUpDown.CheckedChanged += new EventHandler(this.ChkBox_CheckedChanged);
                    }

                }
            }
            catch { }

        }

        // --- NOVAS FUNÇÕES: Combo + lógica para mostrar/hide dos equipGroup ---

        private void InitializeEquipCountCombo()
        {
            // Label
            labelEquipCount = new Label
            {
                Text = "MACROS:",
                ForeColor = Color.White,
                AutoSize = true,
                Font = this.Font
            };

            // ComboBox (0 = nenhum visível)
            comboBoxEquipCount = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(20, 20, 20),
                ForeColor = Color.White,
                Size = new Size(60, 24)
            };
            comboBoxEquipCount.SelectedIndexChanged += comboBoxEquipCount_SelectedIndexChanged;

            comboBoxEquipCount.Items.Clear();
            comboBoxEquipCount.Items.Add("0");
            for (int i = 1; i <= TOTAL_ATKDEF_LANES; i++)
            {
                comboBoxEquipCount.Items.Add(i.ToString());
            }

            this.Controls.Add(labelEquipCount);
            this.Controls.Add(comboBoxEquipCount);

            // posicionamento relativo à direita
            labelEquipCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxEquipCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // padrão = 0 (nenhum)
            comboBoxEquipCount.SelectedIndex = 0;
        }

        private void PositionEquipControls()
        {
            if (comboBoxEquipCount == null || labelEquipCount == null) return;

            int spacing = CONTROL_SPACING;
            int comboW = comboBoxEquipCount.Width;
            int labelW = labelEquipCount.Width;

            int rightEdge = this.ClientSize.Width - RIGHT_MARGIN - SHIFT_FROM_RIGHT;
            int comboX = Math.Max(10, rightEdge - comboW);
            int labelX = comboX - spacing - labelW;
            int y = TOP_OFFSET;

            labelEquipCount.Location = new Point(labelX, y + (comboBoxEquipCount.Height / 2) - (labelEquipCount.Height / 2));
            comboBoxEquipCount.Location = new Point(comboX, y);
        }

        private int GetSelectedEquipCount()
        {
            int count = 0;
            if (comboBoxEquipCount != null && comboBoxEquipCount.SelectedItem != null)
            {
                int.TryParse(comboBoxEquipCount.SelectedItem.ToString(), out count);
            }
            return Math.Max(0, Math.Min(TOTAL_ATKDEF_LANES, count));
        }

        private void comboBoxEquipCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = GetSelectedEquipCount();
            UpdateVisibleLanes(count);
        }

        private void UpdateVisibleLanes(int count)
        {
            for (int i = 1; i <= TOTAL_ATKDEF_LANES; i++)
            {
                try
                {
                    Control[] found = this.Controls.Find("equipGroup" + i, true);
                    if (found.Length > 0 && found[0] is GroupBox)
                    {
                        GroupBox group = (GroupBox)found[0];
                        group.Visible = (i <= count && count > 0);
                    }
                }
                catch { }
            }

            PositionEquipControls();
        }
    }
}