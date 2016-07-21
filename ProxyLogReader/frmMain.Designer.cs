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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbHighHirarchy = new System.Windows.Forms.ListBox();
            this.lbLowHirarchy = new System.Windows.Forms.ListBox();
            this.auswertenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nachIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.auswertenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1002, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbHighHirarchy);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbLowHirarchy);
            this.splitContainer1.Size = new System.Drawing.Size(1002, 498);
            this.splitContainer1.SplitterDistance = 334;
            this.splitContainer1.TabIndex = 1;
            // 
            // lbHighHirarchy
            // 
            this.lbHighHirarchy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHighHirarchy.FormattingEnabled = true;
            this.lbHighHirarchy.Location = new System.Drawing.Point(0, 0);
            this.lbHighHirarchy.Name = "lbHighHirarchy";
            this.lbHighHirarchy.Size = new System.Drawing.Size(334, 498);
            this.lbHighHirarchy.TabIndex = 0;
            this.lbHighHirarchy.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // lbLowHirarchy
            // 
            this.lbLowHirarchy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLowHirarchy.FormattingEnabled = true;
            this.lbLowHirarchy.Location = new System.Drawing.Point(0, 0);
            this.lbLowHirarchy.Name = "lbLowHirarchy";
            this.lbLowHirarchy.Size = new System.Drawing.Size(664, 498);
            this.lbLowHirarchy.TabIndex = 0;
            // 
            // auswertenToolStripMenuItem
            // 
            this.auswertenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nachIPToolStripMenuItem});
            this.auswertenToolStripMenuItem.Name = "auswertenToolStripMenuItem";
            this.auswertenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.auswertenToolStripMenuItem.Text = "Auswerten";
            // 
            // nachIPToolStripMenuItem
            // 
            this.nachIPToolStripMenuItem.Name = "nachIPToolStripMenuItem";
            this.nachIPToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nachIPToolStripMenuItem.Text = "Nach IP";
            this.nachIPToolStripMenuItem.Click += new System.EventHandler(this.nachIPToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 522);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Proxy Log Reader";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbHighHirarchy;
        private System.Windows.Forms.ListBox lbLowHirarchy;
        private System.Windows.Forms.ToolStripMenuItem auswertenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nachIPToolStripMenuItem;
    }
}

