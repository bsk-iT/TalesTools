using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using _4RTools.Model;
using _4RTools.Utils;
using System.Collections.Generic;

namespace _4RTools.Forms
{
    public partial class Container : Form, IObserver
    {

        private Subject subject = new Subject();
        private string currentProfile;
        List<ClientDTO> clients = new List<ClientDTO>();
        private ToggleApplicationStateForm frmToggleApplication = new ToggleApplicationStateForm();

        public Container()
        {
            this.subject.Attach(this);

            InitializeComponent();
            this.Text = AppConfig.Name + " - " + AppConfig.Version; // Window title

            clients.AddRange(LocalServerManager.GetLocalClients()); //Load Local Servers First
            LoadServers(clients);
            GlobalVariablesHelper.CityList = LocalServerManager.GetListCities();
            //Container Configuration
            this.IsMdiContainer = true;

            // Aplicar APENAS barra de título escura
            ApplyDarkTitleBar();

            //Paint Children Forms 
            frmToggleApplication = SetToggleApplicationStateWindow();
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
            SetAutoSwitchHealWindow();
            SetConfigWindow();
            SetDebugWindow();

            // Aplicar barra de título após carregar todos os controles
            this.Load += (sender, e) => {
                ApplyDarkTitleBar();
            };

            // Aplicar barra de título quando a janela for mostrada pela primeira vez
            this.Shown += (sender, e) => {
                ThemeManager.ApplyDarkTitleBar(this);
                ThemeManager.ApplyDarkMdiClientBackground(this);
            };

            //TrackerSingleton.Instance().SendEvent("desktop_login", "page_view", "desktop_container_load");
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
            if (value && this.Handle != IntPtr.Zero)
            {
                ThemeManager.ApplyDarkTitleBar(this);
            }
        }

        /// <summary>
        /// Aplica APENAS a barra de título escura - configure cores no Designer
        /// </summary>
        private void ApplyDarkTitleBar()
        {
            // Aplicar barra de título escura
            ThemeManager.ApplyDarkTitleBar(this);

            // Aplicar fundo escuro ao MdiClient
            ThemeManager.ApplyDarkMdiClientBackground(this);
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

        // Override do método OnPaint - removido aplicação automática de tema
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Configure cores manualmente no Designer
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

            // Carregar o último perfil usado
            LoadLastUsedProfile();

            // Notificar que o perfil foi carregado
            subject.Notify(new Utils.Message(MessageCode.PROFILE_CHANGED, null));

            // Conexão automática com ragnatales.bin
            AutoConnectToRagnaTales();

            // Aplicar barra de título após o carregamento completo
            ApplyDarkTitleBar();

            ThemeManager.ApplyDarkMdiClientBackground(this);
        }

        private void AutoConnectToRagnaTales()
        {
            try
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.MainWindowTitle != "" && (p.ProcessName.ToLower() == "rtales" || p.ProcessName.ToLower() == "rtales.bin"))
                    {
                        if (!ClientListSingleton.ExistsByProcessName(p.ProcessName))
                        {
                            continue;
                        }

                        string processString = string.Format("{0}.exe - {1}", p.ProcessName, p.Id);

                        bool processExists = false;
                        foreach (var item in this.processCB.Items)
                        {
                            if (item.ToString() == processString)
                            {
                                processExists = true;
                                break;
                            }
                        }

                        if (processExists)
                        {
                            this.processCB.SelectedItem = processString;
                            Client client = new Client(processString);
                            ClientSingleton.Instance(client);
                            string charName = client.ReadCharacterName();
                            characterName.Text = charName;
                            subject.Notify(new Utils.Message(Utils.MessageCode.PROCESS_CHANGED, null));
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro na conexão automática: {ex.Message}");
            }
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
                    string processString = string.Format("{0}.exe - {1}", p.ProcessName, p.Id);
                    this.processCB.Items.Add(processString);

                    if ((p.ProcessName.ToLower() == "rtales" || p.ProcessName.ToLower() == "rtales.bin") &&
                        (ClientSingleton.GetClient() == null || this.processCB.SelectedItem == null))
                    {
                        try
                        {
                            this.processCB.SelectedItem = processString;
                            Client client = new Client(processString);
                            ClientSingleton.Instance(client);
                            characterName.Text = client.ReadCharacterName();
                            subject.Notify(new Utils.Message(Utils.MessageCode.PROCESS_CHANGED, null));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Erro na conexão automática durante refresh: {ex.Message}");
                        }
                    }
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
            KeyboardHook.Disable();
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
            System.Diagnostics.Process.Start("https://livepix.gg/hannamori");
        }

