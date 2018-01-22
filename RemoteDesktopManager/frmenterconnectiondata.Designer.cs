namespace RemoteDesktopManager
{
    partial class frmenterconnectiondata
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
            this.picimagerdp = new System.Windows.Forms.PictureBox();
            this.btnconnect = new System.Windows.Forms.Button();
            this.txtcomputer = new System.Windows.Forms.TextBox();
            this.lbusername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picimagerdp)).BeginInit();
            this.SuspendLayout();
            // 
            // picimagerdp
            // 
            this.picimagerdp.BackgroundImage = global::RemoteDesktopManager.Properties.Resources.thumb__emote__esktop__onnection;
            this.picimagerdp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picimagerdp.Location = new System.Drawing.Point(12, 12);
            this.picimagerdp.Name = "picimagerdp";
            this.picimagerdp.Size = new System.Drawing.Size(48, 48);
            this.picimagerdp.TabIndex = 10;
            this.picimagerdp.TabStop = false;
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(285, 66);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(84, 23);
            this.btnconnect.TabIndex = 3;
            this.btnconnect.Text = "Verbinden";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // txtcomputer
            // 
            this.txtcomputer.Location = new System.Drawing.Point(152, 12);
            this.txtcomputer.MaxLength = 100;
            this.txtcomputer.Name = "txtcomputer";
            this.txtcomputer.Size = new System.Drawing.Size(217, 20);
            this.txtcomputer.TabIndex = 1;
            // 
            // lbusername
            // 
            this.lbusername.AutoSize = true;
            this.lbusername.Location = new System.Drawing.Point(155, 38);
            this.lbusername.Name = "lbusername";
            this.lbusername.Size = new System.Drawing.Size(0, 13);
            this.lbusername.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Benutzername:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Computer: ";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(152, 40);
            this.txtusername.MaxLength = 100;
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(217, 20);
            this.txtusername.TabIndex = 2;
            // 
            // frmenterconnectiondata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 99);
            this.Controls.Add(this.picimagerdp);
            this.Controls.Add(this.btnconnect);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.txtcomputer);
            this.Controls.Add(this.lbusername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmenterconnectiondata";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "RemoteDesktop-Verbindung herstellen";
            ((System.ComponentModel.ISupportInitialize)(this.picimagerdp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picimagerdp;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.TextBox txtcomputer;
        private System.Windows.Forms.Label lbusername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtusername;
    }
}