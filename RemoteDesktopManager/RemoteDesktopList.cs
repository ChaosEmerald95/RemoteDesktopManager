using RemoteDesktopManager.RdpConnections;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RemoteDesktopManager
{
    public delegate void RemoteDesktopItemEventHandler(RdpFolderStructureRdpEntry rdpEntry); //Der Delegate für das Event
    public delegate void RemoteDesktopItemRemoveEventHandler(int id); //Der Delegate für das Event, wenn ein Eintrag gelöscht werden soll
    public delegate void RemoteDesktopItemChangedEventHandler(RdpFolderStructureEntry rdpStructureEntry); //Der Delegate für das Event, wenn ein Eintrag geändert wird

    /// <summary>
    /// Zeigt die Kunden-Liste an
    /// </summary>
    public partial class RemoteDesktopList : UserControl
    {
        //Variablen
        private SqliteConnectionManager m_conmanager = null; //Der ConnectionManager
        private List<RdpFolderStructureEntry> m_entries = null; //Speichert die Liste mit den Einträgen
        private int m_actualid = -1; //Die aktuelle Id für die Anzeige der Verbindungen und Ordner
        private int m_parentid = -1; //Die Id des Parents für das Zurück-Navigieren

        //Events
        public event RemoteDesktopItemEventHandler RemoteDesktopItemClicked; //Das Event für den Delegate

        /// <summary>
        /// Erstellt eine neue Instanz von RemoteDesktopList
        /// </summary>
        /// <param name="filePath">Der Pfad zu der SQLite-Datenbank</param>
        /// <param name="password">Das Passwort für die Datenbank. Wenn keins vergeben wurde, leer lassen</param>
        public RemoteDesktopList(string filePath, string password = "")
        {
            InitializeComponent();

            //SQLiteConnectionManager vorbereiten
            try
            {
                m_conmanager = new SqliteConnectionManager(SqliteConnectionManager.CreateConnectionString(filePath, password));
            }
            catch (Exception ex)
            {
                DebugRdpLog.ShowMessageInConsole("Fehler bei der Initialisierung des Controls 'RemoteDesktopList' - Message: " + ex.Message, DebugRdpLog.DebugMessageType.Error);
            }

            //Liste laden
            LoadEntryList();
            m_actualid = -1;
            btnnavigateup.Enabled = false; //Am Anfang muss es false sein
            RefreshList();
        }

        /// <summary>
        /// Lädt die Liste herunter
        /// </summary>
        private void LoadEntryList()
        {
            try //Das ganze in einer Try-Catch, um Fehle abzufangen
            {
                //Daten werden geladen
                m_entries = SqliteDataIO.GetEntries(m_conmanager);
            }
            catch (Exception ex)
            {
                DebugRdpLog.ShowMessageInConsole("Ein Fehler ist beim Laden der Verbindungen aufgetreten - Message: " + ex.Message, DebugRdpLog.DebugMessageType.Error);
            }
        }

        /// <summary>
        /// Aktualisiert die Liste für die Verbindungen (anhand der Id des Parents)
        /// </summary>
        private void RefreshList()
        {
            //Die Liste darf nicht null sein
            if (m_entries != null && m_entries.Count > 0)
            {
                //Liste aktualisieren
                panellist.Controls.Clear();

                //Alle Einträge einzeln durchgehen. Das ganze wird in 2 Foreach-Schleifen abgearbeitet, da die Ordner ganz oben sein sollen
                //Ordner
                foreach (RdpFolderStructureEntry rdp in m_entries)
                {
                    //Der Typ muss 1 sein und die ParentId die aktuelle Id des Controls
                    if (rdp.Type == 1 && rdp.ParentId == m_actualid)
                    {
                        //Control erstellen und einbinden
                        RemoteDesktopListFolderItem l = new RemoteDesktopListFolderItem(rdp);

                        //Events anbinden
                        l.DoubleClick += RemoteDesktopFolderItem_Clicked;
                        l.EntryRemove += RemoveEntry;
                        l.EntryChanged += EntryChanged;

                        l.Dock = DockStyle.Top;
                        l.Show();
                        panellist.Controls.Add(l);
                        panellist.Controls.SetChildIndex(l, 0);
                    }
                }

                //Vebrindungen
                foreach (RdpFolderStructureEntry rdp in m_entries)
                {
                    //Der Typ muss 1 sein und die ParentId die aktuelle Id des Controls
                    if (rdp.Type == 0 && rdp.ParentId == m_actualid)
                    {
                        //Control erstellen und einbinden
                        RemoteDesktopListItem l = new RemoteDesktopListItem((RdpFolderStructureRdpEntry)rdp);

                        //Events anbinden
                        l.DoubleClick += RemoteDesktopItem_Clicked;
                        l.EntryRemove += RemoveEntry;
                        l.EntryChanged += EntryChanged;

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
        /// Wenn auf einen Ordner ein Doppelklick gemacht wird
        /// </summary>
        private void RemoteDesktopFolderItem_Clicked(object sender, EventArgs e)
        {
            //Wenn auf einen Ordner ein Doppelklick gemacht wird, dann soll m_actualid die ID des Ordners bekommen und dann die Liste neu geladen werden
            m_parentid = m_actualid; //Parent überschreiben
            m_actualid = ((RemoteDesktopListFolderItem)sender).FolderId;
            btnnavigateup.Enabled = true; //Kann auf Tru gesetzt werden
            RefreshList();
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
            LoadEntryList();
            m_actualid = -1;
            btnnavigateup.Enabled = false; 
            RefreshList();
        }

        /// <summary>
        /// Event-Methode:
        /// Erlaubt das Hinzufügen eines neue Eintrags
        /// </summary>
        private void btnadd_Click(object sender, EventArgs e)
        {
            //Dialog zur Auswahl einer Eintragsoption öffnen
            dlgrdplistnewelement dlg = new dlgrdplistnewelement();
            dlg.ShowDialog();
            if (dlg.DialogResultId == 0) return; //wenn nichts ausgewählt wurde, hier beenden

            //Anhand des Ergebnisses weiterarbeiten
            if (dlg.DialogResultId == 1) //Ein neuer Ordner soll erstellt werden
            {
                frmfolderentry frm = new frmfolderentry();
                frm.ShowDialog();
                if (frm.FolderData != null) //Nur wenn es NICHT leer ist, darf die Methode fortgesetzt werden
                {
                    //RdpFolderStructureEntry erstellen
                    RdpFolderStructureEntry re = frm.FolderData;
                    re.ParentId = m_actualid;
                    re.Type = 1; //Für Ordner

                    //Eintrag speichern
                    SqliteDataIO.UpdateEntry(m_conmanager, re, true);

                    //Einträge neu laden
                    LoadEntryList();
                    RefreshList();
                }
            }
            else if (dlg.DialogResultId == 2) //Ein neuer Eintrag soll erstellt werden
            {
                frmremotedesktopentry frm = new frmremotedesktopentry(); //Standard-Konstruktor benutzen
                frm.ShowDialog();
                if (frm.RemoteDesktopData != null) //Nur wenn es NICHT null ist, darf die Methode fortgesetzt werden
                {
                    //RdpFolderStructureRemoteEntry erstellen
                    RdpFolderStructureRdpEntry re = frm.RemoteDesktopData;
                    re.ParentId = m_actualid;
                    re.Type = 0; //Für RDP-Einträge

                    //Eintrag speichern
                    SqliteDataIO.UpdateEntry(m_conmanager, re, true);

                    //Einträge neu laden
                    LoadEntryList();
                    RefreshList();
                }
            }
        }

        /// <summary>
        /// Event-Methode:
        /// Entfernt einen Eintrag aus der Datenbank
        /// </summary>
        /// <param name="id">Die ID des Eintrags</param>
        public void RemoveEntry(int id)
        {
            //SQL-Befehl ausführen
            m_conmanager.ExecuteSql("delete from tblConnectionStructure where Id = " + id.ToString() + ";");

            //Einträge neu laden
            LoadEntryList();
            RefreshList();
        }

        /// <summary>
        /// Event-Methode:
        /// Ändert die Daten in der Datenbank
        /// </summary>
        /// <param name="rdpStructureEntry">Das Objekt mit den Daten</param>
        public void EntryChanged(RdpFolderStructureEntry rdpStructureEntry)
        {
            //Hier wird der SQL-Befehl gespeichert. Es sollen nur die Felder geändert werden, die auch geändert werden können
            string sql = "update tblConnectionStructure set Name='" + rdpStructureEntry.Caption + "', Bemerkung='" + rdpStructureEntry.Bemerkung + "'"; 
            if (rdpStructureEntry.Type == 0) //Es ist eine Verbindung
            {
                RdpFolderStructureRdpEntry re = (RdpFolderStructureRdpEntry)rdpStructureEntry; //Objekt casten, um an die zusätzlichen Felder zu kommen

                //SQL-Befehl vervollständigen
                sql += ", Hostname='" + re.HostName + "', Username='" + re.UserName + "', Password='" + re.Password + "', PingHost=" + Convert.ToInt32(re.PingHost).ToString();
            }

            //Ausführung abschliessen
            sql += " where Id=" + rdpStructureEntry.Id.ToString() + ";";
            m_conmanager.ExecuteSql(sql);

            //Einträge neu laden
            LoadEntryList();
            RefreshList();
        }

        /// <summary>
        /// Event-Methode:
        /// Navigiert eine Ebene nach oben
        /// </summary>
        private void btnnavigateup_Click(object sender, EventArgs e)
        {
            //Aktuelle Id mit der des parents überschreiben
            m_actualid = m_parentid;

            //Wenn die neue Ebene nicht -1 ist, dann soll die Parent-ID ermittelt werden
            if (m_actualid != -1)
            {
                //Die Einträge durchgehen und den Parent ermitteln
                foreach (RdpFolderStructureEntry rdp in m_entries)
                {
                    //Der Typ muss 1 sein und die Id die aktuelle Id des Controls
                    if (rdp.Type == 1 && rdp.Id == m_actualid)
                    {
                        //ParentId speichern
                        m_parentid = rdp.ParentId;
                        break;
                    }
                }
            }
            else m_parentid = -1;

            //Button freischalten
            btnnavigateup.Enabled = (m_actualid == -1) ? false : true;

            //Daten laden
            RefreshList();
        }
    }
}
