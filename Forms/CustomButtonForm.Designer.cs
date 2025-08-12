namespace _4RTools.Forms
{
    partial class CustomButtonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomButtonForm));
            this.txtTransferKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAutoClickKey = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxAutoTransfer = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBoxAutoTransfer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTransferKey
            // 
            this.txtTransferKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtTransferKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransferKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTransferKey.ForeColor = System.Drawing.Color.White;
            this.txtTransferKey.Location = new System.Drawing.Point(156, 43);
            this.txtTransferKey.Multiline = true;
            this.txtTransferKey.Name = "txtTransferKey";
            this.txtTransferKey.Size = new System.Drawing.Size(60, 30);
            this.txtTransferKey.TabIndex = 11;
            this.txtTransferKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Transfer Item";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Auto Click";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtAutoClickKey
            // 
            this.txtAutoClickKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtAutoClickKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutoClickKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAutoClickKey.ForeColor = System.Drawing.Color.White;
            this.txtAutoClickKey.Location = new System.Drawing.Point(377, 43);
            this.txtAutoClickKey.Multiline = true;
            this.txtAutoClickKey.Name = "txtAutoClickKey";
            this.txtAutoClickKey.Size = new System.Drawing.Size(60, 30);
            this.txtAutoClickKey.TabIndex = 14;
            this.txtAutoClickKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Location = new System.Drawing.Point(233, 43);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 30);
            this.panel5.TabIndex = 19;
            this.panel5.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(249, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // groupBoxAutoTransfer
            // 
            this.groupBoxAutoTransfer.Controls.Add(this.txtAutoClickKey);
            this.groupBoxAutoTransfer.Controls.Add(this.txtTransferKey);
            this.groupBoxAutoTransfer.Controls.Add(this.pictureBox1);
            this.groupBoxAutoTransfer.Controls.Add(this.pictureBox2);
            this.groupBoxAutoTransfer.Controls.Add(this.label1);
            this.groupBoxAutoTransfer.Controls.Add(this.panel5);
            this.groupBoxAutoTransfer.Controls.Add(this.label2);
            this.groupBoxAutoTransfer.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAutoTransfer.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxAutoTransfer.Name = "groupBoxAutoTransfer";
            this.groupBoxAutoTransfer.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxAutoTransfer.Size = new System.Drawing.Size(450, 100);
            this.groupBoxAutoTransfer.TabIndex = 22;
            this.groupBoxAutoTransfer.TabStop = false;
            this.groupBoxAutoTransfer.Enter += new System.EventHandler(this.groupBoxAutoTransfer_Enter);
            // 
            // CustomButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(450, 100);
            this.Controls.Add(this.groupBoxAutoTransfer);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomButtonForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "StatusEffect";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBoxAutoTransfer.ResumeLayout(false);
            this.groupBoxAutoTransfer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtTransferKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAutoClickKey;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBoxAutoTransfer;
    }
}