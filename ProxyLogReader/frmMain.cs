using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace ProxyLogReader
{
    public partial class frmMain : Form
    {
        ProxyLogEntryCollection proxyLogs;
        public frmMain()
        {
            InitializeComponent();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename; 
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            filename = ofd.FileName;
            ofd.Dispose();

            if (filename != "")
                OpenFile(filename);        
        }

        /// <summary>
        /// Opens a Proxy log file and reads the information into a requestcollection
        /// </summary>
        /// <param name="filename"></param>
        private void OpenFile(string filename)
        {
            FileInfo file = new FileInfo(filename);
            FileStream stream = file.OpenRead();
            
            proxyLogs = new ProxyLogEntryCollection();
            double seconds;
            string[] lines = File.ReadAllLines(filename);

            for (int i = 0; i < lines.GetLength(0) && i < 50000; i++)
            {
                string[] items = lines[i].Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                DateTime x = new DateTime(1970, 1, 1, 0, 0, 0);
                seconds = Convert.ToDouble(items[0]);
                x = x.AddMilliseconds(seconds);
                x = x.AddHours(1);

                if (x.IsDaylightSavingTime())
                    x = x.AddHours(1);

                ProxyLogEntry entry = new ProxyLogEntry();
                entry.TimeStamp = x;
                entry.Time = Convert.ToInt32(items[1]);
                entry.Client = IPAddress.Parse(items[2]);
                entry.LogTag = items[3].Split('/')[0];
                entry.Code = items[3].Split('/')[1];
                entry.Size = Convert.ToInt32(items[4]);
                entry.GetRequest = items[5] == "GET";
                entry.Url = items[6];
                entry.Ident = items[7];
                entry.HierarchyData = items[8].Split('/')[0];
                entry.Hostname = items[8].Split('/')[1];
                proxyLogs.Add(entry);
            }

            
        }

        private void nachIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbHighHirarchy.Items.Clear();
            List<IPAddress> addresses =  proxyLogs.GetHostList();
            foreach (IPAddress address in addresses)
            {
                lbHighHirarchy.Items.Add(address);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            lbLowHirarchy.Items.Clear();
            IPAddress ipAddress = (IPAddress)lbHighHirarchy.Items[lbHighHirarchy.SelectedIndex];

            IEnumerable<ProxyLogEntry> filtered = (IEnumerable<ProxyLogEntry>)proxyLogs.Where<ProxyLogEntry>(entry => entry.Client.ToString() == ipAddress.ToString());

            foreach (ProxyLogEntry item in filtered)
            {
                lbLowHirarchy.Items.Add(item.ToString());
            }
        }
    }
}
