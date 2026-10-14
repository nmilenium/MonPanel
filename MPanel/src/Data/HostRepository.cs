using System;
using System.Collections.Generic;
using System.Linq;

namespace MPanel
{
    public static class HostRepository
    {
        public static List<Host> GetAll()
        {
            using (var context = new MonPanelDBContext())
            {
                return context.Hosts.AsNoTracking().ToList();
            }
        }

        public static void Add(string ipAddress, string port, string additionalInfo)
        {
            using (var context = new MonPanelDBContext())
            {
                var existingHost = context.Hosts.Any(h => h.IpAddress == ipAddress);
                if (!existingHost)
                {
                    var host = new Host(ipAddress, port, additionalInfo);
                    context.Hosts.Add(host);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Потом почитаю про исключения, a пока хост с IP-адресом {ipAddress} уже существует.");
                }
            }
        }
        public static void Update(string ipAddress, string additionalInfo)
        {
            using (var context = new MonPanelDBContext())
            {
                var existingHost = context.Hosts.FirstOrDefault(h => h.IpAddress == ipAddress);
                if (existingHost != null)
                {
                    existingHost.AdditionalInfo = additionalInfo;
                    existingHost.LastUpdated = DateTime.Now;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Потом почитаю про исключения, a пока хост с IP-адресом {ipAddress} не найден.");
                }
            }
        }

        public static void Delete(string ipAddress)
        {
            using (var context = new MonPanelDBContext())
            {
                var existingHost = context.Hosts.FirstOrDefault(h => h.IpAddress == ipAddress);
                if (existingHost != null)
                {
                    context.Hosts.Remove(existingHost);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Потом почитаю про исключения, a пока хост с IP-адресом {ipAddress} не найден.");
                }
            }
        }
    }
}