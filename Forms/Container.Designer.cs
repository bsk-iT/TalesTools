using System;
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
            System.Windows.Forms.TabControl tabsFunction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Container));
            this.tabPageHome = new System.Windows.Forms.TabPage();
            this.panelAutopot = new System.Windows.Forms.Panel();
            this.panelYgg = new System.Windows.Forms.Panel();
            this.tabPageAutoSwitchHeal = new System.Windows.Forms.TabPage();
            this.panelAutoSwitchHeal = new System.Windows.Forms.Panel();
            this.tabPageSpammer = new System.Windows.Forms.TabPage();
            this.tabPageAutobuffSkill = new System.Windows.Forms.TabPage();
            this.tabPageAutobuffStuff = new System.Windows.Forms.TabPage();
            this.tabPageDebuffs = new System.Windows.Forms.TabPage();
            this.tabPageAutoSwitch = new System.Windows.Forms.TabPage();
            this.tabMacroSwitch = new System.Windows.Forms.TabPage();
            this.atkDef = new System.Windows.Forms.TabPage();
            this.tabPageMacroSongs = new System.Windows.Forms.TabPage();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.tabPageProfiles = new System.Windows.Forms.TabPage();
            this.tabPageDebug = new System.Windows.Forms.TabPage();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.processCB = new System.Windows.Forms.ComboBox();
            this.lblLinkDiscord = new System.Windows.Forms.LinkLabel();
            this.lblLinkGithub = new System.Windows.Forms.LinkLabel();
            this.labelProfile = new System.Windows.Forms.Label();
            this.profileCB = new System.Windows.Forms.ComboBox();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.livepixLinkLabelBsk = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.livepixLinkLabel = new System.Windows.Forms.LinkLabel();
            this.websiteLinkLabel = new System.Windows.Forms.LinkLabel();
            this.panelDiscImage = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCharacterName = new System.Windows.Forms.Label();
            this.characterName = new System.Windows.Forms.Label();
            this.groupBoxSkillTimer = new System.Windows.Forms.GroupBox();
            this.panelGithubImage = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            tabsFunction = new System.Windows.Forms.TabControl();
            tabsFunction.SuspendLayout();
            this.tabPageHome.SuspendLayout();
            this.tabPageAutoSwitchHeal.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsFunction
            // 
            tabsFunction.Controls.Add(this.tabPageHome);
            tabsFunction.Controls.Add(this.tabPageAutoSwitchHeal);
            tabsFunction.Controls.Add(this.tabPageSpammer);
            tabsFunction.Controls.Add(this.tabPageAutobuffSkill);
            tabsFunction.Controls.Add(this.tabPageAutobuffStuff);
            tabsFunction.Controls.Add(this.tabPageDebuffs);
            tabsFunction.Controls.Add(this.tabPageAutoSwitch);
            tabsFunction.Controls.Add(this.tabMacroSwitch);
            tabsFunction.Controls.Add(this.atkDef);
            tabsFunction.Controls.Add(this.tabPageMacroSongs);
            tabsFunction.Controls.Add(this.tabConfig);
            tabsFunction.Controls.Add(this.tabPageProfiles);
            tabsFunction.Controls.Add(this.tabPageDebug);
            tabsFunction.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tabsFunction.ForeColor = System.Drawing.Color.White;
            tabsFunction.ItemSize = new System.Drawing.Size(120, 30);
            tabsFunction.Location = new System.Drawing.Point(24, 142);
            tabsFunction.Margin = new System.Windows.Forms.Padding(5);
            tabsFunction.Name = "tabsFunction";
            tabsFunction.SelectedIndex = 0;
            tabsFunction.Size = new System.Drawing.Size(980, 462);
            tabsFunction.TabIndex = 6;
            // 
            // tabPageHome
            // 
            this.tabPageHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPageHome.Controls.Add(this.panelAutopot);
            this.tabPageHome.Controls.Add(this.panelYgg);
            this.tabPageHome.Location = new System.Drawing.Point(4, 34);
            this.tabPageHome.Name = "tabPageHome";
            this.tabPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHome.Size = new System.Drawing.Size(972, 424);
            this.tabPageHome.TabIndex = 12;
            this.tabPageHome.Text = "HOME";
            this.tabPageHome.Click += new System.EventHandler(this.tabPageHome_Click);
            // 
            // panelAutopot
            // 
            this.panelAutopot.Location = new System.Drawing.Point(30, 35);
            this.panelAutopot.Name = "panelAutopot";
            this.panelAutopot.Size = new System.Drawing.Size(450, 330);
            this.panelAutopot.TabIndex = 29;
            // 
            // panelYgg
            // 
            this.panelYgg.Location = new System.Drawing.Point(496, 35);
            this.panelYgg.Name = "panelYgg";
            this.panelYgg.Size = new System.Drawing.Size(450, 330);
            this.panelYgg.TabIndex = 28;
            // 
            // tabPageAutoSwitchHeal
            // 
            this.tabPageAutoSwitchHeal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPageAutoSwitchHeal.Controls.Add(this.panelAutoSwitchHeal);
            this.tabPageAutoSwitchHeal.Location = new System.Drawing.Point(4, 34);
            this.tabPageAutoSwitchHeal.Name = "tabPageAutoSwitchHeal";
            this.tabPageAutoSwitchHeal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAutoSwitchHeal.Size = new System.Drawing.Size(972, 424);
            this.tabPageAutoSwitchHeal.TabIndex = 13;
            this.tabPageAutoSwitchHeal.Text = "AUTOSWITCH HEAL";
            // 
            // panelAutoSwitchHeal
            // 
            this.panelAutoSwitchHeal.Location = new System.Drawing.Point(0, 30);
            this.panelAutoSwitchHeal.Name = "panelAutoSwitchHeal";
            this.panelAutoSwitchHeal.Size = new System.Drawing.Size(972, 350);
            this.panelAutoSwitchHeal.TabIndex = 2;
            // 
            // tabPageSpammer
            // 
            this.tabPageSpammer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPageSpammer.Location = new System.Drawing.Point(4, 34);
            this.tabPageSpammer.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSpammer.Name = "tabPageSpammer";
            this.tabPageSpammer.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageSpammer.Size = new System.Drawing.Size(972, 424);
            this.tabPageSpammer.TabIndex = 1;
            this.tabPageSpammer.Text = "SKILL SPAMMER";
            // 
            // tabPageAutobuffSkill
            // 
            this.tabPageAutobuffSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPageAutobuffSkill.Location = new System.Drawing.Point(4, 34);
            this.tabPageAutobuffSkill.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAutobuffSkill.Name = "tabPageAutobuffSkill";
            this.tabPageAutobuffSkill.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAutobuffSkill.Size = new System.Drawing.Size(972, 424);
            this.tabPageAutobuffSkill.TabIndex = 3;
            this.tabPageAutobuffSkill.Text = "AUTOBUFF";
            // 
            // tabPageAutobuffStuff
            // 
            this.tabPageAutobuffStuff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPageAutobuffStuff.Location = new System.Drawing.Point(4, 34);
            this.tabPageAutobuffStuff.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAutobuffStuff.Name = "tabPageAutobuffStuff";
            this.tabPageAutobuffStuff.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAutobuffStuff.Size = new System.Drawing.Size(972, 424);
            this.tabPageAutobuffStuff.TabIndex = 4;
            this.tabPageAutobuffStuff.Text = "STUFFS";
            this.tabPageAutobuffStuff.Click += new System.EventHandler(this.tabPageAutobuffStuff_Click);
            // 
            // tabPageDebuffs
            // 
            this.tabPageDebuffs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPageDebuffs.Location = new System.Drawing.Point(4, 34);
            this.tabPageDebuffs.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageDebuffs.Name = "tabPageDebuffs";
            this.tabPageDebuffs.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageDebuffs.Size = new System.Drawing.Size(972, 424);
            this.tabPageDebuffs.TabIndex = 7;
            this.tabPageDebuffs.Text = "DEBUFFS";
            // 
            // tabPageAutoSwitch
            // 
            this.tabPageAutoSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPageAutoSwitch.Location = new System.Drawing.Point(4, 34);
            this.tabPageAutoSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAutoSwitch.Name = "tabPageAutoSwitch";
            this.tabPageAutoSwitch.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAutoSwitch.Size = new System.Drawing.Size(972, 424);
            this.tabPageAutoSwitch.TabIndex = 3;
            this.tabPageAutoSwitch.Text = "AUTOSWITCH";
            // 
            // tabMacroSwitch
            // 
            this.tabMacroSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabMacroSwitch.Location = new System.Drawing.Point(4, 34);
            this.tabMacroSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.tabMacroSwitch.Name = "tabMacroSwitch";
            this.tabMacroSwitch.Padding = new System.Windows.Forms.Padding(4);
            this.tabMacroSwitch.Size = new System.Drawing.Size(972, 424);
            this.tabMacroSwitch.TabIndex = 8;
            this.tabMacroSwitch.Text = "MACRO SWITCH";
            // 
            // atkDef
            // 
            this.atkDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.atkDef.Location = new System.Drawing.Point(4, 34);
            this.atkDef.Margin = new System.Windows.Forms.Padding(4);
            this.atkDef.Name = "atkDef";
            this.atkDef.Padding = new System.Windows.Forms.Padding(4);
            this.atkDef.Size = new System.Drawing.Size(972, 424);
            this.atkDef.TabIndex = 5;
            this.atkDef.Text = "ATK x DEF";
            // 
            // tabPageMacroSongs
            // 
            this.tabPageMacroSongs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPageMacroSongs.Location = new System.Drawing.Point(4, 34);
            this.tabPageMacroSongs.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMacroSongs.Name = "tabPageMacroSongs";
            this.tabPageMacroSongs.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageMacroSongs.Size = new System.Drawing.Size(972, 424);
            this.tabPageMacroSongs.TabIndex = 6;
            this.tabPageMacroSongs.Text = "MACRO SONGS";
            // 
            // tabConfig
            // 
            this.tabConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabConfig.Location = new System.Drawing.Point(4, 34);
            this.tabConfig.Margin = new System.Windows.Forms.Padding(4);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(4);
            this.tabConfig.Size = new System.Drawing.Size(972, 424);
            this.tabConfig.TabIndex = 10;
            this.tabConfig.Text = "UTILITIES";
            // 
            // tabPageProfiles
            // 
            this.tabPageProfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPageProfiles.Location = new System.Drawing.Point(4, 34);
            this.tabPageProfiles.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageProfiles.Name = "tabPageProfiles";
            this.tabPageProfiles.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageProfiles.Size = new System.Drawing.Size(972, 424);
            this.tabPageProfiles.TabIndex = 9;
            this.tabPageProfiles.Text = "PROFILES";
            // 
            // tabPageDebug
            // 
            this.tabPageDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabPageDebug.Location = new System.Drawing.Point(4, 34);
            this.tabPageDebug.Name = "tabPageDebug";
            this.tabPageDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDebug.Size = new System.Drawing.Size(972, 424);
            this.tabPageDebug.TabIndex = 11;
            this.tabPageDebug.Text = "DEBUG";
            // 
            // lblProcessName
            // 
            this.lblProcessName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lblProcessName.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessName.ForeColor = System.Drawing.Color.Transparent;
            this.lblProcessName.Location = new System.Drawing.Point(20, 12);
            this.lblProcessName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(160, 22);
            this.lblProcessName.TabIndex = 3;
            this.lblProcessName.Text = "RAGNAROK CLIENT";
            // 
            // processCB
            // 
            this.processCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.processCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.processCB.Font = new System.Drawing.Font("JetBrains Mono", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processCB.ForeColor = System.Drawing.Color.White;
            this.processCB.FormattingEnabled = true;
            this.processCB.Location = new System.Drawing.Point(23, 38);
            this.processCB.Margin = new System.Windows.Forms.Padding(4);
            this.processCB.Name = "processCB";
            this.processCB.Size = new System.Drawing.Size(244, 24);
            this.processCB.TabIndex = 2;
            this.processCB.SelectedIndexChanged += new System.EventHandler(this.processCB_SelectedIndexChanged);
            // 
            // lblLinkDiscord
            // 
            this.lblLinkDiscord.AutoSize = true;
            this.lblLinkDiscord.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkDiscord.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.lblLinkDiscord.Location = new System.Drawing.Point(848, 6);
            this.lblLinkDiscord.Margin = new System.Windows.Forms.Padding(5);
            this.lblLinkDiscord.Name = "lblLinkDiscord";
            this.lblLinkDiscord.Size = new System.Drawing.Size(133, 14);
            this.lblLinkDiscord.TabIndex = 8;
            this.lblLinkDiscord.TabStop = true;
            this.lblLinkDiscord.Text = "Discord Ragnatales";
            this.lblLinkDiscord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLinkDiscord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkDiscord_LinkClicked);
            // 
            // lblLinkGithub
            // 
            this.lblLinkGithub.AutoSize = true;
            this.lblLinkGithub.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkGithub.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.lblLinkGithub.Location = new System.Drawing.Point(34, 5);
            this.lblLinkGithub.Margin = new System.Windows.Forms.Padding(5);
            this.lblLinkGithub.Name = "lblLinkGithub";
            this.lblLinkGithub.Size = new System.Drawing.Size(105, 14);
            this.lblLinkGithub.TabIndex = 9;
            this.lblLinkGithub.TabStop = true;
            this.lblLinkGithub.Text = "Github Project";
            this.lblLinkGithub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLinkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkGithub_LinkClicked);
            // 
            // labelProfile
            // 
            this.labelProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.labelProfile.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProfile.ForeColor = System.Drawing.Color.Transparent;
            this.labelProfile.Location = new System.Drawing.Point(330, 12);
            this.labelProfile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(80, 22);
            this.labelProfile.TabIndex = 15;
            this.labelProfile.Text = "PROFILE";
            // 
            // profileCB
            // 
            this.profileCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.profileCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileCB.Font = new System.Drawing.Font("JetBrains Mono", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileCB.ForeColor = System.Drawing.Color.White;
            this.profileCB.FormattingEnabled = true;
            this.profileCB.Location = new System.Drawing.Point(334, 38);
            this.profileCB.Margin = new System.Windows.Forms.Padding(4);
            this.profileCB.Name = "profileCB";
            this.profileCB.Size = new System.Drawing.Size(240, 24);
            this.profileCB.TabIndex = 14;
            this.profileCB.SelectedIndexChanged += new System.EventHandler(this.profileCB_SelectedIndexChanged);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panelFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelFooter.Controls.Add(this.panel3);
            this.panelFooter.Controls.Add(this.livepixLinkLabelBsk);
            this.panelFooter.Controls.Add(this.panel2);
            this.panelFooter.Controls.Add(this.livepixLinkLabel);
            this.panelFooter.Controls.Add(this.websiteLinkLabel);
            this.panelFooter.Controls.Add(this.panelDiscImage);
            this.panelFooter.Controls.Add(this.lblLinkGithub);
            this.panelFooter.Controls.Add(this.panel1);
            this.panelFooter.Controls.Add(this.lblLinkDiscord);
            this.panelFooter.Location = new System.Drawing.Point(23, 613);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(5);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(981, 25);
            this.panelFooter.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel3.Location = new System.Drawing.Point(394, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(25, 25);
            this.panel3.TabIndex = 16;
            // 
            // livepixLinkLabelBsk
            // 
            this.livepixLinkLabelBsk.AutoSize = true;
            this.livepixLinkLabelBsk.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livepixLinkLabelBsk.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.livepixLinkLabelBsk.Location = new System.Drawing.Point(428, 5);
            this.livepixLinkLabelBsk.Margin = new System.Windows.Forms.Padding(5);
            this.livepixLinkLabelBsk.Name = "livepixLinkLabelBsk";
            this.livepixLinkLabelBsk.Size = new System.Drawing.Size(112, 14);
            this.livepixLinkLabelBsk.TabIndex = 15;
            this.livepixLinkLabelBsk.TabStop = true;
            this.livepixLinkLabelBsk.Text = "Livepix Berserk";
            this.livepixLinkLabelBsk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.livepixLinkLabelBsk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.livepixLinkLabelBsk_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel2.Location = new System.Drawing.Point(204, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(25, 25);
            this.panel2.TabIndex = 15;
            // 
            // livepixLinkLabel
            // 
            this.livepixLinkLabel.AutoSize = true;
            this.livepixLinkLabel.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livepixLinkLabel.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.livepixLinkLabel.Location = new System.Drawing.Point(238, 5);
            this.livepixLinkLabel.Margin = new System.Windows.Forms.Padding(5);
            this.livepixLinkLabel.Name = "livepixLinkLabel";
            this.livepixLinkLabel.Size = new System.Drawing.Size(98, 14);
            this.livepixLinkLabel.TabIndex = 14;
            this.livepixLinkLabel.TabStop = true;
            this.livepixLinkLabel.Text = "Livepix Hanna";
            this.livepixLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.livepixLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.livepixLinkLabel_LinkClicked);
            // 
            // websiteLinkLabel
            // 
            this.websiteLinkLabel.AutoSize = true;
            this.websiteLinkLabel.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.websiteLinkLabel.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.websiteLinkLabel.Location = new System.Drawing.Point(640, 5);
            this.websiteLinkLabel.Margin = new System.Windows.Forms.Padding(5);
            this.websiteLinkLabel.Name = "websiteLinkLabel";
            this.websiteLinkLabel.Size = new System.Drawing.Size(112, 14);
            this.websiteLinkLabel.TabIndex = 12;
            this.websiteLinkLabel.TabStop = true;
            this.websiteLinkLabel.Text = "Site Ragnatales";
            this.websiteLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.websiteLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteLinkLabel_LinkClicked);
            // 
            // panelDiscImage
            // 
            this.panelDiscImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDiscImage.BackgroundImage")));
            this.panelDiscImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDiscImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panelDiscImage.Location = new System.Drawing.Point(814, 0);
            this.panelDiscImage.Margin = new System.Windows.Forms.Padding(4);
            this.panelDiscImage.Name = "panelDiscImage";
            this.panelDiscImage.Size = new System.Drawing.Size(25, 25);
            this.panelDiscImage.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel1.Location = new System.Drawing.Point(606, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 25);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 18;
            // 
            // lblCharacterName
            // 
            this.lblCharacterName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lblCharacterName.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacterName.ForeColor = System.Drawing.Color.Transparent;
            this.lblCharacterName.Location = new System.Drawing.Point(20, 75);
            this.lblCharacterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCharacterName.Name = "lblCharacterName";
            this.lblCharacterName.Size = new System.Drawing.Size(150, 22);
            this.lblCharacterName.TabIndex = 19;
            this.lblCharacterName.Text = "CHARACTER NAME";
            // 
            // characterName
            // 
            this.characterName.AutoSize = true;
            this.characterName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.characterName.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.characterName.ForeColor = System.Drawing.Color.Gold;
            this.characterName.Location = new System.Drawing.Point(24, 101);
            this.characterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.characterName.Name = "characterName";
            this.characterName.Size = new System.Drawing.Size(32, 17);
            this.characterName.TabIndex = 20;
            this.characterName.Text = "- -";
            this.characterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.characterName.Click += new System.EventHandler(this.characterName_Click);
            // 
            // groupBoxSkillTimer
            // 
            this.groupBoxSkillTimer.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSkillTimer.Name = "groupBoxSkillTimer";
            this.groupBoxSkillTimer.Size = new System.Drawing.Size(200, 100);
            this.groupBoxSkillTimer.TabIndex = 0;
            this.groupBoxSkillTimer.TabStop = false;
            // 
            // panelGithubImage
            // 
            this.panelGithubImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelGithubImage.BackgroundImage")));
            this.panelGithubImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelGithubImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panelGithubImage.Location = new System.Drawing.Point(23, 613);
            this.panelGithubImage.Margin = new System.Windows.Forms.Padding(4);
            this.panelGithubImage.Name = "panelGithubImage";
            this.panelGithubImage.Size = new System.Drawing.Size(25, 25);
            this.panelGithubImage.TabIndex = 11;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(275, 38);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.Location = new System.Drawing.Point(665, 12);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(350, 120);
            this.panelStatus.TabIndex = 22;
            // 
            // Container
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1032, 653);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(tabsFunction);
            this.Controls.Add(this.characterName);
            this.Controls.Add(this.labelProfile);
            this.Controls.Add(this.profileCB);
            this.Controls.Add(this.panelGithubImage);
            this.Controls.Add(this.lblCharacterName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblProcessName);
            this.Controls.Add(this.processCB);
            this.Controls.Add(this.panelFooter);
            this.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Container";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BSKTools";
            this.Load += new System.EventHandler(this.Container_Load);
            
            tabsFunction.ResumeLayout(false);
            this.tabPageHome.ResumeLayout(false);
            this.tabPageAutoSwitchHeal.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCharacterName;
        private System.Windows.Forms.Label characterName;
        private TabPage tabPageAutobuffStuff;
        private TabPage tabPageMacroSongs;
        private TabPage atkDef;
        private LinkLabel websiteLinkLabel;
        private Panel panel1;
        private TabPage tabPageProfiles;
        private TabPage tabMacroSwitch;
        private TabPage tabPageAutoSwitch;
        //private TabPage tabPageServer;
        private TabPage tabPageDebuffs;
        private TabPage tabConfig;
        private LinkLabel livepixLinkLabel;
        private Panel panel2;
        private TabPage tabPageDebug;
        private Panel panel3;
        private LinkLabel livepixLinkLabelBsk;
        private TabPage tabPageHome;
        private GroupBox groupBoxSkillTimer;
        private TabPage tabPageAutoSwitchHeal;
        private Panel panelYgg;
        private Panel panelAutopot;
        private Panel panelStatus;
        private Panel panelAutoSwitchHeal;
    }
}