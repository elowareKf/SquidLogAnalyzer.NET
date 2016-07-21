using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ProxyLogAnalyzer
{
    public class IpListEntry
    {
        /// <summary>
        /// Hostname for the Ip
        /// </summary>
        public string Hostname = "";


        public IPAddress IpAddress
        {
            get { return ipAddress; }
            set
            {
                ipAddress = value;
                Hostname = IpIdentifier.GetHostName(value);
            }
        }
        private IPAddress ipAddress;


        /// <summary>
        /// Constructor parses the IP address
        /// </summary>
        /// <param name="ipAddress"></param>
        public IpListEntry(string ipAddress)
        {
            this.IpAddress = IPAddress.Parse(ipAddress);
        }

        public IpListEntry()
        { }

        /// <summary>
        /// Returns the hostname or ip address
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (Hostname == "") ? IpAddress.ToString() : Hostname;
        }

        public override bool Equals(object obj)
        {
            if (obj is DBNull) return true;

            return ((IpListEntry)obj).IpAddress.ToString() == IpAddress.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class IpIdentifier
    {
        private static string filename = Application.StartupPath + "\\ipaddress.txt";
        private static string[] lines;


        static List<IpListEntry> ipList;

        /// <summary>
        /// Initialiezes the ip address list
        /// </summary>
        public static void LoadList()
        {
            ipList = new List<IpListEntry>();

            if (!File.Exists(filename))
                return;

            lines = File.ReadAllLines(filename);

            for (int i = 1; i < lines.GetLength(0); i++)
            {
                IpListEntry list = new IpListEntry();
                string[] cols = lines[i].Split('\t');
                list.IpAddress = IPAddress.Parse(cols[0]);
                list.Hostname = cols[1];
                ipList.Add(list);
            }
        }

        /// <summary>
        /// Identifies a ip address and returns the hostname
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string GetHostName(string address)
        {
            string hostname = "";

            foreach (IpListEntry item in ipList)
            {
                if (item.IpAddress.ToString() == address)
                {
                    hostname = item.Hostname;
                    break;
                }
            }

            return hostname == "" ? address : hostname;
        }

        /// <summary>
        /// Identifies a ip address and returns the hostname
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string GetHostName(IPAddress address)
        {
            string hostname = "";

            foreach (IpListEntry item in ipList)
            {
                if (item.IpAddress.ToString() == address.ToString())
                {
                    hostname = item.Hostname;
                    break;
                }
            }

            return hostname == "" ? address.ToString() : hostname;
        }
    }
}
