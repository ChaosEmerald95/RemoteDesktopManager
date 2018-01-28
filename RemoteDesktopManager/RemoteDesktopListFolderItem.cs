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
    }
}
