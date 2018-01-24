namespace RemoteDesktopManager
{
    partial class RemoteDesktopTabPageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteDesktopTabPageView));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnlockkeycombination = new System.Windows.Forms.ToolStripButton();
            this.axMsRdpClient10NotSafeForScripting1 = new AxMSTSCLib.AxMsRdpClient10NotSafeForScripting();
            this.axMsRdpClient101 = new AxMSTSCLib.AxMsRdpClient10();
            this.rdp = new AxMSTSCLib.AxMsRdpClient9NotSafeForScripting();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient10NotSafeForScripting1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 579);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(867, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnlockkeycombination});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(867, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnlockkeycombination
            // 
            this.tsbtnlockkeycombination.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnlockkeycombination.Image = global::RemoteDesktopManager.Properties.Resources.icon_hyperv_lockkeys;
            this.tsbtnlockkeycombination.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnlockkeycombination.Name = "tsbtnlockkeycombination";
            this.tsbtnlockkeycombination.Size = new System.Drawing.Size(23, 22);
            this.tsbtnlockkeycombination.Text = "STRG+ALT+ENTF";
            this.tsbtnlockkeycombination.Click += new System.EventHandler(this.tsbtnlockkeycombination_Click);
            // 
            // axMsRdpClient10NotSafeForScripting1
            // 
            this.axMsRdpClient10NotSafeForScripting1.Enabled = true;
            this.axMsRdpClient10NotSafeForScripting1.Location = new System.Drawing.Point(0, 0);
            this.axMsRdpClient10NotSafeForScripting1.Name = "axMsRdpClient10NotSafeForScripting1";
            this.axMsRdpClient10NotSafeForScripting1.TabIndex = 0;
            // 
            // axMsRdpClient101
            // 
            this.axMsRdpClient101.Enabled = true;
            this.axMsRdpClient101.Location = new System.Drawing.Point(0, 0);
            this.axMsRdpClient101.Name = "axMsRdpClient101";
            this.axMsRdpClient101.TabIndex = 0;
            // 
            // rdp
            // 
            this.rdp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdp.Enabled = true;
            this.rdp.Location = new System.Drawing.Point(0, 25);
            this.rdp.Name = "rdp";
            this.rdp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdp.OcxState")));
            this.rdp.Size = new System.Drawing.Size(867, 554);
            this.rdp.TabIndex = 2;
            this.rdp.OnConnecting += new System.EventHandler(this.rdp_OnConnecting);
            this.rdp.OnConnected += new System.EventHandler(this.rdp_OnConnected);
            this.rdp.OnDisconnected += new AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEventHandler(this.rdp_OnDisconnected);
            // 
            // RemoteDesktopTabPageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 601);
            this.Controls.Add(this.rdp);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RemoteDesktopTabPageView";
            this.Text = "RemoteDesktopTabPageView";
            this.Shown += new System.EventHandler(this.RemoteDesktopTabPageView_Shown);
            this.SizeChanged += new System.EventHandler(this.RemoteDesktopTabPageView_SizeChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient10NotSafeForScripting1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private AxMSTSCLib.AxMsRdpClient10NotSafeForScripting axMsRdpClient10NotSafeForScripting1;
        private AxMSTSCLib.AxMsRdpClient10 axMsRdpClient101;
        private AxMSTSCLib.AxMsRdpClient9NotSafeForScripting rdp;
        private System.Windows.Forms.ToolStripButton tsbtnlockkeycombination;
    }
}