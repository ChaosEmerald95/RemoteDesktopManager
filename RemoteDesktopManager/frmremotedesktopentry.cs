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
    /// ermöglicht die Erstellung bzw. Bearbeitung eines Eintrags aus der RemoteDesktopList
    /// </summary>
    public partial class frmremotedesktopentry : Form
    {
        private RdpFolderStructureRdpEntry m_rdp = null; //Hier werden die Daten zu der Rdp-Verbindung gespeichert
        private RdpFolderStructureRdpEntry t_rdp = null; //Zwischenspeicher für die Bearbeitung der Daten

        /// <summary>
        /// Erstellt eine neue Instanz von frmremotedesktopentry.
        /// Dieser Konstruktor ist für die Erstellung von neuen Einträgen zuständig
        /// </summary>
        public frmremotedesktopentry()
        {
            InitializeComponent();
            BindEvents();

            //Title anpassen
            Text = "Neue Verbindung erstellen...";
        }

        /// <summary>
        /// Erstellt eine neue Instanz von frmremotedesktopentry.
        /// Dieser Konstruktor ist für die Bearbeitung eines bestehenden Eintrags zuständig
        /// </summary>
        /// <param name="rdpEntry">Die Daten zur Rdp-Verbindung</param>
        public frmremotedesktopentry(RdpFolderStructureRdpEntry rdpEntry)
        {
            InitializeComponent();
            BindEvents();
            t_rdp = rdpEntry;

            //Werte anzeigen
            txtconnectionname.Text = rdpEntry.Caption;
            txthostname.Text = rdpEntry.HostName;
            txtusername.Text = rdpEntry.UserName;
            txtpassword.Text = rdpEntry.Password;
            txtbemerkung.Text = rdpEntry.Bemerkung;
            chpinghost.Checked = rdpEntry.PingHost;
            
            //Title anpassen
            Text = "Verbindung bearbeiten";
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
        /// Die Daten speichern
        /// </summary>
        private void btnsavedata_Click(object sender, EventArgs e)
        {
            //Erstmal überprüfen, ob in die ersten 3 Felder was gespeichert wurde
            if (txtconnectionname.Text == "") { MessageBox.Show("Es muss ein Verbindungsname vergeben werden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (txthostname.Text == "") { MessageBox.Show("Es muss eine gültige Adresse eingegeben werden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (txtusername.Text == "") { MessageBox.Show("Es muss ein Username eingegeben werden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            //Struktur erstellen
            m_rdp = new RdpFolderStructureRdpEntry();
            if (t_rdp != null) //Wenn Daten zwischengespeichert wurden, sollen diese jetzt übernommen werden
            {
                m_rdp.Id = t_rdp.Id;
                m_rdp.ParentId = t_rdp.ParentId;
                m_rdp.Caption = t_rdp.Caption;
                m_rdp.Type = t_rdp.Type;
                m_rdp.Bemerkung = t_rdp.Bemerkung;
                m_rdp.HostName = t_rdp.HostName;
                m_rdp.UserName = t_rdp.UserName;
                m_rdp.Password = t_rdp.Password;
                m_rdp.PingHost = t_rdp.PingHost;
            }

            //DIe aktuellen Einstellungen speichern
            m_rdp.Caption = txtconnectionname.Text;
            m_rdp.HostName = txthostname.Text;
            m_rdp.UserName = txtusername.Text;
            m_rdp.Password = txtpassword.Text;
            m_rdp.Bemerkung = txtbemerkung.Text;
            m_rdp.PingHost = chpinghost.Checked;

            //Fenster schliessen
            Close();
        }

        /// <summary>
        /// Dient der Event-Anbindung der TextBoxen
        /// </summary>
        private void BindEvents()
        {
            txtconnectionname.KeyDown += TextBox_KeyDown;
            txthostname.KeyDown += TextBox_KeyDown;
            txtusername.KeyDown += TextBox_KeyDown;
            txtpassword.KeyDown += TextBox_KeyDown;
            txtbemerkung.KeyDown += TextBox_KeyDown;
            chpinghost.KeyDown += TextBox_KeyDown;
        }

        /// <summary>
        /// Event-Methode:
        /// Löst die Speicherfunktion aus, wenn auf Enter gedrückt wird
        /// </summary>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Speicherevent triggern
            if (e.KeyCode == Keys.Enter) btnsavedata_Click(this, null);
        }
    }
}
