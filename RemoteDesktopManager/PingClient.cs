using System.Net.NetworkInformation;

namespace RemoteDesktopManager
{
    /// <summary>
    /// Enthält eine Methode zum Anpingen eines Clients
    /// Quelle: https://stackoverflow.com/a/11804416
    /// </summary>
    public static class PingClient
    {
        /// <summary>
        /// Pingt einen anderen Host an und gibt das Ergebnis als Boolean zurück
        /// </summary>
        /// <param name="nameOrAddress">Die IP-Adresse des Hosts</param>
        /// <returns></returns>
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }
    }
}
