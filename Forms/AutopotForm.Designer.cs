namespace _4RTools.Forms
{
    partial class AutopotForm
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
            this.txtHPpct = new System.Windows.Forms.NumericUpDown();
            this.labelSP = new System.Windows.Forms.Label();
            this.labelHP = new System.Windows.Forms.Label();
            this.txtAutopotDelay = new System.Windows.Forms.TextBox();
            this.picBoxSP = new System.Windows.Forms.PictureBox();
            this.picBoxHP = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHpKey = new System.Windows.Forms.TextBox();
            this.txtSPKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSPpct = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.firstHP = new System.Windows.Forms.RadioButton();
            this.firstSP = new System.Windows.Forms.RadioButton();
            this.chkStopWitchFC = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtHPpct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPpct)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHPpct
            // 
            this.txtHPpct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtHPpct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHPpct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtHPpct.ForeColor = System.Drawing.Color.White;
            this.txtHPpct.Location = new System.Drawing.Point(265, 41);
            this.txtHPpct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHPpct.Name = "txtHPpct";
            this.txtHPpct.Size = new System.Drawing.Size(59, 26);
            this.txtHPpct.TabIndex = 39;
            this.txtHPpct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHPpct.ValueChanged += new System.EventHandler(this.txtHPpctTextChanged);
            // 
            // labelSP
            // 
            this.labelSP.AutoSize = true;
            this.labelSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSP.Location = new System.Drawing.Point(326, 85);
            this.labelSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSP.Name = "labelSP";
            this.labelSP.Size = new System.Drawing.Size(24, 20);
            this.labelSP.TabIndex = 38;
            this.labelSP.Text = "%";
            // 
            // labelHP
            // 
            this.labelHP.AutoSize = true;
            this.labelHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelHP.Location = new System.Drawing.Point(326, 43);
            this.labelHP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(24, 20);
            this.labelHP.TabIndex = 37;
            this.labelHP.Text = "%";
            // 
            // txtAutopotDelay
            // 
            this.txtAutopotDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtAutopotDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutopotDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAutopotDelay.ForeColor = System.Drawing.Color.White;
            this.txtAutopotDelay.Location = new System.Drawing.Point(358, 37);
            this.txtAutopotDelay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAutopotDelay.Multiline = true;
            this.txtAutopotDelay.Name = "txtAutopotDelay";
            this.txtAutopotDelay.Size = new System.Drawing.Size(60, 30);
            this.txtAutopotDelay.TabIndex = 36;
            this.txtAutopotDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAutopotDelay.TextChanged += new System.EventHandler(this.txtAutopotDelayTextChanged);
            // 
            // picBoxSP
            // 
            this.picBoxSP.BackColor = System.Drawing.Color.Transparent;
            this.picBoxSP.Image = global::_4RTools.Resources._4RTools.ETCResource.SP;
            this.picBoxSP.Location = new System.Drawing.Point(69, 81);
            this.picBoxSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picBoxSP.Name = "picBoxSP";
            this.picBoxSP.Size = new System.Drawing.Size(30, 30);
            this.picBoxSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxSP.TabIndex = 35;
            this.picBoxSP.TabStop = false;
            // 
            // picBoxHP
            // 
            this.picBoxHP.BackColor = System.Drawing.Color.Transparent;
            this.picBoxHP.Image = global::_4RTools.Resources._4RTools.ETCResource.HP;
            this.picBoxHP.Location = new System.Drawing.Point(69, 38);
            this.picBoxHP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picBoxHP.Name = "picBoxHP";
            this.picBoxHP.Size = new System.Drawing.Size(30, 30);
            this.picBoxHP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxHP.TabIndex = 34;
            this.picBoxHP.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(349, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "Delay ms";
            // 
            // txtHpKey
            // 
            this.txtHpKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtHpKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHpKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtHpKey.ForeColor = System.Drawing.Color.White;
            this.txtHpKey.Location = new System.Drawing.Point(148, 38);
            this.txtHpKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHpKey.Multiline = true;
            this.txtHpKey.Name = "txtHpKey";
            this.txtHpKey.Size = new System.Drawing.Size(80, 30);
            this.txtHpKey.TabIndex = 43;
            // 
            // txtSPKey
            // 
            this.txtSPKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtSPKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSPKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSPKey.ForeColor = System.Drawing.Color.White;
            this.txtSPKey.Location = new System.Drawing.Point(147, 81);
            this.txtSPKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSPKey.Multiline = true;
            this.txtSPKey.Name = "txtSPKey";
            this.txtSPKey.Size = new System.Drawing.Size(80, 30);
            this.txtSPKey.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "HP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 89);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "SP";
            // 
            // txtSPpct
            // 
            this.txtSPpct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtSPpct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSPpct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSPpct.ForeColor = System.Drawing.Color.White;
            this.txtSPpct.Location = new System.Drawing.Point(265, 85);
            this.txtSPpct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSPpct.Name = "txtSPpct";
            this.txtSPpct.Size = new System.Drawing.Size(59, 26);
            this.txtSPpct.TabIndex = 40;
            this.txtSPpct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSPpct.ValueChanged += new System.EventHandler(this.txtSPpctTextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(13, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 47;
            this.label5.Text = "First";
            // 
            // firstHP
            // 
            this.firstHP.AutoSize = true;
            this.firstHP.Checked = true;
            this.firstHP.Location = new System.Drawing.Point(26, 48);
            this.firstHP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.firstHP.Name = "firstHP";
            this.firstHP.Size = new System.Drawing.Size(17, 16);
            this.firstHP.TabIndex = 48;
            this.firstHP.TabStop = true;
            this.firstHP.UseVisualStyleBackColor = true;
            this.firstHP.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // firstSP
            // 
            this.firstSP.AutoSize = true;
            this.firstSP.Location = new System.Drawing.Point(26, 90);
            this.firstSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.firstSP.Name = "firstSP";
            this.firstSP.Size = new System.Drawing.Size(17, 16);
            this.firstSP.TabIndex = 49;
            this.firstSP.UseVisualStyleBackColor = true;
            this.firstSP.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // chkStopWitchFC
            // 
            this.chkStopWitchFC.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStopWitchFC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.chkStopWitchFC.Location = new System.Drawing.Point(26, 119);
            this.chkStopWitchFC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkStopWitchFC.Name = "chkStopWitchFC";
            this.chkStopWitchFC.Size = new System.Drawing.Size(324, 50);
            this.chkStopWitchFC.TabIndex = 50;
            this.chkStopWitchFC.Text = "Parar com Ferimento Crítico";
            this.chkStopWitchFC.UseVisualStyleBackColor = true;
            this.chkStopWitchFC.CheckedChanged += new System.EventHandler(this.chkStopWitchFC_CheckedChanged);
            // 
            // AutopotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(442, 182);
            this.Controls.Add(this.chkStopWitchFC);
            this.Controls.Add(this.firstSP);
            this.Controls.Add(this.firstHP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSPKey);
            this.Controls.Add(this.txtHpKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSPpct);
            this.Controls.Add(this.txtHPpct);
            this.Controls.Add(this.labelSP);
            this.Controls.Add(this.labelHP);
            this.Controls.Add(this.txtAutopotDelay);
            this.Controls.Add(this.picBoxSP);
            this.Controls.Add(this.picBoxHP);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AutopotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AutopotForm";
            ((System.ComponentModel.ISupportInitialize)(this.txtHPpct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPpct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown txtHPpct;
        private System.Windows.Forms.Label labelSP;
        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.TextBox txtAutopotDelay;
        private System.Windows.Forms.PictureBox picBoxSP;
        private System.Windows.Forms.PictureBox picBoxHP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHpKey;
        private System.Windows.Forms.TextBox txtSPKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtSPpct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton firstHP;
        private System.Windows.Forms.RadioButton firstSP;
        private System.Windows.Forms.CheckBox chkStopWitchFC;
    }
}