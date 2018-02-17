using RemoteDesktopManager.Components;
using RemoteDesktopManager.RdpConnections;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RemoteDesktopManager
{
    public partial class frmmain : Form
    {
        //Variablen
        private string m_filepath = Directory.GetCurrentDirectory() + @"\rdpconnections.sqlite";
        private RemoteDesktopList rdplist = null; //Das Control für die RemoteDesktop-Verbindungsliste

        /// <summary>
        /// Erstellt eine neue Instanz von frmabout
        /// </summary>
        public frmmain()
        {
            InitializeComponent();

            //Initialisierung von SQLite
            SQLitePCL.Batteries_V2.Init();

            //SQLite-Datenbank vorbereiten, sollte die noch nicht existieren
            if (!File.Exists(m_filepath)) SqliteConnectionManager.CreateSqliteDatabase(m_filepath);

            //Testen der Verbindung. Wenn es fehlschlägt, dann wurde kein passwort vergeben
            if (!SqliteConnectionManager.TestConnection(m_filepath))
            {
                //Programm hier beenden
                Environment.Exit(0);
            }

            //Rdp-List neu einbinden
            rdplist = new RemoteDesktopList(m_filepath);
            rdplist.Dock = DockStyle.Fill;
            rdplist.RemoteDesktopItemClicked += rdplist_RemoteDesktopItemClicked;
            panelsidemenu.Controls.Add(rdplist);
        }

        /// <summary>
        /// Öffnet eine RDP-Verbindung zu einem anderen Computer
        /// </summary>
        private void OpenRdpConnection(RdpFolderStructureRdpEntry rdpEntry)
        {
            if (rdpEntry.PingHost) //Wen PingHost true ist, soll auch ein Ping durchgeführt werden
            {
                //Es wird ein Ping-Test durchgeführt. Schlägt dieser fehl, Methode abbrechen und Fehlermeldung ausgeben
                if (!PingClient.PingHost(rdpEntry.HostName))
                {
                    MessageBox.Show("Es konnte kein Ping mit dem Host hergestellt werden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; //Methode beenden
                }
            }  

            RemoteDesktopTabPage rdp = new RemoteDesktopTabPage(rdpEntry);
            if (!rdp.IsDenied)
                tabc.TabPages.Add(rdp); //TabPage hinzufügen
        }

        /// <summary>
        /// Event-Methode:
        /// Ermöglicht eine direkte Verbindung zum Client
        /// </summary>
        private void direktVerbindenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Das Fenster für Direktverbindungen öffnen
            frmenterconnectiondata frm = new frmenterconnectiondata();
            frm.ShowDialog();
            if (frm.RemoteDesktopData != null) //Wenn es nicht null ist, dann soll die Verbindung geöffnet werden
                OpenRdpConnection(frm.RemoteDesktopData);
        }

        /// <summary>
        /// Event-Methode:
        /// Öffnet eine RemoteDesktop-Verbindung
        /// </summary>
        private void rdplist_RemoteDesktopItemClicked(RdpFolderStructureRdpEntry rdpEntry)
        {
            OpenRdpConnection(rdpEntry);
        }

        /// <summary>
        /// Quelle: https://stackoverflow.com/a/40806408
        /// </summary>
        private void tabc_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                for (int i = 0; i < tabc.TabCount; i++)
                {
                    Rectangle r = tabc.GetTabRect(i);
                    if (r.Contains(e.Location)) //Wenn auf den Header geklickt wurde
                    {
                        ContextMenu cm = new ContextMenu();
                        MenuItem mi = new MenuItem("Schliessen");
                        MenuItem mi2 = new MenuItem("Abdocken");
                        mi.Click += ContextMenuClose_Clicked;
                        mi2.Click += ContextMenuUndock_Clicked;
                        cm.MenuItems.Add(mi);
                        cm.MenuItems.Add(mi2);
                        cm.Show(tabc, e.Location);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Event-Methode:
        /// Dem Fenster den Befehl erteilen, die Verbindung zu schliessen
        /// </summary>
        private void ContextMenuClose_Clicked(object sender, EventArgs e)
        {
            //Verbindung schliessen
            RemoteDesktopTabPage t = (RemoteDesktopTabPage)tabc.SelectedTab;
            if (t.Controls.Count > 0) //Nur RemoteDesktopWindow schliessen, wenn noch mindestens 1 Control enthalten ist
            {
                RemoteDesktopTabPageView r = (RemoteDesktopTabPageView)t.Controls[0];
                r.Disconnect();
            }
            if (!t.IsDisposed) t.Dispose(); //Wenn es noch nicht disposed wurde, dies hier tun
        }

        /// <summary>
        /// Event-Methode:
        /// Die TabPage soll das Fenster abdocken (und sich selbst disposen)
        /// </summary>
        private void ContextMenuUndock_Clicked(object sender, EventArgs e)
        {
            //Verbindung schliessen
            RemoteDesktopTabPage t = (RemoteDesktopTabPage)tabc.SelectedTab;
            t.RemoteDesktopWindowUndock(); //Abdocken
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn eine TabPage entfernt wurde, sollen bestimmte  Controls neu gezeichnet werden
        /// </summary>
        private void tabc_ControlRemoved(object sender, ControlEventArgs e)
        {
            rdplist.Visible = false;
            rdplist.Visible = true;
        }

        /// <summary>
        /// Event-Methode:
        /// Zeigt das About_Fenster zur Anwendung an
        /// </summary>
        private void infoÜberRemoteDesktopManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmabout frm = new frmabout();
            frm.ShowDialog();
        }

        /// <summary>
        /// Event-Methode:
        /// Beendet die Anwendung
        /// </summary>
        private void tsmenuitemcloseapplication_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); //Beendet die Anwendung mit ExitCode 0
        }
    }
}
