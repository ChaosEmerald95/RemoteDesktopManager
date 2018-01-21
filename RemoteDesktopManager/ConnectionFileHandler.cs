using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RemoteDesktopManager
{
    /// <summary>
    /// Regelt das Lesen und Schreiben der Handler-Daten
    /// </summary>
    public static class ConnectionFileHandler
    {
        /// <summary>
        /// Liest die Daten aus der Datei aus und gibt diese als Liste zurück
        /// </summary>
        /// <param name="filepath">Der Pfad der Datei</param>
        /// <returns></returns>
        public static List<RemoteDesktopData> LoadRemoteDesktopConnections(string filepath)
        {
            //Xml-Dokument laden
            XmlDocument xmldoc = new XmlDocument();

            try //Weil das Laden auch schief gehen kann
            {
                xmldoc.Load(filepath);
            }
            catch (Exception ex)
            {
                throw new Exception("Ein Fehler ist beim Laden der Datei aufgetreten", ex);
            }

            //Xml-Root-Node erhalten
            XmlNode root = xmldoc.LastChild;

            //Von dem alle Unternodes ermitteln und in die Liste eintragen
            if (root.ChildNodes.Count > 0)
            {
                //Liste erstellen
                List<RemoteDesktopData> m_list = new List<RemoteDesktopData>();

                foreach (XmlNode n in root.ChildNodes)
                {
                    //Damit der Code etwas übersichtlicher bleibt, werden Zusatzvariablen angelegt
                    string ipadress = n.ChildNodes[0].InnerText;
                    string username = n.ChildNodes[1].InnerText;
                    string password = n.ChildNodes[2].InnerText;
                    string connectionname = n.ChildNodes[3].InnerText;

                    //Jetzt wird die Struktur gebildet
                    RemoteDesktopData data = new RemoteDesktopData(ipadress, username, password, connectionname);

                    //Eintrag zur Liste hinzufügen
                    m_list.Add(data);
                }

                //Liste zurückgeben
                return m_list;
            }
            else
            {
                return null; //Gibt ja nix
            }
        }

        /// <summary>
        /// Speichert die Änderungen in die Datei
        /// </summary>
        /// <param name="filepath">Der Pfad zu der Datei</param>
        /// <param name="data">Die Liste mit den Verbindungen</param>
        /// <returns></returns>
        public static void SaveConnections(string filepath, List<RemoteDesktopData> data)
        {
            //Xml-Dokument-Deklaration einfügen
            XmlDocument xmldoc = new XmlDocument();
            XmlDeclaration xmldec;
            xmldec = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlNode root = xmldoc.CreateElement("RdpConnections");
            xmldoc.AppendChild(root);
            xmldoc.InsertBefore(xmldec, root);

            //Die einzelnen Nodes hinzufügen
            foreach (RemoteDesktopData rdp in data)
            {
                XmlNode n = xmldoc.CreateElement("RdpConnection");
                n.AppendChild(xmldoc.CreateElement("IpAdress")).InnerText = rdp.IpAdresse;
                n.AppendChild(xmldoc.CreateElement("Username")).InnerText = rdp.Username;
                n.AppendChild(xmldoc.CreateElement("Password")).InnerText = rdp.Password;
                n.AppendChild(xmldoc.CreateElement("ConnectionName")).InnerText = rdp.ConnectionName;

                //Dem root-Element anhängen
                root.AppendChild(n);
            }

            //XML-Dokument speichern
            xmldoc.Save(filepath);
        }
    }
}
