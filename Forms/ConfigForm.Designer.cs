using System;
using System.Windows.Forms;

namespace _4RTools.Forms
{
    partial class ConfigForm
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
            this.skillsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkStopWithChat = new System.Windows.Forms.CheckBox();
            this.chkStopHealOnCity = new System.Windows.Forms.CheckBox();
            this.ammo2textBox = new System.Windows.Forms.TextBox();
            this.ammo1textBox = new System.Windows.Forms.TextBox();
            this.switchAmmoCheckBox = new System.Windows.Forms.CheckBox();
            this.textReinKey = new System.Windows.Forms.TextBox();
            this.getOffReinCheckBox = new System.Windows.Forms.CheckBox();
            this.chkStopBuffsOnRein = new System.Windows.Forms.CheckBox();
            this.chkStopBuffsOnCity = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.switchListBox = new System.Windows.Forms.ListBox();
            this.clientDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // skillsListBox
            // 
            this.skillsListBox.AllowDrop = true;
            this.skillsListBox.BackColor = System.Drawing.Color.Black;
            this.skillsListBox.ForeColor = System.Drawing.Color.White;
            this.skillsListBox.FormattingEnabled = true;
            this.skillsListBox.ItemHeight = 16;
            this.skillsListBox.Location = new System.Drawing.Point(17, 31);
            this.skillsListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.skillsListBox.Name = "skillsListBox";
            this.skillsListBox.Size = new System.Drawing.Size(168, 276);
            this.skillsListBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ordem de uso de Autobuffs";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkStopWithChat);
            this.groupBox1.Controls.Add(this.chkStopHealOnCity);
            this.groupBox1.Controls.Add(this.ammo2textBox);
            this.groupBox1.Controls.Add(this.ammo1textBox);
            this.groupBox1.Controls.Add(this.switchAmmoCheckBox);
            this.groupBox1.Controls.Add(this.textReinKey);
            this.groupBox1.Controls.Add(this.getOffReinCheckBox);
            this.groupBox1.Controls.Add(this.chkStopBuffsOnRein);
            this.groupBox1.Controls.Add(this.chkStopBuffsOnCity);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(412, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(400, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações TalesTools";
            // 
            // chkStopWithChat
            // 
            this.chkStopWithChat.AutoSize = true;
            this.chkStopWithChat.Location = new System.Drawing.Point(17, 192);
            this.chkStopWithChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkStopWithChat.Name = "chkStopWithChat";
            this.chkStopWithChat.Size = new System.Drawing.Size(247, 20);
            this.chkStopWithChat.TabIndex = 311;
            this.chkStopWithChat.Text = "Pausar Tales Tools com chat aberto";
            this.chkStopWithChat.UseVisualStyleBackColor = true;
            this.chkStopWithChat.CheckedChanged += new System.EventHandler(this.chkStopWithChat_CheckedChanged);
            // 
            // chkStopHealOnCity
            // 
            this.chkStopHealOnCity.AutoSize = true;
            this.chkStopHealOnCity.Location = new System.Drawing.Point(17, 63);
            this.chkStopHealOnCity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkStopHealOnCity.Name = "chkStopHealOnCity";
            this.chkStopHealOnCity.Size = new System.Drawing.Size(164, 20);
            this.chkStopHealOnCity.TabIndex = 310;
            this.chkStopHealOnCity.Text = "Pausar cura na cidade";
            this.chkStopHealOnCity.UseVisualStyleBackColor = true;
            this.chkStopHealOnCity.CheckedChanged += new System.EventHandler(this.chkStopHealOnCity_CheckedChanged);
            // 
            // ammo2textBox
            // 
            this.ammo2textBox.BackColor = System.Drawing.Color.Black;
            this.ammo2textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ammo2textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ammo2textBox.ForeColor = System.Drawing.Color.White;
            this.ammo2textBox.Location = new System.Drawing.Point(327, 156);
            this.ammo2textBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ammo2textBox.Name = "ammo2textBox";
            this.ammo2textBox.Size = new System.Drawing.Size(59, 26);
            this.ammo2textBox.TabIndex = 309;
            // 
            // ammo1textBox
            // 
            this.ammo1textBox.BackColor = System.Drawing.Color.Black;
            this.ammo1textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ammo1textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ammo1textBox.ForeColor = System.Drawing.Color.White;
            this.ammo1textBox.Location = new System.Drawing.Point(259, 156);
            this.ammo1textBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ammo1textBox.Name = "ammo1textBox";
            this.ammo1textBox.Size = new System.Drawing.Size(59, 26);
            this.ammo1textBox.TabIndex = 308;
            // 
            // switchAmmoCheckBox
            // 
            this.switchAmmoCheckBox.AutoSize = true;
            this.switchAmmoCheckBox.Location = new System.Drawing.Point(17, 160);
            this.switchAmmoCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.switchAmmoCheckBox.Name = "switchAmmoCheckBox";
            this.switchAmmoCheckBox.Size = new System.Drawing.Size(208, 20);
            this.switchAmmoCheckBox.TabIndex = 307;
            this.switchAmmoCheckBox.Text = "Troca Automática de munição";
            this.switchAmmoCheckBox.UseVisualStyleBackColor = true;
            this.switchAmmoCheckBox.CheckedChanged += new System.EventHandler(this.switchAmmoCheckBox_CheckedChanged);
            // 
            // textReinKey
            // 
            this.textReinKey.BackColor = System.Drawing.Color.Black;
            this.textReinKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textReinKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textReinKey.ForeColor = System.Drawing.Color.White;
            this.textReinKey.Location = new System.Drawing.Point(259, 122);
            this.textReinKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textReinKey.Name = "textReinKey";
            this.textReinKey.Size = new System.Drawing.Size(59, 26);
            this.textReinKey.TabIndex = 306;
            // 
            // getOffReinCheckBox
            // 
            this.getOffReinCheckBox.AutoSize = true;
            this.getOffReinCheckBox.Location = new System.Drawing.Point(17, 126);
            this.getOffReinCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.getOffReinCheckBox.Name = "getOffReinCheckBox";
            this.getOffReinCheckBox.Size = new System.Drawing.Size(219, 20);
            this.getOffReinCheckBox.TabIndex = 2;
            this.getOffReinCheckBox.Text = "Desmontar da Rédea ao atacar";
            this.getOffReinCheckBox.UseVisualStyleBackColor = true;
            this.getOffReinCheckBox.CheckedChanged += new System.EventHandler(this.getOffReinCheckBox_CheckedChanged);
            // 
            // chkStopBuffsOnRein
            // 
            this.chkStopBuffsOnRein.AutoSize = true;
            this.chkStopBuffsOnRein.Location = new System.Drawing.Point(17, 94);
            this.chkStopBuffsOnRein.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkStopBuffsOnRein.Name = "chkStopBuffsOnRein";
            this.chkStopBuffsOnRein.Size = new System.Drawing.Size(206, 20);
            this.chkStopBuffsOnRein.TabIndex = 1;
            this.chkStopBuffsOnRein.Text = "Pausar autobuff-skill na rédea";
            this.chkStopBuffsOnRein.UseVisualStyleBackColor = true;
            this.chkStopBuffsOnRein.CheckedChanged += new System.EventHandler(this.chkStopBuffsOnRein_CheckedChanged);
            // 
            // chkStopBuffsOnCity
            // 
            this.chkStopBuffsOnCity.AutoSize = true;
            this.chkStopBuffsOnCity.Location = new System.Drawing.Point(17, 33);
            this.chkStopBuffsOnCity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkStopBuffsOnCity.Name = "chkStopBuffsOnCity";
            this.chkStopBuffsOnCity.Size = new System.Drawing.Size(320, 20);
            this.chkStopBuffsOnCity.TabIndex = 0;
            this.chkStopBuffsOnCity.Text = "Pausar autobuffs/skill timer/auto switch na cidade";
            this.chkStopBuffsOnCity.UseVisualStyleBackColor = true;
            this.chkStopBuffsOnCity.CheckedChanged += new System.EventHandler(this.chkStopBuffsOnCity_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(209, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ordem de uso de MasterBall";
            // 
            // switchListBox
            // 
            this.switchListBox.AllowDrop = true;
            this.switchListBox.BackColor = System.Drawing.Color.Black;
            this.switchListBox.ForeColor = System.Drawing.Color.White;
            this.switchListBox.FormattingEnabled = true;
            this.switchListBox.ItemHeight = 16;
            this.switchListBox.Location = new System.Drawing.Point(215, 31);
            this.switchListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.switchListBox.Name = "switchListBox";
            this.switchListBox.Size = new System.Drawing.Size(168, 276);
            this.switchListBox.TabIndex = 4;
            // 
            // clientDTOBindingSource
            // 
            this.clientDTOBindingSource.DataSource = typeof(_4RTools.Model.ClientDTO);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(899, 315);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.switchListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.skillsListBox);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      
        #endregion
        private System.Windows.Forms.BindingSource clientDTOBindingSource;
        private ListBox skillsListBox;
        private Label label2;
        private GroupBox groupBox1;
        private CheckBox chkStopBuffsOnRein;
        private CheckBox chkStopBuffsOnCity;
        private CheckBox getOffReinCheckBox;
        private TextBox textReinKey;
        private TextBox ammo2textBox;
        private TextBox ammo1textBox;
        private CheckBox switchAmmoCheckBox;
        private CheckBox chkStopHealOnCity;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private Label label1;
        private ListBox switchListBox;
        private CheckBox chkStopWithChat;
    }
}