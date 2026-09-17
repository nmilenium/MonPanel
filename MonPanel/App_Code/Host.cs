using System;


namespace MonPanel
{
    public class Host
    {
        public string Hostname { get; set; }
        public string IpAddress { get; set; }
        public string OsType { get; set; }
        public string Port { get; set; }
        public bool IsOnline { get; set; }
        public DateTime LastUpdated { get; set; }
        public string AdditionalInfo { get; set; }

        private static readonly Random _rand = new Random();

        public Host(string ipaddr, string port, string additionalInfo)
        {
            Hostname = GenerateRandomHostname();
            IpAddress = ipaddr;
            Port = port;
            OsType = GenerateRandomOsType();
            IsOnline = true;
            LastUpdated = DateTime.Now;
            AdditionalInfo = additionalInfo;
        }

        public Host()
        {
        }

        private static string GenerateRandomHostname()
        {
            string[] prefixes = { "app", "db", "web", "srv", "api", "cache", "proxy", "mail", "dns", "ftp" };
            string[] suffixes = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };

            string prefix = prefixes[_rand.Next(prefixes.Length)];
            string suffix = suffixes[_rand.Next(suffixes.Length)];

            return $"{prefix}-{suffix}";
        }

        private static string GenerateRandomOsType()
        {
            string[] osTypes = { "Windows", "Linux" };
            return osTypes[_rand.Next(osTypes.Length)];
        }
    }
}
