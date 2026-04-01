namespace _4RTools.Forms
{
    partial class ToggleApplicationStateForm
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

            // Liberar as imagens customizadas
            if (disposing)
            {
                onImage?.Dispose();
                offImage?.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToggleApplicationStateForm));
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtStatusHealToggleKey = new VerticallyCenteredTextBox();
            this.btnStatusHealToggle = new System.Windows.Forms.Button();
            this.txtStatusToggleKey = new VerticallyCenteredTextBox();
            this.btnStatusToggle = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTray.Icon")));
            this.notifyIconTray.Text = "TalesTools";
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconDoubleClick);
            // 
            // txtStatusHealToggleKey
            // 
            this.txtStatusHealToggleKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtStatusHealToggleKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatusHealToggleKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusHealToggleKey.ForeColor = System.Drawing.Color.White;
            this.txtStatusHealToggleKey.Location = new System.Drawing.Point(229, 29);
            this.txtStatusHealToggleKey.Margin = new System.Windows.Forms.Padding(5);
            this.txtStatusHealToggleKey.Multiline = true;
            this.txtStatusHealToggleKey.Name = "txtStatusHealToggleKey";
            this.txtStatusHealToggleKey.Size = new System.Drawing.Size(35, 35);
            this.txtStatusHealToggleKey.TabIndex = 30;
            this.txtStatusHealToggleKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStatusHealToggleKey.TextChanged += new System.EventHandler(this.txtStatusHealToggleKey_TextChanged);
            // 
            // btnStatusHealToggle
            // 
            this.btnStatusHealToggle.AutoEllipsis = true;
            this.btnStatusHealToggle.BackColor = System.Drawing.Color.Transparent;
            this.btnStatusHealToggle.FlatAppearance.BorderSize = 0;
            this.btnStatusHealToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusHealToggle.Font = new System.Drawing.Font("JetBrains Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatusHealToggle.ForeColor = System.Drawing.Color.Transparent;
            this.btnStatusHealToggle.Location = new System.Drawing.Point(284, 22);
            this.btnStatusHealToggle.Margin = new System.Windows.Forms.Padding(0);
            this.btnStatusHealToggle.Name = "btnStatusHealToggle";
            this.btnStatusHealToggle.Size = new System.Drawing.Size(50, 50);
            this.btnStatusHealToggle.TabIndex = 29;
            this.btnStatusHealToggle.UseVisualStyleBackColor = false;
            this.btnStatusHealToggle.Click += new System.EventHandler(this.btnToggleStatusHealHandler);
            // 
            // txtStatusToggleKey
            // 
            this.txtStatusToggleKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtStatusToggleKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatusToggleKey.Font = new System.Drawing.Font("JetBrains Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusToggleKey.ForeColor = System.Drawing.Color.White;
            this.txtStatusToggleKey.Location = new System.Drawing.Point(60, 29);
            this.txtStatusToggleKey.Margin = new System.Windows.Forms.Padding(5);
            this.txtStatusToggleKey.Multiline = true;
            this.txtStatusToggleKey.Name = "txtStatusToggleKey";
            this.txtStatusToggleKey.Size = new System.Drawing.Size(35, 35);
            this.txtStatusToggleKey.TabIndex = 28;
            this.txtStatusToggleKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStatusToggle
            // 
            this.btnStatusToggle.BackColor = System.Drawing.Color.Transparent;
            this.btnStatusToggle.FlatAppearance.BorderSize = 0;
            this.btnStatusToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusToggle.Font = new System.Drawing.Font("JetBrains Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatusToggle.ForeColor = System.Drawing.Color.Transparent;
            this.btnStatusToggle.Location = new System.Drawing.Point(115, 22);
            this.btnStatusToggle.Margin = new System.Windows.Forms.Padding(0);
            this.btnStatusToggle.Name = "btnStatusToggle";
            this.btnStatusToggle.Size = new System.Drawing.Size(50, 50);
            this.btnStatusToggle.TabIndex = 27;
            this.btnStatusToggle.UseVisualStyleBackColor = false;
            this.btnStatusToggle.Click += new System.EventHandler(this.btnToggleStatusHandler);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(197, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 18);
            this.textBox1.TabIndex = 31;
            this.textBox1.Text = "HEAL";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(27, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 18);
            this.textBox2.TabIndex = 32;
            this.textBox2.Text = "STATUS";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ToggleApplicationStateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(350, 120);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtStatusHealToggleKey);
            this.Controls.Add(this.btnStatusHealToggle);
            this.Controls.Add(this.txtStatusToggleKey);
            this.Controls.Add(this.btnStatusToggle);
            this.Font = new System.Drawing.Font("JetBrains Mono", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ToggleApplicationStateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ToggleApplicationStateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private VerticallyCenteredTextBox txtStatusHealToggleKey;
        private System.Windows.Forms.Button btnStatusHealToggle;
        private VerticallyCenteredTextBox txtStatusToggleKey;
        private System.Windows.Forms.Button btnStatusToggle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;

    }
}