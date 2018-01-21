using System.Windows.Forms;

namespace RemoteDesktopManager
{
    /// <summary>
    /// Stellt einen Eintrag in der RemoteDesktop-Liste dar
    /// </summary>
    public partial class RemoteDesktopListItem : UserControl
    {
        private RemoteDesktopData m_data; //Die Daten der RemoeDesktop-Verbindung

        /// <summary>
        /// Erstellt eine neue Instanz von RemoteDesktopListItem
        /// </summary>
        /// <param name="rdpData">Die Daten zur Remote-Desktop-Verbindung</param>
        public RemoteDesktopListItem(RemoteDesktopData rdpData)
        {
            InitializeComponent();
            m_data = rdpData;
            lbconname.Text = rdpData.ConnectionName;
            lbip.Text = rdpData.IpAdresse;
        }

        /// <summary>
        /// Gibt die Informationen zur RemoteDesktop-Verbindung zurück
        /// </summary>
        public RemoteDesktopData RemoteDesktopData { get => m_data; }
    }
}
