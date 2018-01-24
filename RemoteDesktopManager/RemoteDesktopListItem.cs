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

        /// <summary>
        /// Erstellt eine neue Instanz von RemoteDesktopListItem
        /// </summary>
        /// <param name="rdpData">Die Daten zur Remote-Desktop-Verbindung</param>
        public RemoteDesktopListItem(RemoteDesktopData rdpData)
        {
            InitializeComponent();
            m_data = rdpData;
            lbconname.Text = rdpData.ConnectionName;
            lbip.Text = rdpData.IpAdresse;
        }

        /// <summary>
        /// Gibt die Informationen zur RemoteDesktop-Verbindung zurück
        /// </summary>
        public RemoteDesktopData RemoteDesktopData { get => m_data; }

        #region DoubleClickRedirection
        //Die Methoden dienen nur zur Weiterleitung des DoubleClick-Events, damit auch da
        //das Event ausgelöst wird

        private void picimagerdp_DoubleClick(object sender, System.EventArgs e)
        {
            //Event weitergeben
            this.OnDoubleClick(e);
        }

        private void lbconname_DoubleClick(object sender, System.EventArgs e)
        {
            //Event weitergeben
            this.OnDoubleClick(e);
        }

        private void lbip_DoubleClick(object sender, System.EventArgs e)
        {
            //Event weitergeben
            this.OnDoubleClick(e);
        }
        #endregion

        #region ContextMenuItems
        /// <summary>
        /// Event-Methode:
        /// Verbindet mit dem Computer
        /// </summary>
        private void tsmenuitemconnect_Click(object sender, System.EventArgs e)
        {
            //Event weitergeben
            this.OnDoubleClick(e);
        }

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
            }
        }

        /// <summary>
        /// Event-Methode:
        /// Löscht nach erfolgreicher Bestätigung den Eintrag
        /// </summary>
        private void tsmenuitemsdelete_Click(object sender, System.EventArgs e)
        {
            //Bevor der Eintrag gelöscht wird (eigentlich wird der nur disposed, aber egal xD)
            //muss der Benutzer den Löschvorgang bestätigen
            if (MessageBox.Show("Soll die RemoteDesktop-Verbindung wirklich gelöscht werden?" + Environment.NewLine + Environment.NewLine + "Die Änderung wird erst durch die Speicherung der Einträge übernommen", "Hinweis", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Dispose(); //Control disposen
        }
        #endregion
    }
}
