using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
            rdp.AdvancedSettings9.allowBackgroundInput = 1;
            rdp.AdvancedSettings2.AcceleratorPassthrough = -1;
            rdp.AdvancedSettings9.BitmapPeristence = 1;
            rdp.AdvancedSettings9.Compress = 1;
            rdp.AdvancedSettings9.DoubleClickDetect = 1;
            rdp.AdvancedSettings9.SmartSizing = true;
            rdp.AdvancedSettings2.DisableCtrlAltDel = -1;
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
        /// Gibt dem RemoteDesktop-Steuerelement den Befehl, die Verbindung zu schliessen
        /// </summary>
        public void Disconnect()
        {
            rdp.Disconnect();
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

        /// <summary>
        /// Event-Methode:
        /// Sendet der RDP-Sitzung die Tastenkombination STRG+ALT+ENTF
        /// </summary>
        private void tsbtnlockkeycombination_Click(object sender, EventArgs e)
        {
            //Erstellt ein Wrapper-Objekt, um "SendKeys" nutzen zu können
            MsRdpClientNonScriptableWrapper t_wrapper = new MsRdpClientNonScriptableWrapper(rdp.GetOcx());

            //0x1d: CONTROL
            //0x38: MENU / ALT
            //0x53: DEL
            t_wrapper.SendKeys(new int[] { 0x1d, 0x38, 0x53, 0x53, 0x38, 0x1d}, new bool[] { false, false, false, true, true, true });
        }
    }

    /// <summary>
    /// Ermöglicht den Einsatz von SendKeys bei Remote-Desktop-Anwendungen
    /// Quelle: https://social.msdn.microsoft.com/Forums/windowsdesktop/en-US/9095625c-4361-4e0b-bfcf-be15550b60a8/imsrdpclientnonscriptablesendkeys?forum=windowsgeneraldevelopmentissues
    /// </summary>
    internal class MsRdpClientNonScriptableWrapper
    {
        #region Inline Interface Definition
        [InterfaceType(1)]
        [Guid("2F079C4C-87B2-4AFD-97AB-20CDB43038AE")]
        private interface IMsRdpClientNonScriptable_Sendkeys : MSTSCLib.IMsTscNonScriptable
        {
#pragma warning disable CS0108
            [DispId(4)]
            string BinaryPassword { get; set; }
            [DispId(5)]
            string BinarySalt { get; set; }
            [DispId(1)]
            string ClearTextPassword { set; }
            [DispId(2)]
            string PortablePassword { get; set; }
            [DispId(3)]
            string PortableSalt { get; set; }


            void NotifyRedirectDeviceChange(uint wParam, int lParam);
            void ResetPassword();
#pragma warning restore CS0108

            unsafe void SendKeys(int numKeys, int* pbArrayKeyUp, int* plKeyData);
        }
        #endregion

        private IMsRdpClientNonScriptable_Sendkeys m_ComInterface;

        public MsRdpClientNonScriptableWrapper(object ocx)
        {
            m_ComInterface = (IMsRdpClientNonScriptable_Sendkeys)ocx;
        }

        // keyScanCodes takes the ScanCodes of the pressed keys (1 byte scancode, offset: 0)
        // (Hello Keyboard Layout Nightmares! Why the ____ does Rdp not send virtual keycodes?)

        // XX...XXSSSSSSSS  *S = 1 Bit of the Scancode
        public void SendKeys(int[] keyScanCodes, bool[] keyReleased)
        {
            if (keyScanCodes.Length != keyReleased.Length) throw new ArgumentException("MsRdpClientNonScriptableWrapper.SendKeys: Arraysize must match");
            // at this point I'd rather stay away from everything that does marshalling or converts bools, so we'll do the
            // conversion this way.

            int[] temp = new int[keyReleased.Length];
            for (int i = 0; i < temp.Length; i++) temp[i] = keyReleased[i] ? 1 : 0;

            unsafe
            {
                fixed (int* pScanCodes = keyScanCodes)
                fixed (int* pKeyReleased = temp)
                {
                    m_ComInterface.SendKeys(keyScanCodes.Length, pKeyReleased, pScanCodes);
                }
            }
        }
    }
}