        private void livepixLinkLabelBsk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://livepix.gg/theberserk");
        }

        private void profileCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.profileCB.Text != currentProfile)
            {
                try
                {
                    if (currentProfile != null)
                    {
                        this.frmToggleApplication.TurnOFF();
                    }
                    ProfileSingleton.ClearProfile(this.profileCB.Text);
                    ProfileSingleton.Load(this.profileCB.Text);
                    subject.Notify(new Utils.Message(MessageCode.PROFILE_CHANGED, null));
                    currentProfile = this.profileCB.Text.ToString();
                    SaveLastUsedProfile(currentProfile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveLastUsedProfile(string profileName)
        {
            try
            {
                File.WriteAllText(AppConfig.LastProfileFile, profileName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao salvar último perfil: {ex.Message}");
            }
        }

        private void LoadLastUsedProfile()
        {
            try
            {
                if (File.Exists(AppConfig.LastProfileFile))
                {
                    string lastProfile = File.ReadAllText(AppConfig.LastProfileFile).Trim();

                    bool profileExists = false;
                    foreach (var item in this.profileCB.Items)
                    {
                        if (item.ToString() == lastProfile)
                        {
                            profileExists = true;
                            break;
                        }
                    }

                    if (profileExists)
                    {
                        this.profileCB.SelectedItem = lastProfile;
                    }
                    else
                    {
                        this.profileCB.SelectedItem = "Default";
                    }
                }
                else
                {
                    this.profileCB.SelectedItem = "Default";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar último perfil: {ex.Message}");
                this.profileCB.SelectedItem = "Default";
            }
        }

        private void tabPageAutopot_Click(object sender, EventArgs e)
        {
            // Implementação vazia
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
            }
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

        #region Frames

        // Método auxiliar para adicionar form em GroupBox - SEM aplicação automática de tema
        public void addFormToGroupBox(GroupBox groupBox, Form form)
        {
            if (!groupBox.Controls.Contains(form))
            {
                groupBox.Controls.Add(form);
                form.Dock = DockStyle.Fill;
                form.Show();
                Refresh();
            }
            Refresh();
        }

        public void addFormToPanel(Panel panel, Form form)
        {
            if (!panel.Controls.Contains(form))
            {
                panel.Controls.Add(form);
                form.Dock = DockStyle.Fill;
                form.Show();
                Refresh();
            }
            Refresh();
        }

        public ToggleApplicationStateForm SetToggleApplicationStateWindow()
        {
            ToggleApplicationStateForm frm = new ToggleApplicationStateForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addFormToPanel(this.panelStatus, frm);
            return frm;
        }

        public void SetAutopotWindow()
        {
            AutopotForm frm = new AutopotForm(subject, false);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addFormToPanel(this.panelAutopot, frm);
        }

        public void SetAutoSwitchHealWindow()
        {
            AutoSwitchHealForm frm = new AutoSwitchHealForm(subject, false);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addFormToPanel(this.panelAutoSwitchHeal, frm);
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
            addFormToPanel(this.panelYgg, frm);
        }

        public void SetSkillTimerWindow()
        {
            SkillTimerForm frm = new SkillTimerForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addFormToGroupBox(this.groupBoxSkillTimer, frm);
        }

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
            ProfileForm frm = new ProfileForm(this, subject);
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

        public void SetDebugWindow()
        {
            DebugForm frm = new DebugForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageDebug, frm);
        }

        #endregion

        private void characterName_Click(object sender, EventArgs e)
        {

        }

        private void tabPageAutobuffStuff_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxAutoSwitchHeal_Enter(object sender, EventArgs e)
        {

        }

        private void tabPageHome_Click(object sender, EventArgs e)
        {

        }
    }
}