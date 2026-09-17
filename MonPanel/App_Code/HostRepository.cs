using System;
using System.Collections.Generic;
using System.Linq;


namespace MonPanel
{
    public static class HostRepository
    {
        private static readonly List<Host> _hosts = new List<Host>();
        public static List<Host> GetAll() => _hosts;

        public static void Add(string ipAddress, string port, string additionalInfo)
        {
            var existingHost = _hosts.FirstOrDefault(h => h.IpAddress == ipAddress);
            if (existingHost == null)
            {
                var host = new Host(ipAddress, port, additionalInfo);
                _hosts.Add(host);
            } else
            {
                Console.WriteLine($"Потом почитаю про исключения, a пока хост с IP-адресом {ipAddress} уже существует.");
            }
        }
        public static void Update(string ipAddress, string additionalInfo)
        {
            var existingHost = _hosts.FirstOrDefault(h => h.IpAddress == ipAddress);
            if (existingHost != null)
            {
                existingHost.AdditionalInfo = additionalInfo;
                existingHost.LastUpdated = DateTime.Now;
            }
            else
            {
                Console.WriteLine($"Потом почитаю про исключения, a пока хост с IP-адресом {ipAddress} не найден.");
            }
        }
        public static void PollAll()
        {
            foreach (var host in _hosts)
            {
                host.LastUpdated = DateTime.Now;
            }
        }

        public static void Delete(string ipAddress)
        {
            var existingHost = _hosts.FirstOrDefault(h => h.IpAddress == ipAddress);
            if (existingHost != null)
            {
                _hosts.Remove(existingHost);
            }
            else
            {
                Console.WriteLine($"Потом почитаю про исключения, a пока хост с IP-адресом {ipAddress} не найден.");
            }
        }
    }
}