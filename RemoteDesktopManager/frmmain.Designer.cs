namespace RemoteDesktopManager
{
    partial class frmmain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenuitemdirectconnection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmenuitemcloseapplication = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoÜberRemoteDesktopManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextstriptabcontrol = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelsidemenu = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabc = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programmToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1274, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programmToolStripMenuItem
            // 
            this.programmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenuitemdirectconnection,
            this.toolStripSeparator1,
            this.tsmenuitemcloseapplication});
            this.programmToolStripMenuItem.Name = "programmToolStripMenuItem";
            this.programmToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.programmToolStripMenuItem.Text = "Programm";
            // 
            // tsmenuitemdirectconnection
            // 
            this.tsmenuitemdirectconnection.Name = "tsmenuitemdirectconnection";
            this.tsmenuitemdirectconnection.Size = new System.Drawing.Size(170, 22);
            this.tsmenuitemdirectconnection.Text = "Direkt verbinden...";
            this.tsmenuitemdirectconnection.Click += new System.EventHandler(this.direktVerbindenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // tsmenuitemcloseapplication
            // 
            this.tsmenuitemcloseapplication.Name = "tsmenuitemcloseapplication";
            this.tsmenuitemcloseapplication.Size = new System.Drawing.Size(170, 22);
            this.tsmenuitemcloseapplication.Text = "Beenden";
            this.tsmenuitemcloseapplication.Click += new System.EventHandler(this.tsmenuitemcloseapplication_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoÜberRemoteDesktopManagerToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // infoÜberRemoteDesktopManagerToolStripMenuItem
            // 
            this.infoÜberRemoteDesktopManagerToolStripMenuItem.Name = "infoÜberRemoteDesktopManagerToolStripMenuItem";
            this.infoÜberRemoteDesktopManagerToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.infoÜberRemoteDesktopManagerToolStripMenuItem.Text = "Info über RemoteDesktop-Manager";
            this.infoÜberRemoteDesktopManagerToolStripMenuItem.Click += new System.EventHandler(this.infoÜberRemoteDesktopManagerToolStripMenuItem_Click);
            // 
            // contextstriptabcontrol
            // 
            this.contextstriptabcontrol.Name = "contextstriptabcontrol";
            this.contextstriptabcontrol.Size = new System.Drawing.Size(61, 4);
            // 
            // panelsidemenu
            // 
            this.panelsidemenu.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelsidemenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelsidemenu.Location = new System.Drawing.Point(0, 24);
            this.panelsidemenu.Name = "panelsidemenu";
            this.panelsidemenu.Size = new System.Drawing.Size(215, 606);
            this.panelsidemenu.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(215, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 606);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // tabc
            // 
            this.tabc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabc.Location = new System.Drawing.Point(218, 24);
            this.tabc.Name = "tabc";
            this.tabc.SelectedIndex = 0;
            this.tabc.Size = new System.Drawing.Size(1056, 606);
            this.tabc.TabIndex = 4;
            this.tabc.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tabc_ControlRemoved);
            this.tabc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabc_MouseClick);
            // 
            // frmmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1274, 630);
            this.Controls.Add(this.tabc);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelsidemenu);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmmain";
            this.Text = "RemoteDesktop-Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmenuitemdirectconnection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmenuitemcloseapplication;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoÜberRemoteDesktopManagerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextstriptabcontrol;
        private System.Windows.Forms.Panel panelsidemenu;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tabc;
    }
}

