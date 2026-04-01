namespace _4RTools.Forms
{
    partial class AutoBuffStatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoBuffStatusForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelSelectDebuff = new System.Windows.Forms.Label();
            this.comboBoxDebuffs = new System.Windows.Forms.ComboBox();
            this.panelDebuffsContainer = new System.Windows.Forms.Panel();
            this.DebuffsGP = new System.Windows.Forms.GroupBox();
            this.panelControls1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtStatusKey = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtNewStatusKey = new _4RTools.Forms.VerticallyCenteredTextBox();
            this.panelControls1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 500;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.UseAnimation = true;
            this.toolTip1.UseFading = true;
            // 
            // labelSelectDebuff
            // 
            this.labelSelectDebuff.AutoSize = true;
            this.labelSelectDebuff.Font = new System.Drawing.Font("JetBrains Mono", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelSelectDebuff.ForeColor = System.Drawing.Color.White;
            this.labelSelectDebuff.Location = new System.Drawing.Point(15, 8);
            this.labelSelectDebuff.Name = "labelSelectDebuff";
            this.labelSelectDebuff.Size = new System.Drawing.Size(126, 14);
            this.labelSelectDebuff.TabIndex = 0;
            this.labelSelectDebuff.Text = "SELECIONAR DEBUFF";
            this.labelSelectDebuff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxDebuffs
            // 
            this.comboBoxDebuffs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.comboBoxDebuffs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDebuffs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDebuffs.Font = new System.Drawing.Font("JetBrains Mono", 9F);
            this.comboBoxDebuffs.ForeColor = System.Drawing.Color.White;
            this.comboBoxDebuffs.FormattingEnabled = true;
            this.comboBoxDebuffs.Location = new System.Drawing.Point(15, 25);
            this.comboBoxDebuffs.Name = "comboBoxDebuffs";
            this.comboBoxDebuffs.Size = new System.Drawing.Size(400, 24);
            this.comboBoxDebuffs.TabIndex = 1;
            this.comboBoxDebuffs.SelectedIndexChanged += new System.EventHandler(this.comboBoxDebuffs_SelectedIndexChanged);
            // 
            // panelDebuffsContainer
            // 
            this.panelDebuffsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDebuffsContainer.AutoScroll = true;
            this.panelDebuffsContainer.Location = new System.Drawing.Point(15, 69);
            this.panelDebuffsContainer.Name = "panelDebuffsContainer";
            this.panelDebuffsContainer.Size = new System.Drawing.Size(945, 288);
            this.panelDebuffsContainer.TabIndex = 2;
            // 
            // DebuffsGP
            // 
            this.DebuffsGP.AutoSize = true;
            this.DebuffsGP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DebuffsGP.ForeColor = System.Drawing.Color.White;
            this.DebuffsGP.Location = new System.Drawing.Point(100, 100);
            this.DebuffsGP.Margin = new System.Windows.Forms.Padding(4);
            this.DebuffsGP.Name = "DebuffsGP";
            this.DebuffsGP.Padding = new System.Windows.Forms.Padding(4);
            this.DebuffsGP.Size = new System.Drawing.Size(772, 40);
            this.DebuffsGP.TabIndex = 294;
            this.DebuffsGP.TabStop = false;
            this.DebuffsGP.Text = "DEBUFFS";
            // 
            // panelControls1
            // 
            this.panelControls1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls1.Controls.Add(this.pictureBox1);
            this.panelControls1.Controls.Add(this.txtStatusKey);
            this.panelControls1.Controls.Add(this.pictureBox2);
            this.panelControls1.Controls.Add(this.txtNewStatusKey);
            this.panelControls1.Location = new System.Drawing.Point(434, 13);
            this.panelControls1.Name = "panelControls1";
            this.panelControls1.Size = new System.Drawing.Size(248, 50);
            this.panelControls1.TabIndex = 301;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 296;
            this.pictureBox1.TabStop = false;
            // 
            // txtStatusKey
            // 
            this.txtStatusKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtStatusKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatusKey.Font = new System.Drawing.Font("JetBrains Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusKey.ForeColor = System.Drawing.Color.White;
            this.txtStatusKey.Location = new System.Drawing.Point(64, 10);
            this.txtStatusKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtStatusKey.Multiline = true;
            this.txtStatusKey.Name = "txtStatusKey";
            this.txtStatusKey.Size = new System.Drawing.Size(35, 35);
            this.txtStatusKey.TabIndex = 295;
            this.txtStatusKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(138, 10);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 303;
            this.pictureBox2.TabStop = false;
            // 
            // txtNewStatusKey
            // 
            this.txtNewStatusKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtNewStatusKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewStatusKey.Font = new System.Drawing.Font("JetBrains Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewStatusKey.ForeColor = System.Drawing.Color.White;
            this.txtNewStatusKey.Location = new System.Drawing.Point(180, 10);
            this.txtNewStatusKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewStatusKey.Multiline = true;
            this.txtNewStatusKey.Name = "txtNewStatusKey";
            this.txtNewStatusKey.Size = new System.Drawing.Size(35, 35);
            this.txtNewStatusKey.TabIndex = 302;
            this.txtNewStatusKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AutoBuffStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(972, 424);
            this.Controls.Add(this.panelControls1);
            this.Controls.Add(this.panelDebuffsContainer);
            this.Controls.Add(this.comboBoxDebuffs);
            this.Controls.Add(this.labelSelectDebuff);
            this.Controls.Add(this.DebuffsGP);
            this.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AutoBuffStatusForm";
            this.Text = "AutoBuffStatusForm";
            this.Load += new System.EventHandler(this.AutoBuffStatusForm_Load);
            this.panelControls1.ResumeLayout(false);
            this.panelControls1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelSelectDebuff;
        private System.Windows.Forms.ComboBox comboBoxDebuffs;
        private System.Windows.Forms.Panel panelDebuffsContainer;
        private System.Windows.Forms.GroupBox DebuffsGP;
        private System.Windows.Forms.Panel panelControls1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private VerticallyCenteredTextBox txtStatusKey;
        private System.Windows.Forms.PictureBox pictureBox2;
        private VerticallyCenteredTextBox txtNewStatusKey;
    }
}