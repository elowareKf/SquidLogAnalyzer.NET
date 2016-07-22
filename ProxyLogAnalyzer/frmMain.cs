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
using ProxyLogAnalyzer;
using System.Threading.Tasks;

namespace ProxyLogReader {
    public partial class frmMain : Form {
        private enum KindOfAnalyze {
            No,
            IpAdresse,
            Domain,
            TcpDenied
        }
        System.Threading.Thread GetHostNamesClickMaster;

        KindOfAnalyze kindOfAnalyze = KindOfAnalyze.No;

        ProxyLogEntryCollection proxyLogs;
        public frmMain() {
            InitializeComponent();
        }

        private async void importToolStripMenuItem_Click(object sender, EventArgs e) {
            string filename;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            filename = ofd.FileName;
            ofd.Dispose();
            auswertenToolStripMenuItem.Enabled = false;

            if (filename != "") {
                if (sender == importToolStripMenuItem)
                    await Task.Run(() => { OpenFile(filename, DateTime.Now.AddDays(-1)); });
                else if (sender == importHeutigerDatensätzeToolStripMenuItem)
                    await Task.Run(() => { OpenFile(filename, DateTime.Now); });
                else if (sender == tsmiImportWoFilter)
                    await Task.Run(() => { OpenFile(filename, null); });

            }
        }

        /// <summary>
        /// Opens a Proxy log file and reads the information into a requestcollection
        /// </summary>
        /// <param name="filename"></param>
        private void OpenFile(string filename, DateTime? filter) {
            FileInfo file = new FileInfo(filename);
            FileStream stream = file.OpenRead();

            proxyLogs = new ProxyLogEntryCollection();
            string LinuxDate;

            StreamReader reader = new StreamReader(filename);


            while (!reader.EndOfStream) {
                string line = reader.ReadLine();
                string[] items = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                DateTime x = new DateTime(1970, 1, 1, 0, 0, 0);
                LinuxDate = items[0];

                if (filter != null)
                    if (!LinuxDate.StartsWith(((DateTime)filter).ToString("dd'/'MMM'/'yyyy")))
                        continue;

                ProxyLogEntry entry = new ProxyLogEntry();
                entry.TimeStamp = LinuxDate;
                entry.Time = Convert.ToInt32(items[1]);
                entry.Client = new IpListEntry(items[2]);
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
            reader.Close();

            BeginInvoke(new EmptyDelegate(() => {
                MessageBox.Show("Daten importiert!");
                auswertenToolStripMenuItem.Enabled = true;
            }));
        }

        delegate void EmptyDelegate();

        private void listBox1_DoubleClick(object sender, EventArgs e) {
            //            MessageBox.Show(lbHighHirarchy.SelectedItem.ToString());

            switch (kindOfAnalyze) {
                case KindOfAnalyze.No:
                    break;

                // Analyze ip addresses
                case KindOfAnalyze.IpAdresse:
                    dgvAnalyze.Columns.Clear();
                    dgvAnalyze.Columns.Add("ColTime", "Time");
                    dgvAnalyze.Columns.Add("ColDomain", "Domain");
                    dgvAnalyze.Columns.Add("ColHost", "Hostname");
                    dgvAnalyze.Columns.Add("ColLogTag", "LogTag");
                    dgvAnalyze.Columns.Add("ColURL", "URL");

                    IpListEntry ipAddress = (IpListEntry)lbHighHirarchy.Items[lbHighHirarchy.SelectedIndex];

                    IEnumerable<ProxyLogEntry> filtered = (IEnumerable<ProxyLogEntry>)proxyLogs.Where<ProxyLogEntry>(entry => entry.Client.ToString() == ipAddress.ToString());

                    foreach (ProxyLogEntry item in filtered) {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgvAnalyze);
                        row.Cells[0].Value = item.TimeStamp;
                        row.Cells[0].Tag = item.TimeStamp;
                        row.Cells[1].Value = item.Domain;
                        row.Cells[2].Value = item.Hostname;
                        row.Cells[3].Value = item.LogTag;
                        row.Cells[4].Value = item.Url;

                        dgvAnalyze.Rows.Add(row);
                    }
                    break;

                // Analyze domains
                case KindOfAnalyze.Domain:
                    dgvAnalyze.Columns.Clear();
                    dgvAnalyze.Columns.Add("ColTime", "Time");
                    dgvAnalyze.Columns.Add("ColUser", "User");
                    dgvAnalyze.Columns.Add("ColLogTag", "LogTag");

                    string domain = (string)lbHighHirarchy.Items[lbHighHirarchy.SelectedIndex];

                    filtered = (IEnumerable<ProxyLogEntry>)proxyLogs.Where<ProxyLogEntry>(entry => entry.Domain == domain);

                    foreach (ProxyLogEntry item in filtered) {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgvAnalyze);
                        row.Cells[0].Value = item.TimeStamp;
                        row.Cells[0].Tag = item.TimeStamp;
                        row.Cells[1].Value = GetMachineNameFromIPAddress(item.Client.IpAddress.ToString());
                        row.Cells[2].Value = item.LogTag;

                        dgvAnalyze.Rows.Add(row);
                    }
                    break;

                case KindOfAnalyze.TcpDenied:
                default:
                    break;
            }
        }

