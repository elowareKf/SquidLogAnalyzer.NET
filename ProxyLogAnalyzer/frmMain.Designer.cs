namespace ProxyLogReader
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importHeutigerDatensätzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auswertenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nachIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nachDomäneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unterkategorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zeitAuswertenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.verweigerteZugriffeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listboxExportierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doppelteUrlEinträgeLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbHighHirarchy = new System.Windows.Forms.ListBox();
            this.dgvAnalyze = new System.Windows.Forms.DataGridView();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_MostClickList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalyze)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.auswertenToolStripMenuItem,
            this.datenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1503, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.importHeutigerDatensätzeToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(332, 30);
            this.importToolStripMenuItem.Text = "Import Einträge von gestern...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // importHeutigerDatensätzeToolStripMenuItem
            // 
            this.importHeutigerDatensätzeToolStripMenuItem.Enabled = false;
            this.importHeutigerDatensätzeToolStripMenuItem.Name = "importHeutigerDatensätzeToolStripMenuItem";
            this.importHeutigerDatensätzeToolStripMenuItem.Size = new System.Drawing.Size(332, 30);
            this.importHeutigerDatensätzeToolStripMenuItem.Text = "Import freie Datumswahl...";
            this.importHeutigerDatensätzeToolStripMenuItem.Click += new System.EventHandler(this.importHeutigerDatensätzeToolStripMenuItem_Click);
            // 
            // auswertenToolStripMenuItem
            // 
            this.auswertenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nachIPToolStripMenuItem,
            this.nachDomäneToolStripMenuItem,
            this.unterkategorieToolStripMenuItem,
            this.toolStripMenuItem1,
            this.verweigerteZugriffeToolStripMenuItem,
            this.listboxExportierenToolStripMenuItem,
            this.toolStripMenuItem2,
            this.tsmi_MostClickList});
            this.auswertenToolStripMenuItem.Name = "auswertenToolStripMenuItem";
            this.auswertenToolStripMenuItem.Size = new System.Drawing.Size(107, 29);
            this.auswertenToolStripMenuItem.Text = "Auswerten";
            // 
            // nachIPToolStripMenuItem
            // 
            this.nachIPToolStripMenuItem.Name = "nachIPToolStripMenuItem";
            this.nachIPToolStripMenuItem.Size = new System.Drawing.Size(308, 30);
            this.nachIPToolStripMenuItem.Text = "Nach IP";
            this.nachIPToolStripMenuItem.Click += new System.EventHandler(this.nachIPToolStripMenuItem_Click);
            // 
            // nachDomäneToolStripMenuItem
            // 
            this.nachDomäneToolStripMenuItem.Name = "nachDomäneToolStripMenuItem";
            this.nachDomäneToolStripMenuItem.Size = new System.Drawing.Size(308, 30);
            this.nachDomäneToolStripMenuItem.Text = "Nach Domäne";
            this.nachDomäneToolStripMenuItem.Click += new System.EventHandler(this.nachDomäneToolStripMenuItem_Click);
            // 
            // unterkategorieToolStripMenuItem
            // 
            this.unterkategorieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zeitAuswertenToolStripMenuItem});
            this.unterkategorieToolStripMenuItem.Name = "unterkategorieToolStripMenuItem";
            this.unterkategorieToolStripMenuItem.Size = new System.Drawing.Size(308, 30);
            this.unterkategorieToolStripMenuItem.Text = "Unterkategorie";
            // 
            // zeitAuswertenToolStripMenuItem
            // 
            this.zeitAuswertenToolStripMenuItem.Name = "zeitAuswertenToolStripMenuItem";
            this.zeitAuswertenToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.zeitAuswertenToolStripMenuItem.Text = "Zeit auswerten";
            this.zeitAuswertenToolStripMenuItem.Click += new System.EventHandler(this.zeitAuswertenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(305, 6);
            // 
            // verweigerteZugriffeToolStripMenuItem
            // 
            this.verweigerteZugriffeToolStripMenuItem.Name = "verweigerteZugriffeToolStripMenuItem";
            this.verweigerteZugriffeToolStripMenuItem.Size = new System.Drawing.Size(308, 30);
            this.verweigerteZugriffeToolStripMenuItem.Text = "Verweigerte Zugriffe";
            this.verweigerteZugriffeToolStripMenuItem.Click += new System.EventHandler(this.verweigerteZugriffeToolStripMenuItem_Click);
            // 
            // listboxExportierenToolStripMenuItem
            // 
            this.listboxExportierenToolStripMenuItem.Name = "listboxExportierenToolStripMenuItem";
            this.listboxExportierenToolStripMenuItem.Size = new System.Drawing.Size(308, 30);
            this.listboxExportierenToolStripMenuItem.Text = "Listbox exportieren...";
            this.listboxExportierenToolStripMenuItem.Click += new System.EventHandler(this.listboxExportierenToolStripMenuItem_Click);
            // 
            // datenToolStripMenuItem
            // 
            this.datenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doppelteUrlEinträgeLöschenToolStripMenuItem});
            this.datenToolStripMenuItem.Name = "datenToolStripMenuItem";
            this.datenToolStripMenuItem.Size = new System.Drawing.Size(71, 29);
            this.datenToolStripMenuItem.Text = "Daten";
            // 
            // doppelteUrlEinträgeLöschenToolStripMenuItem
            // 
            this.doppelteUrlEinträgeLöschenToolStripMenuItem.Name = "doppelteUrlEinträgeLöschenToolStripMenuItem";
            this.doppelteUrlEinträgeLöschenToolStripMenuItem.Size = new System.Drawing.Size(423, 30);
            this.doppelteUrlEinträgeLöschenToolStripMenuItem.Text = "Doppelte Einträge löschen (zweite Spalte)";
            this.doppelteUrlEinträgeLöschenToolStripMenuItem.Click += new System.EventHandler(this.doppelteUrlEinträgeLöschenToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbHighHirarchy);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvAnalyze);
            this.splitContainer1.Size = new System.Drawing.Size(1503, 768);
            this.splitContainer1.SplitterDistance = 501;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // lbHighHirarchy
            // 
            this.lbHighHirarchy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHighHirarchy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHighHirarchy.ItemHeight = 26;
            this.lbHighHirarchy.Location = new System.Drawing.Point(0, 0);
            this.lbHighHirarchy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbHighHirarchy.Name = "lbHighHirarchy";
            this.lbHighHirarchy.Size = new System.Drawing.Size(501, 768);
            this.lbHighHirarchy.TabIndex = 0;
            this.lbHighHirarchy.SelectedIndexChanged += new System.EventHandler(this.listBox1_DoubleClick);
            this.lbHighHirarchy.DoubleClick += new System.EventHandler(this.lbHighHirarchy_DoubleClick);
            // 
            // dgvAnalyze
            // 
            this.dgvAnalyze.AllowUserToAddRows = false;
            this.dgvAnalyze.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnalyze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalyze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnalyze.Location = new System.Drawing.Point(0, 0);
            this.dgvAnalyze.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvAnalyze.Name = "dgvAnalyze";
            this.dgvAnalyze.RowHeadersVisible = false;
            this.dgvAnalyze.Size = new System.Drawing.Size(996, 768);
            this.dgvAnalyze.TabIndex = 1;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(305, 6);
            // 
            // tsmi_MostClickList
            // 
            this.tsmi_MostClickList.Name = "tsmi_MostClickList";
            this.tsmi_MostClickList.Size = new System.Drawing.Size(308, 30);
            this.tsmi_MostClickList.Text = "Webseiten Hitliste erstellen";
            this.tsmi_MostClickList.Click += new System.EventHandler(this.tsmi_MostClickList_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 803);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "Proxy Log Reader";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalyze)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbHighHirarchy;
        private System.Windows.Forms.ToolStripMenuItem auswertenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nachIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nachDomäneToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvAnalyze;
        private System.Windows.Forms.ToolStripMenuItem unterkategorieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zeitAuswertenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verweigerteZugriffeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importHeutigerDatensätzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doppelteUrlEinträgeLöschenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listboxExportierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_MostClickList;
    }
}

