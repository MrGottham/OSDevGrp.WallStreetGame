namespace OSDevGrp.WallStreetGame
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorExit = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelStockInformations = new System.Windows.Forms.Panel();
            this.groupBoxStockInformations = new System.Windows.Forms.GroupBox();
            this.panelStocks = new System.Windows.Forms.Panel();
            this.listViewStocks = new System.Windows.Forms.ListView();
            this.panelStockIndex = new System.Windows.Forms.Panel();
            this.comboBoxStockIndex = new System.Windows.Forms.ComboBox();
            this.labelStockIndex = new System.Windows.Forms.Label();
            this.panelPlayerInformations = new System.Windows.Forms.Panel();
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.labelAverageText = new System.Windows.Forms.Label();
            this.labelAverage = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.panelStockInformations.SuspendLayout();
            this.groupBoxStockInformations.SuspendLayout();
            this.panelStocks.SuspendLayout();
            this.panelStockIndex.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFiles,
            this.toolStripMenuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(792, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemFiles
            // 
            this.toolStripMenuItemFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewGame,
            this.toolStripSeparatorExit,
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFiles.Name = "toolStripMenuItemFiles";
            this.toolStripMenuItemFiles.Size = new System.Drawing.Size(39, 20);
            this.toolStripMenuItemFiles.Text = "&Filer";
            // 
            // toolStripMenuItemNewGame
            // 
            this.toolStripMenuItemNewGame.Name = "toolStripMenuItemNewGame";
            this.toolStripMenuItemNewGame.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItemNewGame.Text = "&Nyt spil";
            this.toolStripMenuItemNewGame.Click += new System.EventHandler(this.toolStripMenuItemNewGame_Click);
            // 
            // toolStripSeparatorExit
            // 
            this.toolStripSeparatorExit.Name = "toolStripSeparatorExit";
            this.toolStripSeparatorExit.Size = new System.Drawing.Size(117, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItemExit.Text = "&Afslut";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItemHelp.Text = "&Hjælp";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(101, 22);
            this.toolStripMenuItemAbout.Text = "&Om";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // panelStockInformations
            // 
            this.panelStockInformations.Controls.Add(this.groupBoxStockInformations);
            this.panelStockInformations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStockInformations.Location = new System.Drawing.Point(0, 24);
            this.panelStockInformations.Name = "panelStockInformations";
            this.panelStockInformations.Size = new System.Drawing.Size(792, 442);
            this.panelStockInformations.TabIndex = 1;
            // 
            // groupBoxStockInformations
            // 
            this.groupBoxStockInformations.Controls.Add(this.panelStocks);
            this.groupBoxStockInformations.Controls.Add(this.panelStockIndex);
            this.groupBoxStockInformations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStockInformations.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStockInformations.Name = "groupBoxStockInformations";
            this.groupBoxStockInformations.Size = new System.Drawing.Size(792, 442);
            this.groupBoxStockInformations.TabIndex = 0;
            this.groupBoxStockInformations.TabStop = false;
            this.groupBoxStockInformations.Text = "Aktier";
            // 
            // panelStocks
            // 
            this.panelStocks.Controls.Add(this.listViewStocks);
            this.panelStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStocks.Location = new System.Drawing.Point(3, 50);
            this.panelStocks.Name = "panelStocks";
            this.panelStocks.Size = new System.Drawing.Size(786, 389);
            this.panelStocks.TabIndex = 1;
            // 
            // listViewStocks
            // 
            this.listViewStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewStocks.LargeImageList = this.imageListLarge;
            this.listViewStocks.Location = new System.Drawing.Point(0, 0);
            this.listViewStocks.Name = "listViewStocks";
            this.listViewStocks.Size = new System.Drawing.Size(786, 389);
            this.listViewStocks.SmallImageList = this.imageListSmall;
            this.listViewStocks.TabIndex = 0;
            this.listViewStocks.UseCompatibleStateImageBehavior = false;
            this.listViewStocks.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewStocks_ColumnClick);
            // 
            // panelStockIndex
            // 
            this.panelStockIndex.Controls.Add(this.labelAverage);
            this.panelStockIndex.Controls.Add(this.labelAverageText);
            this.panelStockIndex.Controls.Add(this.comboBoxStockIndex);
            this.panelStockIndex.Controls.Add(this.labelStockIndex);
            this.panelStockIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStockIndex.Location = new System.Drawing.Point(3, 16);
            this.panelStockIndex.Name = "panelStockIndex";
            this.panelStockIndex.Size = new System.Drawing.Size(786, 34);
            this.panelStockIndex.TabIndex = 0;
            // 
            // comboBoxStockIndex
            // 
            this.comboBoxStockIndex.FormattingEnabled = true;
            this.comboBoxStockIndex.Location = new System.Drawing.Point(48, 6);
            this.comboBoxStockIndex.Name = "comboBoxStockIndex";
            this.comboBoxStockIndex.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStockIndex.TabIndex = 1;
            this.comboBoxStockIndex.SelectedIndexChanged += new System.EventHandler(this.comboBoxStockIndex_SelectedIndexChanged);
            // 
            // labelStockIndex
            // 
            this.labelStockIndex.AutoSize = true;
            this.labelStockIndex.Location = new System.Drawing.Point(9, 9);
            this.labelStockIndex.Name = "labelStockIndex";
            this.labelStockIndex.Size = new System.Drawing.Size(33, 13);
            this.labelStockIndex.TabIndex = 0;
            this.labelStockIndex.Text = "Index";
            // 
            // panelPlayerInformations
            // 
            this.panelPlayerInformations.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPlayerInformations.Location = new System.Drawing.Point(0, 466);
            this.panelPlayerInformations.Name = "panelPlayerInformations";
            this.panelPlayerInformations.Size = new System.Drawing.Size(792, 100);
            this.panelPlayerInformations.TabIndex = 2;
            // 
            // imageListLarge
            // 
            this.imageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLarge.ImageStream")));
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLarge.Images.SetKeyName(0, "Stock.bmp");
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "Stock.bmp");
            // 
            // labelAverageText
            // 
            this.labelAverageText.AutoSize = true;
            this.labelAverageText.Location = new System.Drawing.Point(175, 9);
            this.labelAverageText.Name = "labelAverageText";
            this.labelAverageText.Size = new System.Drawing.Size(63, 13);
            this.labelAverageText.TabIndex = 2;
            this.labelAverageText.Text = "Gennemsnit";
            // 
            // labelAverage
            // 
            this.labelAverage.AutoSize = true;
            this.labelAverage.Location = new System.Drawing.Point(244, 9);
            this.labelAverage.Name = "labelAverage";
            this.labelAverage.Size = new System.Drawing.Size(0, 13);
            this.labelAverage.TabIndex = 3;
            this.labelAverage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.panelStockInformations);
            this.Controls.Add(this.panelPlayerInformations);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Aktiespillet";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelStockInformations.ResumeLayout(false);
            this.groupBoxStockInformations.ResumeLayout(false);
            this.panelStocks.ResumeLayout(false);
            this.panelStockIndex.ResumeLayout(false);
            this.panelStockIndex.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFiles;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorExit;
        private System.Windows.Forms.Panel panelStockInformations;
        private System.Windows.Forms.Panel panelPlayerInformations;
        private System.Windows.Forms.GroupBox groupBoxStockInformations;
        private System.Windows.Forms.Panel panelStockIndex;
        private System.Windows.Forms.ComboBox comboBoxStockIndex;
        private System.Windows.Forms.Label labelStockIndex;
        private System.Windows.Forms.Panel panelStocks;
        private System.Windows.Forms.ListView listViewStocks;
        private System.Windows.Forms.ImageList imageListLarge;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.Label labelAverage;
        private System.Windows.Forms.Label labelAverageText;
    }
}

