using System;
using System.Windows.Forms;

namespace RemoteDesktopManager
{
    /// <summary>
    /// Stellt einen Ordnereintrag in der RemoteDesktop-Liste dar
    /// </summary>
    public partial class RemoteDesktopListFolderItem : UserControl
    {
        private int m_folderid = -1; //Die ID des Ordners

        //Events
        public event RemoteDesktopItemRemoveEventHandler EntryRemove;
        public event RemoteDesktopItemFolderChangedEventHandler EntryChanged;

        /// <summary>
        /// Erstellt eine neue Instanz von RemoteDesktopListFolderItem
        /// </summary>
        /// <param name="folderId">Die ID des Ordners</param>
        /// <param name="folderName">Der Name des Ordners</param>
        public RemoteDesktopListFolderItem(int folderId, string folderName)
        {
            InitializeComponent();
            m_folderid = folderId;
            lbfoldername.Text = folderName;

            //Events anbinden
            this.picimagerdp.DoubleClick += Redirect_DoubleClick;
            this.lbfoldername.DoubleClick += Redirect_DoubleClick;
        }

        /// <summary>
        /// Gibt die ID des Ordners zurück
        /// </summary>
        public int FolderId { get => m_folderid; }

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
            frmenterfolderdata frm = new frmenterfolderdata(lbfoldername.Text);
            frm.ShowDialog();
            if (frm.FolderName != "") //Wenn es nicht null ist, dann wurden die Änderungen gespeichert
            {
                //Control-Texte anpassen
                lbfoldername.Text = frm.FolderName;

                //Event auslösen
                EntryChanged(m_folderid, frm.FolderName);
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
                EntryRemove(m_folderid);
        }
    }
}
