using RemoteDesktopManager.RdpConnections;
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
    /// Ermöglicht eine direkte Verbindung zu einem Computer
    /// </summary>
    public partial class frmenterconnectiondata : Form
    {
        private RdpFolderStructureRdpEntry m_rdp = null; //Speichert die Verbindungsdaten zwischen (zumindest ein Teil davon)

        /// <summary>
        /// Erstellt eine neue Instanz von frmenterconnectiondata
        /// </summary>
        public frmenterconnectiondata()
        {
            InitializeComponent();
            txtcomputer.KeyDown += TextBox_KeyDown;
            txtusername.KeyDown += TextBox_KeyDown;
        }

        /// <summary>
        /// Gibt die RemoteDesktop-Daten zurück, die gespeichert wurden. Wenn der Wert null ist, dann wurde das ganze abgebrochen
        /// </summary>
        public RdpFolderStructureRdpEntry RemoteDesktopData
        {
            get => m_rdp;
        }

        /// <summary>
        /// Event-Methode:
        /// Speichert die Daten und schliesst das Fenster
        /// </summary>
        private void btnconnect_Click(object sender, EventArgs e)
        {
            //Die Eingaben überprüfen
            if (txtcomputer.Text == "")
            {
                MessageBox.Show("Geben Sie eine Adresse ein", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtusername.Text == "")
            {
                MessageBox.Show("Geben Sie einen Benutzernamen ein", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Daten speichern
            m_rdp = new RdpFolderStructureRdpEntry();
            m_rdp.HostName = txtcomputer.Text;
            m_rdp.UserName = txtusername.Text;

            //Schliessen
            Close();
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn auf ENTER gedrückt wird, dann soll das Button-Event ausgelöst werden
        /// </summary>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnconnect_Click(this, null);
        }
    }
}
