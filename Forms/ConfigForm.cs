using System;
using _4RTools.Model;
using System.Windows.Forms;
using _4RTools.Utils;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;

namespace _4RTools.Forms
{
    public partial class ConfigForm : Form, IObserver
    {
        private CustomButtonForm customButtonForm;

        public ConfigForm(Subject subject)
        {
            InitializeComponent();
            this.textReinKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.textReinKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.textReinKey.TextChanged += new EventHandler(this.textReinKey_TextChanged);

            // Eventos para rédea automática
            this.txtAutoReinKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtAutoReinKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtAutoReinKey.TextChanged += new EventHandler(this.txtAutoReinKey_TextChanged_1);

            this.ammo1textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.ammo1textBox.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.ammo1textBox.TextChanged += new EventHandler(this.textAmmo1_TextChanged);
            this.ammo2textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.ammo2textBox.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.ammo2textBox.TextChanged += new EventHandler(this.textAmmo2_TextChanged);

            // ToolTips
            toolTip1.SetToolTip(switchAmmoCheckBox, "Intercala entre as munições");
            toolTip2.SetToolTip(textReinKey, "Atalho para desmontar da rédea");
            toolTip3.SetToolTip(ammo1textBox, "Atalho munição 1");
            toolTip4.SetToolTip(ammo2textBox, "Atalho munição 2");
            toolTip5.SetToolTip(txtAutoReinKey, "Tecla para usar rédea automática");
            toolTip5.SetToolTip(chkAutoReinEnabled, "Usa rédea automaticamente após andar X células");
            toolTip5.SetToolTip(numAutoReinCells, "Quantidade de células para usar rédea automática");

            subject.Attach(this);
            InitializeCustomButtonForm(subject);

        }

        // Adicionar este método
        private void InitializeCustomButtonForm(Subject subject)
        {
            // Criar uma instância do CustomButtonForm
            customButtonForm = new CustomButtonForm(subject);

            // Configurar o CustomButtonForm como um controle filho
            customButtonForm.TopLevel = false;
            customButtonForm.FormBorderStyle = FormBorderStyle.None;
            customButtonForm.Dock = DockStyle.Fill;


            groupBox2.Controls.Add(customButtonForm);
            customButtonForm.Show();
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    UpdateUI(subject);
                    break;
            }
        }

