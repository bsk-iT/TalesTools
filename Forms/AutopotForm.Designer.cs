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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHpKey = new System.Windows.Forms.TextBox();
            this.txtSPKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSPpct = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.firstHP = new System.Windows.Forms.RadioButton();
            this.firstSP = new System.Windows.Forms.RadioButton();
            this.chkStopWitchFC = new System.Windows.Forms.CheckBox();
            this.txtHpEquipBefore = new System.Windows.Forms.TextBox();
            this.txtHpEquipAfter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblequipBefore = new System.Windows.Forms.Label();
            this.lblequipAfter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtHPpct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPpct)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHPpct
            // 
            this.txtHPpct.BackColor = System.Drawing.Color.Black;
            this.txtHPpct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHPpct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtHPpct.ForeColor = System.Drawing.Color.White;
            this.txtHPpct.Location = new System.Drawing.Point(159, 46);
            this.txtHPpct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHPpct.Name = "txtHPpct";
            this.txtHPpct.Size = new System.Drawing.Size(59, 26);
            this.txtHPpct.TabIndex = 39;
            this.txtHPpct.ValueChanged += new System.EventHandler(this.txtHPpctTextChanged);
            // 
            // labelSP
            // 
            this.labelSP.AutoSize = true;
            this.labelSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSP.Location = new System.Drawing.Point(220, 91);
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
            this.labelHP.Location = new System.Drawing.Point(220, 49);
            this.labelHP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(24, 20);
            this.labelHP.TabIndex = 37;
            this.labelHP.Text = "%";
            // 
            // txtAutopotDelay
            // 
            this.txtAutopotDelay.BackColor = System.Drawing.Color.Black;
            this.txtAutopotDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutopotDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAutopotDelay.ForeColor = System.Drawing.Color.White;
            this.txtAutopotDelay.Location = new System.Drawing.Point(285, 142);
            this.txtAutopotDelay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAutopotDelay.Name = "txtAutopotDelay";
            this.txtAutopotDelay.Size = new System.Drawing.Size(59, 26);
            this.txtAutopotDelay.TabIndex = 36;
            this.txtAutopotDelay.TextChanged += new System.EventHandler(this.txtAutopotDelayTextChanged);
            // 
            // picBoxSP
            // 
            this.picBoxSP.BackColor = System.Drawing.Color.Transparent;
            this.picBoxSP.Image = global::_4RTools.Resources._4RTools.ETCResource.SP;
            this.picBoxSP.Location = new System.Drawing.Point(32, 87);
            this.picBoxSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picBoxSP.Name = "picBoxSP";
            this.picBoxSP.Size = new System.Drawing.Size(33, 31);
            this.picBoxSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxSP.TabIndex = 35;
            this.picBoxSP.TabStop = false;
            // 
            // picBoxHP
            // 
            this.picBoxHP.BackColor = System.Drawing.Color.Transparent;
            this.picBoxHP.Image = global::_4RTools.Resources._4RTools.ETCResource.HP;
            this.picBoxHP.Location = new System.Drawing.Point(32, 44);
            this.picBoxHP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picBoxHP.Name = "picBoxHP";
            this.picBoxHP.Size = new System.Drawing.Size(33, 31);
            this.picBoxHP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxHP.TabIndex = 34;
            this.picBoxHP.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(228, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "Delay";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(347, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "ms";
            // 
            // txtHpKey
            // 
            this.txtHpKey.BackColor = System.Drawing.Color.Black;
            this.txtHpKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHpKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtHpKey.ForeColor = System.Drawing.Color.White;
            this.txtHpKey.Location = new System.Drawing.Point(93, 46);
            this.txtHpKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHpKey.Name = "txtHpKey";
            this.txtHpKey.Size = new System.Drawing.Size(59, 26);
            this.txtHpKey.TabIndex = 43;
            // 
            // txtSPKey
            // 
            this.txtSPKey.BackColor = System.Drawing.Color.Black;
            this.txtSPKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSPKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSPKey.ForeColor = System.Drawing.Color.White;
            this.txtSPKey.Location = new System.Drawing.Point(93, 89);
            this.txtSPKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSPKey.Name = "txtSPKey";
            this.txtSPKey.Size = new System.Drawing.Size(59, 26);
            this.txtSPKey.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "HP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "SP";
            // 
            // txtSPpct
            // 
            this.txtSPpct.BackColor = System.Drawing.Color.Black;
            this.txtSPpct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSPpct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSPpct.ForeColor = System.Drawing.Color.White;
            this.txtSPpct.Location = new System.Drawing.Point(159, 89);
            this.txtSPpct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSPpct.Name = "txtSPpct";
            this.txtSPpct.Size = new System.Drawing.Size(59, 26);
            this.txtSPpct.TabIndex = 40;
            this.txtSPpct.ValueChanged += new System.EventHandler(this.txtSPpctTextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(-1, 15);
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
            this.firstHP.Location = new System.Drawing.Point(12, 54);
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
            this.firstSP.Location = new System.Drawing.Point(12, 96);
            this.firstSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.firstSP.Name = "firstSP";
            this.firstSP.Size = new System.Drawing.Size(17, 16);
            this.firstSP.TabIndex = 49;
            this.firstSP.UseVisualStyleBackColor = true;
            this.firstSP.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // chkStopWitchFC
            // 
            this.chkStopWitchFC.AutoSize = true;
            this.chkStopWitchFC.ForeColor = System.Drawing.Color.White;
            this.chkStopWitchFC.Location = new System.Drawing.Point(16, 126);
            this.chkStopWitchFC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkStopWitchFC.Name = "chkStopWitchFC";
            this.chkStopWitchFC.Size = new System.Drawing.Size(194, 20);
            this.chkStopWitchFC.TabIndex = 50;
            this.chkStopWitchFC.Text = "Parar com Ferimento Crítico";
            this.chkStopWitchFC.UseVisualStyleBackColor = true;
            this.chkStopWitchFC.CheckedChanged += new System.EventHandler(this.chkStopWitchFC_CheckedChanged);
            // 
            // txtHpEquipBefore
            // 
            this.txtHpEquipBefore.BackColor = System.Drawing.Color.Black;
            this.txtHpEquipBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHpEquipBefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtHpEquipBefore.ForeColor = System.Drawing.Color.White;
            this.txtHpEquipBefore.Location = new System.Drawing.Point(255, 47);
            this.txtHpEquipBefore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHpEquipBefore.Name = "txtHpEquipBefore";
            this.txtHpEquipBefore.Size = new System.Drawing.Size(59, 26);
            this.txtHpEquipBefore.TabIndex = 51;
            // 
            // txtHpEquipAfter
            // 
            this.txtHpEquipAfter.BackColor = System.Drawing.Color.Black;
            this.txtHpEquipAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHpEquipAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtHpEquipAfter.ForeColor = System.Drawing.Color.White;
            this.txtHpEquipAfter.Location = new System.Drawing.Point(324, 47);
            this.txtHpEquipAfter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHpEquipAfter.Name = "txtHpEquipAfter";
            this.txtHpEquipAfter.Size = new System.Drawing.Size(59, 26);
            this.txtHpEquipAfter.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(104, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 20);
            this.label6.TabIndex = 55;
            this.label6.Text = "Pot";
            // 
            // lblequipBefore
            // 
            this.lblequipBefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblequipBefore.Location = new System.Drawing.Point(247, 11);
            this.lblequipBefore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblequipBefore.Name = "lblequipBefore";
            this.lblequipBefore.Size = new System.Drawing.Size(77, 34);
            this.lblequipBefore.TabIndex = 56;
            this.lblequipBefore.Text = "Equipa Antes";
            this.lblequipBefore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblequipAfter
            // 
            this.lblequipAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblequipAfter.Location = new System.Drawing.Point(316, 11);
            this.lblequipAfter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblequipAfter.Name = "lblequipAfter";
            this.lblequipAfter.Size = new System.Drawing.Size(77, 34);
            this.lblequipAfter.TabIndex = 57;
            this.lblequipAfter.Text = "Equipa Depois";
            this.lblequipAfter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutopotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 185);
            this.Controls.Add(this.txtHpEquipBefore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHpEquipAfter);
            this.Controls.Add(this.txtAutopotDelay);
            this.Controls.Add(this.chkStopWitchFC);
            this.Controls.Add(this.firstSP);
            this.Controls.Add(this.firstHP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSPKey);
            this.Controls.Add(this.txtHpKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSPpct);
            this.Controls.Add(this.txtHPpct);
            this.Controls.Add(this.labelSP);
            this.Controls.Add(this.labelHP);
            this.Controls.Add(this.picBoxSP);
            this.Controls.Add(this.picBoxHP);
            this.Controls.Add(this.lblequipAfter);
            this.Controls.Add(this.lblequipBefore);
            this.ForeColor = System.Drawing.Color.White;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHpKey;
        private System.Windows.Forms.TextBox txtSPKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtSPpct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton firstHP;
        private System.Windows.Forms.RadioButton firstSP;
        private System.Windows.Forms.CheckBox chkStopWitchFC;
        private System.Windows.Forms.TextBox txtHpEquipBefore;
        private System.Windows.Forms.TextBox txtHpEquipAfter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblequipBefore;
        private System.Windows.Forms.Label lblequipAfter;
    }
}