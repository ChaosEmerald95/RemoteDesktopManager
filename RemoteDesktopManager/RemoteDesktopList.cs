using RemoteDesktopManager.RdpConnections;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RemoteDesktopManager
{
    public delegate void RemoteDesktopItemEventHandler(RemoteDesktopData data); //Der Delegate für das Event
    public delegate void RemoteDesktopItemRemoveEventHandler(int id); //Der Delegate für das Event, wenn ein Eintrag gelöscht werden soll
    public delegate void RemoteDesktopItemFolderChangedEventHandler(int id, string foldername);
    public delegate void RemoteDesktopItemConnectionChangedEventHandler(int id, RemoteDesktopData rdpData);

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
            if (m_entries != null)
            {
                //Liste aktualisieren
                panellist.Controls.Clear();
                if (m_entries.Count > 0) //Nur durchführen, wenn Einträgee existieren
                {
                    //Alle Einträge einzeln durchgehen. Das ganze wird in 2 Foreach-Schleifen abgearbeitet, da die Ordner ganz oben sein sollen
                    //Ordner
                    foreach (RdpFolderStructureEntry rdp in m_entries)
                    {
                        //Der Typ muss 1 sein und die ParentId die aktuelle Id des Controls
                        if (rdp.Type == 1 && rdp.ParentId == m_actualid)
                        {
                            //Control erstellen und einbinden
                            RemoteDesktopListFolderItem l = new RemoteDesktopListFolderItem(rdp.Id, rdp.Caption);
                            
                            //Events anbinden
                            l.DoubleClick += RemoteDesktopFolderItem_Clicked;
                            l.EntryRemove += RemoveEntry;
                            l.EntryChanged += EntryChanged_Folder;

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
                            //RemoteDesktopData bilden
                            RdpFolderStructureRdpEntry re = (RdpFolderStructureRdpEntry)rdp;
                            RemoteDesktopData r = new RemoteDesktopData(re.HostName, re.UserName, re.Password, re.Caption);

                            //Control erstellen und einbinden
                            RemoteDesktopListItem l = new RemoteDesktopListItem(r, re.Id);

                            //Events anbinden
                            l.DoubleClick += RemoteDesktopItem_Clicked; 
                            l.EntryRemove += RemoveEntry;
                            l.EntryChanged += EntryChanged_Connection;

                            l.Dock = DockStyle.Top;
                            l.Show();
                            panellist.Controls.Add(l);
                            panellist.Controls.SetChildIndex(l, 0);
                        }
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
            m_actualid = ((RemoteDesktopListFolderItem)sender).FolderId;
            if (m_actualid != -1) btnnavigateup.Enabled = true; //Wenn die neue Ebene NICHT -1 ist, den Navigationsbutton aktivieren
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
                frmenterfolderdata frm = new frmenterfolderdata();
                frm.ShowDialog();
                if (frm.FolderName != "") //Nur wenn es NICHT leer ist, darf die Methode fortgesetzt werden
                {
                    //RdpFolderStructureEntry erstellen
                    RdpFolderStructureEntry re = new RdpFolderStructureEntry();
                    re.ParentId = m_actualid;
                    re.Caption = frm.FolderName;
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
                    RdpFolderStructureRdpEntry re = new RdpFolderStructureRdpEntry();
                    re.ParentId = m_actualid;
                    re.Caption = frm.RemoteDesktopData.ConnectionName;
                    re.Type = 0; //Für RDP-Einträge
                    re.HostName = frm.RemoteDesktopData.IpAdresse;
                    re.UserName = frm.RemoteDesktopData.Username;
                    re.Password = frm.RemoteDesktopData.Password;

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
        /// <param name="id">Die ID des Eintrags</param>
        /// <param name="folderName">Der Name des Ordners</param>
        public void EntryChanged_Folder(int id, string folderName)
        {
            //SQL-Befehl ausführen
            m_conmanager.ExecuteSql("update tblConnectionStructure set Name='" + folderName + "' where Id=" + id.ToString() + ";");

            //Einträge neu laden
            LoadEntryList();
            RefreshList();
        }

        /// <summary>
        /// Event-Methode:
        /// Ändert die Daten in der Datenbank
        /// </summary>
        /// <param name="id">Die ID des Eintrags</param>
        /// <param name="rdpData">Die RemtoeDesktop-Daten</param>
        public void EntryChanged_Connection(int id, RemoteDesktopData rdpData)
        {
            //SQL-Befehl ausführen
            m_conmanager.ExecuteSql("update tblConnectionStructure set Name='" + rdpData.ConnectionName + "', Hostname='" + rdpData.IpAdresse + "', Username='" + rdpData.Username + "', Password='" + rdpData.Password + "' where Id=" + id.ToString() + ";");

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
            //ID überschreiben
            m_actualid = m_parentid;

            //Wenn die neue Ebene -1 ist, den Navigationsbutton deaktivieren
            if (m_actualid == -1) btnnavigateup.Enabled = false; 

            //Wenn die neue Ebene nicht -1 ist, dann soll die Parent-ID ermittelt werden
            if (m_actualid != -1)
            {
                //Daten werden geladen
                m_entries = SqliteDataIO.GetEntries(m_conmanager);
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

            //Daten laden
            RefreshList();
        }
    }
}
