using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDesktopManager
{
    public partial class RemoteDesktopTabPageView : Form
    {
        public RemoteDesktopTabPageView(string host, string username, string password, string domain = "")
        {
            InitializeComponent();

            //RDP-Control einstellen
            rdp.Server = host;
            rdp.UserName = username;
            rdp.Domain = domain;

            //Settings für das Control
            rdp.ColorDepth = 32;
            rdp.AdvancedSettings9.ClearTextPassword = password;
            rdp.AdvancedSettings9.EnableAutoReconnect = true;
            rdp.AdvancedSettings9.EnableCredSspSupport = true; //Für Network Layer Authentification notwendig
            rdp.AdvancedSettings9.GrabFocusOnConnect = true;
            rdp.AdvancedSettings9.DisplayConnectionBar = true;
            rdp.AdvancedSettings9.EnableWindowsKey = 1;
            rdp.AdvancedSettings9.DisableCtrlAltDel = 1;
            rdp.AdvancedSettings9.allowBackgroundInput = 1;
            rdp.AdvancedSettings9.AcceleratorPassthrough = 1;
            rdp.AdvancedSettings9.BitmapPeristence = 1;
            rdp.AdvancedSettings9.Compress = 1;
            rdp.AdvancedSettings9.DoubleClickDetect = 1;
        }

        private void RemoteDesktopTabPageView_Shown(object sender, EventArgs e)
        {
            //Verbinden
            rdp.Connect();
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn die Größe des Controls geändert wird, dann soll dies auch für die RemoteDesktopVerbindung gelten
        /// </summary>
        private void RemoteDesktopTabPageView_SizeChanged(object sender, EventArgs e)
        {
            rdp.Dock = DockStyle.Fill;
            rdp.DesktopWidth = rdp.Size.Width;
            rdp.DesktopHeight = rdp.Size.Height;
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn die Verbindung getrennt wurde
        /// </summary>
        private void rdp_OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            //Zwingt die TabPage, zu verschwinden
            base.Parent.Dispose(); 
        }

        private void rdp_OnConnected(object sender, EventArgs e)
        {

        }

        private void rdp_OnConnecting(object sender, EventArgs e)
        {

        }
    }
}
