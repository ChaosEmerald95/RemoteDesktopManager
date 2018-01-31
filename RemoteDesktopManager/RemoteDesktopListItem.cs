using System;
using System.Windows.Forms;

namespace RemoteDesktopManager
{
    /// <summary>
    /// Stellt einen Eintrag in der RemoteDesktop-Liste dar
    /// </summary>
    public partial class RemoteDesktopListItem : UserControl
    {
        private RemoteDesktopData m_data; //Die Daten der RemoeDesktop-Verbindung
        private int m_id = -1; //Die ID des Eintrags

        //Events
        public event RemoteDesktopItemRemoveEventHandler EntryRemove;
        public event RemoteDesktopItemConnectionChangedEventHandler EntryChanged;

        /// <summary>
        /// Erstellt eine neue Instanz von RemoteDesktopListItem
        /// </summary>
        /// <param name="rdpData">Die Daten zur Remote-Desktop-Verbindung</param>
        /// <param name="id">Die ID des Eintrags in der Datenbank</param>
        public RemoteDesktopListItem(RemoteDesktopData rdpData, int id)
        {
            InitializeComponent();
            m_data = rdpData;
            lbconname.Text = rdpData.ConnectionName;
            lbip.Text = rdpData.IpAdresse;
            m_id = id;

            //Wenn ein Passwort vergeben wurde, dann soll das ! angezeigt werden
            if (m_data.Password != "") lbpassword.Visible = true;
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
