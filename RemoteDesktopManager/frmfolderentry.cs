using RemoteDesktopManager.RdpConnections;
using System;
using System.Windows.Forms;

namespace RemoteDesktopManager
{
    /// <summary>
    /// Ermöglicht die Erstellung eines Ordners für die Struktur
    /// </summary>
    public partial class frmfolderentry : Form
    {
        private RdpFolderStructureEntry m_folder = null; //Die Daten des Ordners
        private RdpFolderStructureEntry t_folder = null; //Für den zweiten Konstruktor, damit die Daten zwischengespeichert sind

        /// <summary>
        /// Erstellt eine neue Instanz von frmcreatefolder.
        /// Konstruktor für das Anlegen von neuen Ordnern
        /// </summary>
        public frmfolderentry()
        {
            InitializeComponent();
            BindEvents();
        }

        /// <summary>
        /// Erstellt eine neue Instanz von frmcreatefolder.
        /// Konstruktor für das Bearbeiten eines Ordners
        /// </summary>
        /// <param name="folderEntry">Die Daten des Ordners</param>
        public frmfolderentry(RdpFolderStructureEntry folderEntry)
        {
            InitializeComponent();
            t_folder = folderEntry;
            txtfoldername.Text = t_folder.Caption;
            Text = "Ordner bearbeiten";
            BindEvents();
        }

        /// <summary>
        /// Gibt die Ordner-Daten zurück
        /// </summary>
        public RdpFolderStructureEntry FolderData
        {
            get => m_folder; 
        }

        /// <summary>
        /// Event-Methode:
        /// Prüft die Angabe und speichert die Daten
        /// </summary>
        private void btnok_Click(object sender, EventArgs e)
        {
            //Überprüfen der Eingabe
            if (txtfoldername.Text.Trim() == "")
            {
                MessageBox.Show("Geben Sie einen gültigen Ordnernamen ein", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Struktur erstellen
            m_folder = new RdpFolderStructureEntry();
            if (t_folder != null) //Wenn die Daten nur bearbeitet wurden, dann sollen die Einstellungen übertragen werden
            {
                m_folder.Id = t_folder.Id;
                m_folder.ParentId = t_folder.ParentId;
                m_folder.Caption = t_folder.Caption;
                m_folder.Type = t_folder.Type;
                m_folder.Bemerkung = t_folder.Bemerkung;
            }

            //Daten speichern
            m_folder.Caption = txtfoldername.Text;
            m_folder.Bemerkung = txtfoldername.Text;

            //Fenster schliessen
            Close();
        }

        /// <summary>
        /// Dient der Event-Anbindung der TextBoxen
        /// </summary>
        private void BindEvents()
        {
            txtfoldername.KeyDown += TextBox_KeyDown;
            txtbemerkung.KeyDown += TextBox_KeyDown;
        }

        /// <summary>
        /// Event-Methode:
        /// Löst die Speicherfunktion aus, wenn auf Enter gedrückt wird
        /// </summary>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Speicherevent triggern
            if (e.KeyCode == Keys.Enter) btnok_Click(this, null);
        }
    }
}
