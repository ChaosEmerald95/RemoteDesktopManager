namespace RemoteDesktopManager
{
    /// <summary>
    /// Speichert die Remote-Verbindungsdaten
    /// </summary>
    public class RemoteDesktopData
    {
        private string m_rdname; //Der Name der Verbindung
        private string m_ip; //Die IP-Adresse
        private string m_username; //Der Username
        private string m_password; //Das Passwort

        /// <summary>
        /// Erstellt eine neue Instanz für die RemoteDesktop-Daten
        /// </summary>
        /// <param name="ipadress">Die IP-Adresse des Zielhosts</param>
        /// <param name="username">Der Username des Zielhosts</param>
        /// <param name="password">Das Passwort des Zielhosts</param>
        /// <param name="connectionname">Optional: Der Name der Verbindung</param>
        public RemoteDesktopData()
        {
            m_rdname = "";
            m_ip = "";
            m_username = "";
            m_password = "";
        }

        /// <summary>
        /// Erstellt eine neue Instanz für die RemoteDesktop-Daten
        /// </summary>
        /// <param name="ipadress">Die IP-Adresse des Zielhosts</param>
        /// <param name="username">Der Username des Zielhosts</param>
        /// <param name="password">Das Passwort des Zielhosts</param>
        /// <param name="connectionname">Optional: Der Name der Verbindung</param>
        public RemoteDesktopData(string ipadress, string username, string password, string connectionname = "")
        {
            m_rdname = connectionname;
            m_ip = ipadress;
            m_username = username;
            m_password = password;
        }

        /// <summary>
        /// Gibt den Namen der RemoteDesktop-Verbindung zurück
        /// </summary>
        public string ConnectionName { get { return m_rdname; } }

        /// <summary>
        /// Gibt die IP-Adresse des Zielhosts zurück
        /// </summary>
        public string IpAdresse { get { return m_ip; } }

        /// <summary>
        /// Gibt den Username zurück
        /// </summary>
        public string Username { get { return m_username; } }

        /// <summary>
        /// Gibt das Passwort des Users zurück
        /// </summary>
        public string Password { get { return m_password; } }
    }
}
