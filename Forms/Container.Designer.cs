using System.Windows.Forms;

namespace _4RTools.Forms
{
    partial class Container
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TabControl atkDefMode;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Container));
            this.tabPageSpammer = new System.Windows.Forms.TabPage();
            this.tabPageAutobuffSkill = new System.Windows.Forms.TabPage();
            this.tabPageAutobuffStuff = new System.Windows.Forms.TabPage();
            this.tabPageAutoSwitch = new System.Windows.Forms.TabPage();
            this.atkDef = new System.Windows.Forms.TabPage();
            this.tabPageMacroSongs = new System.Windows.Forms.TabPage();
            this.tabMacroSwitch = new System.Windows.Forms.TabPage();
            this.tabPageDebuffs = new System.Windows.Forms.TabPage();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.tabPageProfiles = new System.Windows.Forms.TabPage();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.processCB = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblLinkDiscord = new System.Windows.Forms.LinkLabel();
            this.lblLinkGithub = new System.Windows.Forms.LinkLabel();
            this.panelDiscImage = new System.Windows.Forms.Panel();
            this.panelGithubImage = new System.Windows.Forms.Panel();
            this.labelProfile = new System.Windows.Forms.Label();
            this.profileCB = new System.Windows.Forms.ComboBox();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.livepixLinkLabel = new System.Windows.Forms.LinkLabel();
            this.websiteLinkLabel = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCharacterName = new System.Windows.Forms.Label();
            this.characterName = new System.Windows.Forms.Label();
            this.tabControlAutopot = new System.Windows.Forms.TabControl();
            this.tabPageAutopot = new System.Windows.Forms.TabPage();
            this.tabPageYggAutopot = new System.Windows.Forms.TabPage();
            this.tabPageSkillTimer = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStatusToggleKey = new System.Windows.Forms.TextBox();
            this.btnStatusToggle = new System.Windows.Forms.Button();
            this.lblStatusToggle = new System.Windows.Forms.Label();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblStatusHealToggle = new System.Windows.Forms.Label();
            this.btnStatusHealToggle = new System.Windows.Forms.Button();
            this.txtStatusHealToggleKey = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxAutoTransfer = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtAutoClickKey = new System.Windows.Forms.TextBox();
            this.label1CustomButton = new System.Windows.Forms.Label();
            this.txtTransferKey = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2CustomButton = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            atkDefMode = new System.Windows.Forms.TabControl();
            atkDefMode.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.tabControlAutopot.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxAutoTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // atkDefMode
            // 
            atkDefMode.Controls.Add(this.tabPageSpammer);
            atkDefMode.Controls.Add(this.tabPageAutobuffSkill);
            atkDefMode.Controls.Add(this.tabPageAutobuffStuff);
            atkDefMode.Controls.Add(this.tabPageAutoSwitch);
            atkDefMode.Controls.Add(this.atkDef);
            atkDefMode.Controls.Add(this.tabPageMacroSongs);
            atkDefMode.Controls.Add(this.tabMacroSwitch);
            atkDefMode.Controls.Add(this.tabPageDebuffs);
            atkDefMode.Controls.Add(this.tabConfig);
            atkDefMode.Controls.Add(this.tabPageProfiles);
            atkDefMode.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            atkDefMode.ItemSize = new System.Drawing.Size(110, 40);
            atkDefMode.Location = new System.Drawing.Point(19, 335);
            atkDefMode.Margin = new System.Windows.Forms.Padding(10);
            atkDefMode.Name = "atkDefMode";
            atkDefMode.SelectedIndex = 0;
            atkDefMode.Size = new System.Drawing.Size(1044, 489);
            atkDefMode.TabIndex = 6;
            // 
            // tabPageSpammer
            // 
            this.tabPageSpammer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.tabPageSpammer.Location = new System.Drawing.Point(4, 44);
            this.tabPageSpammer.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSpammer.Name = "tabPageSpammer";
            this.tabPageSpammer.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageSpammer.Size = new System.Drawing.Size(1036, 441);
            this.tabPageSpammer.TabIndex = 1;
            this.tabPageSpammer.Text = "Skill Spammer";
            // 
            // tabPageAutobuffSkill
            // 
            this.tabPageAutobuffSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.tabPageAutobuffSkill.Location = new System.Drawing.Point(4, 44);
            this.tabPageAutobuffSkill.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAutobuffSkill.Name = "tabPageAutobuffSkill";
            this.tabPageAutobuffSkill.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAutobuffSkill.Size = new System.Drawing.Size(1036, 441);
            this.tabPageAutobuffSkill.TabIndex = 3;
            this.tabPageAutobuffSkill.Text = "Autobuff - Skills";
            // 
            // tabPageAutobuffStuff
            // 
            this.tabPageAutobuffStuff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.tabPageAutobuffStuff.Location = new System.Drawing.Point(4, 44);
            this.tabPageAutobuffStuff.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAutobuffStuff.Name = "tabPageAutobuffStuff";
            this.tabPageAutobuffStuff.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAutobuffStuff.Size = new System.Drawing.Size(1036, 441);
            this.tabPageAutobuffStuff.TabIndex = 4;
            this.tabPageAutobuffStuff.Text = "Autobuff - Stuffs";
            // 
            // tabPageAutoSwitch
            // 
            this.tabPageAutoSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.tabPageAutoSwitch.Location = new System.Drawing.Point(4, 44);
            this.tabPageAutoSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAutoSwitch.Name = "tabPageAutoSwitch";
            this.tabPageAutoSwitch.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAutoSwitch.Size = new System.Drawing.Size(1036, 441);
            this.tabPageAutoSwitch.TabIndex = 3;
            this.tabPageAutoSwitch.Text = "Auto Switch";
            // 
            // atkDef
            // 
            this.atkDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.atkDef.Location = new System.Drawing.Point(4, 44);
            this.atkDef.Margin = new System.Windows.Forms.Padding(4);
            this.atkDef.Name = "atkDef";
            this.atkDef.Padding = new System.Windows.Forms.Padding(4);
            this.atkDef.Size = new System.Drawing.Size(1036, 441);
            this.atkDef.TabIndex = 5;
            this.atkDef.Text = "ATK x DEF";
            // 
            // tabPageMacroSongs
            // 
            this.tabPageMacroSongs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.tabPageMacroSongs.Location = new System.Drawing.Point(4, 44);
            this.tabPageMacroSongs.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMacroSongs.Name = "tabPageMacroSongs";
            this.tabPageMacroSongs.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageMacroSongs.Size = new System.Drawing.Size(1036, 441);
            this.tabPageMacroSongs.TabIndex = 6;
            this.tabPageMacroSongs.Text = "Macro Songs";
            // 
            // tabMacroSwitch
            // 
            this.tabMacroSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.tabMacroSwitch.Location = new System.Drawing.Point(4, 44);
            this.tabMacroSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.tabMacroSwitch.Name = "tabMacroSwitch";
            this.tabMacroSwitch.Padding = new System.Windows.Forms.Padding(4);
            this.tabMacroSwitch.Size = new System.Drawing.Size(1036, 441);
            this.tabMacroSwitch.TabIndex = 8;
            this.tabMacroSwitch.Text = "Macro Switch";
            // 
            // tabPageDebuffs
            // 
            this.tabPageDebuffs.Location = new System.Drawing.Point(4, 44);
            this.tabPageDebuffs.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageDebuffs.Name = "tabPageDebuffs";
            this.tabPageDebuffs.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageDebuffs.Size = new System.Drawing.Size(1036, 441);
            this.tabPageDebuffs.TabIndex = 7;
            this.tabPageDebuffs.Text = "Debuffs";
            this.tabPageDebuffs.UseVisualStyleBackColor = true;
            // 
            // tabConfig
            // 
            this.tabConfig.Location = new System.Drawing.Point(4, 44);
            this.tabConfig.Margin = new System.Windows.Forms.Padding(4);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(4);
            this.tabConfig.Size = new System.Drawing.Size(1036, 441);
            this.tabConfig.TabIndex = 10;
            this.tabConfig.Text = "Config";
            this.tabConfig.UseVisualStyleBackColor = true;
            this.tabConfig.Click += new System.EventHandler(this.tabConfig_Click);
            // 
            // tabPageProfiles
            // 
            this.tabPageProfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.tabPageProfiles.Location = new System.Drawing.Point(4, 44);
            this.tabPageProfiles.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageProfiles.Name = "tabPageProfiles";
            this.tabPageProfiles.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageProfiles.Size = new System.Drawing.Size(1036, 441);
            this.tabPageProfiles.TabIndex = 9;
            this.tabPageProfiles.Text = "Profiles";
            // 
            // lblProcessName
            // 
            this.lblProcessName.AutoSize = true;
            this.lblProcessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblProcessName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.lblProcessName.Location = new System.Drawing.Point(15, 9);
            this.lblProcessName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(128, 20);
            this.lblProcessName.TabIndex = 3;
            this.lblProcessName.Text = "Ragnarok Client";
            // 
            // processCB
            // 
            this.processCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.processCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.processCB.ForeColor = System.Drawing.Color.White;
            this.processCB.FormattingEnabled = true;
            this.processCB.Location = new System.Drawing.Point(19, 37);
            this.processCB.Margin = new System.Windows.Forms.Padding(4);
            this.processCB.Name = "processCB";
            this.processCB.Size = new System.Drawing.Size(244, 24);
            this.processCB.TabIndex = 2;
            this.processCB.SelectedIndexChanged += new System.EventHandler(this.processCB_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(277, 37);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblLinkDiscord
            // 
            this.lblLinkDiscord.AutoSize = true;
            this.lblLinkDiscord.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(244)))));
            this.lblLinkDiscord.Location = new System.Drawing.Point(794, 18);
            this.lblLinkDiscord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLinkDiscord.Name = "lblLinkDiscord";
            this.lblLinkDiscord.Size = new System.Drawing.Size(127, 16);
            this.lblLinkDiscord.TabIndex = 8;
            this.lblLinkDiscord.TabStop = true;
            this.lblLinkDiscord.Text = "Discord Ragnatales";
            this.lblLinkDiscord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkDiscord_LinkClicked);
            // 
            // lblLinkGithub
            // 
            this.lblLinkGithub.AutoSize = true;
            this.lblLinkGithub.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(244)))));
            this.lblLinkGithub.Location = new System.Drawing.Point(58, 18);
            this.lblLinkGithub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLinkGithub.Name = "lblLinkGithub";
            this.lblLinkGithub.Size = new System.Drawing.Size(90, 16);
            this.lblLinkGithub.TabIndex = 9;
            this.lblLinkGithub.TabStop = true;
            this.lblLinkGithub.Text = "Github Project";
            this.lblLinkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkGithub_LinkClicked);
            // 
            // panelDiscImage
            // 
            this.panelDiscImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDiscImage.BackgroundImage")));
            this.panelDiscImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelDiscImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelDiscImage.Location = new System.Drawing.Point(736, 0);
            this.panelDiscImage.Margin = new System.Windows.Forms.Padding(4);
            this.panelDiscImage.Name = "panelDiscImage";
            this.panelDiscImage.Size = new System.Drawing.Size(50, 50);
            this.panelDiscImage.TabIndex = 10;
            // 
            // panelGithubImage
            // 
            this.panelGithubImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelGithubImage.BackgroundImage")));
            this.panelGithubImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelGithubImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelGithubImage.Location = new System.Drawing.Point(4, 0);
            this.panelGithubImage.Margin = new System.Windows.Forms.Padding(4);
            this.panelGithubImage.Name = "panelGithubImage";
            this.panelGithubImage.Size = new System.Drawing.Size(50, 50);
            this.panelGithubImage.TabIndex = 11;
            // 
            // labelProfile
            // 
            this.labelProfile.AutoSize = true;
            this.labelProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.labelProfile.Location = new System.Drawing.Point(471, 11);
            this.labelProfile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(57, 20);
            this.labelProfile.TabIndex = 15;
            this.labelProfile.Text = "Profile";
            // 
            // profileCB
            // 
            this.profileCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.profileCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileCB.ForeColor = System.Drawing.Color.White;
            this.profileCB.FormattingEnabled = true;
            this.profileCB.Location = new System.Drawing.Point(475, 37);
            this.profileCB.Margin = new System.Windows.Forms.Padding(4);
            this.profileCB.Name = "profileCB";
            this.profileCB.Size = new System.Drawing.Size(240, 24);
            this.profileCB.TabIndex = 14;
            this.profileCB.SelectedIndexChanged += new System.EventHandler(this.profileCB_SelectedIndexChanged);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.panelFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFooter.Controls.Add(this.panelDiscImage);
            this.panelFooter.Controls.Add(this.panel1);
            this.panelFooter.Controls.Add(this.panel2);
            this.panelFooter.Controls.Add(this.livepixLinkLabel);
            this.panelFooter.Controls.Add(this.websiteLinkLabel);
            this.panelFooter.Controls.Add(this.lblLinkGithub);
            this.panelFooter.Controls.Add(this.lblLinkDiscord);
            this.panelFooter.Controls.Add(this.panelGithubImage);
            this.panelFooter.Location = new System.Drawing.Point(19, 839);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(5);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1044, 50);
            this.panelFooter.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(491, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(50, 50);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Location = new System.Drawing.Point(268, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(50, 50);
            this.panel2.TabIndex = 15;
            // 
            // livepixLinkLabel
            // 
            this.livepixLinkLabel.AutoSize = true;
            this.livepixLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(244)))));
            this.livepixLinkLabel.Location = new System.Drawing.Point(326, 18);
            this.livepixLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.livepixLinkLabel.Name = "livepixLinkLabel";
            this.livepixLinkLabel.Size = new System.Drawing.Size(92, 16);
            this.livepixLinkLabel.TabIndex = 14;
            this.livepixLinkLabel.TabStop = true;
            this.livepixLinkLabel.Text = "Livepix Hanna";
            this.livepixLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.livepixLinkLabel_LinkClicked);
            // 
            // websiteLinkLabel
            // 
            this.websiteLinkLabel.AutoSize = true;
            this.websiteLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(244)))));
            this.websiteLinkLabel.Location = new System.Drawing.Point(549, 18);
            this.websiteLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.websiteLinkLabel.Name = "websiteLinkLabel";
            this.websiteLinkLabel.Size = new System.Drawing.Size(103, 16);
            this.websiteLinkLabel.TabIndex = 12;
            this.websiteLinkLabel.TabStop = true;
            this.websiteLinkLabel.Text = "Site Ragnatales";
            this.websiteLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteLinkLabel_LinkClicked);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Location = new System.Drawing.Point(19, 81);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1044, 1);
            this.panel4.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 18;
            // 
            // lblCharacterName
            // 
            this.lblCharacterName.AutoSize = true;
            this.lblCharacterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCharacterName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.lblCharacterName.Location = new System.Drawing.Point(843, 11);
            this.lblCharacterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCharacterName.Name = "lblCharacterName";
            this.lblCharacterName.Size = new System.Drawing.Size(137, 20);
            this.lblCharacterName.TabIndex = 19;
            this.lblCharacterName.Text = "Character Name:";
            // 
            // characterName
            // 
            this.characterName.AutoSize = true;
            this.characterName.Font = new System.Drawing.Font("JetBrains Mono", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.characterName.ForeColor = System.Drawing.Color.DarkGreen;
            this.characterName.Location = new System.Drawing.Point(844, 39);
            this.characterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.characterName.Name = "characterName";
            this.characterName.Size = new System.Drawing.Size(36, 19);
            this.characterName.TabIndex = 20;
            this.characterName.Text = "- -";
            // 
            // tabControlAutopot
            // 
            this.tabControlAutopot.Controls.Add(this.tabPageAutopot);
            this.tabControlAutopot.Controls.Add(this.tabPageYggAutopot);
            this.tabControlAutopot.Controls.Add(this.tabPageSkillTimer);
            this.tabControlAutopot.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlAutopot.ItemSize = new System.Drawing.Size(68, 40);
            this.tabControlAutopot.Location = new System.Drawing.Point(19, 91);
            this.tabControlAutopot.Margin = new System.Windows.Forms.Padding(5);
            this.tabControlAutopot.Name = "tabControlAutopot";
            this.tabControlAutopot.SelectedIndex = 0;
            this.tabControlAutopot.Size = new System.Drawing.Size(450, 230);
            this.tabControlAutopot.TabIndex = 25;
            // 
            // tabPageAutopot
            // 
            this.tabPageAutopot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.tabPageAutopot.Location = new System.Drawing.Point(4, 44);
            this.tabPageAutopot.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAutopot.Name = "tabPageAutopot";
            this.tabPageAutopot.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAutopot.Size = new System.Drawing.Size(442, 182);
            this.tabPageAutopot.TabIndex = 0;
            this.tabPageAutopot.Text = "Autopot";
            // 
            // tabPageYggAutopot
            // 
            this.tabPageYggAutopot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.tabPageYggAutopot.Location = new System.Drawing.Point(4, 44);
            this.tabPageYggAutopot.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageYggAutopot.Name = "tabPageYggAutopot";
            this.tabPageYggAutopot.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageYggAutopot.Size = new System.Drawing.Size(442, 182);
            this.tabPageYggAutopot.TabIndex = 1;
            this.tabPageYggAutopot.Text = "Yggdrasil";
            // 
            // tabPageSkillTimer
            // 
            this.tabPageSkillTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.tabPageSkillTimer.Location = new System.Drawing.Point(4, 44);
            this.tabPageSkillTimer.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSkillTimer.Name = "tabPageSkillTimer";
            this.tabPageSkillTimer.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageSkillTimer.Size = new System.Drawing.Size(442, 182);
            this.tabPageSkillTimer.TabIndex = 2;
            this.tabPageSkillTimer.Text = "Skill Timer";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.groupBox1.Controls.Add(this.txtStatusToggleKey);
            this.groupBox1.Controls.Add(this.btnStatusToggle);
            this.groupBox1.Controls.Add(this.lblStatusToggle);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.groupBox1.Location = new System.Drawing.Point(493, 111);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(280, 120);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Status";
            // 
            // txtStatusToggleKey
            // 
            this.txtStatusToggleKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtStatusToggleKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtStatusToggleKey.ForeColor = System.Drawing.Color.White;
            this.txtStatusToggleKey.Location = new System.Drawing.Point(170, 20);
            this.txtStatusToggleKey.Margin = new System.Windows.Forms.Padding(10);
            this.txtStatusToggleKey.Multiline = true;
            this.txtStatusToggleKey.Name = "txtStatusToggleKey";
            this.txtStatusToggleKey.Size = new System.Drawing.Size(90, 35);
            this.txtStatusToggleKey.TabIndex = 23;
            this.txtStatusToggleKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStatusToggle
            // 
            this.btnStatusToggle.BackColor = System.Drawing.Color.Red;
            this.btnStatusToggle.FlatAppearance.BorderSize = 0;
            this.btnStatusToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusToggle.Font = new System.Drawing.Font("JetBrains Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatusToggle.ForeColor = System.Drawing.SystemColors.Window;
            this.btnStatusToggle.Location = new System.Drawing.Point(20, 20);
            this.btnStatusToggle.Margin = new System.Windows.Forms.Padding(10);
            this.btnStatusToggle.Name = "btnStatusToggle";
            this.btnStatusToggle.Size = new System.Drawing.Size(90, 35);
            this.btnStatusToggle.TabIndex = 21;
            this.btnStatusToggle.Text = "OFF";
            this.btnStatusToggle.UseVisualStyleBackColor = false;
            this.btnStatusToggle.Click += new System.EventHandler(this.btnToggleStatusHandler);
            // 
            // lblStatusToggle
            // 
            this.lblStatusToggle.AllowDrop = true;
            this.lblStatusToggle.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusToggle.Location = new System.Drawing.Point(43, 61);
            this.lblStatusToggle.Margin = new System.Windows.Forms.Padding(5);
            this.lblStatusToggle.MaximumSize = new System.Drawing.Size(200, 200);
            this.lblStatusToggle.Name = "lblStatusToggle";
            this.lblStatusToggle.Size = new System.Drawing.Size(200, 50);
            this.lblStatusToggle.TabIndex = 22;
            this.lblStatusToggle.Text = "Pressione uma tecla para começar!";
            this.lblStatusToggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatusToggle.Click += new System.EventHandler(this.lblStatusToggle_Click);
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.Text = "TalesTools";
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconDoubleClick);
            // 
            // lblStatusHealToggle
            // 
            this.lblStatusHealToggle.AllowDrop = true;
            this.lblStatusHealToggle.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusHealToggle.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusHealToggle.Location = new System.Drawing.Point(43, 61);
            this.lblStatusHealToggle.Margin = new System.Windows.Forms.Padding(5);
            this.lblStatusHealToggle.MaximumSize = new System.Drawing.Size(200, 200);
            this.lblStatusHealToggle.Name = "lblStatusHealToggle";
            this.lblStatusHealToggle.Size = new System.Drawing.Size(200, 50);
            this.lblStatusHealToggle.TabIndex = 22;
            this.lblStatusHealToggle.Text = "Pressione uma tecla para iniciar a cura!";
            this.lblStatusHealToggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatusHealToggle.Click += new System.EventHandler(this.lblStatusHealToggle_Click);
            // 
            // btnStatusHealToggle
            // 
            this.btnStatusHealToggle.BackColor = System.Drawing.Color.Red;
            this.btnStatusHealToggle.FlatAppearance.BorderSize = 0;
            this.btnStatusHealToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusHealToggle.Font = new System.Drawing.Font("JetBrains Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatusHealToggle.ForeColor = System.Drawing.SystemColors.Window;
            this.btnStatusHealToggle.Location = new System.Drawing.Point(20, 20);
            this.btnStatusHealToggle.Margin = new System.Windows.Forms.Padding(10);
            this.btnStatusHealToggle.Name = "btnStatusHealToggle";
            this.btnStatusHealToggle.Size = new System.Drawing.Size(90, 35);
            this.btnStatusHealToggle.TabIndex = 21;
            this.btnStatusHealToggle.Text = "OFF";
            this.btnStatusHealToggle.UseVisualStyleBackColor = false;
            this.btnStatusHealToggle.Click += new System.EventHandler(this.btnToggleStatusHealHandler);
            // 
            // txtStatusHealToggleKey
            // 
            this.txtStatusHealToggleKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtStatusHealToggleKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtStatusHealToggleKey.ForeColor = System.Drawing.Color.White;
            this.txtStatusHealToggleKey.Location = new System.Drawing.Point(170, 20);
            this.txtStatusHealToggleKey.Margin = new System.Windows.Forms.Padding(10);
            this.txtStatusHealToggleKey.Multiline = true;
            this.txtStatusHealToggleKey.Name = "txtStatusHealToggleKey";
            this.txtStatusHealToggleKey.Size = new System.Drawing.Size(90, 35);
            this.txtStatusHealToggleKey.TabIndex = 23;
            this.txtStatusHealToggleKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.groupBox2.Controls.Add(this.lblStatusHealToggle);
            this.groupBox2.Controls.Add(this.txtStatusHealToggleKey);
            this.groupBox2.Controls.Add(this.btnStatusHealToggle);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.groupBox2.Location = new System.Drawing.Point(783, 111);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(280, 120);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Heal Status";
            // 
            // groupBoxAutoTransfer
            // 
            this.groupBoxAutoTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.groupBoxAutoTransfer.Controls.Add(this.panel3);
            this.groupBoxAutoTransfer.Controls.Add(this.pictureBox1);
            this.groupBoxAutoTransfer.Controls.Add(this.txtAutoClickKey);
            this.groupBoxAutoTransfer.Controls.Add(this.label1CustomButton);
            this.groupBoxAutoTransfer.Controls.Add(this.txtTransferKey);
            this.groupBoxAutoTransfer.Controls.Add(this.pictureBox2);
            this.groupBoxAutoTransfer.Controls.Add(this.label2CustomButton);
            this.groupBoxAutoTransfer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.groupBoxAutoTransfer.Location = new System.Drawing.Point(493, 240);
            this.groupBoxAutoTransfer.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxAutoTransfer.Name = "groupBoxAutoTransfer";
            this.groupBoxAutoTransfer.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxAutoTransfer.Size = new System.Drawing.Size(570, 80);
            this.groupBoxAutoTransfer.TabIndex = 27;
            this.groupBoxAutoTransfer.TabStop = false;
            this.groupBoxAutoTransfer.Text = "Custom Buttons";
            this.groupBoxAutoTransfer.Enter += new System.EventHandler(this.groupBoxAutoTransfer_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtAutoClickKey
            // 
            this.txtAutoClickKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtAutoClickKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAutoClickKey.ForeColor = System.Drawing.Color.White;
            this.txtAutoClickKey.Location = new System.Drawing.Point(490, 24);
            this.txtAutoClickKey.Margin = new System.Windows.Forms.Padding(5);
            this.txtAutoClickKey.Multiline = true;
            this.txtAutoClickKey.Name = "txtAutoClickKey";
            this.txtAutoClickKey.Size = new System.Drawing.Size(60, 35);
            this.txtAutoClickKey.TabIndex = 14;
            this.txtAutoClickKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1CustomButton
            // 
            this.label1CustomButton.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1CustomButton.Location = new System.Drawing.Point(76, 13);
            this.label1CustomButton.Margin = new System.Windows.Forms.Padding(5);
            this.label1CustomButton.Name = "label1CustomButton";
            this.label1CustomButton.Size = new System.Drawing.Size(117, 51);
            this.label1CustomButton.TabIndex = 13;
            this.label1CustomButton.Text = "Transferir Item";
            this.label1CustomButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1CustomButton.Click += new System.EventHandler(this.label1CustomButton_Click);
            // 
            // txtTransferKey
            // 
            this.txtTransferKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtTransferKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTransferKey.ForeColor = System.Drawing.Color.White;
            this.txtTransferKey.Location = new System.Drawing.Point(200, 24);
            this.txtTransferKey.Margin = new System.Windows.Forms.Padding(5);
            this.txtTransferKey.Multiline = true;
            this.txtTransferKey.Name = "txtTransferKey";
            this.txtTransferKey.Size = new System.Drawing.Size(60, 35);
            this.txtTransferKey.TabIndex = 11;
            this.txtTransferKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.ErrorImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(310, 24);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // label2CustomButton
            // 
            this.label2CustomButton.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2CustomButton.Location = new System.Drawing.Point(384, 15);
            this.label2CustomButton.Margin = new System.Windows.Forms.Padding(5);
            this.label2CustomButton.Name = "label2CustomButton";
            this.label2CustomButton.Size = new System.Drawing.Size(74, 50);
            this.label2CustomButton.TabIndex = 16;
            this.label2CustomButton.Text = "Auto Click";
            this.label2CustomButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2CustomButton.Click += new System.EventHandler(this.label2CustomButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(285, 18);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 50);
            this.panel3.TabIndex = 18;
            // 
            // Container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1082, 903);
            this.Controls.Add(this.groupBoxAutoTransfer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(atkDefMode);
            this.Controls.Add(this.tabControlAutopot);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.characterName);
            this.Controls.Add(this.lblCharacterName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.labelProfile);
            this.Controls.Add(this.profileCB);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblProcessName);
            this.Controls.Add(this.processCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Container";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TalesTools";
            this.Load += new System.EventHandler(this.Container_Load);
            this.Resize += new System.EventHandler(this.containerResize);
            atkDefMode.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.tabControlAutopot.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxAutoTransfer.ResumeLayout(false);
            this.groupBoxAutoTransfer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProcessName;
        private System.Windows.Forms.ComboBox processCB;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabPage tabPageSpammer;
        private System.Windows.Forms.LinkLabel lblLinkDiscord;
        private System.Windows.Forms.LinkLabel lblLinkGithub;
        private System.Windows.Forms.Panel panelDiscImage;
        private System.Windows.Forms.Panel panelGithubImage;
        private System.Windows.Forms.Label labelProfile;
        public System.Windows.Forms.ComboBox profileCB;
        private System.Windows.Forms.TabPage tabPageAutobuffSkill;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCharacterName;
        private System.Windows.Forms.Label characterName;
        private TabPage tabPageAutobuffStuff;
        private TabPage tabPageMacroSongs;
        private TabPage atkDef;
        private TabControl tabControlAutopot;
        private TabPage tabPageAutopot;
        private TabPage tabPageYggAutopot;
        private LinkLabel websiteLinkLabel;
        private Panel panel1;
        private TabPage tabPageProfiles;
        private TabPage tabMacroSwitch;
        private TabPage tabPageSkillTimer;
        private TabPage tabPageAutoSwitch;
        //private TabPage tabPageServer;
        private TabPage tabPageDebuffs;
        private TabPage tabConfig;
        private LinkLabel livepixLinkLabel;
        private Panel panel2;

        // Controles do ToggleApplicationStateForm integrados
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStatusToggle;
        private System.Windows.Forms.Label lblStatusToggle;
        private System.Windows.Forms.TextBox txtStatusToggleKey;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.Label lblStatusHealToggle;
        private System.Windows.Forms.Button btnStatusHealToggle;
        private System.Windows.Forms.TextBox txtStatusHealToggleKey;
        private System.Windows.Forms.GroupBox groupBox2;

        // Controles do CustomButtonForm integrados
        private System.Windows.Forms.GroupBox groupBoxAutoTransfer;
        private System.Windows.Forms.TextBox txtTransferKey;
        private System.Windows.Forms.Label label1CustomButton;
        private System.Windows.Forms.Label label2CustomButton;
        private System.Windows.Forms.TextBox txtAutoClickKey;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private Panel panel3;
    }
}