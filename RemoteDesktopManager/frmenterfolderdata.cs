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
    /// Ermöglicht die Erstellung eines Ordners für die Struktur
    /// </summary>
    public partial class frmenterfolderdata : Form
    {
        private string m_foldername = ""; //Der Name des zu speichernden Ordners

        /// <summary>
        /// Erstellt eine neue Instanz von frmcreatefolder.
        /// Konstruktor für das Anlegen von neuen Ordnern
        /// </summary>
        public frmenterfolderdata()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Erstellt eine neue Instanz von frmcreatefolder.
        /// Konstruktor für das Bearbeiten eines Ordners
        /// </summary>
        public frmenterfolderdata(string folderName)
        {
            InitializeComponent();
            txtfoldername.Text = folderName;
        }

        /// <summary>
        /// Gibt den namen des Ordners zurück
        /// </summary>
        public string FolderName { get => m_foldername; }

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

            //Daten speichern
            m_foldername = txtfoldername.Text;

            //Fenster schliessen
            Close();
        }
    }
}
