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

        #region DoubleClickRedirection
        //Die Methoden dienen nur zur Weiterleitung des DoubleClick-Events, damit auch da
        //das Event ausgelöst wird

        private void picimagerdp_DoubleClick(object sender, System.EventArgs e)
        {
            //Event weitergeben
            this.OnDoubleClick(e);
        }

        private void lbconname_DoubleClick(object sender, System.EventArgs e)
        {
            //Event weitergeben
            this.OnDoubleClick(e);
        }

        private void lbip_DoubleClick(object sender, System.EventArgs e)
        {
            //Event weitergeben
            this.OnDoubleClick(e);
        }
        #endregion
    }
}
