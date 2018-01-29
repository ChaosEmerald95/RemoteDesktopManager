using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RemoteDesktopManager
{
    /// <summary>
    /// Zeigt die Informationen zu dem Programm an
    /// </summary>
    public partial class frmabout : Form
    {
        private const string url_sourcecode = "https://github.com/ChaosEmerald95/RemoteDesktopManager";

        /// <summary>
        /// Erstellt eine neue Instanz von frmabout
        /// </summary>
        public frmabout()
        {
            InitializeComponent();

            //FileVersionInfo
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetCallingAssembly().Location);

            //Daten anzeigen
            lbversionnumber.Text = fvi.ProductMajorPart + "." + fvi.ProductMinorPart + "." + fvi.ProductBuildPart + " Build " + fvi.ProductPrivatePart;
            lbbuild.Text = RetrieveLinkerTimestamp(System.Reflection.Assembly.GetCallingAssembly().Location).ToString();
            lbcopyright.Text = fvi.LegalCopyright;
        }

        /// <summary>
        /// Gibt die Versionsnummer der Assembly zurück
        /// </summary>
        /// <returns></returns>
        private string GetProgramVersion(string path)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(path);
            return fvi.ProductVersion;
        }

        /// <summary>
        /// Gibt den Coprighthinweis der Assembly zurück
        /// </summary>
        /// <returns></returns>
        private string GetProgramCopyright(string path)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(path);
            return fvi.LegalCopyright;
        }

        /// <summary>
        /// Gibt den Zeitstempel zurück, wann diese Assembly erstellt wurde
        /// </summary>
        /// <returns></returns>
        private DateTime RetrieveLinkerTimestamp(string path)
        {
            string filepath = path;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2049];
            Stream s = null;

            try
            {
                s = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                s = null;
            }
            int i = BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.ToLocalTime();
            return dt;
        }

        /// <summary>
        /// Event-Methode:
        /// Öffnet die URL im Browser
        /// </summary>
        private void lblinksrccode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Einfach Prozess starten
            System.Diagnostics.Process.Start(url_sourcecode);
        }
    }
}
