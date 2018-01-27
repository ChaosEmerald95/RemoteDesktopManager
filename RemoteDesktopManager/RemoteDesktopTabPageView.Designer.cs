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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnlockkeycombination = new System.Windows.Forms.ToolStripButton();
            this.tsbtnfullscreen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnconnectionqualitiy = new System.Windows.Forms.ToolStripButton();
            this.axMsRdpClient10NotSafeForScripting1 = new AxMSTSCLib.AxMsRdpClient10NotSafeForScripting();
            this.axMsRdpClient101 = new AxMSTSCLib.AxMsRdpClient10();
            this.tsstripstatus = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tslbbandwidth = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tslbping = new System.Windows.Forms.ToolStripLabel();
            this.rdp = new AxMSTSCLib.AxMsRdpClient9NotSafeForScripting();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient10NotSafeForScripting1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient101)).BeginInit();
            this.tsstripstatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightGray;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnlockkeycombination,
            this.tsbtnfullscreen,
            this.toolStripSeparator1,
            this.tsbtnconnectionqualitiy});
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
            // tsbtnfullscreen
            // 
            this.tsbtnfullscreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnfullscreen.Image = global::RemoteDesktopManager.Properties.Resources.icon_fullscreen;
            this.tsbtnfullscreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnfullscreen.Name = "tsbtnfullscreen";
            this.tsbtnfullscreen.Size = new System.Drawing.Size(23, 22);
            this.tsbtnfullscreen.Text = "Vollbild";
            this.tsbtnfullscreen.Click += new System.EventHandler(this.tsbtnfullscreen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnconnectionqualitiy
            // 
            this.tsbtnconnectionqualitiy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnconnectionqualitiy.Image = global::RemoteDesktopManager.Properties.Resources.icon_rdpquality_level0;
            this.tsbtnconnectionqualitiy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnconnectionqualitiy.Name = "tsbtnconnectionqualitiy";
            this.tsbtnconnectionqualitiy.Size = new System.Drawing.Size(23, 22);
            this.tsbtnconnectionqualitiy.Text = "Verbindungsqualität";
            this.tsbtnconnectionqualitiy.Click += new System.EventHandler(this.tsbtnconnectionquality_Click);
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
            // tsstripstatus
            // 
            this.tsstripstatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsstripstatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsstripstatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tslbbandwidth,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.tslbping});
            this.tsstripstatus.Location = new System.Drawing.Point(0, 576);
            this.tsstripstatus.Name = "tsstripstatus";
            this.tsstripstatus.Size = new System.Drawing.Size(867, 25);
            this.tsstripstatus.TabIndex = 2;
            this.tsstripstatus.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(67, 22);
            this.toolStripLabel1.Text = "Bandbreite:";
            // 
            // tslbbandwidth
            // 
            this.tslbbandwidth.Name = "tslbbandwidth";
            this.tslbbandwidth.Size = new System.Drawing.Size(12, 22);
            this.tslbbandwidth.Text = "-";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(34, 22);
            this.toolStripLabel2.Text = "Ping:";
            // 
            // tslbping
            // 
            this.tslbping.Name = "tslbping";
            this.tslbping.Size = new System.Drawing.Size(12, 22);
            this.tslbping.Text = "-";
            // 
            // rdp
            // 
            this.rdp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdp.Enabled = true;
            this.rdp.Location = new System.Drawing.Point(0, 25);
            this.rdp.Name = "rdp";
            this.rdp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdp.OcxState")));
            this.rdp.Size = new System.Drawing.Size(867, 551);
            this.rdp.TabIndex = 3;
            this.rdp.OnConnecting += new System.EventHandler(this.rdp_OnConnecting);
            this.rdp.OnConnected += new System.EventHandler(this.rdp_OnConnected);
            this.rdp.OnLoginComplete += new System.EventHandler(this.rdp_OnLoginComplete);
            this.rdp.OnDisconnected += new AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEventHandler(this.rdp_OnDisconnected);
            this.rdp.OnLeaveFullScreenMode += new System.EventHandler(this.rdp_OnLeaveFullScreenMode);
            this.rdp.OnFatalError += new AxMSTSCLib.IMsTscAxEvents_OnFatalErrorEventHandler(this.rdp_OnFatalError);
            this.rdp.OnWarning += new AxMSTSCLib.IMsTscAxEvents_OnWarningEventHandler(this.rdp_OnWarning);
            this.rdp.OnRemoteDesktopSizeChange += new AxMSTSCLib.IMsTscAxEvents_OnRemoteDesktopSizeChangeEventHandler(this.rdp_OnRemoteDesktopSizeChange);
            this.rdp.OnReceivedTSPublicKey += new AxMSTSCLib.IMsTscAxEvents_OnReceivedTSPublicKeyEventHandler(this.rdp_OnReceivedTSPublicKey);
            this.rdp.OnLogonError += new AxMSTSCLib.IMsTscAxEvents_OnLogonErrorEventHandler(this.rdp_OnLogonError);
            this.rdp.OnServiceMessageReceived += new AxMSTSCLib.IMsTscAxEvents_OnServiceMessageReceivedEventHandler(this.rdp_OnServiceMessageReceived);
            this.rdp.OnNetworkStatusChanged += new AxMSTSCLib.IMsTscAxEvents_OnNetworkStatusChangedEventHandler(this.rdp_OnNetworkStatusChanged);
            this.rdp.OnAutoReconnected += new System.EventHandler(this.rdp_OnAutoReconnected);
            // 
            // RemoteDesktopTabPageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 601);
            this.Controls.Add(this.rdp);
            this.Controls.Add(this.tsstripstatus);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemoteDesktopTabPageView";
            this.Text = "RemoteDesktopTabPageView";
            this.Shown += new System.EventHandler(this.RemoteDesktopTabPageView_Shown);
            this.SizeChanged += new System.EventHandler(this.RemoteDesktopTabPageView_SizeChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient10NotSafeForScripting1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient101)).EndInit();
            this.tsstripstatus.ResumeLayout(false);
            this.tsstripstatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private AxMSTSCLib.AxMsRdpClient10NotSafeForScripting axMsRdpClient10NotSafeForScripting1;
        private AxMSTSCLib.AxMsRdpClient10 axMsRdpClient101;
        private System.Windows.Forms.ToolStripButton tsbtnlockkeycombination;
        private System.Windows.Forms.ToolStripButton tsbtnfullscreen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnconnectionqualitiy;
        private System.Windows.Forms.ToolStrip tsstripstatus;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel tslbbandwidth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel tslbping;
        private AxMSTSCLib.AxMsRdpClient9NotSafeForScripting rdp;
    }
}