﻿using RemoteDesktopManager.RdpConnections;
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
        private SqliteConnectionManager m_conmanager = null; //Der ConnectionManager
        private List<RdpFolderStructureEntry> m_entries = null; //Speichert die Liste mit den Einträgen
        private int m_actualid = -1; //Die aktuelle Id für die Anzeige der Verbindungen und Ordner

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
                            l.DoubleClick += RemoteDesktopFolderItem_Clicked; //Event anbinden
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
                            RemoteDesktopListItem l = new RemoteDesktopListItem(r);
                            l.DoubleClick += RemoteDesktopItem_Clicked; //Event anbinden
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
            RefreshList();
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
            /*//Liste erstellen
            List<RemoteDesktopData> rdpData = new List<RemoteDesktopData>();
            foreach (Control c in panellist.Controls)
            {
                RemoteDesktopListItem rdpLi = (RemoteDesktopListItem)c;
                rdpData.Add(rdpLi.RemoteDesktopData);
            }

            //Liste speichern
            ConnectionFileHandler.SaveConnections(m_filepath, rdpData);*/
        }
    }
}
