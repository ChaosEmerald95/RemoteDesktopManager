﻿using RemoteDesktopManager.Components;
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

        /// <summary>
        /// Quelle: https://stackoverflow.com/a/40806408
        /// </summary>
        private void tabc_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                for (int i = 0; i < tabc.TabCount; i++)
                {
                    Rectangle r = tabc.GetTabRect(i);
                    if (r.Contains(e.Location)) //Wenn auf den Header geklickt wurde
                    {
                        ContextMenu cm = new ContextMenu();
                        MenuItem mi = new MenuItem("Schliessen");
                        MenuItem mi2 = new MenuItem("Abdocken");
                        mi.Click += ContextMenuClose_Clicked;
                        mi2.Click += ContextMenuUndock_Clicked;
                        cm.MenuItems.Add(mi);
                        cm.MenuItems.Add(mi2);
                        cm.Show(tabc, e.Location);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Event-Methode:
        /// Dem Fenster den Befehl erteilen, die Verbindung zu schliessen
        /// </summary>
        private void ContextMenuClose_Clicked(object sender, EventArgs e)
        {
            //Verbindung schliessen
            RemoteDesktopTabPage t = (RemoteDesktopTabPage)tabc.SelectedTab;
            if (t.Controls.Count > 0) //Nur RemoteDesktopWindow schliessen, wenn noch mindestens 1 Control enthalten ist
            {
                RemoteDesktopTabPageView r = (RemoteDesktopTabPageView)t.Controls[0];
                r.Disconnect();
            }
            if (!t.IsDisposed) t.Dispose(); //Wenn es noch nicht disposed wurde, dies hier tun
        }

        /// <summary>
        /// Event-Methode:
        /// Die TabPage soll das Fenster abdocken (und sich selbst disposen)
        /// </summary>
        private void ContextMenuUndock_Clicked(object sender, EventArgs e)
        {
            //Verbindung schliessen
            RemoteDesktopTabPage t = (RemoteDesktopTabPage)tabc.SelectedTab;
            t.RemoteDesktopWindowUndock(); //Abdocken
        }

        /// <summary>
        /// Event-Methode:
        /// Wenn eine TabPage entfernt wurde, sollen bestimmte  Controls neu gezeichnet werden
        /// </summary>
        private void tabc_ControlRemoved(object sender, ControlEventArgs e)
        {
            rdplist.Visible = false;
            rdplist.Visible = true;
        }
    }
}
