using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RemoteDesktopManager
{
    public delegate void RemoteDesktopItemEventHandler(RemoteDesktopData data); //Der Delegate für das Event

    /// <summary>
    /// Zeigt die Kunden-Liste an
    /// </summary>
    public partial class RemoteDesktopList : UserControl
    {
        //Variablen
        private string m_filepath = Directory.GetCurrentDirectory() + @"\rdpconnections.xml";

        //Events
        public event RemoteDesktopItemEventHandler RemoteDesktopItemClicked; //Das Event für den Delegate

        /// <summary>
        /// Erstellt eine neue Instanz von RemoteDesktopList
        /// </summary>
        public RemoteDesktopList()
        {
            InitializeComponent();

            //Verbindungen laden (sofern welche vorhanden sind)
            if (File.Exists(m_filepath))
                RefreshList(); //Liste aktualisieren
        }

        /// <summary>
        /// Aktualisiert die Liste für die Verbindungen
        /// </summary>
        private void RefreshList()
        {
            //Liste laden
            List<RemoteDesktopData> rdpData = ConnectionFileHandler.LoadRemoteDesktopConnections(m_filepath);

            //Weiter vorgehen, wenn die Liste NICHT null ist
            if (rdpData != null)
            {
                //Liste aktualisieren
                panellist.Controls.Clear();
                if (rdpData.Count > 0) //Nur durchführen, wenn Einträgee existieren
                {
                    //Alle Einträge einzeln durchgehen
                    foreach (RemoteDesktopData rdp in rdpData)
                    {
                        RemoteDesktopListItem l = new RemoteDesktopListItem(rdp);
                        l.DoubleClick += RemoteDesktopItem_Clicked; //Event anbinden
                        l.Dock = DockStyle.Top;
                        l.Show();
                        panellist.Controls.Add(l);
                        panellist.Controls.SetChildIndex(l, 0);
                    }
                }
            }
        }

        /// <summary>
        /// Event-Methode:
        /// Event zum Öffnen einer RemoteDesktop-Verbindung weitergeben
        /// </summary>
        private void RemoteDesktopItem_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("Event RemoteDesktopList::RemoteDesktopItemClicked executed");
            //Event weitergeben
            RemoteDesktopItemClicked(((RemoteDesktopListItem)sender).RemoteDesktopData);
        }

        /// <summary>
        /// Event-Methode:
        /// Aktualisiert die RemoteDesktop-Verbindungsliste
        /// </summary>
        private void btnreload_Click(object sender, EventArgs e)
        {
            //Verbindungen laden (sofern welche vorhanden sind)
            if (File.Exists(m_filepath))
                RefreshList(); //Liste aktualisieren
        }

        /// <summary>
        /// Event-Methode:
        /// Erlaubt das Hinzufügen eines neue Eintrags
        /// </summary>
        private void btnadd_Click(object sender, EventArgs e)
        {
            //Fenster zum Hinzufügen von neuen Einträgen aufrufen
            frmremotedesktopentry frm = new frmremotedesktopentry(); //Standard-Konstruktor benutzen
            frm.ShowDialog();
            if (frm.RemoteDesktopData != null) //Nur wenn es NICHT null ist, darf die Methode fortgesetzt werden
            {
                //Den Eintrag hinzufügen
                RemoteDesktopListItem l = new RemoteDesktopListItem(frm.RemoteDesktopData);
                l.DoubleClick += RemoteDesktopItem_Clicked; //Event anbinden
                l.Dock = DockStyle.Top;
                l.Show();
                panellist.Controls.Add(l);
                panellist.Controls.SetChildIndex(l, 0);
            }
        }

        /// <summary>
        /// Speichert die RemoteDesktop-Verbindungen in die Datei
        /// </summary>
        public void SaveRemoteDesktopConnections()
        {
            //Liste erstellen
            List<RemoteDesktopData> rdpData = new List<RemoteDesktopData>();
            foreach (Control c in panellist.Controls)
            {
                RemoteDesktopListItem rdpLi = (RemoteDesktopListItem)c;
                rdpData.Add(rdpLi.RemoteDesktopData);
            }

            //Liste speichern
            ConnectionFileHandler.SaveConnections(m_filepath, rdpData);
        }
    }
}
