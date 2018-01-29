using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;

namespace RemoteDesktopManager.RdpConnections
{
    /// <summary>
    /// Ermöglicht die Kommunikation mit der SQLite-Datenbank
    /// </summary>
    public class SqliteConnectionManager
    {
        private string m_connectionstring = ""; //Der Connection-String, der verwendet wird
        private SqliteConnection m_connection = null; //Das Objekt für die Datenbank-Verbindung

        /// <summary>
        /// Erstellt eine neue Instanz von SqliteConnectionManager
        /// </summary>
        /// <param name="connectionString">Der ConnectionString, der verwendet werden soll</param>
        public SqliteConnectionManager(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString)); //Wenn null, dann soll eine Exception ausgegeben werden
            m_connection = new SqliteConnection(connectionString);
        }

        /// <summary>
        /// Generiert den ConnectionString und gibt diesen zurück.
        /// Hinweis: Nur für SQLite
        /// </summary>
        /// <param name="filePath">Der Pfad zu der SQLite-Datenbank</param>
        /// <param name="password">Das Passwort für die Datenbankverbindung</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CreateConnectionString(string filePath, string password = "")
        {
            string t = "Data Source=" + filePath + ";";
            if (password != "")
                t += "; Password=" + password + ";";
            return t;
        }

        /// <summary>
        /// Testet die Datenbankverbindung und gibt das Ergebnis zurück. 
        /// </summary>
        /// <param name="filePath">Der Pfad zu der SQLite-Datenbank</param>
        /// <param name="password">Das Passwort für die Datenbankverbindung</param>
        /// <param name="table">Die Tabelle, wo der Test gemacht werden soll</param>
        /// <returns></returns>
        public static bool TestConnection(string filePath, string password = "")
        {
            //Argumente prüfen
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            //ConnectionStríng erstellen
            string t = CreateConnectionString(filePath, password);
            try
            {
                //Verbindung herstellen
                SqliteConnection conn = new SqliteConnection(t);
                conn.Open();

                //Command testen
                SqliteCommand command = conn.CreateCommand();
                command.CommandText = string.Format("select * from tblConnectionStructure;");
                command.ExecuteScalar();
                if (conn.State == ConnectionState.Open)
                    return true;
                else
                    return false;

            }
            catch { return false; }
        }

        /// <summary>
        /// Erstellt eine neue SQLite-Datenbank mit der Tabelle
        /// </summary>
        /// <param name="filePath">Der Pfad, wo die SQLite-Datenbank gespeichert werden soll</param>
        /// <param name="password">Da sPasswort der Datei</param>
        public static void CreateSqliteDatabase(string filePath, string password = "")
        {
            //Um eine leere Datenbank zu erstellen, muss man nur eine leere Datei erstellen. 
            //Quelle: https://stackoverflow.com/a/46084676
            FileStream fs = File.Create(filePath);
            fs.Close();

            //Die Datenbank-Verbindung öffnen
            SqliteConnection t_con = new SqliteConnection(CreateConnectionString(filePath));
            t_con.Open();

            //Wenn ein Passwort vergeben wurde, das auch ändern
            //Quelle: https://stackoverflow.com/a/38368369
            if (password != "")
            {
                using (var command = t_con.CreateCommand())
                {
                    command.CommandText = $"PRAGMA key='" + password + "';";
                    command.ExecuteNonQuery();
                }
            }

            //Tabelle erstellen
            using (var command = t_con.CreateCommand())
            {
                command.CommandText = "create table tblConnectionStructure (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, ParentId INTEGER, Name TEXT, Type INTEGER, Hostname TEXT, Username TEXT, Password TEXT, Bemerkung TEXT);";
                command.ExecuteNonQuery();
            }
            t_con.Close();
        }

        /// <summary>
        /// Gibt den ConnectionString zurück oder legt diesen fest
        /// </summary>
        public string ConnectionString
        {
            get => m_connectionstring;
            set => m_connectionstring = value;
        }

        /// <summary>
        /// Interne Eigenschaft
        /// Gibt das Verbindungs-Objekt zurück
        /// </summary>
        internal SqliteConnection Connection
        {
            get => m_connection;
        }

        /// <summary>
        /// Öffnet die Datenbank-Verbindung
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OpenConnection()
        {
            m_connection.Open();
        }

        /// <summary>
        /// Schliesst die Datenbank-Verbindung
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CloseConnection()
        {
            m_connection.Close();
        }

        /// <summary>
        /// Gibt zurück, ob eine Datenbank-Verbindung besteht
        /// </summary>
        public bool IsConnected
        {
            get
            {
                if (m_connection.State == System.Data.ConnectionState.Closed || m_connection.State == System.Data.ConnectionState.Broken)
                    return false;
                return true;
            }
        }

        /// <summary>
        /// Führt den angegebenen SQL-Befehl aus
        /// </summary>
        /// <param name="sqlCommand">Der auszuführende SQL-Befehl</param>
        public void ExecuteSql(string sqlCommand)
        {
            if (sqlCommand == null) throw new ArgumentNullException(nameof(sqlCommand)); //Wenn null, dann soll eine Exception ausgegeben werden
            if (sqlCommand == "") throw new ArgumentException("The Sql-Command can't be empty"); //Wenn es ein leerer Befehl ist, eine Exception zurückgeben

            //Befehl ausführen
            SqliteCommand cmd = new SqliteCommand(sqlCommand, m_connection);
            if (!IsConnected) OpenConnection(); //Wenn die Verbindung noch geschlossen ist, dann soll diese geöffnet werden

            //Befehl ausführen
            cmd.ExecuteNonQuery();

            //Objekte vernichten und Verbindung schliessen
            CloseConnection();
            cmd.Dispose();
        }

        /// <summary>
        /// Führt den angegebenen SQL-Befehl aus und gibt das Ergebnis zurück
        /// </summary>
        /// <param name="sqlCommand">Der auszuführende SQL-Befehl</param>
        public SqliteDataReader GetSqlResult(string sqlCommand)
        {
            if (sqlCommand == null) throw new ArgumentNullException(nameof(sqlCommand)); //Wenn null, dann soll eine Exception ausgegeben werden
            if (sqlCommand == "") throw new ArgumentException("The Sql-Command can't be empty"); //Wenn es ein leerer Befehl ist, eine Exception zurückgeben

            //Befehl ausführen
            SqliteCommand cmd = new SqliteCommand(sqlCommand, m_connection);
            if (!IsConnected) OpenConnection(); //Wenn die Verbindung noch geschlossen ist, dann soll diese geöffnet werden

            //Befehl ausführen
            cmd.CommandText = sqlCommand;
            cmd.CommandType = System.Data.CommandType.Text;

            //Daten erhalten und lesen
            SqliteDataReader reader = cmd.ExecuteReader();

            //Objekte vernichten und Verbindung schliessen
            CloseConnection();
            cmd.Dispose();
            return reader;
        }
    }
}
