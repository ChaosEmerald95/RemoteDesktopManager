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
    /// Ermöglicht dem Benutzer eine Auswahl, was neu erstellt werden soll
    /// </summary>
    public partial class dlgrdplistnewelement : Form
    {
        private int m_value = 0; //Wert, welcher angibt, was neu erstellt werden soll. 0 = Nichts|1 = Ordner|2 = Verbindung

        /// <summary>
        /// Erstellt eine neue Instanz von dlgrdplistnewelement
        /// </summary>
        public dlgrdplistnewelement()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gibt die ID zurück, die ausgewählt wurde
        /// </summary>
        public int DialogResultId { get => m_value; }

        /// <summary>
        /// Event-Methode:
        /// Wenn eine Auswahl durchgeführt wurde, Wert speichern und Fenster schliessen
        /// </summary>
        private void btnok_Click(object sender, EventArgs e)
        {
            //Wenn nichts ausgewählt wurde, Fehlermeldung anzeigen
            if (!rbaddnewfolder.Checked && !rbaddnewconnection.Checked)
            {
                MessageBox.Show("Es wurde keine Auswahl getroffen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Wert festlegen
            if (rbaddnewfolder.Checked) m_value = 1;
            if (rbaddnewconnection.Checked) m_value = 2;

            //Fenster schliessen
            Close();
        }
    }
}
