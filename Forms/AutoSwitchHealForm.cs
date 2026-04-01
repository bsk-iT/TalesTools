using System.Windows.Forms;
using System;
using System.Windows.Input;
using _4RTools.Model;
using _4RTools.Utils;

namespace _4RTools.Forms
{
    public partial class AutoSwitchHealForm : Form, IObserver
    {
        private AutoSwitchHeal autoSwitchHeal;

        public AutoSwitchHealForm(Subject subject, bool isYgg)
        {
            InitializeComponent();
            // tenta inicializar com o perfil atual (pode ser null)
            this.autoSwitchHeal = ProfileSingleton.GetCurrent()?.AutoSwitchHeal;
            subject.Attach(this);
        }

        public void Update(ISubject subject)
        {
            if (subject == null) return;
            var s = subject as Subject;
            if (s == null || s.Message == null) return;

            switch (s.Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    this.autoSwitchHeal = ProfileSingleton.GetCurrent()?.AutoSwitchHeal;
                    InitializeApplicationForm();
                    break;
                case MessageCode.TURN_HEAL_OFF:
                    // tentar recuperar instância antes de usar
                    if (this.autoSwitchHeal == null) this.autoSwitchHeal = ProfileSingleton.GetCurrent()?.AutoSwitchHeal;
                    if (this.autoSwitchHeal != null)
                    {
                        try { this.autoSwitchHeal.Stop(); } catch { }
                    }
                    break;
                case MessageCode.TURN_HEAL_ON:
                    // tentar recuperar instância antes de usar
                    if (this.autoSwitchHeal == null) this.autoSwitchHeal = ProfileSingleton.GetCurrent()?.AutoSwitchHeal;
                    if (this.autoSwitchHeal != null)
                    {
                        try { this.autoSwitchHeal.Start(); } catch { }
                    }
                    break;
            }
        }

        private void InitializeApplicationForm()
        {
            SetupInputs();
        }
        public void SetupInputs()
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox textBox = (TextBox)c;
                        textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
                        textBox.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
                        textBox.TextChanged += new EventHandler(this.onTextChange);

                    }
                    if (c is NumericUpDown)
                    {
                        NumericUpDown numericUpDown = (NumericUpDown)c;
                        numericUpDown.ValueChanged += new EventHandler(this.onPercentChange);
                    }
                    FillForm(c);
                }
            }
            catch { }

        }

        private void FillForm(Control c)
        {
            // Se não houver perfil/carregamento ainda, apenas limpa os controles sem acessar propriedades do objeto
            if (this.autoSwitchHeal == null)
            {
                if (c is TextBox) ((TextBox)c).Text = "";
                else if (c is NumericUpDown) ((NumericUpDown)c).Value = 0;
                return;
            }

            // Proteção adicional: evitar exceção caso o nome do controle seja menor que 3
            if (c.Name == null || c.Name.Length <= 3) return;

            var property = typeof(AutoSwitchHeal).GetProperty(c.Name.Substring(3));
            if (property != null)
            {
                var value = property.GetValue(this.autoSwitchHeal);

                // Se for uma propriedade Key e o valor for Key.None, deixa vazio
                if (property.PropertyType == typeof(Key) && value != null && value.Equals(Key.None))
                {
                    c.Text = "";
                }
                else
                {
                    c.Text = value?.ToString();
                }
            }
        }
        private void onTextChange(object sender, EventArgs e)
        {
            try
            {
                // garante que temos a instância antes de tentar alterar valores
                if (this.autoSwitchHeal == null) this.autoSwitchHeal = ProfileSingleton.GetCurrent()?.AutoSwitchHeal;
                if (this.autoSwitchHeal == null) return;

                TextBox txtbox = (TextBox)sender;
                if (txtbox.Name == null || txtbox.Name.Length <= 3) return;

                var property = typeof(AutoSwitchHeal).GetProperty(txtbox.Name.Substring(3));
                if (property != null)
                {
                    Key key;

                    // Se o texto estiver vazio, define como Key.None
                    if (string.IsNullOrEmpty(txtbox.Text))
                    {
                        key = Key.None;
                    }
                    else
                    {
                        key = (Key)Enum.Parse(typeof(Key), txtbox.Text.ToString());
                    }

                    var oldValue = property.GetValue(this.autoSwitchHeal);
                    if (!Equals(oldValue, key))
                    {
                        property.SetValue(this.autoSwitchHeal, key);
                        ProfileSingleton.SetConfiguration(this.autoSwitchHeal);
                    }
                }
                this.ActiveControl = null;
            }
            catch
            {
                // Em caso de erro, tenta salvar Key.None se possível
                try
                {
                    if (this.autoSwitchHeal == null) this.autoSwitchHeal = ProfileSingleton.GetCurrent()?.AutoSwitchHeal;
                    if (this.autoSwitchHeal == null) return;

                    TextBox txtbox = (TextBox)sender;
                    if (txtbox.Name == null || txtbox.Name.Length <= 3) return;

                    var property = typeof(AutoSwitchHeal).GetProperty(txtbox.Name.Substring(3));
                    if (property != null)
                    {
                        property.SetValue(this.autoSwitchHeal, Key.None);
                        ProfileSingleton.SetConfiguration(this.autoSwitchHeal);
                    }
                }
                catch { }
            }
        }

        private void onPercentChange(object sender, EventArgs e)
        {
            try
            {
                // garante que temos a instância antes de tentar alterar valores
                if (this.autoSwitchHeal == null) this.autoSwitchHeal = ProfileSingleton.GetCurrent()?.AutoSwitchHeal;
                if (this.autoSwitchHeal == null) return;

                NumericUpDown numericUpDown = (NumericUpDown)sender;
                int percent = Int16.Parse(numericUpDown.Text);

                if (numericUpDown.Name == null || numericUpDown.Name.Length <= 3) return;

                var property = typeof(AutoSwitchHeal).GetProperty(numericUpDown.Name.Substring(3));
                if (property != null)
                {
                    var oldValue = property.GetValue(this.autoSwitchHeal);
                    if (!Equals(oldValue, percent))
                    {
                        property.SetValue(this.autoSwitchHeal, percent);
                        ProfileSingleton.SetConfiguration(this.autoSwitchHeal);
                    }
                }
                this.ActiveControl = null;
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
        }
    }
}