﻿namespace RemoteDesktopManager
{
    partial class frmenterfolderdata
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
            this.picimage = new System.Windows.Forms.PictureBox();
            this.txtfoldername = new System.Windows.Forms.TextBox();
            this.btnok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ordnername: ";
            // 
            // picimage
            // 
            this.picimage.BackgroundImage = global::RemoteDesktopManager.Properties.Resources.icon_folder_win10;
            this.picimage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picimage.Location = new System.Drawing.Point(15, 15);
            this.picimage.Name = "picimage";
            this.picimage.Size = new System.Drawing.Size(48, 48);
            this.picimage.TabIndex = 0;
            this.picimage.TabStop = false;
            // 
            // txtfoldername
            // 
            this.txtfoldername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfoldername.Location = new System.Drawing.Point(72, 38);
            this.txtfoldername.MaxLength = 100;
            this.txtfoldername.Name = "txtfoldername";
            this.txtfoldername.Size = new System.Drawing.Size(265, 25);
            this.txtfoldername.TabIndex = 2;
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(262, 80);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 3;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // frmcreatefolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 115);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.txtfoldername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picimage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmcreatefolder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Neuen Ordner erstellen";
            ((System.ComponentModel.ISupportInitialize)(this.picimage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picimage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtfoldername;
        private System.Windows.Forms.Button btnok;
    }
}