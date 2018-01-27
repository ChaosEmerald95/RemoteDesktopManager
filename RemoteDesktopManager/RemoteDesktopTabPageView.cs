using LOG = RemoteDesktopManager.RdpLog;
using DEBUG = RemoteDesktopManager.DebugRdpLog;
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
        private bool m_isreconnecting = false; //Wenn das true ist, dann darf das Disconnected-Event die TabPage nicht disposen

        //Variablen für spätere Reconnects
        private string m_host = "";
        private string m_username = "";
        private string m_password = "";
        private string m_domain = "";

        public RemoteDesktopTabPageView(string host, string username, string password, string domain = "")
        {
            InitializeComponent();

            //Variablen für spätere Reconnects zwischenspeichern
            m_host = host;
            m_username = username;
            m_password = password;
            m_domain = domain;
            DEBUG.ShowMessageInConsole("Storing Connection-Information - Host: " + host + "|Username: " + username + "|Domain: " + domain + "|Password: " + password);

            //Titel festlegen
            Text = "Verbindung mit " + ((char)34) + host + ((char)34);

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
            LOG.StoreRdpLogMessage("Rdp-ActiveX-Control: Start connection to '" + m_host + "'");
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: Start connection to '" + m_host + "'");
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn die Größe des Controls geändert wird, dann soll dies auch für die RemoteDesktopVerbindung gelten
        /// </summary>
        private void RemoteDesktopTabPageView_SizeChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Gibt dem RemoteDesktop-Steuerelement den Befehl, die Verbindung zu schliessen
        /// </summary>
        public void Disconnect()
        {
            if (rdp.Connected != 0)
            {
                rdp.Disconnect();
            }
        }

        /// <summary>
        /// Trennt die Verbindung und stellt die erneut her
        /// </summary>
        /// <param name="fullscreen">Wenn Vollbild, dann wird die Auflösung entsprechend angepasst. Wenn false, dann wird es an die Größe des Controls gebunden</param>
        private void Reconnect(bool fullscreen = false)
        {
            m_isreconnecting = true; //Damit die Events Bescheid wissen
            Disconnect();

            //Solange das TRennen noch dauert, Programm festhalten
            while (rdp.Connected != 0)
            {
                System.Threading.Thread.Sleep(1000);
                Application.DoEvents();
            }

            //Verbindung erneut herstellen. Vorher die Einstellungen anpassen
            if (fullscreen)
            {
                rdp.DesktopWidth = Screen.PrimaryScreen.Bounds.Width;
                rdp.DesktopHeight = Screen.PrimaryScreen.Bounds.Height;
                rdp.FullScreen = true;
            }
            else
            {
                rdp.DesktopWidth = rdp.Width;
                rdp.DesktopHeight = rdp.Height;
                rdp.FullScreen = false;
            }

            //Verbindung herstellen
            rdp.Connect();
            m_isreconnecting = false; //Damit die Events Bescheid wissen
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn die Verbindung getrennt wurde
        /// </summary>
        private void rdp_OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            LOG.StoreRdpLogMessage("Rdp-ActiveX-Control: Disconnected from host '" + m_host + "'");
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: Disconnected from host '" + m_host + "' - Disconnect-Code: " + e.discReason.ToString());

            //Wenn m_isreconnecting false ist, dann dies ausführen
            if (!m_isreconnecting)
            {
                //Zwingt die TabPage, zu verschwinden
                base.Parent.Dispose();
            }
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn die Verbindung hergestellt wurde
        /// </summary>
        private void rdp_OnConnected(object sender, EventArgs e)
        {
            LOG.StoreRdpLogMessage("Rdp-ActiveX-Control: Connected to host '" + m_host + "'");
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: Connected to host '" + m_host + "'");
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn eine Verbindung hergestellt wird
        /// </summary>
        private void rdp_OnConnecting(object sender, EventArgs e)
        {
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: Connecting to host");
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

        /// <summary>
        /// Event-Methode:
        /// Schaltet das RDP-Control in den Vollbild-Modus
        /// </summary>
        private void tsbtnfullscreen_Click(object sender, EventArgs e)
        {
            rdp.FullScreenTitle = rdp.Server;
            Reconnect(true);
        }

        /// <summary>
        /// Event-Methode:
        /// Schaltet das RDP-Control in den FitToScreen-Modus
        /// </summary>
        private void rdp_OnLeaveFullScreenMode(object sender, EventArgs e)
        {
            Reconnect();
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn eine Warnung aufgetreten ist
        /// </summary>
        private void rdp_OnWarning(object sender, AxMSTSCLib.IMsTscAxEvents_OnWarningEvent e)
        {
            LOG.StoreWarningRdpLogMessage("Rdp-ActiveX-Control: A Warning has been appeared - Warning-Code: " + e.warningCode.ToString());
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: A Warning has been appeared - Warning-Code: " + e.warningCode.ToString(), DEBUG.DebugMessageType.Warning);
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn ein Fehler aufgetreten ist
        /// </summary>
        private void rdp_OnFatalError(object sender, AxMSTSCLib.IMsTscAxEvents_OnFatalErrorEvent e)
        {
            LOG.StoreErrorRdpLogMessage("Rdp-ActiveX-Control: An FatalError has been appeared - Error-Code: " + e.errorCode.ToString());
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: An FatalError has been appeared - Error-Code: " + e.errorCode.ToString(), DEBUG.DebugMessageType.Error);
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn ein Problem bei der Anmeldung aufgetreten ist
        /// </summary>
        private void rdp_OnLogonError(object sender, AxMSTSCLib.IMsTscAxEvents_OnLogonErrorEvent e)
        {
            LOG.StoreErrorRdpLogMessage("Rdp-ActiveX-Control: A LoginError has been appeared - Error-Code: " + e.lError.ToString());
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: A LoginError has been appeared - Error-Code: " + e.lError.ToString(), DEBUG.DebugMessageType.Error);
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn die Anmeldung erfolgreich war
        /// </summary>
        private void rdp_OnLoginComplete(object sender, EventArgs e)
        {
            LOG.StoreRdpLogMessage("Rdp-ActiveX-Control: Login with '" + m_host + "' has been succeed");
            if (m_domain == "")
                DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: Login with '" + m_host + "' has been succeed - Username: " + Environment.UserDomainName + @"\" + m_username);
            else
                DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: Login with '" + m_host + "' has been succeed - Username: " + m_domain + @"\" + m_username);
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn sich das Netzwerk geändert hat
        /// </summary>
        private void rdp_OnNetworkStatusChanged(object sender, AxMSTSCLib.IMsTscAxEvents_OnNetworkStatusChangedEvent e)
        {
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: The Network-State has been changed - Quality-Level: " + e.qualityLevel.ToString() + "| Bandwidth: " + e.bandwidth.ToString() + "|rtt: " + e.rtt.ToString());
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn sich die Auflösung des RemoteDesktops verändert hat
        /// </summary>
        private void rdp_OnRemoteDesktopSizeChange(object sender, AxMSTSCLib.IMsTscAxEvents_OnRemoteDesktopSizeChangeEvent e)
        {
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: The RemoteDesktop-Size has been changed - New Resolution: " + e.width.ToString() + "x" + e.height.ToString());
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn eine Warnung bei der Anmeldung angezeigt wird
        /// </summary>
        private void rdp_OnAuthenticationWarningDisplayed(object sender, EventArgs e)
        {
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: A warning at the login has been displayed", DEBUG.DebugMessageType.Warning);
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn sich der Client automatisch neu verbunden hat
        /// </summary>
        private void rdp_OnAutoReconnected(object sender, EventArgs e)
        {
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: The RdpClient has automatically reconnected");
        }

        /*
        private bool rdp_OnConfirmClose(object sender, AxMSTSCLib.IMsTscAxEvents_OnConfirmCloseEvent e)
        {
            
        }*/

        /// <summary>
        /// Event-Methode:
        /// Wenn der öffentliche Schlüssel empfangen wurde
        /// </summary>
        private bool rdp_OnReceivedTSPublicKey(object sender, AxMSTSCLib.IMsTscAxEvents_OnReceivedTSPublicKeyEvent e)
        {
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: TSPublicKey received - PublicKey: " + e.publicKey);
            return true;
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn eine Nachricht empfangen wurde vom Service (Dienst)
        /// </summary>
        private void rdp_OnServiceMessageReceived(object sender, AxMSTSCLib.IMsTscAxEvents_OnServiceMessageReceivedEvent e)
        {
            DEBUG.ShowMessageInConsole("Rdp-ActiveX-Control: A ServiceMessage has been received - Message: " + e.serviceMessage);
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
