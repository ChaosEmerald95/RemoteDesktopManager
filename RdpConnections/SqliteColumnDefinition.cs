namespace RemoteDesktopManager.RdpConnections
{
    /// <summary>
    /// Stellt eine Spalte in der Sqlite-Tabelle "tblConnectionStructure" dar
    /// </summary>
    public struct SqliteColumnDefinition
    {
        private string m_columnname;
        private string m_columntype;

        /// <summary>
        /// Erstellt eine neue Struktur von SqliteColumnDefinition
        /// </summary>
        /// <param name="columnName">Der Name der Spalte</param>
        /// <param name="columnType">Der Datentyp der Spalte</param>
        public SqliteColumnDefinition(string columnName, string columnType)
        {
            m_columnname = columnName;
            m_columntype = columnType;
        }

        /// <summary>
        /// Gibt den Namen der Spalte zurück
        /// </summary>
        public string ColumnName { get => m_columnname; }

        /// <summary>
        /// Gibt den Datentyp der Spalte als Text zurück
        /// </summary>
        public string ColumnType { get => m_columntype; }
    }
}
