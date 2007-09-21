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
            if (disposing && (StockForms != null))
            {
                while (StockForms.Count > 0)
                {
                    StockForm stockform = StockForms[0];
                    StockForms.Remove(stockform);
                    stockform.Dispose();
                    stockform = null;
                }
                StockForms = null;
            }
            if (disposing && (StatisticsForms != null))
            {
                while (StatisticsForms.Count > 0)
                {
                    StatisticsForm statisticsform = StatisticsForms[0];
                    StatisticsForms.Remove(statisticsform);
                    statisticsform.Dispose();
                    statisticsform = null;
                }
                StatisticsForms = null;
            }
            if (disposing && (Server != null))
            {
                Server.Dispose();
                Server = null;
            }
            if (disposing && (Client != null))
            {
                Client.Dispose();
                Client = null;
            }
            if (disposing && (Game != null))
            {
                Game.Dispose();
                Game = null;
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
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItemView;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripMenuItemDeposit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemValueLineGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemValueBarGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorOpen = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorExit = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemFunctions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTrade = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorPause = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemPause = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemContinue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClient = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelStockInformations = new System.Windows.Forms.Panel();
            this.groupBoxStockInformations = new System.Windows.Forms.GroupBox();
            this.panelStocks = new System.Windows.Forms.Panel();
            this.listViewStocks = new System.Windows.Forms.ListView();
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.panelStockIndex = new System.Windows.Forms.Panel();
            this.labelBrokerage = new System.Windows.Forms.Label();
            this.labelBrokerageText = new System.Windows.Forms.Label();
            this.labelMarketState = new System.Windows.Forms.Label();
            this.labelMarketStateText = new System.Windows.Forms.Label();
            this.labelAverage = new System.Windows.Forms.Label();
            this.labelAverageText = new System.Windows.Forms.Label();
            this.comboBoxStockIndex = new System.Windows.Forms.ComboBox();
            this.labelStockIndex = new System.Windows.Forms.Label();
            this.panelPlayerInformations = new System.Windows.Forms.Panel();
            this.panelPlayer3And4 = new System.Windows.Forms.Panel();
            this.panelPlayer4 = new System.Windows.Forms.Panel();
            this.groupBoxPlayer4 = new System.Windows.Forms.GroupBox();
            this.textBoxPlayer4Value = new System.Windows.Forms.TextBox();
            this.labelPlayer4Value = new System.Windows.Forms.Label();
            this.textBoxPlayer4DepositValue = new System.Windows.Forms.TextBox();
            this.labelPlayer4DepositValue = new System.Windows.Forms.Label();
            this.textBoxPlayer4Capital = new System.Windows.Forms.TextBox();
            this.labelPlayer4Capital = new System.Windows.Forms.Label();
            this.textBoxPlayer4Name = new System.Windows.Forms.TextBox();
            this.labelPlayer4Name = new System.Windows.Forms.Label();
            this.comboBoxPlayer4Company = new System.Windows.Forms.ComboBox();
            this.labelPlayer4Company = new System.Windows.Forms.Label();
            this.panelPlayer3 = new System.Windows.Forms.Panel();
            this.groupBoxPlayer3 = new System.Windows.Forms.GroupBox();
            this.textBoxPlayer3Value = new System.Windows.Forms.TextBox();
            this.labelPlayer3Value = new System.Windows.Forms.Label();
            this.textBoxPlayer3DepositValue = new System.Windows.Forms.TextBox();
            this.labelPlayer3DepositValue = new System.Windows.Forms.Label();
            this.textBoxPlayer3Capital = new System.Windows.Forms.TextBox();
            this.labelPlayer3Capital = new System.Windows.Forms.Label();
            this.textBoxPlayer3Name = new System.Windows.Forms.TextBox();
            this.labelPlayer3Name = new System.Windows.Forms.Label();
            this.comboBoxPlayer3Company = new System.Windows.Forms.ComboBox();
            this.labelPlayer3Company = new System.Windows.Forms.Label();
            this.panelPlayer1And2 = new System.Windows.Forms.Panel();
            this.panelPlayer2 = new System.Windows.Forms.Panel();
            this.groupBoxPlayer2 = new System.Windows.Forms.GroupBox();
            this.textBoxPlayer2Value = new System.Windows.Forms.TextBox();
            this.labelPlayer2Value = new System.Windows.Forms.Label();
            this.textBoxPlayer2DepositValue = new System.Windows.Forms.TextBox();
            this.labelPlayer2DepositValue = new System.Windows.Forms.Label();
            this.textBoxPlayer2Capital = new System.Windows.Forms.TextBox();
            this.labelPlayer2Capital = new System.Windows.Forms.Label();
            this.textBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.labelPlayer2Name = new System.Windows.Forms.Label();
            this.comboBoxPlayer2Company = new System.Windows.Forms.ComboBox();
            this.labelPlayer2Company = new System.Windows.Forms.Label();
            this.panelPlayer1 = new System.Windows.Forms.Panel();
            this.groupBoxPlayer1 = new System.Windows.Forms.GroupBox();
            this.textBoxPlayer1Value = new System.Windows.Forms.TextBox();
            this.labelPlayer1Value = new System.Windows.Forms.Label();
            this.textBoxPlayer1DepositValue = new System.Windows.Forms.TextBox();
            this.labelPlayer1DepositValue = new System.Windows.Forms.Label();
            this.textBoxPlayer1Capital = new System.Windows.Forms.TextBox();
            this.labelPlayer1Capital = new System.Windows.Forms.Label();
            this.textBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.textBoxPlayer1Company = new System.Windows.Forms.TextBox();
            this.labelPlayer1Company = new System.Windows.Forms.Label();
            toolStripMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.panelStockInformations.SuspendLayout();
            this.groupBoxStockInformations.SuspendLayout();
            this.panelStocks.SuspendLayout();
            this.panelStockIndex.SuspendLayout();
            this.panelPlayerInformations.SuspendLayout();
            this.panelPlayer3And4.SuspendLayout();
            this.panelPlayer4.SuspendLayout();
            this.groupBoxPlayer4.SuspendLayout();
            this.panelPlayer3.SuspendLayout();
            this.groupBoxPlayer3.SuspendLayout();
            this.panelPlayer1And2.SuspendLayout();
            this.panelPlayer2.SuspendLayout();
            this.groupBoxPlayer2.SuspendLayout();
            this.panelPlayer1.SuspendLayout();
            this.groupBoxPlayer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItemDeposit
            // 
            this.toolStripMenuItemDeposit.Image = global::OSDevGrp.Properties.Resources.StockHS;
            this.toolStripMenuItemDeposit.Name = "toolStripMenuItemDeposit";
            this.toolStripMenuItemDeposit.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItemDeposit.Text = "&Aktier i depot";
            // 
            // toolStripMenuItemStatistics
            // 
            this.toolStripMenuItemStatistics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemValueLineGraph,
            this.toolStripMenuItemValueBarGraph});
            this.toolStripMenuItemStatistics.Image = global::OSDevGrp.Properties.Resources.StatisticsHS;
            this.toolStripMenuItemStatistics.Name = "toolStripMenuItemStatistics";
            this.toolStripMenuItemStatistics.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItemStatistics.Text = "&Statistikker";
            // 
            // toolStripMenuItemValueLineGraph
            // 
            this.toolStripMenuItemValueLineGraph.Name = "toolStripMenuItemValueLineGraph";
            this.toolStripMenuItemValueLineGraph.Size = new System.Drawing.Size(206, 22);
            this.toolStripMenuItemValueLineGraph.Text = "Aktiver i alt, &liniediagram";
            this.toolStripMenuItemValueLineGraph.Click += new System.EventHandler(this.toolStripMenuItemValueLineGraph_Click);
            // 
            // toolStripMenuItemValueBarGraph
            // 
            this.toolStripMenuItemValueBarGraph.Name = "toolStripMenuItemValueBarGraph";
            this.toolStripMenuItemValueBarGraph.Size = new System.Drawing.Size(206, 22);
            this.toolStripMenuItemValueBarGraph.Text = "Aktiver i alt, &søjlediagram";
            this.toolStripMenuItemValueBarGraph.Click += new System.EventHandler(this.toolStripMenuItemValueBarGraph_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFiles,
            toolStripMenuItemView,
            this.toolStripMenuItemFunctions,
            this.toolStripMenuItemNetwork,
            this.toolStripMenuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(792, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // toolStripMenuItemFiles
            // 
            this.toolStripMenuItemFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewGame,
            this.toolStripSeparatorOpen,
            this.toolStripMenuItemOpen,
            this.toolStripMenuItemSave,
            this.toolStripMenuItemSaveAs,
            this.toolStripSeparatorExit,
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFiles.Name = "toolStripMenuItemFiles";
            this.toolStripMenuItemFiles.Size = new System.Drawing.Size(39, 20);
            this.toolStripMenuItemFiles.Text = "&Filer";
            // 
            // toolStripMenuItemNewGame
            // 
            this.toolStripMenuItemNewGame.Image = global::OSDevGrp.Properties.Resources.NewDocumentHS;
            this.toolStripMenuItemNewGame.Name = "toolStripMenuItemNewGame";
            this.toolStripMenuItemNewGame.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItemNewGame.Text = "&Nyt spil";
            this.toolStripMenuItemNewGame.Click += new System.EventHandler(this.toolStripMenuItemNewGame_Click);
            // 
            // toolStripSeparatorOpen
            // 
            this.toolStripSeparatorOpen.Name = "toolStripSeparatorOpen";
            this.toolStripSeparatorOpen.Size = new System.Drawing.Size(159, 6);
            // 
            // toolStripMenuItemOpen
            // 
            this.toolStripMenuItemOpen.Image = global::OSDevGrp.Properties.Resources.OpenHS;
            this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            this.toolStripMenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItemOpen.Text = "&Åbn spil";
            this.toolStripMenuItemOpen.Click += new System.EventHandler(this.toolStripMenuItemOpen_Click);
            // 
            // toolStripMenuItemSave
            // 
            this.toolStripMenuItemSave.Image = global::OSDevGrp.Properties.Resources.SaveHS;
            this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            this.toolStripMenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSave.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItemSave.Text = "&Gem spil";
            this.toolStripMenuItemSave.Click += new System.EventHandler(this.toolStripMenuItemSave_Click);
            // 
            // toolStripMenuItemSaveAs
            // 
            this.toolStripMenuItemSaveAs.Name = "toolStripMenuItemSaveAs";
            this.toolStripMenuItemSaveAs.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItemSaveAs.Text = "Gem spil som";
            this.toolStripMenuItemSaveAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripMenuItemSaveAs.Click += new System.EventHandler(this.toolStripMenuItemSaveAs_Click);
            // 
            // toolStripSeparatorExit
            // 
            this.toolStripSeparatorExit.Name = "toolStripSeparatorExit";
            this.toolStripSeparatorExit.Size = new System.Drawing.Size(159, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItemExit.Text = "&Afslut";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemView
            // 
            toolStripMenuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDeposit,
            this.toolStripMenuItemStatistics});
            toolStripMenuItemView.Name = "toolStripMenuItemView";
            toolStripMenuItemView.Size = new System.Drawing.Size(32, 20);
            toolStripMenuItemView.Text = "&Vis";
            // 
            // toolStripMenuItemFunctions
            // 
            this.toolStripMenuItemFunctions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTrade,
            this.toolStripSeparatorPause,
            this.toolStripMenuItemPause,
            this.toolStripMenuItemContinue});
            this.toolStripMenuItemFunctions.Name = "toolStripMenuItemFunctions";
            this.toolStripMenuItemFunctions.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItemFunctions.Text = "F&unktioner";
            // 
            // toolStripMenuItemTrade
            // 
            this.toolStripMenuItemTrade.Image = global::OSDevGrp.Properties.Resources.StockHS;
            this.toolStripMenuItemTrade.Name = "toolStripMenuItemTrade";
            this.toolStripMenuItemTrade.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemTrade.Text = "&Købe / sælge aktier";
            this.toolStripMenuItemTrade.Click += new System.EventHandler(this.listViewStocks_DoubleClick);
            // 
            // toolStripSeparatorPause
            // 
            this.toolStripSeparatorPause.Name = "toolStripSeparatorPause";
            this.toolStripSeparatorPause.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripMenuItemPause
            // 
            this.toolStripMenuItemPause.Image = global::OSDevGrp.Properties.Resources.PauseHS;
            this.toolStripMenuItemPause.Name = "toolStripMenuItemPause";
            this.toolStripMenuItemPause.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemPause.Text = "&Pause";
            this.toolStripMenuItemPause.Click += new System.EventHandler(this.toolStripMenuItemPause_Click);
            // 
            // toolStripMenuItemContinue
            // 
            this.toolStripMenuItemContinue.Image = global::OSDevGrp.Properties.Resources.PlayHS;
            this.toolStripMenuItemContinue.Name = "toolStripMenuItemContinue";
            this.toolStripMenuItemContinue.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemContinue.Text = "&Fortsæt";
            this.toolStripMenuItemContinue.Click += new System.EventHandler(this.toolStripMenuItemContinue_Click);
            // 
            // toolStripMenuItemNetwork
            // 
            this.toolStripMenuItemNetwork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemServer,
            this.toolStripMenuItemClient});
            this.toolStripMenuItemNetwork.Name = "toolStripMenuItemNetwork";
            this.toolStripMenuItemNetwork.Size = new System.Drawing.Size(81, 20);
            this.toolStripMenuItemNetwork.Text = "&Netværksspil";
            // 
            // toolStripMenuItemServer
            // 
            this.toolStripMenuItemServer.Name = "toolStripMenuItemServer";
            this.toolStripMenuItemServer.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItemServer.Text = "&Server";
            this.toolStripMenuItemServer.Click += new System.EventHandler(this.toolStripMenuItemServer_Click);
            // 
            // toolStripMenuItemClient
            // 
            this.toolStripMenuItemClient.Name = "toolStripMenuItemClient";
            this.toolStripMenuItemClient.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItemClient.Text = "&Klient";
            this.toolStripMenuItemClient.Click += new System.EventHandler(this.toolStripMenuItemClient_Click);
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
            this.panelStockInformations.Size = new System.Drawing.Size(792, 246);
            this.panelStockInformations.TabIndex = 1;
            // 
            // groupBoxStockInformations
            // 
            this.groupBoxStockInformations.Controls.Add(this.panelStocks);
            this.groupBoxStockInformations.Controls.Add(this.panelStockIndex);
            this.groupBoxStockInformations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStockInformations.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStockInformations.Name = "groupBoxStockInformations";
            this.groupBoxStockInformations.Size = new System.Drawing.Size(792, 246);
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
            this.panelStocks.Size = new System.Drawing.Size(786, 193);
            this.panelStocks.TabIndex = 1;
            // 
            // listViewStocks
            // 
            this.listViewStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewStocks.LargeImageList = this.imageListLarge;
            this.listViewStocks.Location = new System.Drawing.Point(0, 0);
            this.listViewStocks.Name = "listViewStocks";
            this.listViewStocks.Size = new System.Drawing.Size(786, 193);
            this.listViewStocks.SmallImageList = this.imageListSmall;
            this.listViewStocks.TabIndex = 0;
            this.listViewStocks.UseCompatibleStateImageBehavior = false;
            this.listViewStocks.DoubleClick += new System.EventHandler(this.listViewStocks_DoubleClick);
            this.listViewStocks.SelectedIndexChanged += new System.EventHandler(this.listViewStocks_SelectedIndexChanged);
            this.listViewStocks.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewStocks_ColumnClick);
            // 
            // imageListLarge
            // 
            this.imageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLarge.ImageStream")));
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLarge.Images.SetKeyName(0, "Stock.bmp");
            this.imageListLarge.Images.SetKeyName(1, "Server.bmp");
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "Stock.bmp");
            this.imageListSmall.Images.SetKeyName(1, "Server.bmp");
            // 
            // panelStockIndex
            // 
            this.panelStockIndex.Controls.Add(this.labelBrokerage);
            this.panelStockIndex.Controls.Add(this.labelBrokerageText);
            this.panelStockIndex.Controls.Add(this.labelMarketState);
            this.panelStockIndex.Controls.Add(this.labelMarketStateText);
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
            // labelBrokerage
            // 
            this.labelBrokerage.AutoSize = true;
            this.labelBrokerage.Location = new System.Drawing.Point(498, 9);
            this.labelBrokerage.Name = "labelBrokerage";
            this.labelBrokerage.Size = new System.Drawing.Size(31, 13);
            this.labelBrokerage.TabIndex = 7;
            this.labelBrokerage.Text = "#,##";
            // 
            // labelBrokerageText
            // 
            this.labelBrokerageText.AutoSize = true;
            this.labelBrokerageText.Location = new System.Drawing.Point(448, 9);
            this.labelBrokerageText.Name = "labelBrokerageText";
            this.labelBrokerageText.Size = new System.Drawing.Size(44, 13);
            this.labelBrokerageText.TabIndex = 6;
            this.labelBrokerageText.Text = "Kurtage";
            // 
            // labelMarketState
            // 
            this.labelMarketState.AutoSize = true;
            this.labelMarketState.Location = new System.Drawing.Point(393, 9);
            this.labelMarketState.Name = "labelMarketState";
            this.labelMarketState.Size = new System.Drawing.Size(49, 13);
            this.labelMarketState.TabIndex = 5;
            this.labelMarketState.Text = "######";
            this.labelMarketState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelMarketStateText
            // 
            this.labelMarketStateText.AutoSize = true;
            this.labelMarketStateText.Location = new System.Drawing.Point(329, 9);
            this.labelMarketStateText.Name = "labelMarketStateText";
            this.labelMarketStateText.Size = new System.Drawing.Size(58, 13);
            this.labelMarketStateText.TabIndex = 4;
            this.labelMarketStateText.Text = "Konjunktur";
            // 
            // labelAverage
            // 
            this.labelAverage.AutoSize = true;
            this.labelAverage.Location = new System.Drawing.Point(244, 9);
            this.labelAverage.Name = "labelAverage";
            this.labelAverage.Size = new System.Drawing.Size(79, 13);
            this.labelAverage.TabIndex = 3;
            this.labelAverage.Text = "#.###.###,##";
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
            // comboBoxStockIndex
            // 
            this.comboBoxStockIndex.FormattingEnabled = true;
            this.comboBoxStockIndex.Location = new System.Drawing.Point(42, 6);
            this.comboBoxStockIndex.Name = "comboBoxStockIndex";
            this.comboBoxStockIndex.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStockIndex.TabIndex = 1;
            this.comboBoxStockIndex.SelectedIndexChanged += new System.EventHandler(this.comboBoxStockIndex_SelectedIndexChanged);
            // 
            // labelStockIndex
            // 
            this.labelStockIndex.AutoSize = true;
            this.labelStockIndex.Location = new System.Drawing.Point(3, 9);
            this.labelStockIndex.Name = "labelStockIndex";
            this.labelStockIndex.Size = new System.Drawing.Size(33, 13);
            this.labelStockIndex.TabIndex = 0;
            this.labelStockIndex.Text = "Index";
            // 
            // panelPlayerInformations
            // 
            this.panelPlayerInformations.Controls.Add(this.panelPlayer3And4);
            this.panelPlayerInformations.Controls.Add(this.panelPlayer1And2);
            this.panelPlayerInformations.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPlayerInformations.Location = new System.Drawing.Point(0, 270);
            this.panelPlayerInformations.Name = "panelPlayerInformations";
            this.panelPlayerInformations.Size = new System.Drawing.Size(792, 296);
            this.panelPlayerInformations.TabIndex = 2;
            // 
            // panelPlayer3And4
            // 
            this.panelPlayer3And4.Controls.Add(this.panelPlayer4);
            this.panelPlayer3And4.Controls.Add(this.panelPlayer3);
            this.panelPlayer3And4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayer3And4.Location = new System.Drawing.Point(0, 148);
            this.panelPlayer3And4.Name = "panelPlayer3And4";
            this.panelPlayer3And4.Size = new System.Drawing.Size(792, 148);
            this.panelPlayer3And4.TabIndex = 1;
            // 
            // panelPlayer4
            // 
            this.panelPlayer4.Controls.Add(this.groupBoxPlayer4);
            this.panelPlayer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayer4.Location = new System.Drawing.Point(396, 0);
            this.panelPlayer4.Name = "panelPlayer4";
            this.panelPlayer4.Size = new System.Drawing.Size(396, 148);
            this.panelPlayer4.TabIndex = 1;
            this.panelPlayer4.Resize += new System.EventHandler(this.panelPlayer_Resize);
            // 
            // groupBoxPlayer4
            // 
            this.groupBoxPlayer4.Controls.Add(this.textBoxPlayer4Value);
            this.groupBoxPlayer4.Controls.Add(this.labelPlayer4Value);
            this.groupBoxPlayer4.Controls.Add(this.textBoxPlayer4DepositValue);
            this.groupBoxPlayer4.Controls.Add(this.labelPlayer4DepositValue);
            this.groupBoxPlayer4.Controls.Add(this.textBoxPlayer4Capital);
            this.groupBoxPlayer4.Controls.Add(this.labelPlayer4Capital);
            this.groupBoxPlayer4.Controls.Add(this.textBoxPlayer4Name);
            this.groupBoxPlayer4.Controls.Add(this.labelPlayer4Name);
            this.groupBoxPlayer4.Controls.Add(this.comboBoxPlayer4Company);
            this.groupBoxPlayer4.Controls.Add(this.labelPlayer4Company);
            this.groupBoxPlayer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPlayer4.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPlayer4.Name = "groupBoxPlayer4";
            this.groupBoxPlayer4.Size = new System.Drawing.Size(396, 148);
            this.groupBoxPlayer4.TabIndex = 0;
            this.groupBoxPlayer4.TabStop = false;
            // 
            // textBoxPlayer4Value
            // 
            this.textBoxPlayer4Value.Location = new System.Drawing.Point(240, 118);
            this.textBoxPlayer4Value.Name = "textBoxPlayer4Value";
            this.textBoxPlayer4Value.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer4Value.TabIndex = 9;
            // 
            // labelPlayer4Value
            // 
            this.labelPlayer4Value.AutoSize = true;
            this.labelPlayer4Value.Location = new System.Drawing.Point(175, 121);
            this.labelPlayer4Value.Name = "labelPlayer4Value";
            this.labelPlayer4Value.Size = new System.Drawing.Size(59, 13);
            this.labelPlayer4Value.TabIndex = 8;
            this.labelPlayer4Value.Text = "Aktiver i alt";
            // 
            // textBoxPlayer4DepositValue
            // 
            this.textBoxPlayer4DepositValue.Location = new System.Drawing.Point(240, 92);
            this.textBoxPlayer4DepositValue.Name = "textBoxPlayer4DepositValue";
            this.textBoxPlayer4DepositValue.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer4DepositValue.TabIndex = 7;
            // 
            // labelPlayer4DepositValue
            // 
            this.labelPlayer4DepositValue.AutoSize = true;
            this.labelPlayer4DepositValue.Location = new System.Drawing.Point(123, 95);
            this.labelPlayer4DepositValue.Name = "labelPlayer4DepositValue";
            this.labelPlayer4DepositValue.Size = new System.Drawing.Size(111, 13);
            this.labelPlayer4DepositValue.TabIndex = 6;
            this.labelPlayer4DepositValue.Text = "Værdi af aktier i depot";
            // 
            // textBoxPlayer4Capital
            // 
            this.textBoxPlayer4Capital.Location = new System.Drawing.Point(240, 66);
            this.textBoxPlayer4Capital.Name = "textBoxPlayer4Capital";
            this.textBoxPlayer4Capital.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer4Capital.TabIndex = 5;
            // 
            // labelPlayer4Capital
            // 
            this.labelPlayer4Capital.AutoSize = true;
            this.labelPlayer4Capital.Location = new System.Drawing.Point(195, 69);
            this.labelPlayer4Capital.Name = "labelPlayer4Capital";
            this.labelPlayer4Capital.Size = new System.Drawing.Size(39, 13);
            this.labelPlayer4Capital.TabIndex = 4;
            this.labelPlayer4Capital.Text = "Kapital";
            // 
            // textBoxPlayer4Name
            // 
            this.textBoxPlayer4Name.Location = new System.Drawing.Point(44, 40);
            this.textBoxPlayer4Name.Name = "textBoxPlayer4Name";
            this.textBoxPlayer4Name.Size = new System.Drawing.Size(346, 20);
            this.textBoxPlayer4Name.TabIndex = 3;
            // 
            // labelPlayer4Name
            // 
            this.labelPlayer4Name.AutoSize = true;
            this.labelPlayer4Name.Location = new System.Drawing.Point(6, 43);
            this.labelPlayer4Name.Name = "labelPlayer4Name";
            this.labelPlayer4Name.Size = new System.Drawing.Size(33, 13);
            this.labelPlayer4Name.TabIndex = 2;
            this.labelPlayer4Name.Text = "Navn";
            // 
            // comboBoxPlayer4Company
            // 
            this.comboBoxPlayer4Company.FormattingEnabled = true;
            this.comboBoxPlayer4Company.Location = new System.Drawing.Point(44, 13);
            this.comboBoxPlayer4Company.Name = "comboBoxPlayer4Company";
            this.comboBoxPlayer4Company.Size = new System.Drawing.Size(346, 21);
            this.comboBoxPlayer4Company.TabIndex = 1;
            this.comboBoxPlayer4Company.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayerCompany_SelectedIndexChanged);
            // 
            // labelPlayer4Company
            // 
            this.labelPlayer4Company.AutoSize = true;
            this.labelPlayer4Company.Location = new System.Drawing.Point(6, 16);
            this.labelPlayer4Company.Name = "labelPlayer4Company";
            this.labelPlayer4Company.Size = new System.Drawing.Size(32, 13);
            this.labelPlayer4Company.TabIndex = 0;
            this.labelPlayer4Company.Text = "Firma";
            // 
            // panelPlayer3
            // 
            this.panelPlayer3.Controls.Add(this.groupBoxPlayer3);
            this.panelPlayer3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPlayer3.Location = new System.Drawing.Point(0, 0);
            this.panelPlayer3.Name = "panelPlayer3";
            this.panelPlayer3.Size = new System.Drawing.Size(396, 148);
            this.panelPlayer3.TabIndex = 0;
            this.panelPlayer3.Resize += new System.EventHandler(this.panelPlayer_Resize);
            // 
            // groupBoxPlayer3
            // 
            this.groupBoxPlayer3.Controls.Add(this.textBoxPlayer3Value);
            this.groupBoxPlayer3.Controls.Add(this.labelPlayer3Value);
            this.groupBoxPlayer3.Controls.Add(this.textBoxPlayer3DepositValue);
            this.groupBoxPlayer3.Controls.Add(this.labelPlayer3DepositValue);
            this.groupBoxPlayer3.Controls.Add(this.textBoxPlayer3Capital);
            this.groupBoxPlayer3.Controls.Add(this.labelPlayer3Capital);
            this.groupBoxPlayer3.Controls.Add(this.textBoxPlayer3Name);
            this.groupBoxPlayer3.Controls.Add(this.labelPlayer3Name);
            this.groupBoxPlayer3.Controls.Add(this.comboBoxPlayer3Company);
            this.groupBoxPlayer3.Controls.Add(this.labelPlayer3Company);
            this.groupBoxPlayer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPlayer3.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPlayer3.Name = "groupBoxPlayer3";
            this.groupBoxPlayer3.Size = new System.Drawing.Size(396, 148);
            this.groupBoxPlayer3.TabIndex = 0;
            this.groupBoxPlayer3.TabStop = false;
            // 
            // textBoxPlayer3Value
            // 
            this.textBoxPlayer3Value.Location = new System.Drawing.Point(240, 118);
            this.textBoxPlayer3Value.Name = "textBoxPlayer3Value";
            this.textBoxPlayer3Value.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer3Value.TabIndex = 9;
            // 
            // labelPlayer3Value
            // 
            this.labelPlayer3Value.AutoSize = true;
            this.labelPlayer3Value.Location = new System.Drawing.Point(175, 121);
            this.labelPlayer3Value.Name = "labelPlayer3Value";
            this.labelPlayer3Value.Size = new System.Drawing.Size(59, 13);
            this.labelPlayer3Value.TabIndex = 8;
            this.labelPlayer3Value.Text = "Aktiver i alt";
            // 
            // textBoxPlayer3DepositValue
            // 
            this.textBoxPlayer3DepositValue.Location = new System.Drawing.Point(240, 92);
            this.textBoxPlayer3DepositValue.Name = "textBoxPlayer3DepositValue";
            this.textBoxPlayer3DepositValue.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer3DepositValue.TabIndex = 7;
            // 
            // labelPlayer3DepositValue
            // 
            this.labelPlayer3DepositValue.AutoSize = true;
            this.labelPlayer3DepositValue.Location = new System.Drawing.Point(123, 95);
            this.labelPlayer3DepositValue.Name = "labelPlayer3DepositValue";
            this.labelPlayer3DepositValue.Size = new System.Drawing.Size(111, 13);
            this.labelPlayer3DepositValue.TabIndex = 6;
            this.labelPlayer3DepositValue.Text = "Værdi af aktier i depot";
            // 
            // textBoxPlayer3Capital
            // 
            this.textBoxPlayer3Capital.Location = new System.Drawing.Point(240, 66);
            this.textBoxPlayer3Capital.Name = "textBoxPlayer3Capital";
            this.textBoxPlayer3Capital.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer3Capital.TabIndex = 5;
            // 
            // labelPlayer3Capital
            // 
            this.labelPlayer3Capital.AutoSize = true;
            this.labelPlayer3Capital.Location = new System.Drawing.Point(195, 69);
            this.labelPlayer3Capital.Name = "labelPlayer3Capital";
            this.labelPlayer3Capital.Size = new System.Drawing.Size(39, 13);
            this.labelPlayer3Capital.TabIndex = 4;
            this.labelPlayer3Capital.Text = "Kapital";
            // 
            // textBoxPlayer3Name
            // 
            this.textBoxPlayer3Name.Location = new System.Drawing.Point(44, 40);
            this.textBoxPlayer3Name.Name = "textBoxPlayer3Name";
            this.textBoxPlayer3Name.Size = new System.Drawing.Size(346, 20);
            this.textBoxPlayer3Name.TabIndex = 3;
            // 
            // labelPlayer3Name
            // 
            this.labelPlayer3Name.AutoSize = true;
            this.labelPlayer3Name.Location = new System.Drawing.Point(6, 43);
            this.labelPlayer3Name.Name = "labelPlayer3Name";
            this.labelPlayer3Name.Size = new System.Drawing.Size(33, 13);
            this.labelPlayer3Name.TabIndex = 2;
            this.labelPlayer3Name.Text = "Navn";
            // 
            // comboBoxPlayer3Company
            // 
            this.comboBoxPlayer3Company.FormattingEnabled = true;
            this.comboBoxPlayer3Company.Location = new System.Drawing.Point(44, 13);
            this.comboBoxPlayer3Company.Name = "comboBoxPlayer3Company";
            this.comboBoxPlayer3Company.Size = new System.Drawing.Size(346, 21);
            this.comboBoxPlayer3Company.TabIndex = 1;
            this.comboBoxPlayer3Company.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayerCompany_SelectedIndexChanged);
            // 
            // labelPlayer3Company
            // 
            this.labelPlayer3Company.AutoSize = true;
            this.labelPlayer3Company.Location = new System.Drawing.Point(6, 16);
            this.labelPlayer3Company.Name = "labelPlayer3Company";
            this.labelPlayer3Company.Size = new System.Drawing.Size(32, 13);
            this.labelPlayer3Company.TabIndex = 0;
            this.labelPlayer3Company.Text = "Firma";
            // 
            // panelPlayer1And2
            // 
            this.panelPlayer1And2.Controls.Add(this.panelPlayer2);
            this.panelPlayer1And2.Controls.Add(this.panelPlayer1);
            this.panelPlayer1And2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPlayer1And2.Location = new System.Drawing.Point(0, 0);
            this.panelPlayer1And2.Name = "panelPlayer1And2";
            this.panelPlayer1And2.Size = new System.Drawing.Size(792, 148);
            this.panelPlayer1And2.TabIndex = 0;
            // 
            // panelPlayer2
            // 
            this.panelPlayer2.Controls.Add(this.groupBoxPlayer2);
            this.panelPlayer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayer2.Location = new System.Drawing.Point(396, 0);
            this.panelPlayer2.Name = "panelPlayer2";
            this.panelPlayer2.Size = new System.Drawing.Size(396, 148);
            this.panelPlayer2.TabIndex = 1;
            this.panelPlayer2.Resize += new System.EventHandler(this.panelPlayer_Resize);
            // 
            // groupBoxPlayer2
            // 
            this.groupBoxPlayer2.Controls.Add(this.textBoxPlayer2Value);
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2Value);
            this.groupBoxPlayer2.Controls.Add(this.textBoxPlayer2DepositValue);
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2DepositValue);
            this.groupBoxPlayer2.Controls.Add(this.textBoxPlayer2Capital);
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2Capital);
            this.groupBoxPlayer2.Controls.Add(this.textBoxPlayer2Name);
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2Name);
            this.groupBoxPlayer2.Controls.Add(this.comboBoxPlayer2Company);
            this.groupBoxPlayer2.Controls.Add(this.labelPlayer2Company);
            this.groupBoxPlayer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPlayer2.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPlayer2.Name = "groupBoxPlayer2";
            this.groupBoxPlayer2.Size = new System.Drawing.Size(396, 148);
            this.groupBoxPlayer2.TabIndex = 0;
            this.groupBoxPlayer2.TabStop = false;
            // 
            // textBoxPlayer2Value
            // 
            this.textBoxPlayer2Value.Location = new System.Drawing.Point(240, 117);
            this.textBoxPlayer2Value.Name = "textBoxPlayer2Value";
            this.textBoxPlayer2Value.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer2Value.TabIndex = 9;
            // 
            // labelPlayer2Value
            // 
            this.labelPlayer2Value.AutoSize = true;
            this.labelPlayer2Value.Location = new System.Drawing.Point(175, 120);
            this.labelPlayer2Value.Name = "labelPlayer2Value";
            this.labelPlayer2Value.Size = new System.Drawing.Size(59, 13);
            this.labelPlayer2Value.TabIndex = 8;
            this.labelPlayer2Value.Text = "Aktiver i alt";
            // 
            // textBoxPlayer2DepositValue
            // 
            this.textBoxPlayer2DepositValue.Location = new System.Drawing.Point(240, 91);
            this.textBoxPlayer2DepositValue.Name = "textBoxPlayer2DepositValue";
            this.textBoxPlayer2DepositValue.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer2DepositValue.TabIndex = 7;
            // 
            // labelPlayer2DepositValue
            // 
            this.labelPlayer2DepositValue.AutoSize = true;
            this.labelPlayer2DepositValue.Location = new System.Drawing.Point(123, 94);
            this.labelPlayer2DepositValue.Name = "labelPlayer2DepositValue";
            this.labelPlayer2DepositValue.Size = new System.Drawing.Size(111, 13);
            this.labelPlayer2DepositValue.TabIndex = 6;
            this.labelPlayer2DepositValue.Text = "Værdi af aktier i depot";
            // 
            // textBoxPlayer2Capital
            // 
            this.textBoxPlayer2Capital.Location = new System.Drawing.Point(240, 65);
            this.textBoxPlayer2Capital.Name = "textBoxPlayer2Capital";
            this.textBoxPlayer2Capital.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer2Capital.TabIndex = 5;
            // 
            // labelPlayer2Capital
            // 
            this.labelPlayer2Capital.AutoSize = true;
            this.labelPlayer2Capital.Location = new System.Drawing.Point(195, 68);
            this.labelPlayer2Capital.Name = "labelPlayer2Capital";
            this.labelPlayer2Capital.Size = new System.Drawing.Size(39, 13);
            this.labelPlayer2Capital.TabIndex = 4;
            this.labelPlayer2Capital.Text = "Kapital";
            // 
            // textBoxPlayer2Name
            // 
            this.textBoxPlayer2Name.Location = new System.Drawing.Point(44, 39);
            this.textBoxPlayer2Name.Name = "textBoxPlayer2Name";
            this.textBoxPlayer2Name.Size = new System.Drawing.Size(346, 20);
            this.textBoxPlayer2Name.TabIndex = 3;
            // 
            // labelPlayer2Name
            // 
            this.labelPlayer2Name.AutoSize = true;
            this.labelPlayer2Name.Location = new System.Drawing.Point(6, 42);
            this.labelPlayer2Name.Name = "labelPlayer2Name";
            this.labelPlayer2Name.Size = new System.Drawing.Size(33, 13);
            this.labelPlayer2Name.TabIndex = 2;
            this.labelPlayer2Name.Text = "Navn";
            // 
            // comboBoxPlayer2Company
            // 
            this.comboBoxPlayer2Company.FormattingEnabled = true;
            this.comboBoxPlayer2Company.Location = new System.Drawing.Point(44, 13);
            this.comboBoxPlayer2Company.Name = "comboBoxPlayer2Company";
            this.comboBoxPlayer2Company.Size = new System.Drawing.Size(346, 21);
            this.comboBoxPlayer2Company.TabIndex = 1;
            this.comboBoxPlayer2Company.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayerCompany_SelectedIndexChanged);
            // 
            // labelPlayer2Company
            // 
            this.labelPlayer2Company.AutoSize = true;
            this.labelPlayer2Company.Location = new System.Drawing.Point(6, 16);
            this.labelPlayer2Company.Name = "labelPlayer2Company";
            this.labelPlayer2Company.Size = new System.Drawing.Size(32, 13);
            this.labelPlayer2Company.TabIndex = 0;
            this.labelPlayer2Company.Text = "Firma";
            // 
            // panelPlayer1
            // 
            this.panelPlayer1.Controls.Add(this.groupBoxPlayer1);
            this.panelPlayer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPlayer1.Location = new System.Drawing.Point(0, 0);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(396, 148);
            this.panelPlayer1.TabIndex = 0;
            this.panelPlayer1.Resize += new System.EventHandler(this.panelPlayer_Resize);
            // 
            // groupBoxPlayer1
            // 
            this.groupBoxPlayer1.Controls.Add(this.textBoxPlayer1Value);
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1Value);
            this.groupBoxPlayer1.Controls.Add(this.textBoxPlayer1DepositValue);
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1DepositValue);
            this.groupBoxPlayer1.Controls.Add(this.textBoxPlayer1Capital);
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1Capital);
            this.groupBoxPlayer1.Controls.Add(this.textBoxPlayer1Name);
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1Name);
            this.groupBoxPlayer1.Controls.Add(this.textBoxPlayer1Company);
            this.groupBoxPlayer1.Controls.Add(this.labelPlayer1Company);
            this.groupBoxPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPlayer1.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPlayer1.Name = "groupBoxPlayer1";
            this.groupBoxPlayer1.Size = new System.Drawing.Size(396, 148);
            this.groupBoxPlayer1.TabIndex = 0;
            this.groupBoxPlayer1.TabStop = false;
            // 
            // textBoxPlayer1Value
            // 
            this.textBoxPlayer1Value.Location = new System.Drawing.Point(240, 117);
            this.textBoxPlayer1Value.Name = "textBoxPlayer1Value";
            this.textBoxPlayer1Value.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer1Value.TabIndex = 9;
            // 
            // labelPlayer1Value
            // 
            this.labelPlayer1Value.AutoSize = true;
            this.labelPlayer1Value.Location = new System.Drawing.Point(175, 120);
            this.labelPlayer1Value.Name = "labelPlayer1Value";
            this.labelPlayer1Value.Size = new System.Drawing.Size(59, 13);
            this.labelPlayer1Value.TabIndex = 8;
            this.labelPlayer1Value.Text = "Aktiver i alt";
            // 
            // textBoxPlayer1DepositValue
            // 
            this.textBoxPlayer1DepositValue.Location = new System.Drawing.Point(240, 91);
            this.textBoxPlayer1DepositValue.Name = "textBoxPlayer1DepositValue";
            this.textBoxPlayer1DepositValue.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer1DepositValue.TabIndex = 7;
            // 
            // labelPlayer1DepositValue
            // 
            this.labelPlayer1DepositValue.AutoSize = true;
            this.labelPlayer1DepositValue.Location = new System.Drawing.Point(123, 94);
            this.labelPlayer1DepositValue.Name = "labelPlayer1DepositValue";
            this.labelPlayer1DepositValue.Size = new System.Drawing.Size(111, 13);
            this.labelPlayer1DepositValue.TabIndex = 6;
            this.labelPlayer1DepositValue.Text = "Værdi af aktier i depot";
            // 
            // textBoxPlayer1Capital
            // 
            this.textBoxPlayer1Capital.Location = new System.Drawing.Point(240, 65);
            this.textBoxPlayer1Capital.Name = "textBoxPlayer1Capital";
            this.textBoxPlayer1Capital.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayer1Capital.TabIndex = 5;
            // 
            // labelPlayer1Capital
            // 
            this.labelPlayer1Capital.AutoSize = true;
            this.labelPlayer1Capital.Location = new System.Drawing.Point(195, 68);
            this.labelPlayer1Capital.Name = "labelPlayer1Capital";
            this.labelPlayer1Capital.Size = new System.Drawing.Size(39, 13);
            this.labelPlayer1Capital.TabIndex = 4;
            this.labelPlayer1Capital.Text = "Kapital";
            // 
            // textBoxPlayer1Name
            // 
            this.textBoxPlayer1Name.Location = new System.Drawing.Point(44, 39);
            this.textBoxPlayer1Name.Name = "textBoxPlayer1Name";
            this.textBoxPlayer1Name.Size = new System.Drawing.Size(346, 20);
            this.textBoxPlayer1Name.TabIndex = 3;
            // 
            // labelPlayer1Name
            // 
            this.labelPlayer1Name.AutoSize = true;
            this.labelPlayer1Name.Location = new System.Drawing.Point(6, 42);
            this.labelPlayer1Name.Name = "labelPlayer1Name";
            this.labelPlayer1Name.Size = new System.Drawing.Size(33, 13);
            this.labelPlayer1Name.TabIndex = 2;
            this.labelPlayer1Name.Text = "Navn";
            // 
            // textBoxPlayer1Company
            // 
            this.textBoxPlayer1Company.Location = new System.Drawing.Point(44, 13);
            this.textBoxPlayer1Company.Name = "textBoxPlayer1Company";
            this.textBoxPlayer1Company.Size = new System.Drawing.Size(346, 20);
            this.textBoxPlayer1Company.TabIndex = 1;
            // 
            // labelPlayer1Company
            // 
            this.labelPlayer1Company.AutoSize = true;
            this.labelPlayer1Company.Location = new System.Drawing.Point(6, 16);
            this.labelPlayer1Company.Name = "labelPlayer1Company";
            this.labelPlayer1Company.Size = new System.Drawing.Size(32, 13);
            this.labelPlayer1Company.TabIndex = 0;
            this.labelPlayer1Company.Text = "Firma";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.panelStockInformations);
            this.Controls.Add(this.panelPlayerInformations);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Aktiespillet";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelStockInformations.ResumeLayout(false);
            this.groupBoxStockInformations.ResumeLayout(false);
            this.panelStocks.ResumeLayout(false);
            this.panelStockIndex.ResumeLayout(false);
            this.panelStockIndex.PerformLayout();
            this.panelPlayerInformations.ResumeLayout(false);
            this.panelPlayer3And4.ResumeLayout(false);
            this.panelPlayer4.ResumeLayout(false);
            this.groupBoxPlayer4.ResumeLayout(false);
            this.groupBoxPlayer4.PerformLayout();
            this.panelPlayer3.ResumeLayout(false);
            this.groupBoxPlayer3.ResumeLayout(false);
            this.groupBoxPlayer3.PerformLayout();
            this.panelPlayer1And2.ResumeLayout(false);
            this.panelPlayer2.ResumeLayout(false);
            this.groupBoxPlayer2.ResumeLayout(false);
            this.groupBoxPlayer2.PerformLayout();
            this.panelPlayer1.ResumeLayout(false);
            this.groupBoxPlayer1.ResumeLayout(false);
            this.groupBoxPlayer1.PerformLayout();
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
        private System.Windows.Forms.Panel panelPlayer1And2;
        private System.Windows.Forms.Panel panelPlayer3And4;
        private System.Windows.Forms.Panel panelPlayer1;
        private System.Windows.Forms.Panel panelPlayer2;
        private System.Windows.Forms.Panel panelPlayer4;
        private System.Windows.Forms.Panel panelPlayer3;
        private System.Windows.Forms.GroupBox groupBoxPlayer1;
        private System.Windows.Forms.GroupBox groupBoxPlayer2;
        private System.Windows.Forms.GroupBox groupBoxPlayer3;
        private System.Windows.Forms.GroupBox groupBoxPlayer4;
        private System.Windows.Forms.TextBox textBoxPlayer1Company;
        private System.Windows.Forms.Label labelPlayer1Company;
        private System.Windows.Forms.TextBox textBoxPlayer1Name;
        private System.Windows.Forms.Label labelPlayer1Name;
        private System.Windows.Forms.Label labelPlayer2Company;
        private System.Windows.Forms.Label labelPlayer4Company;
        private System.Windows.Forms.Label labelPlayer3Company;
        private System.Windows.Forms.ComboBox comboBoxPlayer4Company;
        private System.Windows.Forms.ComboBox comboBoxPlayer3Company;
        private System.Windows.Forms.ComboBox comboBoxPlayer2Company;
        private System.Windows.Forms.Label labelPlayer2Name;
        private System.Windows.Forms.TextBox textBoxPlayer2Name;
        private System.Windows.Forms.TextBox textBoxPlayer3Name;
        private System.Windows.Forms.Label labelPlayer3Name;
        private System.Windows.Forms.TextBox textBoxPlayer4Name;
        private System.Windows.Forms.Label labelPlayer4Name;
        private System.Windows.Forms.Label labelPlayer1Capital;
        private System.Windows.Forms.TextBox textBoxPlayer1Capital;
        private System.Windows.Forms.TextBox textBoxPlayer1DepositValue;
        private System.Windows.Forms.Label labelPlayer1DepositValue;
        private System.Windows.Forms.TextBox textBoxPlayer1Value;
        private System.Windows.Forms.Label labelPlayer1Value;
        private System.Windows.Forms.TextBox textBoxPlayer2Value;
        private System.Windows.Forms.Label labelPlayer2Value;
        private System.Windows.Forms.TextBox textBoxPlayer2DepositValue;
        private System.Windows.Forms.Label labelPlayer2DepositValue;
        private System.Windows.Forms.TextBox textBoxPlayer2Capital;
        private System.Windows.Forms.Label labelPlayer2Capital;
        private System.Windows.Forms.TextBox textBoxPlayer3DepositValue;
        private System.Windows.Forms.Label labelPlayer3DepositValue;
        private System.Windows.Forms.TextBox textBoxPlayer3Capital;
        private System.Windows.Forms.Label labelPlayer3Capital;
        private System.Windows.Forms.TextBox textBoxPlayer3Value;
        private System.Windows.Forms.Label labelPlayer3Value;
        private System.Windows.Forms.TextBox textBoxPlayer4DepositValue;
        private System.Windows.Forms.Label labelPlayer4DepositValue;
        private System.Windows.Forms.TextBox textBoxPlayer4Capital;
        private System.Windows.Forms.Label labelPlayer4Capital;
        private System.Windows.Forms.TextBox textBoxPlayer4Value;
        private System.Windows.Forms.Label labelPlayer4Value;
        private System.Windows.Forms.Label labelMarketStateText;
        private System.Windows.Forms.Label labelMarketState;
        private System.Windows.Forms.Label labelBrokerageText;
        private System.Windows.Forms.Label labelBrokerage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFunctions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTrade;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeposit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStatistics;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemValueLineGraph;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemValueBarGraph;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorPause;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPause;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemContinue;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNetwork;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemServer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClient;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
    }
}

