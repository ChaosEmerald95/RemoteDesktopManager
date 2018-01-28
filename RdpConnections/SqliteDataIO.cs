using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace RemoteDesktopManager.RdpConnections
{
    /// <summary>
    /// Stellt Methoden zur Verarbeitung der Einträge dar
    /// </summary>
    public static class SqliteDataIO
    {
        private const string TABLE_CONNECTIONS = "tblConnectionStructure";

        /// <summary>
        /// Gibt eine Liste aller Einträge zurück
        /// </summary>
        /// <param name="connectionManager">Der ConnectionManager für die Datenbankverbindung</param>
        /// <returns></returns>
        public static List<RdpFolderStructureEntry> GetEntries(SqliteConnectionManager connectionManager)
        {
            //Wenn Parameter null ist, direkt eine ArgumentNullException zurückgeben
            if (connectionManager == null) throw new ArgumentNullException(nameof(connectionManager));

            //Die Daten per DataReader herunterladen
            SqliteDataReader reader = connectionManager.GetSqlResult("Select * from " + TABLE_CONNECTIONS);
            
            //Mit einer If prüfen, ob Rows im Reader erhalten sind. Wenn nicht, direkt zum Ende der Methode gehen
            if (reader.HasRows)
            {
                //Die einzelnen Zeilen lesen und in eine Liste eintragen
                List<RdpFolderStructureEntry> t_lentries = new List<RdpFolderStructureEntry>(); //Liste wird erstellt

                while (reader.Read()) //Solange noch Zeilen existieren, weiterlesen
                {
                    //Mit einer If-Abfrage anhand des Typs arbeiten
                    if (Convert.ToInt32(reader["Type"]) == 0)
                    {
                        //Daten speichern
                        RdpFolderStructureRdpEntry entry = new RdpFolderStructureRdpEntry();
                        entry.Id = Convert.ToInt32(reader["Id"]);
                        entry.ParentId = Convert.ToInt32(reader["ParentId"]);
                        entry.Caption = reader["Name"].ToString();
                        entry.Type = Convert.ToInt32(reader["Type"]);
                        entry.Bemerkung = reader["Bemerkung"].ToString();
                        entry.HostName = reader["Hostname"].ToString();
                        entry.UserName = reader["Username"].ToString();
                        entry.Password = reader["Password"].ToString();

                        //Eintrag der Liste hinzufügen
                        t_lentries.Add(entry);
                    }
                    else if (Convert.ToInt32(reader["Type"]) == 1)
                    {
                        //Daten speichern
                        RdpFolderStructureEntry entry = new RdpFolderStructureEntry();
                        entry.Id = Convert.ToInt32(reader["Id"]);
                        entry.ParentId = Convert.ToInt32(reader["ParentId"]);
                        entry.Caption = reader["Name"].ToString();
                        entry.Type = Convert.ToInt32(reader["Type"]);
                        entry.Bemerkung = reader["Bemerkung"].ToString();

                        //Eintrag der Liste hinzufügen
                        t_lentries.Add(entry);
                    }
                }
                //Liste zurückgeben
                return t_lentries;
            }
            //null zurückgeben
            return null;
        }

        /// <summary>
        /// Aktualisiert einen Eintrag oder fügt einen neuen hinzu
        /// </summary>
        /// <param name="entry">Der zu speichernde Eintrag</param>
        /// <param name="adding">Angabe, ob ein neuer hinzugefügt werden soll oder nicht</param>
        public static void UpdateEntry(SqliteConnectionManager connectionManager, ref RdpFolderStructureEntry entry, bool adding = false)
        {
            //Prüfen, dass nix null ist
            if (connectionManager == null) throw new ArgumentNullException(nameof(connectionManager));
            if (entry == null) throw new ArgumentNullException(nameof(entry));

            string sqlc = ""; //Der SQL-Befehl, der ausgeführt werden soll
            if (adding) //Es soll ein Insert-Befehl ausgeführt werden
            {
                //Befehl erstellen
                sqlc += "insert into " + TABLE_CONNECTIONS + " (ParentId, Name, Type, Bemerkung";
                if (entry.Type == 0)
                    sqlc += ", Hostname, Username, Password";
                sqlc += ") values (" + entry.ParentId.ToString() + ", '" + entry.Caption + "', " + entry.Type.ToString() + ", '" + entry.Bemerkung + "'";
                if (entry.Type == 0)
                {
                    RdpFolderStructureRdpEntry t_rdpentry = (RdpFolderStructureRdpEntry)entry;
                    sqlc += ", '" + t_rdpentry.HostName + "', '" + t_rdpentry.UserName + "', '" + t_rdpentry.Password + "'";
                }
                sqlc += ");";
            }
            else //Es soll ein Update-Befehl ausgeführt werden
            {
                //Befehl erstellen
                sqlc += "update " + TABLE_CONNECTIONS + " set ParentId=" + entry.ParentId.ToString() + ", Name='" + entry.Caption + "', Type=" + entry.Type.ToString();
                sqlc += ", Bemerkung='" + entry.Bemerkung + "'";
                if (entry.Type == 0)
                {
                    RdpFolderStructureRdpEntry t_rdpentry = (RdpFolderStructureRdpEntry)entry;
                    sqlc += ", Hostname='" + t_rdpentry.HostName + "', Username='" + t_rdpentry.UserName + "', Password='" + t_rdpentry.Password + "'";
                }
                sqlc += " where Id=" + entry.Id.ToString() +";";
            }

            //Befehl ausführen
            connectionManager.ExecuteSql(sqlc); //Befehl ausführen

            //Wenn es ein Add-Vorgang war, dann soll dem Eintrag noch die Id gegeben werden
            if (adding)
            {
                SqliteDataReader t_r = connectionManager.GetSqlResult("Select Max(Id) as MaxId from " + TABLE_CONNECTIONS);
                if (t_r.HasRows) //Nur wenn Zeilen vorhanden sind, bringt das ganze was
                {
                    t_r.Read();
                    entry.Id = Convert.ToInt32(t_r["MaxId"]);
                }
                else
                    entry.Id = -1; //Damit das Programm damit einen Fehler feststellt
            }
        }
    }
}
