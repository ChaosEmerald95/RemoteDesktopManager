using RemoteDesktopManager.RdpConnections;
using System;
using System.Windows.Forms;

namespace RemoteDesktopManager
{
    /// <summary>
    /// Stellt einen Ordnereintrag in der RemoteDesktop-Liste dar
    /// </summary>
    public partial class RemoteDesktopListFolderItem : UserControl
    {
        private RdpFolderStructureEntry m_folder = null; //Die Daten des Ordners

        //Events
        public event RemoteDesktopItemRemoveEventHandler EntryRemove;
        public event RemoteDesktopItemChangedEventHandler EntryChanged;

        /// <summary>
        /// Erstellt eine neue Instanz von RemoteDesktopListFolderItem
        /// </summary>
        /// <param name="folderEntry">Die Daten des Ordners</param>
        public RemoteDesktopListFolderItem(RdpFolderStructureEntry folderEntry)
        {
            InitializeComponent();
            m_folder = folderEntry;
            lbfoldername.Text = folderEntry.Caption;

            //Events anbinden
            this.picimagerdp.DoubleClick += Redirect_DoubleClick;
            this.lbfoldername.DoubleClick += Redirect_DoubleClick;
        }

        /// <summary>
        /// Gibt die ID des Ordners zurück
        /// </summary>
        public int FolderId { get => m_folder.Id; }

        /// <summary>
        /// Event_Methode:
        /// Leitet das DoubleClick-Event an das UserControl weiter
        /// </summary>
        public void Redirect_DoubleClick(object sender, EventArgs e)
        {
            //Event weitergeben
            this.OnDoubleClick(e);
        }

        /// <summary>
        /// Event-Methode:
        /// Ermöglicht die Bearbeitung der Einstellungen
        /// </summary>
        private void tsmenuitemeditsettings_Click(object sender, EventArgs e)
        {
            frmfolderentry frm = new frmfolderentry(m_folder);
            frm.ShowDialog();
            if (frm.FolderData != null) //Wenn es nicht null ist, dann wurden die Änderungen gespeichert
            {
                //Änderungen speichern
                m_folder = frm.FolderData;

                //Control-Texte anpassen
                lbfoldername.Text = m_folder.Caption;

                //Event auslösen
                EntryChanged(m_folder);
            }
        }

        /// <summary>
        /// Event-Methode:
        /// Löscht nach erfolgreicher Bestätigung den Eintrag
        /// </summary>
        private void tsmenuitemsdelete_Click(object sender, EventArgs e)
        {
            //Bevor der Eintrag gelöscht wird 
            //muss der Benutzer den Löschvorgang bestätigen
            if (MessageBox.Show("Soll der Ordner wirklich werden?" + Environment.NewLine + Environment.NewLine + "Alle Einträge und Ordner in diesem Ordner werden mit entfernt", "Hinweis", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                EntryRemove(m_folder.Id);
        }
    }
}
