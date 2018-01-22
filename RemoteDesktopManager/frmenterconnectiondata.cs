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
        private RemoteDesktopData m_rdpdata = null;

        /// <summary>
        /// Erstellt eine neue Instanz von frmenterconnectiondata
        /// </summary>
        public frmenterconnectiondata()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gibt die RemoteDesktop-Daten zurück, die gespeichert wurden. Wenn der Wert null ist, dann wurde das ganze abgebrochen
        /// </summary>
        public RemoteDesktopData RemoteDesktopData
        {
            get => m_rdpdata;
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
            m_rdpdata = new RemoteDesktopData(txtcomputer.Text, txtusername.Text, "", txtcomputer.Text);

            //Schliessen
            Close();
        }
    }
}
