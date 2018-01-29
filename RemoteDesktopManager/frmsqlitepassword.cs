using RemoteDesktopManager.RdpConnections;
using System;
using System.Windows.Forms;

namespace RemoteDesktopManager
{
    /// <summary>
    /// Dialog zur Eingabe des Passworts für die SQLite-Datenbank
    /// </summary>
    public partial class frmsqlitepassword : Form
    {
        private const int c_tries_max = 3; //KOnstante, wie viele Versuche generell möglich sind

        private bool m_connected = false; //Angabe, ob die verbindung hergestellt werden konnte oder nicht
        private int m_tries = 0; //Angabe, wie viele aktuelle Versuche der Benutzer bereits hatte
        private string m_filePath = ""; //Der PFad zur SQLite-Datenbank

        /// <summary>
        /// Erstellt eine neue Instanz von frmsqlitepassword
        /// </summary>
        /// <param name="filePathSqlite">Der Pfad zur SQLite-Datenbank</param>
        public frmsqlitepassword(string filePathSqlite)
        {
            InitializeComponent();
            m_filePath = filePathSqlite; //Pfad speichern

            //Events anbinden
            txtpassword.KeyDown += PasswordTextField_KeyPress;
            btnconnect.Click += SqliteLogin_Start;
        }

        /// <summary>
        /// Gibt zurück, ob eine Verbindung erfolgreich hergestellt wurde
        /// </summary>
        public bool IsConnected { get => m_connected; }

        /// <summary>
        /// Event-methode:
        /// Wenn auf ENTER geklickt wird, soll die SqliteLogin_Start()-Methode ausgeführt werden
        /// </summary>
        private void PasswordTextField_KeyPress(object sender, KeyEventArgs e)
        {
            //Wenn Enter gedrückt wird, Methode starten
            if (e.KeyCode == Keys.Enter)
                SqliteLogin_Start(this, null);
        }

        /// <summary>
        /// Event-Methode:
        /// Versucht eine Verbindung mit der SQLite-Datenbank herzustellen
        /// </summary>
        private void SqliteLogin_Start(object sender, EventArgs e)
        {
            //Wenn kein Passwort eingegeben wurde, dann soll eine Fehlermeldung erscheinen (Counter nicht hochzählen)
            if (txtpassword.Text.Trim() == "")
            {
                MessageBox.Show("Geben Sie ein Passwort ein!", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Anmeldeversuch starten. Wenn es fehlschlägt, Fehlermeldung anzeigen und hochzählen
            if (!SqliteConnectionManager.TestConnection(m_filePath, txtpassword.Text))
            {
                MessageBox.Show("Das Passwort ist falsch!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                m_tries++; //Counter wird hochgezählt
                if (m_tries == c_tries_max) //Wenn die maximale Anzahl erreicht wurde, dann soll das Fenster sofort beendet werden
                    Close();
                return;
            }

            //Wenn es geklappt hat, Bool-Wert auf true setzen und Fenster schliessen
            m_connected = true;
            Close();
        }
    }
}
