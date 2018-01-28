namespace RemoteDesktopManager
{
    partial class RemoteDesktopListFolderItem
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
            this.lbfoldername = new System.Windows.Forms.Label();
            this.picimagerdp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picimagerdp)).BeginInit();
            this.SuspendLayout();
            // 
            // lbfoldername
            // 
            this.lbfoldername.AutoSize = true;
            this.lbfoldername.BackColor = System.Drawing.Color.Transparent;
            this.lbfoldername.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfoldername.Location = new System.Drawing.Point(65, 14);
            this.lbfoldername.Name = "lbfoldername";
            this.lbfoldername.Size = new System.Drawing.Size(132, 25);
            this.lbfoldername.TabIndex = 3;
            this.lbfoldername.Text = "lbfoldername";
            // 
            // picimagerdp
            // 
            this.picimagerdp.BackgroundImage = global::RemoteDesktopManager.Properties.Resources.icon_folder_win10;
            this.picimagerdp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picimagerdp.Location = new System.Drawing.Point(11, 3);
            this.picimagerdp.Name = "picimagerdp";
            this.picimagerdp.Size = new System.Drawing.Size(48, 48);
            this.picimagerdp.TabIndex = 4;
            this.picimagerdp.TabStop = false;
            // 
            // RemoteDesktopListFolderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.picimagerdp);
            this.Controls.Add(this.lbfoldername);
            this.Name = "RemoteDesktopListFolderItem";
            this.Size = new System.Drawing.Size(362, 55);
            ((System.ComponentModel.ISupportInitialize)(this.picimagerdp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picimagerdp;
        private System.Windows.Forms.Label lbfoldername;
    }
}
