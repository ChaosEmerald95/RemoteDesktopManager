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
    /// ermöglicht die Erstellung bzw. Bearbeitung eines Eintrags aus der RemoteDesktopList
    /// </summary>
    public partial class frmremotedesktopentry : Form
    {
        private RemoteDesktopData m_rdpdata = null; //Hier werden die Remote-Desktop-Daten gespeichert

        /// <summary>
        /// Erstellt eine neue Instanz von frmremotedesktopentry.
        /// Dieser Konstruktor ist für die Erstellung von neuen Einträgen zuständig
        /// </summary>
        public frmremotedesktopentry()
        {
            InitializeComponent();

            //Title anpassen
            Text = "Neue Verbindung erstellen...";
        }

        /// <summary>
        /// Erstellt eine neue Instanz von frmremotedesktopentry.
        /// Dieser Konstruktor ist für die Bearbeitung eines bestehenden Eintrags zuständig
        /// </summary>
        public frmremotedesktopentry(RemoteDesktopData rdpData)
        {
            InitializeComponent();

            //Werte anzeigen
            txthostname.Text = rdpData.IpAdresse;
            txtusername.Text = rdpData.Username;
            txtpassword.Text = rdpData.Password;
            txtconnectionname.Text = rdpData.ConnectionName;
            
            //Title anpassen
            Text = "Verbindung bearbeiten";
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
        /// Die Daten speichern
        /// </summary>
        private void btnsavedata_Click(object sender, EventArgs e)
        {
            //Erstmal überprüfen, ob in die ersten 3 Felder was gespeichert wurde
            if (txtconnectionname.Text == "") { MessageBox.Show("Es muss ein Verbindungsname vergeben werden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (txthostname.Text == "") { MessageBox.Show("Es muss eine gültige Adresse eingegeben werden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (txtusername.Text == "") { MessageBox.Show("Es muss ein Username eingegeben werden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            //Wenn die Überprüfungen überstanden sind, wird das ganze in ein RemoteDesktopData-Objekt gespeichert
            m_rdpdata = new RemoteDesktopData(txthostname.Text, txtusername.Text, txtpassword.Text, txtconnectionname.Text);

            //Fenster schliessen
            Close();
        }
    }
}
