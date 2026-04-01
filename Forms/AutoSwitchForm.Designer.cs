using _4RTools.Utils;
using System.Windows.Forms;
using System;

namespace _4RTools.Forms
{
    partial class AutoSwitchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoSwitchForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ITEMin319 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NEXTITEMin319 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.AutoSwitchGP = new System.Windows.Forms.GroupBox();
            this.btnAddAutoSwitch = new System.Windows.Forms.Button();
            this.skillCB = new System.Windows.Forms.ComboBox();
            this.ProcSwitchGP = new System.Windows.Forms.GroupBox();
            this.ITEMin126 = new System.Windows.Forms.TextBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.NEXTITEMin126 = new System.Windows.Forms.TextBox();
            this.ITEMin461 = new System.Windows.Forms.TextBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.NEXTITEMin461 = new System.Windows.Forms.TextBox();
            this.ITEMin355 = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.NEXTITEMin355 = new System.Windows.Forms.TextBox();
            this.ITEMin25 = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.NEXTITEMin25 = new System.Windows.Forms.TextBox();
            this.ITEMin2015 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.NEXTITEMin2015 = new System.Windows.Forms.TextBox();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.numSwitchDelay = new System.Windows.Forms.NumericUpDown();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.ProcSwitchGP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSwitchDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 2;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(694, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 322;
            this.label4.Text = "TROCA DELAY";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.label4, "Delay entre Item e Próximo Item Recomendado 1000 ms");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(59, 36);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 296;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "319";
            // 
            // ITEMin319
            // 
            this.ITEMin319.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ITEMin319.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin319.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMin319.ForeColor = System.Drawing.Color.White;
            this.ITEMin319.Location = new System.Drawing.Point(110, 36);
            this.ITEMin319.Margin = new System.Windows.Forms.Padding(4);
            this.ITEMin319.Multiline = true;
            this.ITEMin319.Name = "ITEMin319";
            this.ITEMin319.Size = new System.Drawing.Size(35, 35);
            this.ITEMin319.TabIndex = 295;
            this.ITEMin319.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 304;
            this.label2.Text = "ITEM";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 305;
            this.label3.Text = "PRÓXIMO ITEM";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NEXTITEMin319
            // 
            this.NEXTITEMin319.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NEXTITEMin319.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin319.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NEXTITEMin319.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin319.Location = new System.Drawing.Point(261, 36);
            this.NEXTITEMin319.Margin = new System.Windows.Forms.Padding(4);
            this.NEXTITEMin319.Multiline = true;
            this.NEXTITEMin319.Name = "NEXTITEMin319";
            this.NEXTITEMin319.Size = new System.Drawing.Size(35, 35);
            this.NEXTITEMin319.TabIndex = 308;
            this.NEXTITEMin319.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(195, 48);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(19, 11);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 313;
            this.pictureBox4.TabStop = false;
            // 
            // AutoSwitchGP
            // 
            this.AutoSwitchGP.AutoSize = true;
            this.AutoSwitchGP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AutoSwitchGP.ForeColor = System.Drawing.Color.White;
            this.AutoSwitchGP.Location = new System.Drawing.Point(40, 90);
            this.AutoSwitchGP.Margin = new System.Windows.Forms.Padding(4);
            this.AutoSwitchGP.Name = "AutoSwitchGP";
            this.AutoSwitchGP.Padding = new System.Windows.Forms.Padding(4);
            this.AutoSwitchGP.Size = new System.Drawing.Size(403, 49);
            this.AutoSwitchGP.TabIndex = 314;
            this.AutoSwitchGP.TabStop = false;
            this.AutoSwitchGP.Text = "CUSTOMIZADOS";
            this.AutoSwitchGP.Enter += new System.EventHandler(this.AutoSwitchGP_Enter);
            // 
            // btnAddAutoSwitch
            // 
            this.btnAddAutoSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAddAutoSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAutoSwitch.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAutoSwitch.ForeColor = System.Drawing.Color.White;
            this.btnAddAutoSwitch.Location = new System.Drawing.Point(381, 38);
            this.btnAddAutoSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAutoSwitch.Name = "btnAddAutoSwitch";
            this.btnAddAutoSwitch.Size = new System.Drawing.Size(60, 30);
            this.btnAddAutoSwitch.TabIndex = 316;
            this.btnAddAutoSwitch.Text = "ADD";
            this.btnAddAutoSwitch.UseVisualStyleBackColor = false;
            this.btnAddAutoSwitch.Click += new System.EventHandler(this.btnNewSwitch);
            // 
            // skillCB
            // 
            this.skillCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.skillCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skillCB.Font = new System.Drawing.Font("JetBrains Mono", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skillCB.ForeColor = System.Drawing.Color.White;
            this.skillCB.Location = new System.Drawing.Point(40, 40);
            this.skillCB.Margin = new System.Windows.Forms.Padding(4);
            this.skillCB.Name = "skillCB";
            this.skillCB.Size = new System.Drawing.Size(333, 24);
            this.skillCB.TabIndex = 317;
            // 
            // ProcSwitchGP
            // 
            this.ProcSwitchGP.Controls.Add(this.ITEMin126);
            this.ProcSwitchGP.Controls.Add(this.pictureBox11);
            this.ProcSwitchGP.Controls.Add(this.pictureBox12);
            this.ProcSwitchGP.Controls.Add(this.NEXTITEMin126);
            this.ProcSwitchGP.Controls.Add(this.ITEMin461);
            this.ProcSwitchGP.Controls.Add(this.pictureBox9);
            this.ProcSwitchGP.Controls.Add(this.pictureBox10);
            this.ProcSwitchGP.Controls.Add(this.NEXTITEMin461);
            this.ProcSwitchGP.Controls.Add(this.ITEMin355);
            this.ProcSwitchGP.Controls.Add(this.pictureBox7);
            this.ProcSwitchGP.Controls.Add(this.pictureBox8);
            this.ProcSwitchGP.Controls.Add(this.NEXTITEMin355);
            this.ProcSwitchGP.Controls.Add(this.ITEMin25);
            this.ProcSwitchGP.Controls.Add(this.pictureBox5);
            this.ProcSwitchGP.Controls.Add(this.pictureBox6);
            this.ProcSwitchGP.Controls.Add(this.NEXTITEMin25);
            this.ProcSwitchGP.Controls.Add(this.ITEMin2015);
            this.ProcSwitchGP.Controls.Add(this.pictureBox2);
            this.ProcSwitchGP.Controls.Add(this.pictureBox3);
            this.ProcSwitchGP.Controls.Add(this.NEXTITEMin2015);
            this.ProcSwitchGP.Controls.Add(this.ITEMin319);
            this.ProcSwitchGP.Controls.Add(this.pictureBox1);
            this.ProcSwitchGP.Controls.Add(this.label2);
            this.ProcSwitchGP.Controls.Add(this.label3);
            this.ProcSwitchGP.Controls.Add(this.pictureBox4);
            this.ProcSwitchGP.Controls.Add(this.NEXTITEMin319);
            this.ProcSwitchGP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProcSwitchGP.ForeColor = System.Drawing.Color.White;
            this.ProcSwitchGP.Location = new System.Drawing.Point(512, 90);
            this.ProcSwitchGP.Margin = new System.Windows.Forms.Padding(4);
            this.ProcSwitchGP.Name = "ProcSwitchGP";
            this.ProcSwitchGP.Padding = new System.Windows.Forms.Padding(4);
            this.ProcSwitchGP.Size = new System.Drawing.Size(360, 301);
            this.ProcSwitchGP.TabIndex = 318;
            this.ProcSwitchGP.TabStop = false;
            this.ProcSwitchGP.Text = "EXCLUSIVOS";
            // 
            // ITEMin126
            // 
            this.ITEMin126.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ITEMin126.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin126.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMin126.ForeColor = System.Drawing.Color.White;
            this.ITEMin126.Location = new System.Drawing.Point(110, 253);
            this.ITEMin126.Margin = new System.Windows.Forms.Padding(4);
            this.ITEMin126.Multiline = true;
            this.ITEMin126.Name = "ITEMin126";
            this.ITEMin126.Size = new System.Drawing.Size(35, 35);
            this.ITEMin126.TabIndex = 330;
            this.ITEMin126.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(59, 253);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(35, 35);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 331;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(195, 266);
            this.pictureBox12.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(19, 11);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox12.TabIndex = 333;
            this.pictureBox12.TabStop = false;
            // 
            // NEXTITEMin126
            // 
            this.NEXTITEMin126.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NEXTITEMin126.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin126.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NEXTITEMin126.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin126.Location = new System.Drawing.Point(261, 253);
            this.NEXTITEMin126.Margin = new System.Windows.Forms.Padding(4);
            this.NEXTITEMin126.Multiline = true;
            this.NEXTITEMin126.Name = "NEXTITEMin126";
            this.NEXTITEMin126.Size = new System.Drawing.Size(35, 35);
            this.NEXTITEMin126.TabIndex = 332;
            this.NEXTITEMin126.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ITEMin461
            // 
            this.ITEMin461.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ITEMin461.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin461.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMin461.ForeColor = System.Drawing.Color.White;
            this.ITEMin461.Location = new System.Drawing.Point(110, 210);
            this.ITEMin461.Margin = new System.Windows.Forms.Padding(4);
            this.ITEMin461.Multiline = true;
            this.ITEMin461.Name = "ITEMin461";
            this.ITEMin461.Size = new System.Drawing.Size(35, 35);
            this.ITEMin461.TabIndex = 326;
            this.ITEMin461.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(59, 210);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(35, 35);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 327;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(195, 222);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(19, 11);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox10.TabIndex = 329;
            this.pictureBox10.TabStop = false;
            // 
            // NEXTITEMin461
            // 
            this.NEXTITEMin461.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NEXTITEMin461.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin461.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NEXTITEMin461.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin461.Location = new System.Drawing.Point(261, 210);
            this.NEXTITEMin461.Margin = new System.Windows.Forms.Padding(4);
            this.NEXTITEMin461.Multiline = true;
            this.NEXTITEMin461.Name = "NEXTITEMin461";
            this.NEXTITEMin461.Size = new System.Drawing.Size(35, 35);
            this.NEXTITEMin461.TabIndex = 328;
            this.NEXTITEMin461.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ITEMin355
            // 
            this.ITEMin355.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ITEMin355.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin355.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMin355.ForeColor = System.Drawing.Color.White;
            this.ITEMin355.Location = new System.Drawing.Point(110, 167);
            this.ITEMin355.Margin = new System.Windows.Forms.Padding(4);
            this.ITEMin355.Multiline = true;
            this.ITEMin355.Name = "ITEMin355";
            this.ITEMin355.Size = new System.Drawing.Size(35, 35);
            this.ITEMin355.TabIndex = 322;
            this.ITEMin355.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(59, 167);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(35, 35);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 323;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(195, 179);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(19, 11);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox8.TabIndex = 325;
            this.pictureBox8.TabStop = false;
            // 
            // NEXTITEMin355
            // 
            this.NEXTITEMin355.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NEXTITEMin355.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin355.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NEXTITEMin355.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin355.Location = new System.Drawing.Point(261, 167);
            this.NEXTITEMin355.Margin = new System.Windows.Forms.Padding(4);
            this.NEXTITEMin355.Multiline = true;
            this.NEXTITEMin355.Name = "NEXTITEMin355";
            this.NEXTITEMin355.Size = new System.Drawing.Size(35, 35);
            this.NEXTITEMin355.TabIndex = 324;
            this.NEXTITEMin355.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ITEMin25
            // 
            this.ITEMin25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ITEMin25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin25.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMin25.ForeColor = System.Drawing.Color.White;
            this.ITEMin25.Location = new System.Drawing.Point(110, 124);
            this.ITEMin25.Margin = new System.Windows.Forms.Padding(4);
            this.ITEMin25.Multiline = true;
            this.ITEMin25.Name = "ITEMin25";
            this.ITEMin25.Size = new System.Drawing.Size(35, 35);
            this.ITEMin25.TabIndex = 318;
            this.ITEMin25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(59, 124);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(35, 35);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 319;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(195, 138);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(19, 11);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 321;
            this.pictureBox6.TabStop = false;
            // 
            // NEXTITEMin25
            // 
            this.NEXTITEMin25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NEXTITEMin25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin25.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NEXTITEMin25.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin25.Location = new System.Drawing.Point(261, 124);
            this.NEXTITEMin25.Margin = new System.Windows.Forms.Padding(4);
            this.NEXTITEMin25.Multiline = true;
            this.NEXTITEMin25.Name = "NEXTITEMin25";
            this.NEXTITEMin25.Size = new System.Drawing.Size(35, 35);
            this.NEXTITEMin25.TabIndex = 320;
            this.NEXTITEMin25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ITEMin2015
            // 
            this.ITEMin2015.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ITEMin2015.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin2015.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ITEMin2015.ForeColor = System.Drawing.Color.White;
            this.ITEMin2015.Location = new System.Drawing.Point(110, 81);
            this.ITEMin2015.Margin = new System.Windows.Forms.Padding(4);
            this.ITEMin2015.Multiline = true;
            this.ITEMin2015.Name = "ITEMin2015";
            this.ITEMin2015.Size = new System.Drawing.Size(35, 35);
            this.ITEMin2015.TabIndex = 314;
            this.ITEMin2015.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(59, 81);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 315;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(195, 96);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(19, 11);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 317;
            this.pictureBox3.TabStop = false;
            // 
            // NEXTITEMin2015
            // 
            this.NEXTITEMin2015.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NEXTITEMin2015.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin2015.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NEXTITEMin2015.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin2015.Location = new System.Drawing.Point(261, 81);
            this.NEXTITEMin2015.Margin = new System.Windows.Forms.Padding(4);
            this.NEXTITEMin2015.Multiline = true;
            this.NEXTITEMin2015.Name = "NEXTITEMin2015";
            this.NEXTITEMin2015.Size = new System.Drawing.Size(35, 35);
            this.NEXTITEMin2015.TabIndex = 316;
            this.NEXTITEMin2015.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numDelay
            // 
            this.numDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.numDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDelay.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDelay.ForeColor = System.Drawing.Color.White;
            this.numDelay.Location = new System.Drawing.Point(554, 38);
            this.numDelay.Margin = new System.Windows.Forms.Padding(4);
            this.numDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(80, 27);
            this.numDelay.TabIndex = 319;
            this.numDelay.Tag = "delay";
            this.numDelay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numDelay.ValueChanged += new System.EventHandler(this.txtDelay_TextChanged);
            // 
            // numSwitchDelay
            // 
            this.numSwitchDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.numSwitchDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSwitchDelay.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSwitchDelay.ForeColor = System.Drawing.Color.White;
            this.numSwitchDelay.Location = new System.Drawing.Point(792, 38);
            this.numSwitchDelay.Margin = new System.Windows.Forms.Padding(4);
            this.numSwitchDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numSwitchDelay.Name = "numSwitchDelay";
            this.numSwitchDelay.Size = new System.Drawing.Size(80, 27);
            this.numSwitchDelay.TabIndex = 320;
            this.numSwitchDelay.Tag = "switchDelay";
            this.numSwitchDelay.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numSwitchDelay.ValueChanged += new System.EventHandler(this.txtSwitchDelay_TextChanged);
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
            this.pictureBox13.Location = new System.Drawing.Point(512, 35);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(35, 35);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 323;
            this.pictureBox13.TabStop = false;
            // 
            // AutoSwitchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(972, 424);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numSwitchDelay);
            this.Controls.Add(this.numDelay);
            this.Controls.Add(this.ProcSwitchGP);
            this.Controls.Add(this.skillCB);
            this.Controls.Add(this.btnAddAutoSwitch);
            this.Controls.Add(this.AutoSwitchGP);
            this.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AutoSwitchForm";
            this.Text = "AutoSwitchForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ProcSwitchGP.ResumeLayout(false);
            this.ProcSwitchGP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSwitchDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox ITEMin319;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NEXTITEMin319;
        private System.Windows.Forms.PictureBox pictureBox4;
        private GroupBox AutoSwitchGP;
        private Button btnAddAutoSwitch;
        private ComboBox skillCB;
        private GroupBox ProcSwitchGP;
        private NumericUpDown numDelay;
        private NumericUpDown numSwitchDelay;
        private Label label4;
        private TextBox ITEMin25;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private TextBox NEXTITEMin25;
        private TextBox ITEMin2015;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TextBox NEXTITEMin2015;
        private TextBox ITEMin461;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private TextBox NEXTITEMin461;
        private TextBox ITEMin355;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private TextBox NEXTITEMin355;
        private TextBox ITEMin126;
        private PictureBox pictureBox11;
        private PictureBox pictureBox12;
        private TextBox NEXTITEMin126;
        private PictureBox pictureBox13;
    }
}