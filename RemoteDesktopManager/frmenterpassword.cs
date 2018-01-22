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
    /// Fenster zur Eingabe des Passworts für die Verbindung
    /// </summary>
    public partial class frmenterpassword : Form
    {
        private string m_pw = "";

        /// <summary>
        /// Erstellt eine neue Instanz von frmenterpassword
        /// </summary>
        public frmenterpassword(string userName)
        {
            InitializeComponent();

            //Username anzeigen
            lbusername.Text = userName;
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn ein Passwort eingegeben wurde, dann soll das Fenster geschlossen werden
        /// </summary>
        private void btnconnect_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                MessageBox.Show("Geben Sie ein Passwort ein!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Passwort "speichern"
            m_pw = txtpassword.Text;

            //Schliessen
            Close();
        }

        /// <summary>
        /// Gibt das Passwort zurück. Wenn "" zurückgegeben wird, dann wurde abgebrochen
        /// </summary>
        public string Password
        {
            get => m_pw;
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn auf ENTER gedrückt wird, dann soll das Button-Event ausgelöst werden
        /// </summary>
        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnconnect_Click(btnconnect, null);
        }
    }
}
