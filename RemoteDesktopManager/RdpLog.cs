using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace RemoteDesktopManager
{
    /// <summary>
    /// Ermöglicht die Speicherung des Logs für RDP-Verbindungen
    /// </summary>
    public static class RdpLog
    {
        /// <summary>
        /// Schreibt eine INFO-Message in den Log
        /// </summary>
        /// <param name="message">Die zu speichernde Nachricht</param>
        public static void StoreRdpLogMessage(string message)
        {
            StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\rdplog.log", true);
            sw.WriteLine("[" + DateTime.Now.ToString() + "] INFO: " + message);
            sw.Close();
        }

        /// <summary>
        /// Schreibt eine WARNING-Message in den Log
        /// </summary>
        /// <param name="message">Die zu speichernde Nachricht</param>
        public static void StoreWarningRdpLogMessage(string message)
        {
            StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\rdplog.log", true);
            sw.WriteLine("[" + DateTime.Now.ToString() + "] WARNING: " + message);
            sw.Close();
        }

        /// <summary>
        /// Schreibt eine ERROR-Message in den Log
        /// </summary>
        /// <param name="message">Die zu speichernde Nachricht</param>
        public static void StoreErrorRdpLogMessage(string message)
        {
            StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + @"\rdplog.log", true);
            sw.WriteLine("[" + DateTime.Now.ToString() + "] ERROR: " + message);
            sw.Close();
        }
    }

    /// <summary>
    /// Interne Klasse für Debug-Zwecke zum Anschauen des Logs in der Debug-Konsole
    /// </summary>
    internal static class DebugRdpLog
    {
        internal enum DebugMessageType
        {
            Info,
            Warning, 
            Error
        }

        /// <summary>
        /// Zeigt eine Nachricht in der Debug-Konsole an
        /// </summary>
        /// <param name="message">Die anzuzeigende Nachricht</param>
        /// <param name="type">Der Typ der Nachricht</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ShowMessageInConsole(string message, DebugMessageType type = DebugMessageType.Info, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Debug.Print("[" + DateTime.Now.ToString() + "] " + type.ToString() + sourceFilePath + "(" + sourceLineNumber.ToString() + "): " + message);
        }
    }
}
