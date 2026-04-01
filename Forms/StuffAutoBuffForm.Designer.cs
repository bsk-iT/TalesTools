namespace _4RTools.Forms
{
    partial class StuffAutoBuffForm
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StuffAutoBuffForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBoxStuff = new System.Windows.Forms.ComboBox();
            this.labelSelectStuff = new System.Windows.Forms.Label();
            this.panelStuffContainer = new System.Windows.Forms.Panel();
            this.btnResetAutobuff = new System.Windows.Forms.Button();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.numericDelay = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelControls2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelControls2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 10000;  // Aumentar para 10 segundos (era 5000)
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 2;
            this.toolTip1.UseAnimation = true;
            this.toolTip1.UseFading = true;
            // 
            // comboBoxStuff
            // 
            this.comboBoxStuff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.comboBoxStuff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStuff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxStuff.Font = new System.Drawing.Font("JetBrains Mono", 9F);
            this.comboBoxStuff.ForeColor = System.Drawing.Color.White;
            this.comboBoxStuff.FormattingEnabled = true;
            this.comboBoxStuff.Location = new System.Drawing.Point(15, 25);
            this.comboBoxStuff.Name = "comboBoxStuff";
            this.comboBoxStuff.Size = new System.Drawing.Size(400, 24);
            this.comboBoxStuff.TabIndex = 1;
            this.comboBoxStuff.SelectedIndexChanged += new System.EventHandler(this.comboBoxStuff_SelectedIndexChanged);
            // 
            // labelSelectStuff
            // 
            this.labelSelectStuff.AutoSize = true;
            this.labelSelectStuff.Font = new System.Drawing.Font("JetBrains Mono", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelSelectStuff.ForeColor = System.Drawing.Color.White;
            this.labelSelectStuff.Location = new System.Drawing.Point(15, 8);
            this.labelSelectStuff.Name = "labelSelectStuff";
            this.labelSelectStuff.Size = new System.Drawing.Size(196, 14);
            this.labelSelectStuff.TabIndex = 0;
            this.labelSelectStuff.Text = "SELECIONAR ITEM / CATEGORIA";
            this.labelSelectStuff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelStuffContainer
            // 
            this.panelStuffContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStuffContainer.AutoScroll = true;
            this.panelStuffContainer.Location = new System.Drawing.Point(15, 60);
            this.panelStuffContainer.Name = "panelStuffContainer";
            this.panelStuffContainer.Size = new System.Drawing.Size(945, 288);
            this.panelStuffContainer.TabIndex = 2;
            // 
            // btnResetAutobuff
            // 
            this.btnResetAutobuff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnResetAutobuff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetAutobuff.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnResetAutobuff.ForeColor = System.Drawing.Color.White;
            this.btnResetAutobuff.Location = new System.Drawing.Point(130, 9);
            this.btnResetAutobuff.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetAutobuff.Name = "btnResetAutobuff";
            this.btnResetAutobuff.Size = new System.Drawing.Size(80, 30);
            this.btnResetAutobuff.TabIndex = 299;
            this.btnResetAutobuff.Text = "RESET";
            this.toolTip2.SetToolTip(this.btnResetAutobuff, "Remove todos os atalhos");
            this.btnResetAutobuff.UseVisualStyleBackColor = false;
            this.btnResetAutobuff.Click += new System.EventHandler(this.btnResetAutobuff_Click);
            // 
            // numericDelay
            // 
            this.numericDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.numericDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericDelay.Font = new System.Drawing.Font("JetBrains Mono", 11.25F);
            this.numericDelay.ForeColor = System.Drawing.Color.White;
            this.numericDelay.Location = new System.Drawing.Point(42, 11);
            this.numericDelay.Margin = new System.Windows.Forms.Padding(4);
            this.numericDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericDelay.Name = "numericDelay";
            this.numericDelay.Size = new System.Drawing.Size(80, 27);
            this.numericDelay.TabIndex = 302;
            this.numericDelay.ValueChanged += new System.EventHandler(this.numericDelay_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 303;
            this.pictureBox1.TabStop = false;
            // 
            // panelControls2
            // 
            this.panelControls2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControls2.Controls.Add(this.pictureBox1);
            this.panelControls2.Controls.Add(this.numericDelay);
            this.panelControls2.Controls.Add(this.btnResetAutobuff);
            this.panelControls2.Location = new System.Drawing.Point(15, 363);
            this.panelControls2.Name = "panelControls2";
            this.panelControls2.Size = new System.Drawing.Size(945, 50);
            this.panelControls2.TabIndex = 3;
            // 
            // StuffAutoBuffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(972, 424);
            this.Controls.Add(this.panelControls2);
            this.Controls.Add(this.panelStuffContainer);
            this.Controls.Add(this.comboBoxStuff);
            this.Controls.Add(this.labelSelectStuff);
            this.Font = new System.Drawing.Font("JetBrains Mono", 7.8F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StuffAutoBuffForm";
            this.Text = "StuffAutoBuffForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelControls2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBoxStuff;
        private System.Windows.Forms.Label labelSelectStuff;
        private System.Windows.Forms.Panel panelStuffContainer;
        private System.Windows.Forms.Button btnResetAutobuff;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.NumericUpDown numericDelay;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelControls2;
    }
}