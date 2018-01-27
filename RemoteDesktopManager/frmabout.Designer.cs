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
            this.picimage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbversionnumber = new System.Windows.Forms.Label();
            this.lbbuild = new System.Windows.Forms.Label();
            this.lbcopyright = new System.Windows.Forms.Label();
            this.lblinksrccode = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).BeginInit();
            this.SuspendLayout();
            // 
            // picimage
            // 
            this.picimage.BackgroundImage = global::RemoteDesktopManager.Properties.Resources.thumb__emote__esktop__onnection;
            this.picimage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picimage.Location = new System.Drawing.Point(20, 20);
            this.picimage.Name = "picimage";
            this.picimage.Size = new System.Drawing.Size(64, 64);
            this.picimage.TabIndex = 0;
            this.picimage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "RemoteDesktop-Manager";
            // 
            // lbversionnumber
            // 
            this.lbversionnumber.AutoSize = true;
            this.lbversionnumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbversionnumber.Location = new System.Drawing.Point(96, 51);
            this.lbversionnumber.Name = "lbversionnumber";
            this.lbversionnumber.Size = new System.Drawing.Size(120, 20);
            this.lbversionnumber.TabIndex = 1;
            this.lbversionnumber.Text = "lbversionnumber";
            // 
            // lbbuild
            // 
            this.lbbuild.AutoSize = true;
            this.lbbuild.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbbuild.Location = new System.Drawing.Point(16, 102);
            this.lbbuild.Name = "lbbuild";
            this.lbbuild.Size = new System.Drawing.Size(56, 20);
            this.lbbuild.TabIndex = 1;
            this.lbbuild.Text = "lbbuild";
            // 
            // lbcopyright
            // 
            this.lbcopyright.AutoSize = true;
            this.lbcopyright.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcopyright.Location = new System.Drawing.Point(16, 132);
            this.lbcopyright.Name = "lbcopyright";
            this.lbcopyright.Size = new System.Drawing.Size(85, 20);
            this.lbcopyright.TabIndex = 1;
            this.lbcopyright.Text = "lbcopyright";
            // 
            // lblinksrccode
            // 
            this.lblinksrccode.AutoSize = true;
            this.lblinksrccode.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinksrccode.Location = new System.Drawing.Point(16, 161);
            this.lblinksrccode.Name = "lblinksrccode";
            this.lblinksrccode.Size = new System.Drawing.Size(93, 20);
            this.lblinksrccode.TabIndex = 2;
            this.lblinksrccode.TabStop = true;
            this.lblinksrccode.Text = "Source Code";
            // 
            // frmabout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 194);
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
            this.Text = "Über RemoteDesktop-Manager";
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picimage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbversionnumber;
        private System.Windows.Forms.Label lbbuild;
        private System.Windows.Forms.Label lbcopyright;
        private System.Windows.Forms.LinkLabel lblinksrccode;
    }
}