namespace RemoteDesktopManager
{
    partial class RemoteDesktopList
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panellist = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnadd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnreload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panellist
            // 
            this.panellist.BackColor = System.Drawing.Color.White;
            this.panellist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panellist.Location = new System.Drawing.Point(0, 27);
            this.panellist.Name = "panellist";
            this.panellist.Size = new System.Drawing.Size(262, 564);
            this.panellist.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::RemoteDesktopManager.Properties.Resources.ButtonFace;
            this.panel2.Controls.Add(this.btnadd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 591);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 29);
            this.panel2.TabIndex = 1;
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.Transparent;
            this.btnadd.FlatAppearance.BorderSize = 0;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(3, 1);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(259, 26);
            this.btnadd.TabIndex = 2;
            this.btnadd.Text = "+ Neues Element";
            this.btnadd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::RemoteDesktopManager.Properties.Resources.ButtonFace;
            this.panel1.Controls.Add(this.btnreload);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 27);
            this.panel1.TabIndex = 0;
            // 
            // btnreload
            // 
            this.btnreload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnreload.BackColor = System.Drawing.Color.Transparent;
            this.btnreload.FlatAppearance.BorderSize = 0;
            this.btnreload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreload.Font = new System.Drawing.Font("MS Outlook", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnreload.Location = new System.Drawing.Point(229, 3);
            this.btnreload.Name = "btnreload";
            this.btnreload.Size = new System.Drawing.Size(29, 23);
            this.btnreload.TabIndex = 1;
            this.btnreload.Text = "C";
            this.btnreload.UseVisualStyleBackColor = false;
            this.btnreload.Click += new System.EventHandler(this.btnreload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Verbindungen";
            // 
            // RemoteDesktopList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panellist);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RemoteDesktopList";
            this.Size = new System.Drawing.Size(262, 620);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnreload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Panel panellist;
    }
}
