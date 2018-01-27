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
    /// <summary>
    /// Zeigt das Verbindungsqualitätsfenster zu der Rdp-Verbindung an
    /// </summary>
    public partial class frmshowrdpqualitystate : Form
    {
        /// <summary>
        /// Erstellt eine neue Instanz von frmshowrdpqualitystate
        /// </summary>
        /// <param name="qualityLevel">Das aktuelle Qualitätslevel der Verbindung</param>
        public frmshowrdpqualitystate(int qualityLevel)
        {
            InitializeComponent();

            //Per Switch-Case die Fälle durchgehen
            switch (qualityLevel)
            {
                case 1: lbmessage.Text = "Die Qualität der Verbindung mit dem Remotecomputer ist schlecht."; break;
                case 2: lbmessage.Text = "Die Qualität der Verbindung mit dem Remotecomputer ist gut."; break;
                case 3: lbmessage.Text = "Die Qualität der Verbindung mit dem Remotecomputer ist sehr gut."; break;
                case 4: lbmessage.Text = "Die Qualität der Verbindung mit dem Remotecomputer ist hervorragend."; break;
                default: lbmessage.Text = "Die Qualität der Verbindung mit dem Remotecomputer ist unbekannt."; break;
            }
        }
    }
}