        private void nachIPToolStripMenuItem_Click(object sender, EventArgs e) {
            lbHighHirarchy.Items.Clear();
            kindOfAnalyze = KindOfAnalyze.IpAdresse;

            List<IpListEntry> addresses = proxyLogs.GetHostList();
            foreach (IpListEntry address in addresses.OrderBy(x => x.ToString())) {
                lbHighHirarchy.Items.Add(address);
            }
            lbHighHirarchy.Refresh();
        }


        private void nachDomäneToolStripMenuItem_Click(object sender, EventArgs e) {
            lbHighHirarchy.Items.Clear();
            kindOfAnalyze = KindOfAnalyze.Domain;

            List<string> addresses = proxyLogs.GetDomainList();
            addresses.Sort();
            foreach (string address in addresses) {
                lbHighHirarchy.Items.Add(address);
            }

        }

        /// <summary>
        /// Wertet den aktuellen Benutzer nach der Zeit aus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zeitAuswertenToolStripMenuItem_Click(object sender, EventArgs e) {
            if (kindOfAnalyze != KindOfAnalyze.IpAdresse) {
                MessageBox.Show("Bitte nach IP auswerten");
                return;
            }

            List<TimeSpan> timeSpans = new List<TimeSpan>();

            DateTime start = DateTime.MinValue;

            for (int i = 0; i < dgvAnalyze.Rows.Count - 1; i++) {
                if (dgvAnalyze.Rows[i].Cells[3].Value.ToString() == "TCP_DENIED")
                    continue;

                DateTime time = (DateTime)dgvAnalyze.Rows[i].Cells[0].Tag;
                DateTime nxtTime = (DateTime)dgvAnalyze.Rows[i + 1].Cells[0].Tag;



                if (start == DateTime.MinValue)
                    start = time;

                if (time.AddMinutes(15) < nxtTime) {
                    timeSpans.Add(new TimeSpan(nxtTime.Ticks - start.Ticks));
                    start = DateTime.MinValue;
                }

            }

            TimeSpan whole = new TimeSpan(0);
            foreach (TimeSpan span in timeSpans) {
                whole += span;
            }

