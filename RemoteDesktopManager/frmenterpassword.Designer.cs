namespace RemoteDesktopManager
{
    partial class frmenterpassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbusername = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.btnconnect = new System.Windows.Forms.Button();
            this.picimagerdp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picimagerdp)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Benutzername: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Passwort: ";
            // 
            // lbusername
            // 
            this.lbusername.AutoSize = true;
            this.lbusername.Location = new System.Drawing.Point(155, 16);
            this.lbusername.Name = "lbusername";
            this.lbusername.Size = new System.Drawing.Size(0, 13);
            this.lbusername.TabIndex = 1;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(158, 37);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '•';
            this.txtpassword.Size = new System.Drawing.Size(217, 20);
            this.txtpassword.TabIndex = 2;
            this.txtpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpassword_KeyDown);
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(291, 69);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(84, 23);
            this.btnconnect.TabIndex = 3;
            this.btnconnect.Text = "Verbinden";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // picimagerdp
            // 
            this.picimagerdp.BackgroundImage = global::RemoteDesktopManager.Properties.Resources.thumb__emote__esktop__onnection;
            this.picimagerdp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picimagerdp.Location = new System.Drawing.Point(12, 12);
            this.picimagerdp.Name = "picimagerdp";
            this.picimagerdp.Size = new System.Drawing.Size(48, 48);
            this.picimagerdp.TabIndex = 4;
            this.picimagerdp.TabStop = false;
            // 
            // frmenterpassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 100);
            this.Controls.Add(this.picimagerdp);
            this.Controls.Add(this.btnconnect);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.lbusername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmenterpassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Benutzerabfrage";
            ((System.ComponentModel.ISupportInitialize)(this.picimagerdp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.PictureBox picimagerdp;
    }
}