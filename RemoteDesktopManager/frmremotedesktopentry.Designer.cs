namespace RemoteDesktopManager
{
    partial class frmremotedesktopentry
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.picimagerdp = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txthostname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnsavedata = new System.Windows.Forms.Button();
            this.txtconnectionname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbemerkung = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chpinghost = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picimagerdp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.picimagerdp);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 64);
            this.panel1.TabIndex = 0;
            // 
            // picimagerdp
            // 
            this.picimagerdp.BackgroundImage = global::RemoteDesktopManager.Properties.Resources.img_remotedesktop_config;
            this.picimagerdp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picimagerdp.Location = new System.Drawing.Point(2, 2);
            this.picimagerdp.Name = "picimagerdp";
            this.picimagerdp.Size = new System.Drawing.Size(60, 60);
            this.picimagerdp.TabIndex = 1;
            this.picimagerdp.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(68, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "RemoteDesktop";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Computer:";
            // 
            // txthostname
            // 
            this.txthostname.Location = new System.Drawing.Point(114, 151);
            this.txthostname.Name = "txthostname";
            this.txthostname.Size = new System.Drawing.Size(157, 20);
            this.txthostname.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Benutzername:";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(114, 186);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(157, 20);
            this.txtusername.TabIndex = 3;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(114, 220);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(157, 20);
            this.txtpassword.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Passwort:";
            // 
            // btnsavedata
            // 
            this.btnsavedata.Location = new System.Drawing.Point(143, 346);
            this.btnsavedata.Name = "btnsavedata";
            this.btnsavedata.Size = new System.Drawing.Size(128, 35);
            this.btnsavedata.TabIndex = 7;
            this.btnsavedata.Text = "Speichern";
            this.btnsavedata.UseVisualStyleBackColor = true;
            this.btnsavedata.Click += new System.EventHandler(this.btnsavedata_Click);
            // 
            // txtconnectionname
            // 
            this.txtconnectionname.Location = new System.Drawing.Point(114, 80);
            this.txtconnectionname.Name = "txtconnectionname";
            this.txtconnectionname.Size = new System.Drawing.Size(157, 20);
            this.txtconnectionname.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Verbindung:";
            // 
            // txtbemerkung
            // 
            this.txtbemerkung.Location = new System.Drawing.Point(114, 254);
            this.txtbemerkung.Multiline = true;
            this.txtbemerkung.Name = "txtbemerkung";
            this.txtbemerkung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbemerkung.Size = new System.Drawing.Size(157, 58);
            this.txtbemerkung.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Bemerkung:";
            // 
            // chpinghost
            // 
            this.chpinghost.AutoSize = true;
            this.chpinghost.Checked = true;
            this.chpinghost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chpinghost.Location = new System.Drawing.Point(114, 320);
            this.chpinghost.Name = "chpinghost";
            this.chpinghost.Size = new System.Drawing.Size(131, 17);
            this.chpinghost.TabIndex = 6;
            this.chpinghost.Text = "Ping-Test durchführen";
            this.chpinghost.UseVisualStyleBackColor = true;
            // 
            // frmremotedesktopentry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 393);
            this.Controls.Add(this.chpinghost);
            this.Controls.Add(this.txtbemerkung);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtconnectionname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnsavedata);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txthostname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmremotedesktopentry";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmremotedesktopentry";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picimagerdp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txthostname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnsavedata;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picimagerdp;
        private System.Windows.Forms.TextBox txtconnectionname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbemerkung;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chpinghost;
    }
}