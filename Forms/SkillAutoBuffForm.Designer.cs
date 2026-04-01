namespace _4RTools.Forms
{
    partial class SkillAutoBuffForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillAutoBuffForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.btnResetAutobuff = new System.Windows.Forms.Button();
            this.panelSkillsContainer = new System.Windows.Forms.Panel();
            this.comboBoxSkills = new System.Windows.Forms.ComboBox();
            this.labelSelectSkill = new System.Windows.Forms.Label();
            this.numericDelay = new System.Windows.Forms.NumericUpDown();
            this.panelControls1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).BeginInit();
            this.panelControls1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // panelSkillsContainer
            // 
            this.panelSkillsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSkillsContainer.AutoScroll = true;
            this.panelSkillsContainer.Location = new System.Drawing.Point(15, 60);
            this.panelSkillsContainer.Name = "panelSkillsContainer";
            this.panelSkillsContainer.Size = new System.Drawing.Size(945, 288);
            this.panelSkillsContainer.TabIndex = 2;
            // 
            // comboBoxSkills
            // 
            this.comboBoxSkills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.comboBoxSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSkills.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSkills.Font = new System.Drawing.Font("JetBrains Mono", 9F);
            this.comboBoxSkills.ForeColor = System.Drawing.Color.White;
            this.comboBoxSkills.FormattingEnabled = true;
            this.comboBoxSkills.Location = new System.Drawing.Point(15, 25);
            this.comboBoxSkills.Name = "comboBoxSkills";
            this.comboBoxSkills.Size = new System.Drawing.Size(400, 24);
            this.comboBoxSkills.TabIndex = 1;
            this.comboBoxSkills.SelectedIndexChanged += new System.EventHandler(this.comboBoxSkills_SelectedIndexChanged);
            // 
            // labelSelectSkill
            // 
            this.labelSelectSkill.AutoSize = true;
            this.labelSelectSkill.Font = new System.Drawing.Font("JetBrains Mono", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelSelectSkill.ForeColor = System.Drawing.Color.White;
            this.labelSelectSkill.Location = new System.Drawing.Point(15, 8);
            this.labelSelectSkill.Name = "labelSelectSkill";
            this.labelSelectSkill.Size = new System.Drawing.Size(182, 14);
            this.labelSelectSkill.TabIndex = 0;
            this.labelSelectSkill.Text = "SELECIONAR SKILL / CLASSE";
            this.labelSelectSkill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // panelControls1
            // 
            this.panelControls1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls1.Controls.Add(this.pictureBox1);
            this.panelControls1.Controls.Add(this.numericDelay);
            this.panelControls1.Controls.Add(this.btnResetAutobuff);
            this.panelControls1.Location = new System.Drawing.Point(15, 363);
            this.panelControls1.Name = "panelControls1";
            this.panelControls1.Size = new System.Drawing.Size(945, 50);
            this.panelControls1.TabIndex = 401;
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
            // SkillAutoBuffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(972, 424);
            this.Controls.Add(this.panelControls1);
            this.Controls.Add(this.panelSkillsContainer);
            this.Controls.Add(this.comboBoxSkills);
            this.Controls.Add(this.labelSelectSkill);
            this.Font = new System.Drawing.Font("JetBrains Mono", 7.8F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SkillAutoBuffForm";
            this.Text = "SkillAutoBuffForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).EndInit();
            this.panelControls1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ComboBox comboBoxSkills;
        private System.Windows.Forms.Label labelSelectSkill;
        private System.Windows.Forms.Panel panelSkillsContainer;
        private System.Windows.Forms.Button btnResetAutobuff;
        private System.Windows.Forms.NumericUpDown numericDelay;
        private System.Windows.Forms.Panel panelControls1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}