namespace RemoteDesktopManager
{
    partial class frmshowrdpqualitystate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmshowrdpqualitystate));
            this.picimage = new System.Windows.Forms.PictureBox();
            this.lbmessage = new System.Windows.Forms.Label();
            this.btnok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).BeginInit();
            this.SuspendLayout();
            // 
            // picimage
            // 
            this.picimage.BackgroundImage = global::RemoteDesktopManager.Properties.Resources.thumb__emote__esktop__onnection;
            this.picimage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picimage.Location = new System.Drawing.Point(10, 13);
            this.picimage.Name = "picimage";
            this.picimage.Size = new System.Drawing.Size(48, 48);
            this.picimage.TabIndex = 0;
            this.picimage.TabStop = false;
            // 
            // lbmessage
            // 
            this.lbmessage.Location = new System.Drawing.Point(64, 18);
            this.lbmessage.Name = "lbmessage";
            this.lbmessage.Size = new System.Drawing.Size(300, 40);
            this.lbmessage.TabIndex = 1;
            // 
            // btnok
            // 
            this.btnok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnok.Location = new System.Drawing.Point(289, 72);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 2;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = true;
            // 
            // frmshowrdpqualitystate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 107);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.lbmessage);
            this.Controls.Add(this.picimage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmshowrdpqualitystate";
            this.Text = "Remotedesktopverbindung";
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picimage;
        private System.Windows.Forms.Label lbmessage;
        private System.Windows.Forms.Button btnok;
    }
}