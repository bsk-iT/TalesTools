using System;
using System.Windows.Forms;
using _4RTools.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.groupConfigRein = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkStopWithChat = new System.Windows.Forms.CheckBox();
            this.chkStopBuffsOnCity = new System.Windows.Forms.CheckBox();
            this.switchAmmoCheckBox = new System.Windows.Forms.CheckBox();
            this.lblAutoReinCells = new System.Windows.Forms.Label();
            this.chkStopHealOnCity = new System.Windows.Forms.CheckBox();
            this.numAutoReinCells = new System.Windows.Forms.NumericUpDown();
            this.chkAutoReinEnabled = new System.Windows.Forms.CheckBox();
            this.getOffReinCheckBox = new System.Windows.Forms.CheckBox();
            this.chkStopBuffsOnRein = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ammo2textBox = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.ammo1textBox = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.txtAutoReinKey = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.textReinKey = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.clientDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupConfigRein.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoReinCells)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupConfigRein
            // 
            this.groupConfigRein.Controls.Add(this.textBox2);
            this.groupConfigRein.Controls.Add(this.textBox1);
            this.groupConfigRein.Controls.Add(this.ammo2textBox);
            this.groupConfigRein.Controls.Add(this.pictureBox1);
            this.groupConfigRein.Controls.Add(this.ammo1textBox);
            this.groupConfigRein.Controls.Add(this.chkStopWithChat);
            this.groupConfigRein.Controls.Add(this.txtAutoReinKey);
            this.groupConfigRein.Controls.Add(this.chkStopBuffsOnCity);
            this.groupConfigRein.Controls.Add(this.switchAmmoCheckBox);
            this.groupConfigRein.Controls.Add(this.lblAutoReinCells);
            this.groupConfigRein.Controls.Add(this.chkStopHealOnCity);
            this.groupConfigRein.Controls.Add(this.numAutoReinCells);
            this.groupConfigRein.Controls.Add(this.chkAutoReinEnabled);
            this.groupConfigRein.Controls.Add(this.textReinKey);
            this.groupConfigRein.Controls.Add(this.getOffReinCheckBox);
            this.groupConfigRein.Controls.Add(this.chkStopBuffsOnRein);
            this.groupConfigRein.ForeColor = System.Drawing.Color.White;
            this.groupConfigRein.Location = new System.Drawing.Point(20, 10);
            this.groupConfigRein.Margin = new System.Windows.Forms.Padding(4);
            this.groupConfigRein.Name = "groupConfigRein";
            this.groupConfigRein.Padding = new System.Windows.Forms.Padding(4);
            this.groupConfigRein.Size = new System.Drawing.Size(450, 390);
            this.groupConfigRein.TabIndex = 0;
            this.groupConfigRein.TabStop = false;
            this.groupConfigRein.Text = "CONFIGURAÇÕES";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(19, 82);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 318;
            this.pictureBox1.TabStop = false;
            // 
            // chkStopWithChat
            // 
            this.chkStopWithChat.AutoSize = true;
            this.chkStopWithChat.Location = new System.Drawing.Point(19, 306);
            this.chkStopWithChat.Margin = new System.Windows.Forms.Padding(10);
            this.chkStopWithChat.Name = "chkStopWithChat";
            this.chkStopWithChat.Size = new System.Drawing.Size(257, 18);
            this.chkStopWithChat.TabIndex = 311;
            this.chkStopWithChat.Text = "PAUSAR TALESTOOLS COM CHAT ABERTO\r\n";
            this.chkStopWithChat.UseVisualStyleBackColor = true;
            this.chkStopWithChat.CheckedChanged += new System.EventHandler(this.chkStopWithChat_CheckedChanged);
            // 
            // chkStopBuffsOnCity
            // 
            this.chkStopBuffsOnCity.AutoSize = true;
            this.chkStopBuffsOnCity.Location = new System.Drawing.Point(19, 224);
            this.chkStopBuffsOnCity.Margin = new System.Windows.Forms.Padding(10);
            this.chkStopBuffsOnCity.Name = "chkStopBuffsOnCity";
            this.chkStopBuffsOnCity.Size = new System.Drawing.Size(362, 18);
            this.chkStopBuffsOnCity.TabIndex = 0;
            this.chkStopBuffsOnCity.Text = "PAUSAR AUTOBUFF/SKILL TIMER/AUTOSWITCH NA CIDADE";
            this.chkStopBuffsOnCity.UseVisualStyleBackColor = true;
            this.chkStopBuffsOnCity.CheckedChanged += new System.EventHandler(this.chkStopBuffsOnCity_CheckedChanged);
            // 
            // switchAmmoCheckBox
            // 
            this.switchAmmoCheckBox.AutoSize = true;
            this.switchAmmoCheckBox.Location = new System.Drawing.Point(19, 347);
            this.switchAmmoCheckBox.Margin = new System.Windows.Forms.Padding(10);
            this.switchAmmoCheckBox.Name = "switchAmmoCheckBox";
            this.switchAmmoCheckBox.Size = new System.Drawing.Size(215, 18);
            this.switchAmmoCheckBox.TabIndex = 307;
            this.switchAmmoCheckBox.Text = "TROCA AUTOMÁTICA DE MUNIÇÃO";
            this.switchAmmoCheckBox.UseVisualStyleBackColor = true;
            this.switchAmmoCheckBox.CheckedChanged += new System.EventHandler(this.switchAmmoCheckBox_CheckedChanged);
            // 
            // lblAutoReinCells
            // 
            this.lblAutoReinCells.AutoSize = true;
            this.lblAutoReinCells.Location = new System.Drawing.Point(65, 93);
            this.lblAutoReinCells.Name = "lblAutoReinCells";
            this.lblAutoReinCells.Size = new System.Drawing.Size(63, 14);
            this.lblAutoReinCells.TabIndex = 313;
            this.lblAutoReinCells.Text = "CÉLULAS:";
            this.lblAutoReinCells.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkStopHealOnCity
            // 
            this.chkStopHealOnCity.AutoSize = true;
            this.chkStopHealOnCity.Location = new System.Drawing.Point(19, 265);
            this.chkStopHealOnCity.Margin = new System.Windows.Forms.Padding(10);
            this.chkStopHealOnCity.Name = "chkStopHealOnCity";
            this.chkStopHealOnCity.Size = new System.Drawing.Size(173, 18);
            this.chkStopHealOnCity.TabIndex = 310;
            this.chkStopHealOnCity.Text = "PAUSAR CURA NA CIDADE";
            this.chkStopHealOnCity.UseVisualStyleBackColor = true;
            this.chkStopHealOnCity.CheckedChanged += new System.EventHandler(this.chkStopHealOnCity_CheckedChanged);
            // 
            // numAutoReinCells
            // 
            this.numAutoReinCells.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.numAutoReinCells.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAutoReinCells.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAutoReinCells.ForeColor = System.Drawing.Color.White;
            this.numAutoReinCells.Location = new System.Drawing.Point(137, 87);
            this.numAutoReinCells.Margin = new System.Windows.Forms.Padding(4);
            this.numAutoReinCells.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numAutoReinCells.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAutoReinCells.Name = "numAutoReinCells";
            this.numAutoReinCells.Size = new System.Drawing.Size(80, 27);
            this.numAutoReinCells.TabIndex = 314;
            this.numAutoReinCells.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAutoReinCells.ValueChanged += new System.EventHandler(this.numAutoReinCells_ValueChanged);
            // 
            // chkAutoReinEnabled
            // 
            this.chkAutoReinEnabled.AutoSize = true;
            this.chkAutoReinEnabled.Location = new System.Drawing.Point(19, 41);
            this.chkAutoReinEnabled.Margin = new System.Windows.Forms.Padding(10);
            this.chkAutoReinEnabled.Name = "chkAutoReinEnabled";
            this.chkAutoReinEnabled.Size = new System.Drawing.Size(138, 18);
            this.chkAutoReinEnabled.TabIndex = 312;
            this.chkAutoReinEnabled.Text = "RÉDEA AUTOMÁTICA";
            this.chkAutoReinEnabled.UseVisualStyleBackColor = true;
            this.chkAutoReinEnabled.CheckedChanged += new System.EventHandler(this.chkAutoReinEnabled_CheckedChanged);
            // 
            // getOffReinCheckBox
            // 
            this.getOffReinCheckBox.AutoSize = true;
            this.getOffReinCheckBox.Location = new System.Drawing.Point(19, 183);
            this.getOffReinCheckBox.Margin = new System.Windows.Forms.Padding(10);
            this.getOffReinCheckBox.Name = "getOffReinCheckBox";
            this.getOffReinCheckBox.Size = new System.Drawing.Size(222, 18);
            this.getOffReinCheckBox.TabIndex = 2;
            this.getOffReinCheckBox.Text = "DESMONTAR DA RÉDEA AO ATACAR";
            this.getOffReinCheckBox.UseVisualStyleBackColor = true;
            this.getOffReinCheckBox.CheckedChanged += new System.EventHandler(this.getOffReinCheckBox_CheckedChanged);
            // 
            // chkStopBuffsOnRein
            // 
            this.chkStopBuffsOnRein.AutoSize = true;
            this.chkStopBuffsOnRein.Location = new System.Drawing.Point(19, 142);
            this.chkStopBuffsOnRein.Margin = new System.Windows.Forms.Padding(10);
            this.chkStopBuffsOnRein.Name = "chkStopBuffsOnRein";
            this.chkStopBuffsOnRein.Size = new System.Drawing.Size(236, 18);
            this.chkStopBuffsOnRein.TabIndex = 1;
            this.chkStopBuffsOnRein.Text = "PAUSAR AUTOBUFF SKILL NA RÉDEA";
            this.chkStopBuffsOnRein.UseVisualStyleBackColor = true;
            this.chkStopBuffsOnRein.CheckedChanged += new System.EventHandler(this.chkStopBuffsOnRein_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(496, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CUSTOM BUTTONS";
            // 
            // ammo2textBox
            // 
            this.ammo2textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ammo2textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ammo2textBox.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ammo2textBox.ForeColor = System.Drawing.Color.White;
            this.ammo2textBox.Location = new System.Drawing.Point(284, 338);
            this.ammo2textBox.Margin = new System.Windows.Forms.Padding(4);
            this.ammo2textBox.Multiline = true;
            this.ammo2textBox.Name = "ammo2textBox";
            this.ammo2textBox.Size = new System.Drawing.Size(35, 35);
            this.ammo2textBox.TabIndex = 309;
            this.ammo2textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ammo1textBox
            // 
            this.ammo1textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ammo1textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ammo1textBox.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ammo1textBox.ForeColor = System.Drawing.Color.White;
            this.ammo1textBox.Location = new System.Drawing.Point(241, 338);
            this.ammo1textBox.Margin = new System.Windows.Forms.Padding(4);
            this.ammo1textBox.Multiline = true;
            this.ammo1textBox.Name = "ammo1textBox";
            this.ammo1textBox.Size = new System.Drawing.Size(35, 35);
            this.ammo1textBox.TabIndex = 308;
            this.ammo1textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAutoReinKey
            // 
            this.txtAutoReinKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAutoReinKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutoReinKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutoReinKey.ForeColor = System.Drawing.Color.White;
            this.txtAutoReinKey.Location = new System.Drawing.Point(238, 82);
            this.txtAutoReinKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtAutoReinKey.Multiline = true;
            this.txtAutoReinKey.Name = "txtAutoReinKey";
            this.txtAutoReinKey.Size = new System.Drawing.Size(35, 35);
            this.txtAutoReinKey.TabIndex = 316;
            this.txtAutoReinKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAutoReinKey.TextChanged += new System.EventHandler(this.txtAutoReinKey_TextChanged_1);
            // 
            // textReinKey
            // 
            this.textReinKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textReinKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textReinKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textReinKey.ForeColor = System.Drawing.Color.White;
            this.textReinKey.Location = new System.Drawing.Point(251, 174);
            this.textReinKey.Margin = new System.Windows.Forms.Padding(4);
            this.textReinKey.Multiline = true;
            this.textReinKey.Name = "textReinKey";
            this.textReinKey.Size = new System.Drawing.Size(35, 35);
            this.textReinKey.TabIndex = 306;
            this.textReinKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // clientDTOBindingSource
            // 
            this.clientDTOBindingSource.DataSource = typeof(_4RTools.Model.ClientDTO);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(276, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 15);
            this.textBox1.TabIndex = 319;
            this.textBox1.Text = "KEY DA RÉDEA NO RAG";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(289, 184);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(154, 15);
            this.textBox2.TabIndex = 320;
            this.textBox2.Text = "KEY DA RÉDEA NO RAG";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(972, 424);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupConfigRein);
            this.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigForm";
            this.groupConfigRein.ResumeLayout(false);
            this.groupConfigRein.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoReinCells)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.BindingSource clientDTOBindingSource;
        private GroupBox groupConfigRein;
        private CheckBox chkStopBuffsOnRein;
        private CheckBox chkStopBuffsOnCity;
        private CheckBox getOffReinCheckBox;
        private VerticallyCenteredTextBox textReinKey;
        private VerticallyCenteredTextBox ammo2textBox;
        private VerticallyCenteredTextBox ammo1textBox;
        private CheckBox switchAmmoCheckBox;
        private CheckBox chkStopHealOnCity;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private ToolTip toolTip5;
        private CheckBox chkStopWithChat;
        private CheckBox chkAutoReinEnabled;
        private NumericUpDown numAutoReinCells;
        private VerticallyCenteredTextBox txtAutoReinKey;
        private Label lblAutoReinCells;
        private PictureBox pictureBox1;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}