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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutopotForm));
            this.txtHPpct = new System.Windows.Forms.NumericUpDown();
            this.labelSP = new System.Windows.Forms.Label();
            this.labelHP = new System.Windows.Forms.Label();
            this.txtAutopotDelay = new VerticallyCenteredTextBox();
            this.txtHpKey = new VerticallyCenteredTextBox();
            this.txtSPKey = new VerticallyCenteredTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSPpct = new System.Windows.Forms.NumericUpDown();
            this.firstHP = new System.Windows.Forms.RadioButton();
            this.firstSP = new System.Windows.Forms.RadioButton();
            this.chkStopWitchFC = new System.Windows.Forms.CheckBox();
            this.txtHpEquipBefore = new VerticallyCenteredTextBox();
            this.txtHpEquipAfter = new VerticallyCenteredTextBox();
            this.lblequipBefore = new System.Windows.Forms.Label();
            this.lblequipAfter = new System.Windows.Forms.Label();
            this.picBoxSP = new System.Windows.Forms.PictureBox();
            this.picBoxHP = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new VerticallyCenteredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtHPpct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPpct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHPpct
            // 
            this.txtHPpct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtHPpct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHPpct.Font = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHPpct.ForeColor = System.Drawing.Color.White;
            this.txtHPpct.Location = new System.Drawing.Point(203, 48);
            this.txtHPpct.Margin = new System.Windows.Forms.Padding(4);
            this.txtHPpct.Name = "txtHPpct";
            this.txtHPpct.Size = new System.Drawing.Size(80, 25);
            this.txtHPpct.TabIndex = 39;
            this.txtHPpct.ValueChanged += new System.EventHandler(this.txtHPpctTextChanged);
            // 
            // labelSP
            // 
            this.labelSP.AutoSize = true;
            this.labelSP.Font = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSP.Location = new System.Drawing.Point(291, 116);
            this.labelSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSP.Name = "labelSP";
            this.labelSP.Size = new System.Drawing.Size(16, 18);
            this.labelSP.TabIndex = 38;
            this.labelSP.Text = "%";
            // 
            // labelHP
            // 
            this.labelHP.AutoSize = true;
            this.labelHP.Font = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHP.Location = new System.Drawing.Point(291, 50);
            this.labelHP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(16, 18);
            this.labelHP.TabIndex = 37;
            this.labelHP.Text = "%";
            // 
            // txtAutopotDelay
            // 
            this.txtAutopotDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAutopotDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutopotDelay.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutopotDelay.ForeColor = System.Drawing.Color.White;
            this.txtAutopotDelay.Location = new System.Drawing.Point(370, 42);
            this.txtAutopotDelay.Margin = new System.Windows.Forms.Padding(4);
            this.txtAutopotDelay.Multiline = true;
            this.txtAutopotDelay.Name = "txtAutopotDelay";
            this.txtAutopotDelay.Size = new System.Drawing.Size(35, 35);
            this.txtAutopotDelay.TabIndex = 36;
            this.txtAutopotDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAutopotDelay.TextChanged += new System.EventHandler(this.txtAutopotDelayTextChanged);
            // 
            // txtHpKey
            // 
            this.txtHpKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtHpKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHpKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHpKey.ForeColor = System.Drawing.Color.White;
            this.txtHpKey.Location = new System.Drawing.Point(120, 42);
            this.txtHpKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtHpKey.Multiline = true;
            this.txtHpKey.Name = "txtHpKey";
            this.txtHpKey.Size = new System.Drawing.Size(35, 35);
            this.txtHpKey.TabIndex = 43;
            this.txtHpKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSPKey
            // 
            this.txtSPKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtSPKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSPKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSPKey.ForeColor = System.Drawing.Color.White;
            this.txtSPKey.Location = new System.Drawing.Point(120, 106);
            this.txtSPKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtSPKey.Multiline = true;
            this.txtSPKey.Name = "txtSPKey";
            this.txtSPKey.Size = new System.Drawing.Size(35, 35);
            this.txtSPKey.TabIndex = 44;
            this.txtSPKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(163, 50);
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
            this.label4.Location = new System.Drawing.Point(163, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "SP";
            // 
            // txtSPpct
            // 
            this.txtSPpct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtSPpct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSPpct.Font = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSPpct.ForeColor = System.Drawing.Color.White;
            this.txtSPpct.Location = new System.Drawing.Point(203, 112);
            this.txtSPpct.Margin = new System.Windows.Forms.Padding(4);
            this.txtSPpct.Name = "txtSPpct";
            this.txtSPpct.Size = new System.Drawing.Size(80, 25);
            this.txtSPpct.TabIndex = 40;
            this.txtSPpct.ValueChanged += new System.EventHandler(this.txtSPpctTextChanged);
            // 
            // firstHP
            // 
            this.firstHP.AutoSize = true;
            this.firstHP.Checked = true;
            this.firstHP.Location = new System.Drawing.Point(54, 54);
            this.firstHP.Margin = new System.Windows.Forms.Padding(4);
            this.firstHP.Name = "firstHP";
            this.firstHP.Size = new System.Drawing.Size(14, 13);
            this.firstHP.TabIndex = 48;
            this.firstHP.TabStop = true;
            this.firstHP.UseVisualStyleBackColor = true;
            this.firstHP.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // firstSP
            // 
            this.firstSP.AutoSize = true;
            this.firstSP.Location = new System.Drawing.Point(54, 118);
            this.firstSP.Margin = new System.Windows.Forms.Padding(4);
            this.firstSP.Name = "firstSP";
            this.firstSP.Size = new System.Drawing.Size(14, 13);
            this.firstSP.TabIndex = 49;
            this.firstSP.UseVisualStyleBackColor = true;
            this.firstSP.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // chkStopWitchFC
            // 
            this.chkStopWitchFC.AutoSize = true;
            this.chkStopWitchFC.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStopWitchFC.ForeColor = System.Drawing.Color.White;
            this.chkStopWitchFC.Location = new System.Drawing.Point(54, 164);
            this.chkStopWitchFC.Margin = new System.Windows.Forms.Padding(4);
            this.chkStopWitchFC.Name = "chkStopWitchFC";
            this.chkStopWitchFC.Size = new System.Drawing.Size(243, 21);
            this.chkStopWitchFC.TabIndex = 50;
            this.chkStopWitchFC.Text = "PARAR COM FERIMENTO CRÍTICO";
            this.chkStopWitchFC.UseVisualStyleBackColor = true;
            this.chkStopWitchFC.CheckedChanged += new System.EventHandler(this.chkStopWitchFC_CheckedChanged);
            // 
            // txtHpEquipBefore
            // 
            this.txtHpEquipBefore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtHpEquipBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHpEquipBefore.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHpEquipBefore.ForeColor = System.Drawing.Color.White;
            this.txtHpEquipBefore.Location = new System.Drawing.Point(120, 208);
            this.txtHpEquipBefore.Margin = new System.Windows.Forms.Padding(4);
            this.txtHpEquipBefore.Multiline = true;
            this.txtHpEquipBefore.Name = "txtHpEquipBefore";
            this.txtHpEquipBefore.Size = new System.Drawing.Size(35, 35);
            this.txtHpEquipBefore.TabIndex = 51;
            this.txtHpEquipBefore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHpEquipAfter
            // 
            this.txtHpEquipAfter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtHpEquipAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHpEquipAfter.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHpEquipAfter.ForeColor = System.Drawing.Color.White;
            this.txtHpEquipAfter.Location = new System.Drawing.Point(248, 208);
            this.txtHpEquipAfter.Margin = new System.Windows.Forms.Padding(4);
            this.txtHpEquipAfter.Multiline = true;
            this.txtHpEquipAfter.Name = "txtHpEquipAfter";
            this.txtHpEquipAfter.Size = new System.Drawing.Size(35, 35);
            this.txtHpEquipAfter.TabIndex = 53;
            this.txtHpEquipAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblequipBefore
            // 
            this.lblequipBefore.AutoSize = true;
            this.lblequipBefore.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblequipBefore.Location = new System.Drawing.Point(85, 256);
            this.lblequipBefore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblequipBefore.Name = "lblequipBefore";
            this.lblequipBefore.Size = new System.Drawing.Size(104, 17);
            this.lblequipBefore.TabIndex = 56;
            this.lblequipBefore.Text = "EQUIPA ANTES";
            this.lblequipBefore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblequipAfter
            // 
            this.lblequipAfter.AutoSize = true;
            this.lblequipAfter.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblequipAfter.Location = new System.Drawing.Point(213, 256);
            this.lblequipAfter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblequipAfter.Name = "lblequipAfter";
            this.lblequipAfter.Size = new System.Drawing.Size(112, 17);
            this.lblequipAfter.TabIndex = 57;
            this.lblequipAfter.Text = "EQUIPA DEPOIS";
            this.lblequipAfter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBoxSP
            // 
            this.picBoxSP.BackColor = System.Drawing.Color.Transparent;
            this.picBoxSP.Image = global::_4RTools.Resources._4RTools.ETCResource.SP;
            this.picBoxSP.Location = new System.Drawing.Point(76, 106);
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
            this.picBoxHP.Location = new System.Drawing.Point(76, 42);
            this.picBoxHP.Margin = new System.Windows.Forms.Padding(4);
            this.picBoxHP.Name = "picBoxHP";
            this.picBoxHP.Size = new System.Drawing.Size(35, 35);
            this.picBoxHP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHP.TabIndex = 34;
            this.picBoxHP.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(328, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("JetBrains Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Gold;
            this.textBox1.Location = new System.Drawing.Point(54, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 59;
            this.textBox1.Text = "POTIONS";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AutopotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtHpEquipBefore);
            this.Controls.Add(this.txtHpEquipAfter);
            this.Controls.Add(this.txtAutopotDelay);
            this.Controls.Add(this.chkStopWitchFC);
            this.Controls.Add(this.firstSP);
            this.Controls.Add(this.firstHP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSPKey);
            this.Controls.Add(this.txtHpKey);
            this.Controls.Add(this.txtSPpct);
            this.Controls.Add(this.txtHPpct);
            this.Controls.Add(this.labelSP);
            this.Controls.Add(this.labelHP);
            this.Controls.Add(this.picBoxSP);
            this.Controls.Add(this.picBoxHP);
            this.Controls.Add(this.lblequipAfter);
            this.Controls.Add(this.lblequipBefore);
            this.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AutopotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AutopotForm";
            this.Load += new System.EventHandler(this.AutopotForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtHPpct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPpct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown txtHPpct;
        private System.Windows.Forms.Label labelSP;
        private System.Windows.Forms.Label labelHP;
        private VerticallyCenteredTextBox txtAutopotDelay;
        private System.Windows.Forms.PictureBox picBoxSP;
        private System.Windows.Forms.PictureBox picBoxHP;
        private VerticallyCenteredTextBox txtHpKey;
        private VerticallyCenteredTextBox txtSPKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtSPpct;
        private System.Windows.Forms.RadioButton firstHP;
        private System.Windows.Forms.RadioButton firstSP;
        private System.Windows.Forms.CheckBox chkStopWitchFC;
        private VerticallyCenteredTextBox txtHpEquipBefore;
        private VerticallyCenteredTextBox txtHpEquipAfter;
        private System.Windows.Forms.Label lblequipBefore;
        private System.Windows.Forms.Label lblequipAfter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private VerticallyCenteredTextBox textBox1;
    }
}