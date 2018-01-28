namespace RemoteDesktopManager
{
    partial class dlgrdplistnewelement
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
            this.rbaddnewfolder = new System.Windows.Forms.RadioButton();
            this.rbaddnewconnection = new System.Windows.Forms.RadioButton();
            this.btnok = new System.Windows.Forms.Button();
            this.btnabort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbaddnewfolder
            // 
            this.rbaddnewfolder.AutoSize = true;
            this.rbaddnewfolder.Location = new System.Drawing.Point(25, 22);
            this.rbaddnewfolder.Name = "rbaddnewfolder";
            this.rbaddnewfolder.Size = new System.Drawing.Size(134, 17);
            this.rbaddnewfolder.TabIndex = 1;
            this.rbaddnewfolder.TabStop = true;
            this.rbaddnewfolder.Text = "Neuen Ordner erstellen";
            this.rbaddnewfolder.UseVisualStyleBackColor = true;
            // 
            // rbaddnewconnection
            // 
            this.rbaddnewconnection.AutoSize = true;
            this.rbaddnewconnection.Location = new System.Drawing.Point(25, 45);
            this.rbaddnewconnection.Name = "rbaddnewconnection";
            this.rbaddnewconnection.Size = new System.Drawing.Size(150, 17);
            this.rbaddnewconnection.TabIndex = 2;
            this.rbaddnewconnection.TabStop = true;
            this.rbaddnewconnection.Text = "Neue Verbindung erstellen";
            this.rbaddnewconnection.UseVisualStyleBackColor = true;
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(106, 76);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 3;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btnabort
            // 
            this.btnabort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnabort.Location = new System.Drawing.Point(25, 76);
            this.btnabort.Name = "btnabort";
            this.btnabort.Size = new System.Drawing.Size(75, 23);
            this.btnabort.TabIndex = 4;
            this.btnabort.Text = "Abbrechen";
            this.btnabort.UseVisualStyleBackColor = true;
            // 
            // dlgrdplistnewelement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 111);
            this.ControlBox = false;
            this.Controls.Add(this.btnabort);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.rbaddnewconnection);
            this.Controls.Add(this.rbaddnewfolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "dlgrdplistnewelement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Neues Element hinzufügen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbaddnewfolder;
        private System.Windows.Forms.RadioButton rbaddnewconnection;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btnabort;
    }
}