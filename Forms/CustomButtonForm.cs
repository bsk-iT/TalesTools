using System;
using System.Windows.Forms;
using _4RTools.Utils;
using _4RTools.Model;
using System.Windows.Input;

namespace _4RTools.Forms
{
    public partial class CustomButtonForm : Form, IObserver
    {

        private Custom custom;
        public CustomButtonForm(Subject subject)
        {
            InitializeComponent();
            toolTip1.SetToolTip(label1, "Simula alt+botão direito do mouse para transferencia rapida de itens entre armazem e inventario");
            // tenta inicializar imediatamente com o perfil atual (pode ser null)
            this.custom = ProfileSingleton.GetCurrent()?.Custom;
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
                    InitializeApplicationForm();
                    break;
                case MessageCode.TURN_OFF:
                    // tenta recuperar a instância caso ainda não tenha sido inicializada
                    if (this.custom == null) this.custom = ProfileSingleton.GetCurrent()?.Custom;
                    if (this.custom != null)
                    {
                        try { this.custom.Stop(); } catch { }
                    }
                    break;
                case MessageCode.TURN_ON:
                    // tenta recuperar a instância caso ainda não tenha sido inicializada
                    if (this.custom == null) this.custom = ProfileSingleton.GetCurrent()?.Custom;
                    if (this.custom != null)
                    {
                        try { this.custom.Start(); } catch { }
                    }
                    break;
            }
        }

        private void InitializeApplicationForm()
        {
            Client roClient = ClientSingleton.GetClient();
            if (roClient != null)
            {
                KeyboardHookHelper.PriorityKey = ProfileSingleton.GetCurrent().Custom.priorityKey;
                KeyboardHookHelper.GameWindowHandle = roClient.process.MainWindowHandle;
                KeyboardHookHelper.PriorityDelay = ProfileSingleton.GetCurrent().Custom.priorityDelay;
            }
            this.custom = ProfileSingleton.GetCurrent().Custom;

            // Configuração simples dos TextBox sem métodos especiais
            this.txtTransferKey.Text = custom.tiMode == Key.None ? "" : custom.tiMode.ToString();
            this.txtPriorityKey.Text = custom.priorityKey == Key.None ? "" : custom.priorityKey.ToString();
            this.txtPriorityDelay.Text = this.custom.priorityDelay.ToString();

            this.txtTransferKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtTransferKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtTransferKey.TextChanged += new EventHandler(onTransferKeyChange);
            this.txtPriorityKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtPriorityKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtPriorityKey.TextChanged += new EventHandler(onPriorityKeyChange);
            this.ActiveControl = null;
        }

        private void txtPriorityDelay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ProfileSingleton.GetCurrent().Custom.priorityDelay = Convert.ToInt16(this.txtPriorityDelay.Value);
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().Custom);
            }
            catch { }
        }

        private void onTransferKeyChange(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                this.custom.tiMode = Key.None;
            }
            else
            {
                try
                {
                    Key key = (Key)Enum.Parse(typeof(Key), textBox.Text.ToString());
                    this.custom.tiMode = key;
                }
                catch
                {
                    // Em caso de erro, define como Key.None
                    this.custom.tiMode = Key.None;
                }
            }

            ProfileSingleton.SetConfiguration(this.custom);
            this.ActiveControl = null;
        }

        private void onPriorityKeyChange(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                this.custom.priorityKey = Key.None;
            }
            else
            {
                try
                {
                    Key key = (Key)Enum.Parse(typeof(Key), textBox.Text.ToString());
                    this.custom.priorityKey = key;
                }
                catch
                {
                    // Em caso de erro, define como Key.None
                    this.custom.priorityKey = Key.None;
                }
            }

            ProfileSingleton.SetConfiguration(this.custom);
            this.ActiveControl = null;
        }
    }
}