using RemoteDesktopManager.RdpConnections;
using System;
using System.Windows.Forms;

namespace RemoteDesktopManager
{
    /// <summary>
    /// Stellt einen Eintrag in der RemoteDesktop-Liste dar
    /// </summary>
    public partial class RemoteDesktopListItem : UserControl
    {
        private RdpFolderStructureRdpEntry m_rdp = null; //Das RemoteDesktop-Objekt mit den Daten
        private RemoteDesktopData m_data; //Die Daten der RemoeDesktop-Verbindung (deprecated)
        private int m_id = -1; //Die ID des Eintrags

        //Events
        public event RemoteDesktopItemRemoveEventHandler EntryRemove;
        public event RemoteDesktopItemConnectionChangedEventHandler EntryChanged;

        /// <summary>
        /// Erstellt eine neue Instanz von RemoteDesktopListItem
        /// </summary>
        /// <param name="rdpEntry">Die Daten zur Remote-Desktop-Verbindung</param>
        public RemoteDesktopListItem(RdpFolderStructureRdpEntry rdpEntry)
        {
            InitializeComponent();
            m_rdp = rdpEntry;
            m_data = new RemoteDesktopData(rdpEntry.HostName, rdpEntry.UserName, rdpEntry.Password, rdpEntry.Caption);
            lbconname.Text = m_rdp.Caption;
            lbip.Text = m_rdp.HostName;
            m_id = m_rdp.Id;

            //Wenn ein Passwort vergeben wurde, dann soll das ! angezeigt werden
            if (m_rdp.Password != "") lbpassword.Visible = true;
            else lbpassword.Visible = false;

            //Events anbinden
            picimagerdp.DoubleClick += Redirect_DoubleClick;
            lbconname.DoubleClick += Redirect_DoubleClick;
            lbip.DoubleClick += Redirect_DoubleClick;
            tsmenuitemconnect.DoubleClick += Redirect_DoubleClick;
        }

        /// <summary>
        /// Gibt die Informationen zur RemoteDesktop-Verbindung zurück
        /// </summary>
        public RemoteDesktopData RemoteDesktopData { get => m_data; }

        /// <summary>
        /// Event-Methode:
        /// Gibt dne DoubleClick weiter an das UserControl
        /// </summary>
        private void Redirect_DoubleClick(object sender, System.EventArgs e)
        {
            //Event weitergeben
            this.OnDoubleClick(e);
        }

        #region ContextMenuItems
        /// <summary>
        /// Event-Methode:
        /// Ermöglicht die Bearbeitung der Einstellungen
        /// </summary>
        private void tsmenuitemeditsettings_Click(object sender, System.EventArgs e)
        {
            frmremotedesktopentry frm = new frmremotedesktopentry(m_data); //Daten übergeben, damit diese bearbeitet werden können
            frm.ShowDialog();
            if (frm.RemoteDesktopData != null) //Wenn es nicht null ist, dann wurden die Änderungen gespeichert
            {
                m_data = frm.RemoteDesktopData; //Daten speichern

                //Control-Texte anpassen
                lbconname.Text = m_data.ConnectionName;
                lbip.Text = m_data.IpAdresse;

                //Wenn ein Passwort vergeben wurde, dann soll das ! angezeigt werden
                if (m_data.Password != "") lbpassword.Visible = true;
                else lbpassword.Visible = false;

                //Event auslösen
                EntryChanged(m_id, frm.RemoteDesktopData);
            }
        }

        /// <summary>
        /// Event-Methode:
        /// Löscht nach erfolgreicher Bestätigung den Eintrag
        /// </summary>
        private void tsmenuitemsdelete_Click(object sender, System.EventArgs e)
        {
            //Bevor der Eintrag gelöscht wird
            //muss der Benutzer den Löschvorgang bestätigen
            if (MessageBox.Show("Soll die RemoteDesktop-Verbindung wirklich gelöscht werden?", "Hinweis", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                EntryRemove(m_id);
        }
        #endregion
    }
}
