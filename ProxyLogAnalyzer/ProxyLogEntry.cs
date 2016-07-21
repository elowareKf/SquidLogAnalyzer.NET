using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using ProxyLogAnalyzer;

namespace ProxyLogReader
{
    // Timestamp	Elapsed Time	Client Address	Log Tag / HTTP Code	Size	Request	Url	Ident	Hierarchy Data / Hostname	Content Type

    class ProxyLogEntry
    {
        public string TimeStamp { get; set; }
        public int Time { get; set; }
        public IpListEntry Client { get; set; }
        public string Destination { get; set; }
        public string LogTag { get; set; }
        public string Code { get; set; }
        public int Size { get; set; }
        public bool GetRequest { get; set; }
        public string Url { get; set; }
        public string Ident { get; set; }
        public string HierarchyData { get; set; }
        public string Hostname { get; set; }
        public string ContentType { get; set; }

        /// <summary>
        /// The sub domain of the Request
        /// </summary>
        public string SubDomain
        {
            get
            {
                string domain;

                if (Url.IndexOf('/') > 0)
                    domain = Url.Split('/')[2];
                else
                    domain = Url;
                return domain;
            }
        }

        /// <summary>
        /// Returns the domain 
        /// </summary>
        public string Domain
        {
            get
            {
                string domain;

                if (Url.IndexOf('/') > 0)
                    domain = Url.Split('/')[2];
                else
                    domain = Url;

                if (domain.IndexOf('.') > 0)
                {
                    string[] dom = domain.Split('.');
                    domain = dom[dom.GetLength(0) - 2] + "." + dom[dom.GetLength(0) - 1];
                }

                if (domain.IndexOf(':') > 0)
                    domain = domain.Substring(0, domain.IndexOf(':'));

                return domain;
            }
        }

        public override string ToString()
        {
            return TimeStamp + " - " + Domain + " - " + Hostname + " - " + LogTag;
        }
    }


    class ProxyLogEntryCollection : ICollection<ProxyLogEntry>, IEnumerable<ProxyLogEntry>
    {
        private List<ProxyLogEntry> collection;

        /// <summary>
        /// Returns a list of clients accessing the internet
        /// </summary>
        /// <returns></returns>
        public List<IpListEntry> GetHostList()
        {
            List<IpListEntry> hosts = new List<IpListEntry>();

            foreach (ProxyLogEntry host in collection)
            {
                if (hosts.Contains(host.Client))
                    continue;

                hosts.Add(host.Client);
            }

            return hosts;
        }

        /// <summary>
        /// Generates a list of domains
        /// </summary>
        /// <returns></returns>
        public List<string> GetDomainList()
        {
            List<string> domains = new List<string>();
            foreach (ProxyLogEntry host in collection)
            {
                if (domains.Contains(host.Domain))
                    continue;

                domains.Add(host.Domain);
            }

            return domains;
        }

        #region Implementation of Interfaces
        public ProxyLogEntryCollection()
        {
            collection = new List<ProxyLogEntry>();
        }

        public void Add(ProxyLogEntry item)
        {
            collection.Add(item);
        }

        public void Clear()
        {
            collection.Clear();
        }

        public bool Contains(ProxyLogEntry item)
        {
            return collection.Contains(item);
        }

        public void CopyTo(ProxyLogEntry[] array, int arrayIndex)
        {
            collection.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return collection.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(ProxyLogEntry item)
        {
            return collection.Remove(item);
        }

        public IEnumerator<ProxyLogEntry> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }
        #endregion
    }

}
