using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDesktopManager.Components
{
    /// <summary>
    /// Basis-Klasse für die RemoteDesktopFenster
    /// </summary>
    public class RemoteDesktopTabPage : TabPage
    {
        private bool m_dispose = false; //Wenn auf true, dann soll keine TabPage hinzugefügt werden

        /// <summary>
        /// Erstellt eine neue Instanz von RemoteDesktopTabPage
        /// </summary>
        /// <param name="rdpData">Die RemoteDesktop-Daten, die für die Anzeige verwendet werden sollen</param>
        public RemoteDesktopTabPage(RemoteDesktopData rdpData) :base (rdpData.ConnectionName + " (" + rdpData.IpAdresse + ")")
        {
            //Username und Domäne trennen, wenn ein Backslash vorhanden ist
            string domain = "";
            string username = "";
            string password = "";
            if (rdpData.Username.Contains(@"\"))
            {
                domain = rdpData.Username.Substring(0, rdpData.Username.IndexOf(@"\"));
                username = rdpData.Username.Substring(rdpData.Username.IndexOf(@"\") + 1);
            }
            else
                username = rdpData.Username;

            //Wenn kein Passwort übergeben wurde, dann soll das Eingabefenster dazu geöffnet werden
            if (rdpData.Password != "")
                password = rdpData.Password;
            else
            {
                //Eingabefenster anzeigen
                frmenterpassword frmpw = new frmenterpassword(rdpData.Username);
                frmpw.ShowDialog();

                //Wenn es nicht leer ist, frotsetzen
                if (frmpw.Password != "")
                {
                    password = frmpw.Password;
                }
                else
                {
                    MessageBox.Show("Es wurde kein Passwort eingegeben! Der Vorgang wird abgebrochen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_dispose = true;
                    return;
                }
            }

            //Fenster wird erstellt und mit Daten gefüttert
            RemoteDesktopTabPageView rdpView = new RemoteDesktopTabPageView(rdpData.IpAdresse, username, password, domain);
            rdpView.Dock = DockStyle.Fill;
            rdpView.TopLevel = false;
            rdpView.FormBorderStyle = FormBorderStyle.None;

            //Vorher hinzufügen, damit die Größe stimmt
            Controls.Add(rdpView);

            //jetzt Element anzeigen
            rdpView.Show();

            //ContextMenuStrip erstellen und konfigurieren
            ContextMenuStrip strip = new ContextMenuStrip();
            ToolStripItem tsitem1 = new ToolStripMenuItem("Schliessen");
            tsitem1.Click += ContextMenuClose_Clicked;
            strip.Items.Add(tsitem1);

            //ContextMenuStrip der TabPage hinzufügen
            ContextMenuStrip = strip;
        }

        /// <summary>
        /// Wenn auf true, dann soll die TabPage erst nicht hinzugefügt werden
        /// </summary>
        internal bool IsDenied
        {
            get => m_dispose;
        }

        /// <summary>
        /// Event-Methode:
        /// Dem Fenster den Befehl erteilen, die Verbindung zu schliessen
        /// </summary>
        private void ContextMenuClose_Clicked(object sender, EventArgs e)
        {
            //Verbindung schliessen
            RemoteDesktopTabPageView r = (RemoteDesktopTabPageView)Controls[0];
            r.Disconnect();
        }
    }
}