            MessageBox.Show("Der User war " + whole.ToString() + " im Internet");
        }

        private void frmMain_Load(object sender, EventArgs e) {
            IpIdentifier.LoadList();
        }


        private void verweigerteZugriffeToolStripMenuItem_Click(object sender, EventArgs e) {
            kindOfAnalyze = KindOfAnalyze.TcpDenied;

            DataGridViewLinkColumn col = new DataGridViewLinkColumn();
            col.Name = "ColLink";
            col.Text = "Link";


            dgvAnalyze.Columns.Clear();
            dgvAnalyze.Columns.Add("ColTime", "Time");
            dgvAnalyze.Columns.Add("ColDomain", "Domain");
            dgvAnalyze.Columns.Add("ColUser", "User");
            dgvAnalyze.Columns.Add(col);

            //            string domain = (string)lbHighHirarchy.Items[lbHighHirarchy.SelectedIndex];

            IEnumerable<ProxyLogEntry> filtered = (IEnumerable<ProxyLogEntry>)proxyLogs.Where<ProxyLogEntry>(entry => entry.LogTag == "TCP_DENIED");

            foreach (ProxyLogEntry item in filtered.OrderBy(x => x.Url)) {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvAnalyze);
                row.Cells[0].Value = item.TimeStamp;
                row.Cells[0].Tag = item.TimeStamp;
                row.Cells[1].Value = item.SubDomain;
                row.Cells[2].Value = IpIdentifier.GetHostName(item.Client.IpAddress);
                row.Cells[3].Value = item.Url;
                row.Cells[3].ToolTipText = item.Url;
                ((DataGridViewLinkCell)(row.Cells[3])).LinkBehavior = LinkBehavior.AlwaysUnderline;

                dgvAnalyze.Rows.Add(row);
            }

        }

        private void doppelteUrlEinträgeLöschenToolStripMenuItem_Click(object sender, EventArgs e) {
            List<string> urls = new List<string>();

            for (int i = 0; i < dgvAnalyze.RowCount; i++) {
                string url = dgvAnalyze.Rows[i].Cells[1].Value.ToString();
                if (urls.Contains(url)) {
                    dgvAnalyze.Rows.Remove(dgvAnalyze.Rows[i]);
                    i--;
                } else
                    urls.Add(url);
            }
        }

        private void listboxExportierenToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK) {
                File.WriteAllLines(sfd.FileName, lbHighHirarchy.Items.Cast<string>().ToArray<string>());
            }
        }

        private void lbHighHirarchy_DoubleClick(object sender, EventArgs e) {
            string command = $"http://www.{lbHighHirarchy.SelectedItem.ToString()}";
            System.Diagnostics.Process.Start(command);
        }


        Dictionary<string, string> ipLookupTable = new Dictionary<string, string>();
        private string GetMachineNameFromIPAddress(string ipAddress) {
            if (!ipLookupTable.ContainsKey(ipAddress)) {

                string machineName = string.Empty;
                try {
                    IPHostEntry hostEntry = Dns.GetHostEntry(ipAddress);

                    machineName = hostEntry.HostName;
                } catch (Exception ex) {
                    ipLookupTable.Add(ipAddress, ipAddress);
                    return ipAddress;
                }
                ipLookupTable.Add(ipAddress, machineName);
                return machineName;
            } else
                return ipLookupTable[ipAddress];
        }

        private class ChartEntry {
            public string Website { get; set; }
            public int Clicks { get; set; }
            public override string ToString() => Website + " " + Clicks.ToString();
        }


        private void tsmi_MostClickList_Click(object sender, EventArgs e) {
            if (GetHostNamesClickMaster.ThreadState == System.Threading.ThreadState.Running)
                GetHostNamesClickMaster.Abort();

            List<ChartEntry> charts = new List<ChartEntry>();
            foreach (var log in proxyLogs) {
                if (charts.Find(x => x.Website == log.Domain) == null)
                    charts.Add(new ChartEntry() { Website = log.Domain, Clicks = 1 });
                else
                    charts.Find(x => x.Website == log.Domain).Clicks++;
            }
            dgvAnalyze.Rows.Clear();
            dgvAnalyze.Columns.Clear();
            dgvAnalyze.Columns.Add("Website", "Website");
            dgvAnalyze.Columns.Add("Clicks", "Clicks");

            foreach (var hit in charts) {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvAnalyze);
                row.Cells[0].Value = hit.Website;
                row.Cells[1].Value = hit.Clicks;
                dgvAnalyze.Rows.Add(row);
            }
        }


        private class ClickMaster {
            public IPAddress IpAddress { get; set; }
            public string Name { get; set; }
            public int Clicks { get; set; }
            public override string ToString() => $"{IpAddress} - {Name}: {Clicks}";
        }

        private void tsmiClickmaster_Click(object sender, EventArgs e) {
            List<ClickMaster> charts = new List<ClickMaster>();
            foreach (var log in proxyLogs) {
                if (charts.Find(x => x.IpAddress.ToString() == log.Client.IpAddress.ToString()) == null)
                    charts.Add(new ClickMaster() { IpAddress = log.Client.IpAddress, Clicks = 1 });
                else
                    charts.Find(x => x.IpAddress.ToString() == log.Client.IpAddress.ToString()).Clicks++;
            }

            dgvAnalyze.Rows.Clear();
            dgvAnalyze.Columns.Clear();
            dgvAnalyze.Columns.Add("IP", "IP Adresse");
            dgvAnalyze.Columns.Add("NetName", "PC Name");
            dgvAnalyze.Columns.Add("Clicks", "Clicks");

            foreach (var hit in charts) {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvAnalyze);
                row.Cells[0].Value = hit.IpAddress;
                row.Cells[2].Value = hit.Clicks;
                dgvAnalyze.Rows.Add(row);
            }

            GetHostNamesClickMaster = new System.Threading.Thread(() => {
            foreach (DataGridViewRow row in dgvAnalyze.Rows) {
                string ipAddress = ((IPAddress)row.Cells[0].Value).ToString();
                string name = GetMachineNameFromIPAddress(ipAddress);

                BeginInvoke((EmptyDelegate)(() => {
                    row.Cells[1].Value = name;
                }));
                }
            });
            GetHostNamesClickMaster.Start();
        }

        delegate void StringParamDelegate(string param, DataGridViewRow row);
    }
}
