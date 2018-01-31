namespace RemoteDesktopManager
{
    partial class RemoteDesktopListItem
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
            this.components = new System.ComponentModel.Container();
            this.lbconname = new System.Windows.Forms.Label();
            this.lbip = new System.Windows.Forms.Label();
            this.contextsingleconnection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmenuitemconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmenuitemeditsettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuitemsdelete = new System.Windows.Forms.ToolStripMenuItem();
            this.lbpassword = new System.Windows.Forms.Label();
            this.picimagerdp = new System.Windows.Forms.PictureBox();
            this.contextsingleconnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picimagerdp)).BeginInit();
            this.SuspendLayout();
            // 
            // lbconname
            // 
            this.lbconname.AutoSize = true;
            this.lbconname.BackColor = System.Drawing.Color.Transparent;
            this.lbconname.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbconname.Location = new System.Drawing.Point(69, 8);
            this.lbconname.Name = "lbconname";
            this.lbconname.Size = new System.Drawing.Size(86, 20);
            this.lbconname.TabIndex = 0;
            this.lbconname.Text = "lbconname";
            // 
            // lbip
            // 
            this.lbip.AutoSize = true;
            this.lbip.BackColor = System.Drawing.Color.Transparent;
            this.lbip.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbip.ForeColor = System.Drawing.Color.Gray;
            this.lbip.Location = new System.Drawing.Point(70, 30);
            this.lbip.Name = "lbip";
            this.lbip.Size = new System.Drawing.Size(27, 13);
            this.lbip.TabIndex = 0;
            this.lbip.Text = "lbip";
            // 
            // contextsingleconnection
            // 
            this.contextsingleconnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuitemconnect,
            this.toolStripSeparator1,
            this.tsmenuitemeditsettings,
            this.tsmenuitemsdelete});
            this.contextsingleconnection.Name = "contextsingleconnection";
            this.contextsingleconnection.Size = new System.Drawing.Size(131, 76);
            // 
            // tsmenuitemconnect
            // 
            this.tsmenuitemconnect.Name = "tsmenuitemconnect";
            this.tsmenuitemconnect.Size = new System.Drawing.Size(130, 22);
            this.tsmenuitemconnect.Text = "Verbinden";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // tsmenuitemeditsettings
            // 
            this.tsmenuitemeditsettings.Name = "tsmenuitemeditsettings";
            this.tsmenuitemeditsettings.Size = new System.Drawing.Size(130, 22);
            this.tsmenuitemeditsettings.Text = "Bearbeiten";
            this.tsmenuitemeditsettings.Click += new System.EventHandler(this.tsmenuitemeditsettings_Click);
            // 
            // tsmenuitemsdelete
            // 
            this.tsmenuitemsdelete.Name = "tsmenuitemsdelete";
            this.tsmenuitemsdelete.Size = new System.Drawing.Size(130, 22);
            this.tsmenuitemsdelete.Text = "Löschen";
            this.tsmenuitemsdelete.Click += new System.EventHandler(this.tsmenuitemsdelete_Click);
            // 
            // lbpassword
            // 
            this.lbpassword.AutoSize = true;
            this.lbpassword.BackColor = System.Drawing.Color.Transparent;
            this.lbpassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpassword.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbpassword.Location = new System.Drawing.Point(0, 2);
            this.lbpassword.Name = "lbpassword";
            this.lbpassword.Size = new System.Drawing.Size(14, 20);
            this.lbpassword.TabIndex = 2;
            this.lbpassword.Text = "!";
            // 
            // picimagerdp
            // 
            this.picimagerdp.BackgroundImage = global::RemoteDesktopManager.Properties.Resources.thumb__emote__esktop__onnection;
            this.picimagerdp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picimagerdp.Location = new System.Drawing.Point(13, 3);
            this.picimagerdp.Name = "picimagerdp";
            this.picimagerdp.Size = new System.Drawing.Size(48, 48);
            this.picimagerdp.TabIndex = 3;
            this.picimagerdp.TabStop = false;
            // 
            // RemoteDesktopListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextsingleconnection;
            this.Controls.Add(this.picimagerdp);
            this.Controls.Add(this.lbpassword);
            this.Controls.Add(this.lbip);
            this.Controls.Add(this.lbconname);
            this.Name = "RemoteDesktopListItem";
            this.Size = new System.Drawing.Size(362, 55);
            this.contextsingleconnection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picimagerdp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbconname;
        private System.Windows.Forms.Label lbip;
        private System.Windows.Forms.ContextMenuStrip contextsingleconnection;
        private System.Windows.Forms.ToolStripMenuItem tsmenuitemconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmenuitemeditsettings;
        private System.Windows.Forms.ToolStripMenuItem tsmenuitemsdelete;
        private System.Windows.Forms.Label lbpassword;
        private System.Windows.Forms.PictureBox picimagerdp;
    }
}