        public void UpdateUI(ISubject subject)
        {
            try
            {
                // Desvincula temporariamente os eventos para evitar salvamentos durante o carregamento
                this.textReinKey.TextChanged -= this.textReinKey_TextChanged;
                this.ammo1textBox.TextChanged -= this.textAmmo1_TextChanged;
                this.ammo2textBox.TextChanged -= this.textAmmo2_TextChanged;
                this.txtAutoReinKey.TextChanged -= this.txtAutoReinKey_TextChanged_1;
                this.numAutoReinCells.ValueChanged -= this.numAutoReinCells_ValueChanged;

                // Desvincula os CheckBoxes
                this.chkStopBuffsOnCity.CheckedChanged -= this.chkStopBuffsOnCity_CheckedChanged;
                this.chkStopBuffsOnRein.CheckedChanged -= this.chkStopBuffsOnRein_CheckedChanged;
                this.chkStopHealOnCity.CheckedChanged -= this.chkStopHealOnCity_CheckedChanged;
                this.getOffReinCheckBox.CheckedChanged -= this.getOffReinCheckBox_CheckedChanged;
                this.chkStopWithChat.CheckedChanged -= this.chkStopWithChat_CheckedChanged;
                this.chkAutoReinEnabled.CheckedChanged -= this.chkAutoReinEnabled_CheckedChanged;
                this.switchAmmoCheckBox.CheckedChanged -= this.switchAmmoCheckBox_CheckedChanged;

                // Atualiza os valores
                this.chkStopBuffsOnCity.Checked = ProfileSingleton.GetCurrent().UserPreferences.stopBuffsCity;
                this.chkStopBuffsOnRein.Checked = ProfileSingleton.GetCurrent().UserPreferences.stopBuffsRein;
                this.chkStopHealOnCity.Checked = ProfileSingleton.GetCurrent().UserPreferences.stopHealCity;
                this.getOffReinCheckBox.Checked = ProfileSingleton.GetCurrent().UserPreferences.getOffRein;

                // Mostrar vazio se a tecla for Key.None
                var getOffKey = ProfileSingleton.GetCurrent().UserPreferences.getOffReinKey;
                this.textReinKey.Text = (getOffKey != Key.None) ? getOffKey.ToString() : "";

                this.switchAmmoCheckBox.Checked = ProfileSingleton.GetCurrent().UserPreferences.switchAmmo;

                var ammo1 = ProfileSingleton.GetCurrent().UserPreferences.ammo1Key;
                this.ammo1textBox.Text = (ammo1 != Key.None) ? ammo1.ToString() : "";

                var ammo2 = ProfileSingleton.GetCurrent().UserPreferences.ammo2Key;
                this.ammo2textBox.Text = (ammo2 != Key.None) ? ammo2.ToString() : "";

                this.chkStopWithChat.Checked = ProfileSingleton.GetCurrent().UserPreferences.stopWithChat;

                // Configurações de rédea automática
                this.chkAutoReinEnabled.Checked = ProfileSingleton.GetCurrent().UserPreferences.autoReinEnabled;
                this.numAutoReinCells.Value = ProfileSingleton.GetCurrent().UserPreferences.autoReinCellCount;

                var autoReinKey = ProfileSingleton.GetCurrent().UserPreferences.autoReinKey;
                this.txtAutoReinKey.Text = (autoReinKey != Key.None) ? autoReinKey.ToString() : "";

                // Reconecta os eventos
                this.textReinKey.TextChanged += this.textReinKey_TextChanged;
                this.ammo1textBox.TextChanged += this.textAmmo1_TextChanged;
                this.ammo2textBox.TextChanged += this.textAmmo2_TextChanged;
                this.txtAutoReinKey.TextChanged += this.txtAutoReinKey_TextChanged_1;
                this.numAutoReinCells.ValueChanged += this.numAutoReinCells_ValueChanged;

                this.chkStopBuffsOnCity.CheckedChanged += this.chkStopBuffsOnCity_CheckedChanged;
                this.chkStopBuffsOnRein.CheckedChanged += this.chkStopBuffsOnRein_CheckedChanged;
                this.chkStopHealOnCity.CheckedChanged += this.chkStopHealOnCity_CheckedChanged;
                this.getOffReinCheckBox.CheckedChanged += this.getOffReinCheckBox_CheckedChanged;
                this.chkStopWithChat.CheckedChanged += this.chkStopWithChat_CheckedChanged;
                this.chkAutoReinEnabled.CheckedChanged += this.chkAutoReinEnabled_CheckedChanged;
                this.switchAmmoCheckBox.CheckedChanged += this.switchAmmoCheckBox_CheckedChanged;
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
        }

        // Event Handlers para Rédea Automática
        private void chkAutoReinEnabled_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.autoReinEnabled = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void numAutoReinCells_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = sender as NumericUpDown;
            ProfileSingleton.GetCurrent().UserPreferences.autoReinCellCount = (int)num.Value;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void txtAutoReinKey_TextChanged(object sender, EventArgs e)
        {
            // manter compatibilidade caso outro handler chame este método
            txtAutoReinKey_TextChanged_1(sender, e);
        }

        private void txtAutoReinKey_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBox = (TextBox)sender;
                if (string.IsNullOrEmpty(txtBox.Text))
                {
                    ProfileSingleton.GetCurrent().UserPreferences.autoReinKey = Key.None;
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                }
                else
                {
                    Key key = (Key)Enum.Parse(typeof(Key), txtBox.Text.ToString());
                    ProfileSingleton.GetCurrent().UserPreferences.autoReinKey = key;
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                }
            }
            catch { }
        }

        // Event Handlers existentes
        private void chkStopBuffsOnRein_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.stopBuffsRein = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void chkStopBuffsOnCity_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.stopBuffsCity = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void chkStopHealOnCity_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.stopHealCity = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void getOffReinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.getOffRein = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void chkStopWithChat_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.stopWithChat = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void textReinKey_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBox = (TextBox)sender;
                if (string.IsNullOrEmpty(txtBox.Text))
                {
                    ProfileSingleton.GetCurrent().UserPreferences.getOffReinKey = Key.None;
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                    return;
                }

                Key key = (Key)Enum.Parse(typeof(Key), txtBox.Text.ToString());
                ProfileSingleton.GetCurrent().UserPreferences.getOffReinKey = key;
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
            }
            catch { }
        }

        private void switchAmmoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.switchAmmo = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void textAmmo1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBox = (TextBox)sender;
                if (string.IsNullOrEmpty(txtBox.Text))
                {
                    ProfileSingleton.GetCurrent().UserPreferences.ammo1Key = Key.None;
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                    return;
                }

                Key key = (Key)Enum.Parse(typeof(Key), txtBox.Text.ToString());
                ProfileSingleton.GetCurrent().UserPreferences.ammo1Key = key;
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
            }
            catch { }
        }

        private void textAmmo2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBox = (TextBox)sender;
                if (string.IsNullOrEmpty(txtBox.Text))
                {
                    ProfileSingleton.GetCurrent().UserPreferences.ammo2Key = Key.None;
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                    return;
                }

                Key key = (Key)Enum.Parse(typeof(Key), txtBox.Text.ToString());
                ProfileSingleton.GetCurrent().UserPreferences.ammo2Key = key;
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
            }
            catch { }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textReinKey_TextChanged_1(object sender, EventArgs e)
        {
            // mantido compatível caso o Designer ou outro trecho chame este nome
            textReinKey_TextChanged(sender, e);
        }
    }
}