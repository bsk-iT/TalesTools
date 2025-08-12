using _4RTools.Model;
using _4RTools.Properties;
using _4RTools.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace _4RTools.Forms
{
    public partial class Container : Form, IObserver
    {
        private Subject subject = new Subject();
        private string currentProfile;
        List<ClientDTO> clients = new List<ClientDTO>();

        // Variáveis do ToggleApplicationStateForm integradas
        private ContextMenu contextMenu;
        private MenuItem menuItem;
        private Keys lastKey;
        private Keys healLastKey;
        private string autoClickLastKey; // Mudado para string para suportar mouse buttons

        // Variáveis do CustomButtonForm integradas
        private Custom custom;

        // Variáveis do AutoClick
        private bool autoClickActive = false;
        private System.Windows.Forms.Timer autoClickTimer;

        public Container()
        {
            this.subject.Attach(this);

            InitializeComponent();
            this.Text = AppConfig.Name + " - " + AppConfig.Version; // Window title

            clients.AddRange(LocalServerManager.GetLocalClients()); // Load Local Servers First
            LoadServers(clients);

            // Container Configuration
            this.IsMdiContainer = true;
            SetBackGroundColorOfMDIForm();

            // Inicializa a funcionalidade do ToggleApplicationState integrada
            InitializeToggleApplicationState();

            // Inicializa a funcionalidade do CustomButton integrada
            InitializeCustomButton();

            // Inicializa o AutoClick
            InitializeAutoClick();

            // Paint Children Forms 
            SetAutopotWindow();
            SetAutopotYggWindow();
            SetSkillTimerWindow();
            SetAHKWindow();
            SetAutoBuffStatusWindow();
            SetProfileWindow();
            SetAutobuffStuffWindow();
            SetAutobuffSkillWindow();
            SetSongMacroWindow();
            SetATKDEFWindow();
            SetMacroSwitchWindow();
            SetAutoSwitchWindow();
            SetConfigWindow();

            // Aplica tema e fonte ao iniciar
            ThemeManager.ApplyThemeToForm(this);
        }

        // Sobrescrita para garantir que os botões mantenham as cores corretas
        public void ApplyThemeWithStatusColors()
        {
            ThemeManager.ApplyThemeToForm(this);
            ThemeManager.UpdateStatusButtonColors(this);
        }

        //TrackerSingleton.Instance().SendEvent("desktop_login", "page_view", "desktop_container_load");


        private void InitializeToggleApplicationState()
        {
            KeyboardHook.Enable();
            this.txtStatusToggleKey.Text = ProfileSingleton.GetCurrent().UserPreferences.toggleStateKey;
            this.txtStatusToggleKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtStatusToggleKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtStatusToggleKey.TextChanged += new EventHandler(this.onStatusToggleKeyChange);

            this.txtStatusHealToggleKey.Text = ProfileSingleton.GetCurrent().UserPreferences.toggleStateHealKey;
            this.txtStatusHealToggleKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtStatusHealToggleKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtStatusHealToggleKey.TextChanged += new EventHandler(this.onStatusHealToggleKeyChange);

            InitializeContextualMenu();
        }

        private void InitializeCustomButton()
        {
            toolTip1.SetToolTip(label1CustomButton, "Simula alt+botão direito do mouse para transferencia rapida de itens entre armazem e inventario");
            InitializeCustomButtonForm();
        }

        private void InitializeAutoClick()
        {
            // Inicializa o timer do autoclick
            autoClickTimer = new System.Windows.Forms.Timer();
            autoClickTimer.Interval = 50; // 10ms de intervalo para clicks rápidos
            autoClickTimer.Tick += AutoClickTimer_Tick;

            // Configura tooltip para o label de autoclick
            if (toolTip1 != null)
            {
                toolTip1.SetToolTip(label2CustomButton, "Autoclick: Clica automaticamente com o botão esquerdo do mouse (Padrão: None)");
            }

            // Habilita mouse hook
            MouseHook.Enable();

            // Inicializa o controle de tecla do autoclick
            InitializeAutoClickKeyControl();
        }

        private void InitializeAutoClickKeyControl()
        {
            // Configura o textbox da tecla do autoclick
            this.txtAutoClickKey.Text = ProfileSingleton.GetCurrent().UserPreferences.autoClickKey;

            // Remove os eventos de teclado normais e adiciona os específicos para autoclick
            this.txtAutoClickKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnAutoClickKeyDown);
            this.txtAutoClickKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FormUtils.OnKeyPress);

            // Adiciona evento de mouse específico que aceita apenas botões laterais
            this.txtAutoClickKey.MouseDown += new System.Windows.Forms.MouseEventHandler(FormUtils.OnAutoClickMouseDown);
            this.txtAutoClickKey.TextChanged += new EventHandler(this.onAutoClickKeyChange);

            // Configura o hook da tecla/botão apenas se não for "None"
            if (ProfileSingleton.GetCurrent().UserPreferences.autoClickKey != "None")
            {
                ConfigureAutoClickHook(ProfileSingleton.GetCurrent().UserPreferences.autoClickKey);
            }
        }

        private void ConfigureAutoClickHook(string keyOrButton)
        {
            // Remove hook anterior
            RemoveAutoClickHook();

            // Só configura hook se não for "None"
            if (keyOrButton == "None")
            {
                autoClickLastKey = "None";
                return;
            }

            // Configura novo hook apenas para botões laterais do mouse
            if (IsValidAutoClickButton(keyOrButton))
            {
                int mouseButton = GetMouseButtonCode(keyOrButton);
                if (mouseButton != -1)
                {
                    MouseHook.AddMouseDown(mouseButton, new MouseHook.MousePressed(this.toggleAutoClickByKey));
                    autoClickLastKey = keyOrButton;
                }
            }
            else
            {
                // Se o botão não for válido, volta para "None"
                this.txtAutoClickKey.Text = "None";
                autoClickLastKey = "None";
                ProfileSingleton.GetCurrent().UserPreferences.autoClickKey = "None";
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
            }
        }

        private void RemoveAutoClickHook()
        {
            if (autoClickLastKey != null && autoClickLastKey != "None")
            {
                if (IsValidAutoClickButton(autoClickLastKey))
                {
                    int mouseButton = GetMouseButtonCode(autoClickLastKey);
                    if (mouseButton != -1)
                    {
                        MouseHook.RemoveMouseDown(mouseButton);
                    }
                }
            }
        }

        private bool IsValidAutoClickButton(string keyOrButton)
        {
            // Aceita apenas os botões laterais do mouse
            return keyOrButton == "BrowserForward" || keyOrButton == "BrowserBack";
        }

        private bool IsMouseButton(string keyOrButton)
        {
            return keyOrButton == "BrowserForward" || keyOrButton == "BrowserBack" ||
                   keyOrButton == "MiddleButton" || keyOrButton == "RightButton" ||
                   keyOrButton == "LeftButton";
        }

        private int GetMouseButtonCode(string mouseButton)
        {
            switch (mouseButton)
            {
                case "BrowserBack":
                    return 1; // XButton1
                case "BrowserForward":
                    return 2; // XButton2
                default:
                    return -1; // Outros botões não são suportados
            }
        }

        private void InitializeCustomButtonForm()
        {
            this.custom = ProfileSingleton.GetCurrent().Custom;
            this.txtTransferKey.Text = custom.tiMode.ToString();

            this.txtTransferKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtTransferKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtTransferKey.TextChanged += new EventHandler(onTransferKeyChange);
            this.ActiveControl = null;
        }

        private void InitializeContextualMenu()
        {
            this.contextMenu = new ContextMenu();
            this.menuItem = new MenuItem();

            this.contextMenu.MenuItems.AddRange(
                    new MenuItem[] { this.menuItem });

            this.menuItem.Index = 0;
            this.menuItem.Text = "Close";
            this.menuItem.Click += new EventHandler(this.notifyShutdownApplication);

            this.notifyIconTray.ContextMenu = this.contextMenu;
        }

        public void addform(TabPage tp, Form f)
        {
            if (!tp.Controls.Contains(f))
            {
                tp.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
                Refresh();
            }
            Refresh();
        }

        private void SetBackGroundColorOfMDIForm()
        {
            foreach (Control ctl in this.Controls)
            {
                if ((ctl) is MdiClient)
                {
                    ctl.BackColor = ThemeManager.GetBackgroundColor();
                }
            }
        }

        private void processCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client client = new Client(this.processCB.SelectedItem.ToString());
            ClientSingleton.Instance(client);
            characterName.Text = client.ReadCharacterName();
            subject.Notify(new Utils.Message(Utils.MessageCode.PROCESS_CHANGED, null));
        }

        private void Container_Load(object sender, EventArgs e)
        {
            ProfileSingleton.Create("Default");
            this.refreshProcessList();
            this.refreshProfileList();
            this.profileCB.SelectedItem = "Default";
        }

        public void refreshProfileList()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.profileCB.Items.Clear();
            });
            foreach (string p in Profile.ListAll())
            {
                this.profileCB.Items.Add(p);
            }
        }

        private void refreshProcessList()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.processCB.Items.Clear();
            });
            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowTitle != "" && ClientListSingleton.ExistsByProcessName(p.ProcessName))
                {
                    this.processCB.Items.Add(string.Format("{0}.exe - {1}", p.ProcessName, p.Id));
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.refreshProcessList();
        }

        protected override void OnClosed(EventArgs e)
        {
            ShutdownApplication();
            base.OnClosed(e);
        }

        private void ShutdownApplication()
        {
            // Para o autoclick ao fechar a aplicação
            if (autoClickTimer != null)
            {
                autoClickTimer.Stop();
                autoClickTimer.Dispose();
            }

            KeyboardHook.Disable();
            MouseHook.Disable();
            subject.Notify(new Utils.Message(MessageCode.TURN_OFF, null));
            Environment.Exit(0);
        }

        private void lblLinkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(AppConfig.GithubLink);
        }

        private void lblLinkDiscord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(AppConfig.DiscordLink);
        }

        private void websiteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(AppConfig.Website);
        }

        private void livepixLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(AppConfig.Livepix);
        }

        private void profileCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.profileCB.Text != currentProfile)
            {
                try
                {
                    if (currentProfile != null)
                    {
                        this.TurnOFF();
                    }
                    ProfileSingleton.ClearProfile(this.profileCB.Text);
                    ProfileSingleton.Load(this.profileCB.Text); //LOAD PROFILE
                    subject.Notify(new Utils.Message(MessageCode.PROFILE_CHANGED, null));
                    currentProfile = this.profileCB.Text.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.TURN_ON:
                case MessageCode.PROFILE_CHANGED:
                    Client client = ClientSingleton.GetClient();
                    if (client != null)
                    {
                        characterName.Text = ClientSingleton.GetClient().ReadCharacterName();
                    }

                    // Atualização dos controles de toggle quando o perfil muda
                    if ((subject as Subject).Message.code == MessageCode.PROFILE_CHANGED)
                    {
                        Keys currentToggleKey = (Keys)Enum.Parse(typeof(Keys), ProfileSingleton.GetCurrent().UserPreferences.toggleStateKey);
                        KeyboardHook.RemoveDown(lastKey);

                        this.txtStatusToggleKey.Text = currentToggleKey.ToString();
                        KeyboardHook.AddKeyDown(currentToggleKey, new KeyboardHook.KeyPressed(this.toggleStatus));
                        lastKey = currentToggleKey;

                        Keys currentHealToggleKey = (Keys)Enum.Parse(typeof(Keys), ProfileSingleton.GetCurrent().UserPreferences.toggleStateHealKey);
                        KeyboardHook.RemoveUp(healLastKey);

                        this.txtStatusHealToggleKey.Text = currentHealToggleKey.ToString();
                        KeyboardHook.AddKeyUp(currentHealToggleKey, new KeyboardHook.KeyPressed(this.toggleStatusHeal));
                        healLastKey = currentHealToggleKey;

                        // Atualização dos controles do CustomButton quando o perfil muda
                        InitializeCustomButtonForm();

                        // Atualização dos controles do AutoClick quando o perfil muda
                        this.txtAutoClickKey.Text = ProfileSingleton.GetCurrent().UserPreferences.autoClickKey;
                        ConfigureAutoClickHook(ProfileSingleton.GetCurrent().UserPreferences.autoClickKey);
                    }
                    break;
                case MessageCode.SERVER_LIST_CHANGED:
                    this.refreshProcessList();
                    break;
                case MessageCode.CLICK_ICON_TRAY:
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    break;
                case MessageCode.SHUTDOWN_APPLICATION:
                    this.ShutdownApplication();
                    break;
                case MessageCode.TURN_OFF:
                    if (this.custom != null)
                        this.custom.Stop();

                    // Para o autoclick quando desligado
                    StopAutoClick();
                    break;
            }
        }

        private void containerResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) { this.Hide(); }
        }

        private void LoadServers(List<ClientDTO> clients)
        {
            foreach (ClientDTO clientDTO in clients)
            {
                try
                {
                    ClientListSingleton.AddClient(new Client(clientDTO));
                }
                catch { }
            }
        }

        #region ToggleApplicationState Methods (Integrados)

        private void btnToggleStatusHandler(object sender, EventArgs e)
        {
            this.toggleStatus();
        }

        private void onStatusToggleKeyChange(object sender, EventArgs e)
        {
            Keys currentToggleKey = (Keys)Enum.Parse(typeof(Keys), this.txtStatusToggleKey.Text);
            KeyboardHook.RemoveDown(lastKey);
            KeyboardHook.AddKeyDown(currentToggleKey, new KeyboardHook.KeyPressed(this.toggleStatus));
            ProfileSingleton.GetCurrent().UserPreferences.toggleStateKey = currentToggleKey.ToString();
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);

            lastKey = currentToggleKey;
        }

        private bool toggleStatus()
        {
            bool isOn = this.btnStatusToggle.Text == "ON";
            if (isOn)
            {
                this.btnStatusToggle.BackColor = Color.Red;
                this.btnStatusToggle.Text = "OFF";
                this.notifyIconTray.Icon = Resources._4RTools.ETCResource.TalesIcon_off;
                this.subject.Notify(new Utils.Message(MessageCode.TURN_OFF, null));
                this.lblStatusToggle.Text = "Pressione uma tecla para começar!!";
                this.lblStatusToggle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
                new SoundPlayer(Resources._4RTools.ETCResource.Speech_Off).Play();
            }
            else
            {
                Client client = ClientSingleton.GetClient();
                if (client != null)
                {
                    this.btnStatusToggle.BackColor = Color.Green;
                    this.btnStatusToggle.Text = "ON";
                    this.notifyIconTray.Icon = Resources._4RTools.ETCResource.TalesIcon_on;
                    this.subject.Notify(new Utils.Message(MessageCode.TURN_ON, null));
                    this.lblStatusToggle.Text = "Press the key to stop!";
                    this.lblStatusToggle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
                    new SoundPlayer(Resources._4RTools.ETCResource.Speech_On).Play();
                }
                else
                {
                    this.lblStatusToggle.Text = "Please select a valid Ragnarok Client!";
                    this.lblStatusToggle.ForeColor = Color.Red;
                }
            }

            // Garante que a cor do botão seja mantida mesmo após mudanças de tema
            this.btnStatusToggle.FlatStyle = FlatStyle.Flat;
            this.btnStatusToggle.FlatAppearance.BorderSize = 0;

            return true;
        }

        public bool TurnOFF()
        {
            bool isOn = this.btnStatusToggle.Text == "ON";
            if (isOn)
            {
                this.btnStatusToggle.BackColor = Color.Red;
                this.btnStatusToggle.Text = "OFF";
                this.subject.Notify(new Utils.Message(MessageCode.TURN_OFF, null));
                this.lblStatusToggle.Text = "Pressione uma tecla para começar!!";
                this.lblStatusToggle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
                new SoundPlayer(Resources._4RTools.ETCResource.Speech_Off).Play();
            }

            bool isOnheal = this.btnStatusHealToggle.Text == "ON";
            if (isOnheal)
            {
                this.btnStatusHealToggle.BackColor = Color.Red;
                this.btnStatusHealToggle.Text = "OFF";
                this.subject.Notify(new Utils.Message(MessageCode.TURN_HEAL_OFF, null));
                this.lblStatusHealToggle.Text = "Pressione uma tecla para iniciar a cura!";
                this.lblStatusHealToggle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
                new SoundPlayer(Resources._4RTools.ETCResource.Healing_Off).Play();
            }

            // Para os CustomButtons
            if (this.custom != null)
                this.custom.Stop();

            // Para o autoclick
            StopAutoClick();

            return true;
        }

        private void btnToggleStatusHealHandler(object sender, EventArgs e)
        {
            this.toggleStatusHeal();
        }

        private void onStatusHealToggleKeyChange(object sender, EventArgs e)
        {
            Keys currentHealToggleKey = (Keys)Enum.Parse(typeof(Keys), this.txtStatusHealToggleKey.Text);
            KeyboardHook.RemoveUp(healLastKey);
            KeyboardHook.AddKeyUp(currentHealToggleKey, new KeyboardHook.KeyPressed(this.toggleStatusHeal));
            ProfileSingleton.GetCurrent().UserPreferences.toggleStateHealKey = currentHealToggleKey.ToString();
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);

            healLastKey = currentHealToggleKey;
        }

        private bool toggleStatusHeal()
        {
            bool isOn = this.btnStatusHealToggle.Text == "ON";
            if (isOn)
            {
                this.btnStatusHealToggle.BackColor = Color.Red;
                this.btnStatusHealToggle.Text = "OFF";
                this.subject.Notify(new Utils.Message(MessageCode.TURN_HEAL_OFF, null));
                this.lblStatusHealToggle.Text = "Pressione uma tecla para iniciar a cura!";
                this.lblStatusHealToggle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
                new SoundPlayer(Resources._4RTools.ETCResource.Healing_Off).Play();
            }
            else
            {
                Client client = ClientSingleton.GetClient();
                if (client != null)
                {
                    this.btnStatusHealToggle.BackColor = Color.Green;
                    this.btnStatusHealToggle.Text = "ON";
                    this.subject.Notify(new Utils.Message(MessageCode.TURN_HEAL_ON, null));
                    this.lblStatusHealToggle.Text = "Press the key to stop healing!";
                    this.lblStatusHealToggle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
                    new SoundPlayer(Resources._4RTools.ETCResource.Healing_On).Play();
                }
                else
                {
                    this.lblStatusHealToggle.Text = "Please select a valid Ragnarok Client!";
                    this.lblStatusHealToggle.ForeColor = Color.Red;
                }
            }

            // Garante que a cor do botão seja mantida mesmo após mudanças de tema
            this.btnStatusHealToggle.FlatStyle = FlatStyle.Flat;
            this.btnStatusHealToggle.FlatAppearance.BorderSize = 0;

            return true;
        }

        private void notifyIconDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.subject.Notify(new Utils.Message(MessageCode.CLICK_ICON_TRAY, null));
        }

        private void notifyShutdownApplication(object Sender, EventArgs e)
        {
            this.subject.Notify(new Utils.Message(MessageCode.SHUTDOWN_APPLICATION, null));
        }

        #endregion

        #region CustomButton Methods (Integrados)

        private void onTransferKeyChange(object sender, EventArgs e)
        {
            Key key = (Key)Enum.Parse(typeof(Key), this.txtTransferKey.Text.ToString());
            try
            {
                this.custom.tiMode = key;
                ProfileSingleton.SetConfiguration(this.custom);
            }
            catch { }
            this.ActiveControl = null;
        }

        private void label2CustomButton_Click(object sender, EventArgs e)
        {
            // Implementação do AutoClick por clique no label
            ToggleAutoClick();
        }

        private void groupBoxAutoTransfer_Enter(object sender, EventArgs e)
        {
            // Método vazio mantido para compatibilidade
        }

        private void label1CustomButton_Click(object sender, EventArgs e)
        {
            // Método vazio mantido para compatibilidade
        }

        #endregion

        #region AutoClick Methods

        private void onAutoClickKeyChange(object sender, EventArgs e)
        {
            string newKeyOrButton = this.txtAutoClickKey.Text;

            try
            {
                // Salva a configuração independentemente se é válida ou não
                ProfileSingleton.GetCurrent().UserPreferences.autoClickKey = newKeyOrButton;
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);

                // Configura o hook apenas se for um botão válido e não for "None"
                if (newKeyOrButton != "None")
                {
                    ConfigureAutoClickHook(newKeyOrButton);
                }
                else
                {
                    RemoveAutoClickHook();
                    autoClickLastKey = "None";
                }
            }
            catch (Exception)
            {
                // Se houver erro, reverte para "None"
                string fallbackKey = "None";
                this.txtAutoClickKey.Text = fallbackKey;
                RemoveAutoClickHook();
                autoClickLastKey = "None";
                ProfileSingleton.GetCurrent().UserPreferences.autoClickKey = fallbackKey;
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
            }
        }

        private bool toggleAutoClickByKey()
        {
            ToggleAutoClick();
            return true;
        }

        private void ToggleAutoClick()
        {
            if (autoClickActive)
            {
                StopAutoClick();
            }
            else
            {
                StartAutoClick();
            }
        }

        private void StartAutoClick()
        {
            Client client = ClientSingleton.GetClient();
            if (client == null)
            {
                MessageBox.Show("Por favor, selecione um cliente Ragnarok válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se há um botão configurado
            if (autoClickLastKey == "None" || autoClickLastKey == null)
            {
                MessageBox.Show("Por favor, configure um botão lateral do mouse primeiro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            autoClickActive = true;
            autoClickTimer.Start();

            // Atualiza visual do label para indicar que está ativo
            if (label2CustomButton != null)
            {
                label2CustomButton.ForeColor = Color.Green;
                label2CustomButton.Text = "AutoClick: ON";
            }
        }

        private void StopAutoClick()
        {
            autoClickActive = false;
            if (autoClickTimer != null)
            {
                autoClickTimer.Stop();
            }

            // Atualiza visual do label para indicar que está inativo
            if (label2CustomButton != null)
            {
                label2CustomButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
                label2CustomButton.Text = "AutoClick: OFF";
            }
        }

        private void AutoClickTimer_Tick(object sender, EventArgs e)
        {
            if (!autoClickActive) return;

            Client client = ClientSingleton.GetClient();
            if (client == null)
            {
                StopAutoClick();
                return;
            }

            try
            {
                // Simula clique do botão esquerdo do mouse (clique normal)
                Interop.PostMessage(client.process.MainWindowHandle, Constants.WM_LBUTTONDOWN, 0, 0);
                Thread.Sleep(1);
                Interop.PostMessage(client.process.MainWindowHandle, Constants.WM_LBUTTONUP, 0, 0);
            }
            catch (Exception ex)
            {
                // Em caso de erro, para o autoclick
                StopAutoClick();
                MessageBox.Show($"Erro no AutoClick: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Frames

        public void SetAutopotWindow()
        {
            AutopotForm frm = new AutopotForm(subject, false);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageAutopot, frm);
        }

        private void SetAutoBuffStatusWindow()
        {
            AutoBuffStatusForm frm = new AutoBuffStatusForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageDebuffs, frm);
        }

        public void SetAutopotYggWindow()
        {
            AutopotForm frm = new AutopotForm(subject, true);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageYggAutopot, frm);
        }

        public void SetSkillTimerWindow()
        {
            SkillTimerForm frm = new SkillTimerForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageSkillTimer, frm);
        }

        // Método comentado pois a funcionalidade foi integrada diretamente no Container
        /*
        public void SetCustomButtonsWindow()
        {
            CustomButtonForm form = new CustomButtonForm(subject);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Location = new Point(445, 220);
            form.MdiParent = this;
            form.Show();
        }
        */

        public void SetAHKWindow()
        {
            AHKForm frm = new AHKForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageSpammer, frm);
        }

        public void SetProfileWindow()
        {
            ProfileForm frm = new ProfileForm(this);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageProfiles, frm);
        }

        public void SetAutobuffStuffWindow()
        {
            StuffAutoBuffForm frm = new StuffAutoBuffForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageAutobuffStuff, frm);
        }

        public void SetAutobuffSkillWindow()
        {
            SkillAutoBuffForm frm = new SkillAutoBuffForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.tabPageAutobuffSkill, frm);
            frm.Show();
        }

        public void SetSongMacroWindow()
        {
            MacroSongForm frm = new MacroSongForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.tabPageMacroSongs, frm);
            frm.Show();
        }

        public void SetATKDEFWindow()
        {
            ATKDEFForm frm = new ATKDEFForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.atkDef, frm);
            frm.Show();
        }

        public void SetMacroSwitchWindow()
        {
            MacroSwitchForm frm = new MacroSwitchForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.tabMacroSwitch, frm);
            frm.Show();
        }

        public void SetAutoSwitchWindow()
        {
            AutoSwitchForm frm = new AutoSwitchForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageAutoSwitch, frm);
        }

        public void SetConfigWindow()
        {
            ConfigForm frm = new ConfigForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.tabConfig, frm);
            frm.Show();
        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabConfig_Click(object sender, EventArgs e)
        {

        }

        private void lblStatusHealToggle_Click(object sender, EventArgs e)
        {

        }

        private void lblStatusToggle_Click(object sender, EventArgs e)
        {

        }
    }
}