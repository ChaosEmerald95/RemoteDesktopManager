using RemoteDesktopManager.RdpConnections;
using System;
using System.Windows.Forms;

namespace RemoteDesktopManager.Components
{
    /// <summary>
    /// Basis-Klasse für die RemoteDesktopFenster
    /// </summary>
    public class RemoteDesktopTabPage : TabPage
    {
        private bool m_dispose = false; //Wenn auf true, dann soll keine TabPage hinzugefügt werden
        RemoteDesktopTabPageView rdpView = null;

        /// <summary>
        /// Erstellt eine neue Instanz von RemoteDesktopTabPage
        /// </summary>
        /// <param name="rdpData">Die RemoteDesktop-Daten, die für die Anzeige verwendet werden sollen</param>
        public RemoteDesktopTabPage(RdpFolderStructureRdpEntry rdpEntry) :base (rdpEntry.Caption + " (" + rdpEntry.HostName + ")")
        {
            //Das Passwort ist ein optionaler Parameter. Wenn keiner gespeichert wurde, dann soll das Eingabefenster erscheinen
            //Bei Direktverbindungen wird dieses generell geöffnet, da dort keine Passwörter gespeichert werden können
            string password = "";

            //Wenn kein Passwort übergeben wurde, dann soll das Eingabefenster dazu geöffnet werden
            if (rdpEntry.Password != "")
                password = rdpEntry.Password;
            else
            {
                //Eingabefenster anzeigen
                frmenterpassword frmpw = new frmenterpassword(rdpEntry.UserName);
                frmpw.ShowDialog();

                //Wenn es nicht leer ist, frotsetzen
                if (frmpw.Password != "")
                    password = frmpw.Password;
                else
                {
                    MessageBox.Show("Es wurde kein Passwort eingegeben! Der Vorgang wird abgebrochen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    m_dispose = true;
                    return;
                }
            }

            //Fenster wird erstellt und mit Daten gefüttert
            rdpView = new RemoteDesktopTabPageView(rdpEntry.HostName, rdpEntry.GetUserAndDomain().Value, password, rdpEntry.GetUserAndDomain().Key);
            rdpView.Dock = DockStyle.Fill;
            rdpView.TopLevel = false;
            rdpView.FormBorderStyle = FormBorderStyle.None;

            //Vorher hinzufügen, damit die Größe stimmt
            Controls.Add(rdpView);

            //jetzt Element anzeigen
            rdpView.Show();
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

        /// <summary>
        /// Dockt das Fenster aus der TabPage
        /// </summary>
        internal void RemoteDesktopWindowUndock()
        {
            //Fenster abdocken
            rdpView.Dock = DockStyle.None;
            rdpView.Hide();
            Controls.RemoveAt(0);
            rdpView.TopLevel = true;
            rdpView.FormBorderStyle = FormBorderStyle.Sizable;
            rdpView.ShowIcon = true;
            rdpView.ShowInTaskbar = true;
            rdpView.DesktopLocation = new System.Drawing.Point(250, 100);
            rdpView.Show();
            Dispose();
        }
    }
}
