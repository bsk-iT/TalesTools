using _4RTools.Utils;
using System.Windows.Forms;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _4RTools.Forms
{
    partial class AutoSwitchHealForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoSwitchHealForm));
            this.txtlessHpPercent = new System.Windows.Forms.NumericUpDown();
            this.labelHP = new System.Windows.Forms.Label();
            this.txtlessHpKey = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.txtlessSpKey = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtlessSpPercent = new System.Windows.Forms.NumericUpDown();
            this.txtmoreSpKey = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.txtmoreHpKey = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.txtmoreSpPercent = new System.Windows.Forms.NumericUpDown();
            this.txtmoreHpPercent = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtitemKey = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.txtskillKey = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.txtspPercent = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtnextItemKey = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.txtqtdSkill = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtequipDelay = new System.Windows.Forms.NumericUpDown();
            this.txtswitchDelay = new System.Windows.Forms.NumericUpDown();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.picBoxSP = new System.Windows.Forms.PictureBox();
            this.picBoxHP = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.labelSP = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtlessHpPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlessSpPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmoreSpPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmoreHpPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtspPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtqtdSkill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtequipDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtswitchDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // txtlessHpPercent
            // 
            this.txtlessHpPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtlessHpPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlessHpPercent.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlessHpPercent.ForeColor = System.Drawing.Color.White;
            this.txtlessHpPercent.Location = new System.Drawing.Point(259, 34);
            this.txtlessHpPercent.Margin = new System.Windows.Forms.Padding(4);
            this.txtlessHpPercent.Name = "txtlessHpPercent";
            this.txtlessHpPercent.Size = new System.Drawing.Size(80, 27);
            this.txtlessHpPercent.TabIndex = 39;
            // 
            // labelHP
            // 
            this.labelHP.AutoSize = true;
            this.labelHP.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHP.ForeColor = System.Drawing.Color.White;
            this.labelHP.Location = new System.Drawing.Point(347, 38);
            this.labelHP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(18, 19);
            this.labelHP.TabIndex = 37;
            this.labelHP.Text = "%";
            // 
            // txtlessHpKey
            // 
            this.txtlessHpKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtlessHpKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlessHpKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlessHpKey.ForeColor = System.Drawing.Color.White;
            this.txtlessHpKey.Location = new System.Drawing.Point(380, 29);
            this.txtlessHpKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtlessHpKey.Multiline = true;
            this.txtlessHpKey.Name = "txtlessHpKey";
            this.txtlessHpKey.Size = new System.Drawing.Size(35, 35);
            this.txtlessHpKey.TabIndex = 43;
            this.txtlessHpKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtlessSpKey
            // 
            this.txtlessSpKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtlessSpKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlessSpKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlessSpKey.ForeColor = System.Drawing.Color.White;
            this.txtlessSpKey.Location = new System.Drawing.Point(380, 91);
            this.txtlessSpKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtlessSpKey.Multiline = true;
            this.txtlessSpKey.Name = "txtlessSpKey";
            this.txtlessSpKey.Size = new System.Drawing.Size(35, 35);
            this.txtlessSpKey.TabIndex = 44;
            this.txtlessSpKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(227, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 45;
            this.label3.Text = "HP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(227, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "SP";
            // 
            // txtlessSpPercent
            // 
            this.txtlessSpPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtlessSpPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlessSpPercent.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlessSpPercent.ForeColor = System.Drawing.Color.White;
            this.txtlessSpPercent.Location = new System.Drawing.Point(259, 96);
            this.txtlessSpPercent.Margin = new System.Windows.Forms.Padding(4);
            this.txtlessSpPercent.Name = "txtlessSpPercent";
            this.txtlessSpPercent.Size = new System.Drawing.Size(80, 27);
            this.txtlessSpPercent.TabIndex = 40;
            // 
            // txtmoreSpKey
            // 
            this.txtmoreSpKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtmoreSpKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmoreSpKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmoreSpKey.ForeColor = System.Drawing.Color.White;
            this.txtmoreSpKey.Location = new System.Drawing.Point(555, 91);
            this.txtmoreSpKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtmoreSpKey.Multiline = true;
            this.txtmoreSpKey.Name = "txtmoreSpKey";
            this.txtmoreSpKey.Size = new System.Drawing.Size(35, 35);
            this.txtmoreSpKey.TabIndex = 56;
            this.txtmoreSpKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtmoreHpKey
            // 
            this.txtmoreHpKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtmoreHpKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmoreHpKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmoreHpKey.ForeColor = System.Drawing.Color.White;
            this.txtmoreHpKey.Location = new System.Drawing.Point(555, 29);
            this.txtmoreHpKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtmoreHpKey.Multiline = true;
            this.txtmoreHpKey.Name = "txtmoreHpKey";
            this.txtmoreHpKey.Size = new System.Drawing.Size(35, 35);
            this.txtmoreHpKey.TabIndex = 55;
            this.txtmoreHpKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtmoreSpPercent
            // 
            this.txtmoreSpPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtmoreSpPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmoreSpPercent.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmoreSpPercent.ForeColor = System.Drawing.Color.White;
            this.txtmoreSpPercent.Location = new System.Drawing.Point(437, 96);
            this.txtmoreSpPercent.Margin = new System.Windows.Forms.Padding(4);
            this.txtmoreSpPercent.Name = "txtmoreSpPercent";
            this.txtmoreSpPercent.Size = new System.Drawing.Size(80, 27);
            this.txtmoreSpPercent.TabIndex = 54;
            // 
            // txtmoreHpPercent
            // 
            this.txtmoreHpPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtmoreHpPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmoreHpPercent.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmoreHpPercent.ForeColor = System.Drawing.Color.White;
            this.txtmoreHpPercent.Location = new System.Drawing.Point(437, 34);
            this.txtmoreHpPercent.Margin = new System.Windows.Forms.Padding(4);
            this.txtmoreHpPercent.Name = "txtmoreHpPercent";
            this.txtmoreHpPercent.Size = new System.Drawing.Size(80, 27);
            this.txtmoreHpPercent.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(525, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 19);
            this.label5.TabIndex = 52;
            this.label5.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(525, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 19);
            this.label6.TabIndex = 51;
            this.label6.Text = "%";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(259, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 57;
            this.label7.Text = "ABAIXO DE";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(443, 13);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 58;
            this.label8.Text = "ACIMA DE";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(369, 8);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 59;
            this.label9.Text = "EQUIPA";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(546, 8);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 60;
            this.label10.Text = "EQUIPA";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtitemKey
            // 
            this.txtitemKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtitemKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtitemKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtitemKey.ForeColor = System.Drawing.Color.White;
            this.txtitemKey.Location = new System.Drawing.Point(275, 238);
            this.txtitemKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtitemKey.Multiline = true;
            this.txtitemKey.Name = "txtitemKey";
            this.txtitemKey.Size = new System.Drawing.Size(35, 35);
            this.txtitemKey.TabIndex = 314;
            this.txtitemKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtskillKey
            // 
            this.txtskillKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtskillKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtskillKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtskillKey.ForeColor = System.Drawing.Color.White;
            this.txtskillKey.Location = new System.Drawing.Point(380, 238);
            this.txtskillKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtskillKey.Multiline = true;
            this.txtskillKey.Name = "txtskillKey";
            this.txtskillKey.Size = new System.Drawing.Size(35, 35);
            this.txtskillKey.TabIndex = 316;
            this.txtskillKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtspPercent
            // 
            this.txtspPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtspPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtspPercent.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtspPercent.ForeColor = System.Drawing.Color.White;
            this.txtspPercent.Location = new System.Drawing.Point(259, 303);
            this.txtspPercent.Margin = new System.Windows.Forms.Padding(4);
            this.txtspPercent.Name = "txtspPercent";
            this.txtspPercent.Size = new System.Drawing.Size(80, 27);
            this.txtspPercent.TabIndex = 318;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(251, 217);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 17);
            this.label11.TabIndex = 319;
            this.label11.Text = "MASTERBALL";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(374, 217);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 17);
            this.label12.TabIndex = 320;
            this.label12.Text = "SKILL";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(462, 217);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 17);
            this.label13.TabIndex = 323;
            this.label13.Text = "PRÓXIMO PET";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtnextItemKey
            // 
            this.txtnextItemKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtnextItemKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnextItemKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnextItemKey.ForeColor = System.Drawing.Color.White;
            this.txtnextItemKey.Location = new System.Drawing.Point(491, 238);
            this.txtnextItemKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtnextItemKey.Multiline = true;
            this.txtnextItemKey.Name = "txtnextItemKey";
            this.txtnextItemKey.Size = new System.Drawing.Size(35, 35);
            this.txtnextItemKey.TabIndex = 321;
            this.txtnextItemKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtqtdSkill
            // 
            this.txtqtdSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtqtdSkill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtqtdSkill.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtqtdSkill.ForeColor = System.Drawing.Color.White;
            this.txtqtdSkill.Location = new System.Drawing.Point(377, 303);
            this.txtqtdSkill.Margin = new System.Windows.Forms.Padding(4);
            this.txtqtdSkill.Name = "txtqtdSkill";
            this.txtqtdSkill.Size = new System.Drawing.Size(80, 27);
            this.txtqtdSkill.TabIndex = 324;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(347, 307);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 19);
            this.label14.TabIndex = 325;
            this.label14.Text = "%";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(466, 307);
            this.label15.Margin = new System.Windows.Forms.Padding(1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 19);
            this.label15.TabIndex = 326;
            this.label15.Text = "X";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(227, 307);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 17);
            this.label18.TabIndex = 332;
            this.label18.Text = "SP";
            // 
            // txtequipDelay
            // 
            this.txtequipDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtequipDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtequipDelay.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtequipDelay.ForeColor = System.Drawing.Color.White;
            this.txtequipDelay.Location = new System.Drawing.Point(661, 33);
            this.txtequipDelay.Margin = new System.Windows.Forms.Padding(4);
            this.txtequipDelay.Name = "txtequipDelay";
            this.txtequipDelay.Size = new System.Drawing.Size(80, 27);
            this.txtequipDelay.TabIndex = 333;
            this.txtequipDelay.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // txtswitchDelay
            // 
            this.txtswitchDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtswitchDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtswitchDelay.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtswitchDelay.ForeColor = System.Drawing.Color.White;
            this.txtswitchDelay.Location = new System.Drawing.Point(661, 301);
            this.txtswitchDelay.Margin = new System.Windows.Forms.Padding(4);
            this.txtswitchDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtswitchDelay.Name = "txtswitchDelay";
            this.txtswitchDelay.Size = new System.Drawing.Size(80, 27);
            this.txtswitchDelay.TabIndex = 334;
            this.txtswitchDelay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::_4RTools.Resources._4RTools.ETCResource.SP;
            this.pictureBox3.Location = new System.Drawing.Point(186, 297);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 331;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(446, 248);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 11);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 322;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(186, 238);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 315;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "319";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(337, 248);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(19, 11);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 317;
            this.pictureBox4.TabStop = false;
            // 
            // picBoxSP
            // 
            this.picBoxSP.BackColor = System.Drawing.Color.Transparent;
            this.picBoxSP.Image = global::_4RTools.Resources._4RTools.ETCResource.SP;
            this.picBoxSP.Location = new System.Drawing.Point(186, 91);
            this.picBoxSP.Margin = new System.Windows.Forms.Padding(4);
            this.picBoxSP.Name = "picBoxSP";
            this.picBoxSP.Size = new System.Drawing.Size(35, 35);
            this.picBoxSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxSP.TabIndex = 35;
            this.picBoxSP.TabStop = false;
            // 
            // picBoxHP
            // 
            this.picBoxHP.BackColor = System.Drawing.Color.Transparent;
            this.picBoxHP.Image = global::_4RTools.Resources._4RTools.ETCResource.HP;
            this.picBoxHP.Location = new System.Drawing.Point(186, 29);
            this.picBoxHP.Margin = new System.Windows.Forms.Padding(4);
            this.picBoxHP.Name = "picBoxHP";
            this.picBoxHP.Size = new System.Drawing.Size(35, 35);
            this.picBoxHP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHP.TabIndex = 34;
            this.picBoxHP.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(619, 29);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(35, 35);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 335;
            this.pictureBox5.TabStop = false;
            // 
            // labelSP
            // 
            this.labelSP.AutoSize = true;
            this.labelSP.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSP.ForeColor = System.Drawing.Color.White;
            this.labelSP.Location = new System.Drawing.Point(347, 100);
            this.labelSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSP.Name = "labelSP";
            this.labelSP.Size = new System.Drawing.Size(18, 19);
            this.labelSP.TabIndex = 38;
            this.labelSP.Text = "%";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(619, 297);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(35, 35);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 336;
            this.pictureBox6.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 4);
            this.panel1.TabIndex = 337;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(232, 248);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(19, 11);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 338;
            this.pictureBox7.TabStop = false;
            // 
            // AutoSwitchHealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(972, 424);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.txtswitchDelay);
            this.Controls.Add(this.txtequipDelay);
            this.Controls.Add(this.txtspPercent);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtqtdSkill);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtnextItemKey);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtitemKey);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txtskillKey);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtmoreSpKey);
            this.Controls.Add(this.txtmoreHpKey);
            this.Controls.Add(this.txtmoreSpPercent);
            this.Controls.Add(this.txtmoreHpPercent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtlessSpKey);
            this.Controls.Add(this.txtlessHpKey);
            this.Controls.Add(this.txtlessSpPercent);
            this.Controls.Add(this.txtlessHpPercent);
            this.Controls.Add(this.labelSP);
            this.Controls.Add(this.labelHP);
            this.Controls.Add(this.picBoxSP);
            this.Controls.Add(this.picBoxHP);
            this.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AutoSwitchHealForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AutopotForm";
            ((System.ComponentModel.ISupportInitialize)(this.txtlessHpPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlessSpPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmoreSpPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmoreHpPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtspPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtqtdSkill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtequipDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtswitchDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown txtlessHpPercent;
        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.PictureBox picBoxSP;
        private System.Windows.Forms.PictureBox picBoxHP;
        private VerticallyCenteredTextBox txtlessHpKey;
        private VerticallyCenteredTextBox txtlessSpKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtlessSpPercent;
        private VerticallyCenteredTextBox txtmoreSpKey;
        private VerticallyCenteredTextBox txtmoreHpKey;
        private System.Windows.Forms.NumericUpDown txtmoreSpPercent;
        private System.Windows.Forms.NumericUpDown txtmoreHpPercent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private VerticallyCenteredTextBox txtitemKey;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private VerticallyCenteredTextBox txtskillKey;
        private System.Windows.Forms.NumericUpDown txtspPercent;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private VerticallyCenteredTextBox txtnextItemKey;
        private System.Windows.Forms.NumericUpDown txtqtdSkill;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private NumericUpDown txtequipDelay;
        private NumericUpDown txtswitchDelay;
        private PictureBox pictureBox5;
        private Label labelSP;
        private PictureBox pictureBox6;
        private Panel panel1;
        private PictureBox pictureBox7;
    }
}