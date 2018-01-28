using System.Collections.Generic;

namespace RemoteDesktopManager.RdpConnections
{
    /// <summary>
    /// Stellt einen Eintrag in der Ordnerstruktur dar
    /// </summary>
    public class RdpFolderStructureEntry
    {
        //Variablen
        private int m_id = -1; //Die ID des Eintrags
        private int m_parentId = -1; //Die ID des Parents. -1 = Ist Root
        private string m_name = ""; //Der Name des Eintrags
        private int m_type = 0; //Der Typ des Eintrags. 0 = Rdp-Verbindung| 1 = Ordner| 2 = Unknown
        private string m_bemerkung = ""; //Ein Text mit der zusätlichen Bemerkung

        /// <summary>
        /// Erstellt eine neue Instanz von RdpFolderStructureEntry
        /// </summary>
        public RdpFolderStructureEntry() { }

        /// <summary>
        /// Gibt die ID des Eintrags zurück oder legt diesen fest
        /// </summary>
        public int Id
        {
            get => m_id;
            set => m_id = value;
        }

        /// <summary>
        /// Gibt die Parent-ID des Eintrags zurück oder legt diesen fest. -1 bedeutet, dass das Item im Root liegt
        /// </summary>
        public int ParentId
        {
            get => m_id;
            set => m_id = value;
        }

        /// <summary>
        /// Gibt den Namen des Eintrags zurück oder legt diesen fest
        /// </summary>
        public string Caption
        {
            get => m_name;
            set => m_name = value;
        }

        /// <summary>
        /// Gibt den Typen des Eintrags zurück oder legt diesen fest. 0 = Rdp-Verbindung| 1 = Ordner| 2 = Unknown
        /// </summary>
        public int Type
        {
            get => m_type
            set
            {
                if (value < 0 || value > 1)
                    m_type = 2;
                else
                    m_type = value;
            }
        }

        /// <summary>
        /// Gibt die Bemerkung des Eintrags zurück oder legt diesen fest
        /// </summary>
        public string Bemerkung
        {
            get => m_bemerkung;
            set => m_bemerkung = value;
        }
    }

    /// <summary>
    /// Stellt einen RDP-Eintrag in der Ordnerstruktur dar
    /// </summary>
    public class RdpFolderStructureRdpEntry : RdpFolderStructureEntry
    {
        //Variablen
        private string m_host = ""; //Die Adresse des Hosts
        private string m_username = ""; //Der Username des Eintrags
        private string m_password = ""; //Das Passwort des Eintrags

        /// <summary>
        /// Erstellt eine neue Instanz von RdpFolderStructureRdpEntry
        /// </summary>
        public RdpFolderStructureRdpEntry() : base() { }

        /// <summary>
        /// Gibt die Adresse des Remote-Computers zurück oder legt diese fest
        /// </summary>
        public string HostName
        {
            get => m_host;
            set => m_host = value;
        }

        /// <summary>
        /// Gibt den Benutzer zurück oder legt diese fest
        /// </summary>
        public string UserName
        {
            get => m_username;
            set => m_username = value;
        }

        /// <summary>
        /// Gibt das Passwort des Benutzers zurück oder legt diese fest
        /// </summary>
        public string Password
        {
            get => m_password;
            set => m_password = value;
        }

        /// <summary>
        /// Gibt den Benutzer und Domäne zurück. Key = Domäne| Value = Benutzer
        /// </summary>
        public KeyValuePair<string, string> GetUserAndDomain()
        {
            if (m_username.Contains(@"\"))
                return new KeyValuePair<string, string>(m_username.Substring(0, m_username.IndexOf(@"\")), m_username.Substring(m_username.IndexOf(@"\") + 1));
            else
                return new KeyValuePair<string, string>(m_host, m_username);
        }
    }
}
