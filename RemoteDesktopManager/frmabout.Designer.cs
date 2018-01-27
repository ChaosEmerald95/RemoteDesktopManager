namespace RemoteDesktopManager
{
    partial class frmabout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmabout));
            this.lblinksrccode = new System.Windows.Forms.LinkLabel();
            this.lbcopyright = new System.Windows.Forms.Label();
            this.lbbuild = new System.Windows.Forms.Label();
            this.lbversionnumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picimage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblinksrccode
            // 
            this.lblinksrccode.AutoSize = true;
            this.lblinksrccode.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinksrccode.Location = new System.Drawing.Point(18, 164);
            this.lblinksrccode.Name = "lblinksrccode";
            this.lblinksrccode.Size = new System.Drawing.Size(93, 20);
            this.lblinksrccode.TabIndex = 8;
            this.lblinksrccode.TabStop = true;
            this.lblinksrccode.Text = "Source Code";
            // 
            // lbcopyright
            // 
            this.lbcopyright.AutoSize = true;
            this.lbcopyright.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcopyright.Location = new System.Drawing.Point(18, 135);
            this.lbcopyright.Name = "lbcopyright";
            this.lbcopyright.Size = new System.Drawing.Size(85, 20);
            this.lbcopyright.TabIndex = 4;
            this.lbcopyright.Text = "lbcopyright";
            // 
            // lbbuild
            // 
            this.lbbuild.AutoSize = true;
            this.lbbuild.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbuild.Location = new System.Drawing.Point(18, 105);
            this.lbbuild.Name = "lbbuild";
            this.lbbuild.Size = new System.Drawing.Size(56, 20);
            this.lbbuild.TabIndex = 5;
            this.lbbuild.Text = "lbbuild";
            // 
            // lbversionnumber
            // 
            this.lbversionnumber.AutoSize = true;
            this.lbversionnumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbversionnumber.Location = new System.Drawing.Point(98, 54);
            this.lbversionnumber.Name = "lbversionnumber";
            this.lbversionnumber.Size = new System.Drawing.Size(120, 20);
            this.lbversionnumber.TabIndex = 6;
            this.lbversionnumber.Text = "lbversionnumber";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "RemoteDesktop-Manager";
            // 
            // picimage
            // 
            this.picimage.BackgroundImage = global::RemoteDesktopManager.Properties.Resources.thumb__emote__esktop__onnection;
            this.picimage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picimage.Location = new System.Drawing.Point(22, 23);
            this.picimage.Name = "picimage";
            this.picimage.Size = new System.Drawing.Size(64, 64);
            this.picimage.TabIndex = 3;
            this.picimage.TabStop = false;
            // 
            // frmabout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 206);
            this.Controls.Add(this.lblinksrccode);
            this.Controls.Add(this.lbcopyright);
            this.Controls.Add(this.lbbuild);
            this.Controls.Add(this.lbversionnumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picimage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmabout";
            this.ShowInTaskbar = false;
            this.Text = "Über RemoteDesktop-Manager";
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblinksrccode;
        private System.Windows.Forms.Label lbcopyright;
        private System.Windows.Forms.Label lbbuild;
        private System.Windows.Forms.Label lbversionnumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picimage;
    }
}