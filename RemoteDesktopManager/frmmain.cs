using RemoteDesktopManager.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDesktopManager
{
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Öffnet eine RDP-Verbindung zu einem anderen Computer
        /// </summary>
        private void OpenRdpConnection(RemoteDesktopData rdpData)
        {
            RemoteDesktopTabPage rdp = new RemoteDesktopTabPage(rdpData);
            if (!rdp.IsDenied)
                tabc.TabPages.Add(rdp); //TabPage hinzufügen
        }

        /// <summary>
        /// Event-Methode:
        /// Ermöglicht eine direkte Verbindung zum Client
        /// </summary>
        private void direktVerbindenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Das Fenster für Direktverbindungen öffnen
            frmenterconnectiondata frm = new frmenterconnectiondata();
            frm.ShowDialog();
            if (frm.RemoteDesktopData != null) //Wenn es nicht null ist, dann soll die Verbindung geöffnet werden
                OpenRdpConnection(frm.RemoteDesktopData);
        }

        /// <summary>
        /// Event-Methode:
        /// Speichert die RemoteDesktop-Verbindungen in eine Datei
        /// </summary>
        private void tsmenuitemstoreconnections_Click(object sender, EventArgs e)
        {
            //Liste den Befehl erteilen, die Einträge zu speichern
            rdplist.SaveRemoteDesktopConnections();
        }

        /// <summary>
        /// Event-Methode:
        /// Öffnet eine RemoteDesktop-Verbindung
        /// </summary>
        private void rdplist_RemoteDesktopItemClicked(RemoteDesktopData data)
        {
            System.Diagnostics.Debug.Print("Event frmmain::RemoteDesktopItemClicked executed");
            OpenRdpConnection(data);
        }
    }
}
