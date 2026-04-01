using System.Windows.Forms;
using System;
using System.Windows.Input;
using _4RTools.Model;
using _4RTools.Utils;
using System.Drawing;

namespace _4RTools.Forms
{
    public partial class AutopotForm : Form, IObserver
    {
        private Autopot autopot;
        private bool isYgg;

        public AutopotForm(Subject subject, bool isYgg)
        {
            InitializeComponent();
            if (isYgg)
            {
                this.picBoxHP.Image = Resources._4RTools.ETCResource.Yggdrasil;
                this.picBoxSP.Image = Resources._4RTools.ETCResource.Yggdrasil;
                this.chkStopWitchFC.Hide();
                this.lblequipBefore.Hide();
                this.lblequipAfter.Hide();
                this.txtHpEquipAfter.Hide();
                this.txtHpEquipBefore.Hide();
                this.textBox1.Text = "YGG";
            }
            else
            {
                // Garante que seja POTIONS quando não for YGG
                this.textBox1.Text = "POTIONS";
            }
            subject.Attach(this);
            this.isYgg = isYgg;
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    this.autopot = this.isYgg ? ProfileSingleton.GetCurrent().AutopotYgg : ProfileSingleton.GetCurrent().Autopot;
                    InitializeApplicationForm();
                    break;
                case MessageCode.TURN_HEAL_OFF:
                    this.autopot.Stop();
                    break;
                case MessageCode.TURN_HEAL_ON:
                    this.autopot.Start();
                    break;
            }
        }

        private void InitializeApplicationForm()
        {
            // Configuração simples dos TextBox
            this.txtHpKey.Text = this.autopot.hpKey == Key.None ? "" : this.autopot.hpKey.ToString();
            this.txtSPKey.Text = this.autopot.spKey == Key.None ? "" : this.autopot.spKey.ToString();

            // Para equipamentos (se não for YGG)
            if (!this.isYgg)
            {
                this.txtHpEquipBefore.Text = this.autopot.hpEquipBefore == Key.None ? "" : this.autopot.hpEquipBefore.ToString();
                this.txtHpEquipAfter.Text = this.autopot.hpEquipAfter == Key.None ? "" : this.autopot.hpEquipAfter.ToString();
            }

            this.txtHPpct.Text = this.autopot.hpPercent.ToString();
            this.txtSPpct.Text = this.autopot.spPercent.ToString();
            this.txtAutopotDelay.Text = this.autopot.delay.ToString();
            this.chkStopWitchFC.Checked = this.autopot.stopWitchFC;
            RadioButton rdHealFirst = (RadioButton)this.Controls[ProfileSingleton.GetCurrent().Autopot.firstHeal];
            if (rdHealFirst != null) { rdHealFirst.Checked = true; }
            ;

            txtHpKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            txtHpKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            txtHpKey.TextChanged += new EventHandler(this.onHpTextChange);
            txtSPKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            txtSPKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            txtSPKey.TextChanged += new EventHandler(this.onSpTextChange);
            txtHpEquipBefore.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            txtHpEquipBefore.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            txtHpEquipBefore.TextChanged += new EventHandler(this.txtHpEquipBeforeTextChange);
            txtHpEquipAfter.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            txtHpEquipAfter.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            txtHpEquipAfter.TextChanged += new EventHandler(this.txtHpEquipAfterTextChange);
        }

        private void onHpTextChange(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                this.autopot.hpKey = Key.None;
            }
            else
            {
                Key key = (Key)Enum.Parse(typeof(Key), textBox.Text.ToString());
                this.autopot.hpKey = key;
            }

            ProfileSingleton.SetConfiguration(this.autopot);
            this.ActiveControl = null;
        }

        private void onSpTextChange(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                this.autopot.spKey = Key.None;
            }
            else
            {
                Key key = (Key)Enum.Parse(typeof(Key), textBox.Text.ToString());
                this.autopot.spKey = key;
            }

            ProfileSingleton.SetConfiguration(this.autopot);
            this.ActiveControl = null;
        }

        private void txtAutopotDelayTextChanged(object sender, EventArgs e)
        {
            try
            {
                this.autopot.delay = Int16.Parse(this.txtAutopotDelay.Text);
                ProfileSingleton.SetConfiguration(this.autopot);
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
        }

        private void txtHPpctTextChanged(object sender, EventArgs e)
        {
            try
            {
                this.autopot.hpPercent = Int16.Parse(this.txtHPpct.Text);
                ProfileSingleton.SetConfiguration(this.autopot);
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
        }

        private void chkStopWitchFC_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            this.autopot.stopWitchFC = chk.Checked;
            ProfileSingleton.SetConfiguration(this.autopot);
        }

        private void txtSPpctTextChanged(object sender, EventArgs e)
        {
            try
            {
                this.autopot.spPercent = Int16.Parse(this.txtSPpct.Text);
                ProfileSingleton.SetConfiguration(this.autopot);
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                this.autopot.firstHeal = rb.Name;
                ProfileSingleton.SetConfiguration(this.autopot);
            }
        }

        private void txtHpEquipAfterTextChange(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtHpEquipAfter.Text))
                {
                    this.autopot.hpEquipAfter = Key.None;
                }
                else
                {
                    Key key = (Key)Enum.Parse(typeof(Key), txtHpEquipAfter.Text.ToString());
                    this.autopot.hpEquipAfter = key;
                }
                ProfileSingleton.SetConfiguration(this.autopot);
                this.ActiveControl = null;
            }
            catch
            {
                // Em caso de erro, define como Key.None
                this.autopot.hpEquipAfter = Key.None;
                ProfileSingleton.SetConfiguration(this.autopot);
            }
        }

        private void txtHpEquipBeforeTextChange(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtHpEquipBefore.Text))
                {
                    this.autopot.hpEquipBefore = Key.None;
                }
                else
                {
                    Key key = (Key)Enum.Parse(typeof(Key), txtHpEquipBefore.Text.ToString());
                    this.autopot.hpEquipBefore = key;
                }
                ProfileSingleton.SetConfiguration(this.autopot);
                this.ActiveControl = null;
            }
            catch
            {
                // Em caso de erro, define como Key.None
                this.autopot.hpEquipBefore = Key.None;
                ProfileSingleton.SetConfiguration(this.autopot);
            }
        }

        private void AutopotForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}