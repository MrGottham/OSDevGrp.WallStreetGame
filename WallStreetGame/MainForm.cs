﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OSDevGrp.WallStreetGame
{
    public partial class MainForm : Form, System.ComponentModel.ISynchronizeInvoke
    {
        private const string PRODUCT_NAME = "Aktiespillet";
        private const string WSG_FILE_INFORMATION = "Aktiespillet, gemt spil";

        private enum ListViewItemComparerMethod
        {
            String = 1,
            Integer = 2,
            Double = 3,
            Unknown = 4
        }

        private class ListViewItemComparer : System.Object, System.Collections.IComparer
        {
            private int _ColumnToSort = 0;
            private ListViewItemComparerMethod _Method = ListViewItemComparerMethod.Unknown;
            private System.Windows.Forms.SortOrder _SortOrder = System.Windows.Forms.SortOrder.None;

            public ListViewItemComparer() : this(0)
            {
            }

            public ListViewItemComparer(int column) : this(column, ListViewItemComparerMethod.Unknown)
            {
            }

            public ListViewItemComparer(int column, ListViewItemComparerMethod method) : this(column, method, System.Windows.Forms.SortOrder.None)
            {
            }

            public ListViewItemComparer(int column, ListViewItemComparerMethod method, System.Windows.Forms.SortOrder sortorder) : base()
            {
                try
                {
                    ColumnToSort = column;
                    Method = method;
                    SortOrder = sortorder;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

            }

            public int ColumnToSort
            {
                get
                {
                    return _ColumnToSort; 
                }
                set
                {
                    _ColumnToSort = value;
                }
            }

            public ListViewItemComparerMethod Method
            {
                get
                {
                    return _Method;
                }
                set
                {
                    _Method = value;
                }
            }

            public System.Windows.Forms.SortOrder SortOrder
            {
                get
                {
                    return _SortOrder;
                }
                set
                {
                    _SortOrder = value;
                }
            }

            public int Compare(object x, object y)
            {
                try
                {
                    System.Windows.Forms.ListViewItem x_lvi = (System.Windows.Forms.ListViewItem) x;
                    System.Windows.Forms.ListViewItem y_lvi = (System.Windows.Forms.ListViewItem) y;
                    switch (Method)
                    {
                        case ListViewItemComparerMethod.String:
                            switch (SortOrder)
                            {
                                case System.Windows.Forms.SortOrder.Ascending:
                                case System.Windows.Forms.SortOrder.None:
                                    return String.Compare(x_lvi.SubItems[ColumnToSort].Text.ToUpper(), y_lvi.SubItems[ColumnToSort].Text.ToUpper());
                                case System.Windows.Forms.SortOrder.Descending:
                                    return String.Compare(y_lvi.SubItems[ColumnToSort].Text.ToUpper(), x_lvi.SubItems[ColumnToSort].Text.ToUpper());
                                default:
                                    return 0;
                            }
                        case ListViewItemComparerMethod.Integer:
                            {
                                System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                                string x_s = x_lvi.SubItems[ColumnToSort].Text;
                                int x_p = x_s.IndexOf(' ');
                                if (x_p >= 0)
                                {
                                    x_s = x_s.Substring(0, x_p);
                                }
                                int x_i = 0;
                                if (x_s.Length > 0)
                                    x_i = int.Parse(x_s, System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowThousands, nfi);
                                string y_s = y_lvi.SubItems[ColumnToSort].Text;
                                int y_p = y_s.IndexOf(' ');
                                if (y_p >= 0)
                                {
                                    y_s = y_s.Substring(0, y_p);
                                }
                                int y_i = 0;
                                if (y_s.Length > 0)
                                    y_i = int.Parse(y_s, System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowThousands, nfi);
                                switch (SortOrder)
                                {
                                    case System.Windows.Forms.SortOrder.Ascending:
                                    case System.Windows.Forms.SortOrder.None:
                                        return x_i > y_i ? 1 : (x_i < y_i ? -1 : 0);
                                    case System.Windows.Forms.SortOrder.Descending:
                                        return x_i > y_i ? -1 : (x_i < y_i ? 1 : 0);
                                    default:
                                        return 0;
                                }
                            }
                        case ListViewItemComparerMethod.Double:
                            {
                                System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                                string x_s = x_lvi.SubItems[ColumnToSort].Text;
                                int x_p = x_s.IndexOf(' ');
                                if (x_p >= 0)
                                {
                                    x_s = x_s.Substring(0, x_p);
                                }
                                double x_d = 0D;
                                if (x_s.Length > 0)
                                    x_d = double.Parse(x_s, System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint, nfi);
                                string y_s = y_lvi.SubItems[ColumnToSort].Text;
                                int y_p = y_s.IndexOf(' ');
                                if (y_p >= 0)
                                {
                                    y_s = y_s.Substring(0, y_p);
                                }
                                double y_d = 0D;
                                if (y_s.Length > 0)
                                    y_d = double.Parse(y_s, System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint, nfi);
                                switch (SortOrder)
                                {
                                    case System.Windows.Forms.SortOrder.Ascending:
                                    case System.Windows.Forms.SortOrder.None:
                                        return x_d > y_d ? 1 : (x_d < y_d ? -1 : 0);
                                    case System.Windows.Forms.SortOrder.Descending:
                                        return x_d > y_d ? -1 : (x_d < y_d ? 1 : 0);
                                    default:
                                        return 0;
                                }
                            }
                        default:
                            switch (SortOrder)
                            {
                                case System.Windows.Forms.SortOrder.Ascending:
                                case System.Windows.Forms.SortOrder.None:
                                    return String.Compare(x_lvi.SubItems[ColumnToSort].Text.ToUpper(), y_lvi.SubItems[ColumnToSort].Text.ToUpper());
                                case System.Windows.Forms.SortOrder.Descending:
                                    return string.Compare(y_lvi.SubItems[ColumnToSort].Text.ToUpper(), x_lvi.SubItems[ColumnToSort].Text.ToUpper());
                                default:
                                    return 0;
                            }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }

        private Game _Game = null;
        private Server _Server = null;
        private Client _Client = null;
        private StockForms _StockForms = null;
        private StatisticsForms _StatisticsForms = null;
        private bool _AskToSaveOnClose = true;
        private string _OldFileName = null;

        public MainForm() : this(null)
        {
        }

        public MainForm(string[] args) : base()
        {
            InitializeComponent();
            try
            {
                Game = new Game(this);
                Game.BeforeResetEvent = this.BeforeReset;
                Game.AfterResetEvent = this.AfterReset;
                Game.BeforeLoadEvent = this.BeforeLoad;
                Game.AfterLoadEvent = this.AfterLoad;
                Game.BeforeSaveEvent = this.BeforeSave;
                Game.AfterSaveEvent = this.AfterSave;
                Game.OnPauseEvent = this.OnPause;
                Game.OnContinueEvent = this.OnContinue;
                Game.UpdateStockInformationsEvent = this.UpdateStockInformations;
                Game.UpdatePlayerInformationsEvent = this.UpdatePlayerInformations;
                StockForms = new StockForms();
                StatisticsForms = new StatisticsForms();
                if (args != null)
                {
                    if (args.Length > 0)
                    {
                        foreach (string s in args)
                        {
                            if (s.ToLower().IndexOf("/open=") == 0)
                            {
                                Game.Load(s.Substring(6));
                            }
                        }
                    }
                }
                AskToSaveOnClose = true;
                System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                this.Text = ProductName;
                this.toolStripMenuItemAbout.Text = this.toolStripMenuItemAbout.Text + " " + ProductName;
                this.comboBoxStockIndex.Items.Clear();
                this.comboBoxStockIndex.DisplayMember = "Name";
                if (Game.StockIndexes.Count > 0)
                {
                    foreach (StockIndex si in Game.StockIndexes.Values)
                        this.comboBoxStockIndex.Items.Add(si);
                }
                this.listViewStocks.FullRowSelect = true;
                this.listViewStocks.GridLines = true;
                this.listViewStocks.LabelEdit = false;
                this.listViewStocks.LabelWrap = false;
                this.listViewStocks.MultiSelect = false;
                this.listViewStocks.View = System.Windows.Forms.View.Details;
                System.Windows.Forms.ColumnHeader ch = new System.Windows.Forms.ColumnHeader();
                ch.Name = "Name";
                ch.Text = "Aktie";
                ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                ch.Tag = ListViewItemComparerMethod.String;
                this.listViewStocks.Columns.Add(ch);
                ch = new System.Windows.Forms.ColumnHeader();
                ch.Name = "Price";
                ch.Text = "Kurs";
                ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                ch.Tag = ListViewItemComparerMethod.Double;
                this.listViewStocks.Columns.Add(ch);
                ch = new System.Windows.Forms.ColumnHeader();
                ch.Name = "PriceDifference";
                ch.Text = nfi.PositiveSign + "/" + nfi.NegativeSign;
                ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                ch.Tag = ListViewItemComparerMethod.Double;
                this.listViewStocks.Columns.Add(ch);
                ch = new System.Windows.Forms.ColumnHeader();
                ch.Name = "PriceDifferenceProcent";
                ch.Text = nfi.PercentSymbol;
                ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                ch.Tag = ListViewItemComparerMethod.Double;
                this.listViewStocks.Columns.Add(ch);
                ch = new System.Windows.Forms.ColumnHeader();
                ch.Name = "Available";
                ch.Text = "Frie aktier";
                ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                ch.Tag = ListViewItemComparerMethod.Integer;
                this.listViewStocks.Columns.Add(ch);
                ch = new System.Windows.Forms.ColumnHeader();
                ch.Name = "Deposit";
                ch.Text = "Aktier i depot";
                ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                ch.Tag = ListViewItemComparerMethod.Integer;
                this.listViewStocks.Columns.Add(ch);
                ch = new System.Windows.Forms.ColumnHeader();
                ch.Name = "Empty";
                ch.Text = String.Empty;
                ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                ch.Tag = ListViewItemComparerMethod.Unknown;
                this.listViewStocks.Columns.Add(ch);
                if (this.comboBoxStockIndex.Items.Count > 0)
                    this.comboBoxStockIndex.SelectedItem = this.comboBoxStockIndex.Items[0];
                this.panelPlayer1.Tag = this.panelPlayer1.Width;
                this.panelPlayer2.Tag = this.panelPlayer2.Width;
                this.panelPlayer3.Tag = this.panelPlayer3.Width;
                this.panelPlayer4.Tag = this.panelPlayer4.Width;
                this.panelPlayer1.Width = (this.panelPlayer1And2.Width / 2);
                this.panelPlayer3.Width = (this.panelPlayer3And4.Width / 2);
                int m = this.labelPlayer1Company.Location.X;
                this.panelPlayer1.MinimumSize = new System.Drawing.Size(m + this.labelPlayer1DepositValue.Width + m + this.textBoxPlayer1DepositValue.Width + m, this.panelPlayer1.Height);
                while (this.textBoxPlayer1Company.DataBindings.Count > 0)
                    this.textBoxPlayer1Company.DataBindings.Clear();
                this.textBoxPlayer1Company.DataBindings.Add(new System.Windows.Forms.Binding("Text", Game.CurrentPlayer, "Company", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                while (this.textBoxPlayer1Name.DataBindings.Count > 0)
                    this.textBoxPlayer1Name.DataBindings.Clear();
                this.textBoxPlayer1Name.DataBindings.Add(new System.Windows.Forms.Binding("Text", Game.CurrentPlayer, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.textBoxPlayer1Capital.MinimumSize = new System.Drawing.Size(this.textBoxPlayer1Capital.Width, this.textBoxPlayer1Capital.Height);
                this.textBoxPlayer1Capital.ReadOnly = true;
                this.textBoxPlayer1Capital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayer1Capital.TabStop = false;
                this.textBoxPlayer1DepositValue.MinimumSize = new System.Drawing.Size(this.textBoxPlayer1DepositValue.Width, this.textBoxPlayer1DepositValue.Height);
                this.textBoxPlayer1DepositValue.ReadOnly = true;
                this.textBoxPlayer1DepositValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayer1DepositValue.TabStop = false;
                this.textBoxPlayer1Value.MinimumSize = new System.Drawing.Size(this.textBoxPlayer1Value.Width, this.textBoxPlayer1Value.Height);
                this.textBoxPlayer1Value.ReadOnly = true;
                this.textBoxPlayer1Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayer1Value.TabStop = false;
                m = this.labelPlayer2Company.Location.X;
                this.panelPlayer2.MinimumSize = new System.Drawing.Size(m + this.labelPlayer2DepositValue.Width + m + this.textBoxPlayer2DepositValue.Width + m, this.panelPlayer2.Height);
                this.textBoxPlayer2Name.ReadOnly = true;
                this.textBoxPlayer2Name.TabStop = false;
                this.textBoxPlayer2Capital.MinimumSize = new System.Drawing.Size(this.textBoxPlayer2Capital.Width, this.textBoxPlayer2Capital.Height);
                this.textBoxPlayer2Capital.ReadOnly = true;
                this.textBoxPlayer2Capital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayer2Capital.TabStop = false;
                this.textBoxPlayer2DepositValue.MinimumSize = new System.Drawing.Size(this.textBoxPlayer2DepositValue.Width, this.textBoxPlayer2DepositValue.Height);
                this.textBoxPlayer2DepositValue.ReadOnly = true;
                this.textBoxPlayer2DepositValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayer2DepositValue.TabStop = false;
                this.textBoxPlayer2Value.MinimumSize = new System.Drawing.Size(this.textBoxPlayer2Value.Width, this.textBoxPlayer2Value.Height);
                this.textBoxPlayer2Value.ReadOnly = true;
                this.textBoxPlayer2Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayer2Value.TabStop = false;
                m = this.labelPlayer3Company.Location.X;
                this.panelPlayer3.MinimumSize = new System.Drawing.Size(m + this.labelPlayer3DepositValue.Width + m + this.textBoxPlayer3DepositValue.Width + m, this.panelPlayer3.Height);
                this.textBoxPlayer3Name.ReadOnly = true;
                this.textBoxPlayer3Name.TabStop = false;
                this.textBoxPlayer3Capital.MinimumSize = new System.Drawing.Size(this.textBoxPlayer3Capital.Width, this.textBoxPlayer3Capital.Height);
                this.textBoxPlayer3Capital.ReadOnly = true;
                this.textBoxPlayer3Capital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayer3Capital.TabStop = false;
                this.textBoxPlayer3DepositValue.MinimumSize = new System.Drawing.Size(this.textBoxPlayer3DepositValue.Width, this.textBoxPlayer3DepositValue.Height);
                this.textBoxPlayer3DepositValue.ReadOnly = true;
                this.textBoxPlayer3DepositValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayer3DepositValue.TabStop = false;
                this.textBoxPlayer3Value.MinimumSize = new System.Drawing.Size(this.textBoxPlayer3Value.Width, this.textBoxPlayer3Value.Height);
                this.textBoxPlayer3Value.ReadOnly = true;
                this.textBoxPlayer3Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayer3Value.TabStop = false;
                m = this.labelPlayer4Company.Location.X;
                this.panelPlayer4.MinimumSize = new System.Drawing.Size(m + this.labelPlayer4DepositValue.Width + m + this.textBoxPlayer4DepositValue.Width + m, this.panelPlayer4.Height);
                this.textBoxPlayer4Name.ReadOnly = true;
                this.textBoxPlayer4Name.TabStop = false;
                this.textBoxPlayer4Capital.MinimumSize = new System.Drawing.Size(this.textBoxPlayer4Capital.Width, this.textBoxPlayer4Capital.Height);
                this.textBoxPlayer4Capital.ReadOnly = true;
                this.textBoxPlayer4Capital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayer4Capital.TabStop = false;
                this.textBoxPlayer4DepositValue.MinimumSize = new System.Drawing.Size(this.textBoxPlayer4DepositValue.Width, this.textBoxPlayer4DepositValue.Height);
                this.textBoxPlayer4DepositValue.ReadOnly = true;
                this.textBoxPlayer4DepositValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayer4DepositValue.TabStop = false;
                this.textBoxPlayer4Value.MinimumSize = new System.Drawing.Size(this.textBoxPlayer4Value.Width, this.textBoxPlayer4Value.Height);
                this.textBoxPlayer4Value.ReadOnly = true;
                this.textBoxPlayer4Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayer4Value.TabStop = false;
                this.panelPlayer1And2.MinimumSize = new System.Drawing.Size(this.panelPlayer1.MinimumSize.Width + this.panelPlayer2.MinimumSize.Width, this.panelPlayer1.MinimumSize.Height);
                this.panelPlayer3And4.MinimumSize = new System.Drawing.Size(this.panelPlayer3.MinimumSize.Width + this.panelPlayer4.MinimumSize.Width, this.panelPlayer3.MinimumSize.Height);
                this.panelPlayerInformations.MinimumSize = new System.Drawing.Size(this.panelPlayer1And2.MinimumSize.Width, this.panelPlayer1And2.MinimumSize.Height + this.panelPlayer3And4.MinimumSize.Height);
                m = this.panelPlayerInformations.Location.X;
                this.MinimumSize = new System.Drawing.Size(m + this.panelPlayerInformations.MinimumSize.Width + m + this.Width - this.panelPlayerInformations.Width, this.panelPlayerInformations.MinimumSize.Height * 2);
                UpdatePlayerInformations();
                this.textBoxPlayer1Company.Select();
                GrayItems();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        static public new string ProductName
        {
            get
            {
                return PRODUCT_NAME;
            }
        }

        static public string WsgFileInformation
        {
            get
            {
                return WSG_FILE_INFORMATION;
            }
        }

        public Game Game
        {
            get
            {
                return _Game;
            }
            private set
            {
                _Game = value;
            }
        }

        public Server Server
        {
            get
            {
                return _Server;
            }
            private set
            {
                _Server = value;
            }
        }

        public Client Client
        {
            get
            {
                return _Client;
            }
            private set
            {
                _Client = value;
            }
        }

        private bool ServerRunning
        {
            get
            {
                if (Server != null)
                    return Server.Running;
                return false;
            }
        }

        private bool ClientConnected
        {
            get
            {
                if (Client != null)
                    return Client.Connected;
                return false;
            }
        }

        public StockForms StockForms
        {
            get
            {
                return _StockForms;
            }
            private set
            {
                _StockForms = value;
            }
        }

        public StatisticsForms StatisticsForms
        {
            get
            {
                return _StatisticsForms;
            }
            private set
            {
                _StatisticsForms = value;
            }

        }

        private bool AskToSaveOnClose
        {
            get
            {
                return _AskToSaveOnClose;
            }
            set
            {
                _AskToSaveOnClose = value;
            }
        }

        private string OldFileName
        {
            get
            {
                if (_OldFileName != null)
                    return _OldFileName;
                return String.Empty;
            }
            set
            {
                _OldFileName = value;
            }
        }

        private bool BeforeReset()
        {
            try
            {
                if (System.Windows.Forms.MessageBox.Show(this, "Nyt spil?", ProductName, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    OldFileName = Game.FileName;
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                throw ex;
            }
            return false;
        }

        private void AfterReset()
        {
            try
            {
                if (OldFileName.Length > 0)
                {
                    string s = this.toolStripMenuItemSave.Text;
                    if (s.IndexOf(" (" + System.IO.Path.GetFileName(OldFileName) + ')') >= 0)
                        s = s.Substring(0, s.IndexOf(" (" + System.IO.Path.GetFileName(OldFileName) + ')'));
                    this.toolStripMenuItemSave.Text = s;
                    OldFileName = null;
                }
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void BeforeSave()
        {
            try
            {
                OldFileName = Game.FileName;
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void AfterSave()
        {
            try
            {
                string s = null;
                if (OldFileName.Length > 0)
                {
                    s = this.toolStripMenuItemSave.Text;
                    if (s.IndexOf(" (" + System.IO.Path.GetFileName(OldFileName) + ')') >= 0)
                        s = s.Substring(0, s.IndexOf(" (" + System.IO.Path.GetFileName(OldFileName) + ')'));
                    this.toolStripMenuItemSave.Text = s;
                    OldFileName = null;
                }
                s = this.toolStripMenuItemSave.Text;
                if (s.IndexOf(" (" + System.IO.Path.GetFileName(Game.FileName) + ')') >= 0)
                    s = s.Substring(0, s.IndexOf(" (" + System.IO.Path.GetFileName(Game.FileName) + ')'));
                s = s + " (" + System.IO.Path.GetFileName(Game.FileName) + ')';
                this.toolStripMenuItemSave.Text = s;
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void BeforeLoad()
        {
            try
            {
                while (StockForms.Count > 0)
                {
                    StockForm stockform = StockForms[0];
                    StockForms.Remove(stockform);
                    if (stockform.Visible)
                        stockform.Close();
                    stockform.Dispose();
                }
                while (StatisticsForms.Count > 0)
                {
                    StatisticsForm statisticsform = StatisticsForms[0];
                    StatisticsForms.Remove(statisticsform);
                    if (statisticsform.Visible)
                        statisticsform.Close();
                    statisticsform.Dispose();
                }
                OldFileName = Game.FileName;
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void AfterLoad()
        {
            try
            {
                string s = null;
                if (OldFileName.Length > 0)
                {
                    s = this.toolStripMenuItemSave.Text;
                    if (s.IndexOf(" (" + System.IO.Path.GetFileName(OldFileName) + ')') >= 0)
                        s = s.Substring(0, s.IndexOf(" (" + System.IO.Path.GetFileName(OldFileName) + ')'));
                    this.toolStripMenuItemSave.Text = s;
                    OldFileName = null;
                }
                s = this.toolStripMenuItemSave.Text;
                if (s.IndexOf(" (" + System.IO.Path.GetFileName(Game.FileName) + ')') >= 0)
                    s = s.Substring(0, s.IndexOf(" (" + System.IO.Path.GetFileName(Game.FileName) + ')'));
                s = s + " (" + System.IO.Path.GetFileName(Game.FileName) + ')';
                this.toolStripMenuItemSave.Text = s;
                while (this.toolStripMenuItemDeposit.DropDownItems.Count > 0)
                    this.toolStripMenuItemDeposit.DropDownItems.Clear();
                while (this.comboBoxStockIndex.Items.Count > 0)
                    this.comboBoxStockIndex.Items.Clear();
                if (this.listViewStocks.Columns.Count > 0)
                {
                    int i = 0;
                    while (i < this.listViewStocks.Columns.Count)
                    {
                        if (this.listViewStocks.Columns[i].Tag is Player)
                            this.listViewStocks.Columns.RemoveAt(i);
                        else
                            i++;
                    }
                }
                while (this.listViewStocks.Items.Count > 0)
                    this.listViewStocks.Items.Clear();
                while (this.textBoxPlayer1Company.DataBindings.Count > 0)
                    this.textBoxPlayer1Company.DataBindings.Clear();
                this.textBoxPlayer1Company.DataBindings.Add(new System.Windows.Forms.Binding("Text", Game.CurrentPlayer, "Company"));
                while (this.textBoxPlayer1Name.DataBindings.Count > 0)
                    this.textBoxPlayer1Name.DataBindings.Clear();
                this.textBoxPlayer1Name.DataBindings.Add(new System.Windows.Forms.Binding("Text", Game.CurrentPlayer, "Name"));
                while (this.comboBoxPlayer2Company.Items.Count > 0)
                    this.comboBoxPlayer2Company.Items.Clear();
                while (this.comboBoxPlayer3Company.Items.Count > 0)
                    this.comboBoxPlayer3Company.Items.Clear();
                while (this.comboBoxPlayer4Company.Items.Count > 0)
                    this.comboBoxPlayer4Company.Items.Clear();
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void OnPause()
        {
            try
            {
                GrayItems();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void OnContinue()
        {
            try
            {
                GrayItems();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateStockInformations()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                System.Globalization.RegionInfo ri = System.Globalization.RegionInfo.CurrentRegion;
                if (this.comboBoxStockIndex.Items.Count == 0)
                {
                    if (Game.StockIndexes.Count > 0)
                    {
                        foreach (StockIndex si in Game.StockIndexes.Values)
                            this.comboBoxStockIndex.Items.Add(si);
                    }
                    if (this.comboBoxStockIndex.Items.Count > 0)
                        this.comboBoxStockIndex.SelectedItem = this.comboBoxStockIndex.Items[0];
                }
                StockIndex stockindex = (StockIndex) this.comboBoxStockIndex.SelectedItem;
                if (stockindex != null)
                {
                    this.labelAverage.Text = stockindex.PriceAverage.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                    if (this.listViewStocks.Items.Count > 0)
                    {
                        this.listViewStocks.BeginUpdate();
                        foreach (System.Windows.Forms.ListViewItem lvi in this.listViewStocks.Items)
                        {
                            Stock stock = (Stock) lvi.Tag;
                            DepositContent depositcontent = null;
                            Player player = null;
                            switch (lvi.Name)
                            {
                                case "Price":
                                    lvi.Text = stock.Price.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                                    break;
                                case "PriceDifference":
                                    lvi.Text = stock.PriceDifference.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                                    break;
                                case "PriceDifferenceProcent":
                                    lvi.Text = stock.PriceDifferenceProcent.ToString("n", nfi) + " " + nfi.PercentSymbol;
                                    break;
                                case "Available":
                                    lvi.Text = stock.Available.ToString("#,##0", nfi);
                                    break;
                                case "Deposit":
                                    if (Game.CurrentPlayer.Deposit.TryGetValue(stock.Id, out depositcontent))
                                        lvi.Text = depositcontent.Count.ToString("#,##0", nfi);
                                    else
                                        lvi.Text = String.Empty;
                                    break;
                                case "OtherDeposit":
                                    player = (Player) lvi.Tag;
                                    if (player.Deposit.TryGetValue(stock.Id, out depositcontent))
                                        lvi.Text = depositcontent.Count.ToString("#,##0", nfi);
                                    else
                                        lvi.Text = String.Empty;
                                    break;
                            }
                            if (lvi.SubItems.Count > 0)
                            {
                                foreach (System.Windows.Forms.ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                                {
                                    switch (lvsi.Name)
                                    {
                                        case "Price":
                                            lvsi.Text = stock.Price.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                                            break;
                                        case "PriceDifference":
                                            lvsi.Text = stock.PriceDifference.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                                            break;
                                        case "PriceDifferenceProcent":
                                            lvsi.Text = stock.PriceDifferenceProcent.ToString("n", nfi) + " " + nfi.PercentSymbol;
                                            break;
                                        case "Available":
                                            lvsi.Text = stock.Available.ToString("#,##0", nfi);
                                            break;
                                        case "Deposit":
                                            if (Game.CurrentPlayer.Deposit.TryGetValue(stock.Id, out depositcontent))
                                                lvsi.Text = depositcontent.Count.ToString("#,##0", nfi);
                                            else
                                                lvsi.Text = String.Empty;
                                            break;
                                        case "OtherDeposit":
                                            player = (Player) lvsi.Tag;
                                            if (player.Deposit.TryGetValue(stock.Id, out depositcontent))
                                                lvsi.Text = depositcontent.Count.ToString("#,##0", nfi);
                                            else
                                                lvsi.Text = String.Empty;
                                            break;
                                    }
                                }
                            }
                        }
                        this.listViewStocks.AutoResizeColumns(System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize);
                        this.listViewStocks.EndUpdate();
                    }
                    else if (stockindex.Stocks.Count > 0 && this.listViewStocks.Columns.Count > 0)
                    {
                        this.listViewStocks.BeginUpdate();
                        foreach (Stock stock in stockindex.Stocks.Values)
                        {
                            System.Windows.Forms.ListViewItem lvi = null;
                            DepositContent depositcontent = null;
                            Player player = null;
                            foreach (System.Windows.Forms.ColumnHeader ch in this.listViewStocks.Columns)
                            {
                                if (lvi == null)
                                {
                                    switch (ch.Name)
                                    {
                                        case "Name":
                                            lvi = new System.Windows.Forms.ListViewItem(stock.Name, 0);
                                            lvi.Name = ch.Name;
                                            break;
                                        case "Price":
                                            lvi = new System.Windows.Forms.ListViewItem(stock.Price.ToString("n", nfi) + " " + ri.ISOCurrencySymbol, 0);
                                            lvi.Name = ch.Name;
                                            break;
                                        case "PriceDifference":
                                            lvi = new System.Windows.Forms.ListViewItem(stock.PriceDifference.ToString("n", nfi) + " " + ri.ISOCurrencySymbol, 0);
                                            lvi.Name = ch.Name;
                                            break;
                                        case "PriceDifferenceProcent":
                                            lvi = new System.Windows.Forms.ListViewItem(stock.PriceDifferenceProcent.ToString("n", nfi) + " " + nfi.PercentSymbol, 0);
                                            lvi.Name = ch.Name;
                                            break;
                                        case "Available":
                                            lvi = new System.Windows.Forms.ListViewItem(stock.Available.ToString("#,##0", nfi), 0);
                                            lvi.Name = ch.Name;
                                            break;
                                        case "Deposit":
                                            if (Game.CurrentPlayer.Deposit.TryGetValue(stock.Id, out depositcontent))
                                                lvi.Text = depositcontent.Count.ToString("#,##0", nfi);
                                            else
                                                lvi.Text = String.Empty;
                                            lvi.Name = ch.Name;
                                            break;
                                        case "OtherDeposit":
                                            player = (Player) ch.Tag;
                                            if (player.Deposit.TryGetValue(stock.Id, out depositcontent))
                                                lvi.Text = depositcontent.Count.ToString("#,##0", nfi);
                                            else
                                                lvi.Text = string.Empty;
                                            lvi.Name = ch.Name;
                                            lvi.Tag = ch.Tag;
                                            break;
                                    }
                                }
                                else
                                {
                                    System.Windows.Forms.ListViewItem.ListViewSubItem lvsi = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                                    switch (ch.Name)
                                    {
                                        case "Name":
                                            lvsi.Text = stock.Name;
                                            lvsi.Name = ch.Name;
                                            break;
                                        case "Price":
                                            lvsi.Text = stock.Price.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                                            lvsi.Name = ch.Name;
                                            break;
                                        case "PriceDifference":
                                            lvsi.Text = stock.PriceDifference.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                                            lvsi.Name = ch.Name;
                                            break;
                                        case "PriceDifferenceProcent":
                                            lvsi.Text = stock.PriceDifferenceProcent.ToString("n", nfi) + " " + nfi.PercentSymbol;
                                            lvsi.Name = ch.Name;
                                            break;
                                        case "Available":
                                            lvsi.Text = stock.Available.ToString("#,##0", nfi);
                                            lvsi.Name = ch.Name;
                                            break;
                                        case "Deposit":
                                            if (Game.CurrentPlayer.Deposit.TryGetValue(stock.Id, out depositcontent))
                                                lvsi.Text = depositcontent.Count.ToString("#,##0", nfi);
                                            else
                                                lvsi.Text = String.Empty;
                                            lvsi.Name = ch.Name;
                                            break;
                                        case "OtherDeposit":
                                            player = (Player) ch.Tag;
                                            if (player.Deposit.TryGetValue(stock.Id, out depositcontent))
                                                lvsi.Text = depositcontent.Count.ToString("#,##0", nfi);
                                            else
                                                lvsi.Text = string.Empty;
                                            lvsi.Name = ch.Name;
                                            lvsi.Tag = ch.Tag;
                                            break;
                                    }
                                    if (lvsi != null)
                                        lvi.SubItems.Add(lvsi);
                                }
                            }
                            if (lvi != null)
                            {
                                lvi.Tag = stock;
                                this.listViewStocks.Items.Add(lvi);
                            }
                        }
                        this.listViewStocks.AutoResizeColumns(System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize);
                        if (this.listViewStocks.Columns.Count > 0)
                        {
                            if (this.listViewStocks.ListViewItemSorter != null)
                            {
                                ListViewItemComparer lvic = (ListViewItemComparer) this.listViewStocks.ListViewItemSorter;
                                lvic.ColumnToSort = 0;
                                lvic.Method = (ListViewItemComparerMethod) this.listViewStocks.Columns[0].Tag;
                                lvic.SortOrder = System.Windows.Forms.SortOrder.Ascending;
                                this.listViewStocks.Sort();
                            }
                            else
                                this.listViewStocks.ListViewItemSorter = new ListViewItemComparer(0, (ListViewItemComparerMethod) this.listViewStocks.Columns[0].Tag, System.Windows.Forms.SortOrder.Ascending);
                        }
                        this.listViewStocks.EndUpdate();
                    }
                }
                switch (Game.MarketState.State)
                {
                    case MarketStateType.Normal:
                        this.labelMarketState.Text = "Normal";
                        break;
                    case MarketStateType.Depression:
                        this.labelMarketState.Text = "Lav";
                        break;
                    case MarketStateType.Boom:
                        this.labelMarketState.Text = "Høj";
                        break;
                }
                this.labelBrokerage.Text = Game.MarketState.Brokerage.ToString("n", nfi) + " " + nfi.PercentSymbol;
                if (this.StockForms.Count > 0)
                {
                    foreach (StockForm stockform in this.StockForms)
                    {
                        if (stockform.Visible)
                            stockform.UpdateStockInformations();
                    }
                }
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void UpdatePlayerInformations(System.Windows.Forms.Panel panel, Players computerplayers)
        {
            try
            {
                int panelno = int.Parse(panel.Name.Substring(panel.Name.Length - 1));
                if (panel.Controls["GroupBoxPlayer" + panelno.ToString()] != null)
                {
                    Player player = null;
                    System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                    System.Globalization.RegionInfo ri = System.Globalization.RegionInfo.CurrentRegion;
                    if (panel.Controls["GroupBoxPlayer" + panelno.ToString()].Controls["textBoxPlayer" + panelno.ToString() + "Company"] != null)
                    {
                        player = Game.CurrentPlayer;
                    }
                    else if (panel.Controls["GroupBoxPlayer" + panelno.ToString()].Controls["comboBoxPlayer" + panelno.ToString() + "Company"] != null)
                    {
                        System.Windows.Forms.ComboBox combobox = (System.Windows.Forms.ComboBox) panel.Controls["GroupBoxPlayer" + panelno.ToString()].Controls["comboBoxPlayer" + panelno.ToString() + "Company"];
                        if (combobox.Items.Count > 0)
                        {
                            combobox.DisplayMember = String.Empty;
                            foreach (Player p in Game.Players)
                            {
                                if (!combobox.Items.Contains(p) && p.Company.Length > 0 && !p.IsYou)
                                    combobox.Items.Add(p);
                            }
                            for (int i = combobox.Items.Count - 1; i >= 0; i--)
                            {
                                if (!Game.Players.Contains((Player) combobox.Items[i]))
                                    combobox.Items.RemoveAt(i);
                                else if (((Player)combobox.Items[i]).Company.Length == 0)
                                    combobox.Items.RemoveAt(i);
                            }
                            combobox.DisplayMember = "Company";
                            if (combobox.SelectedItem != null)
                                player = (Player) combobox.SelectedItem;
                        }
                        else if (Game.Players.Count > 0)
                        {
                            combobox.DisplayMember = "Company";
                            foreach (Player p in Game.Players)
                            {
                                if (p.Company.Length > 0 && !p.IsYou)
                                    combobox.Items.Add(p);
                            }
                            if (combobox.Items.Count > panelno - 2)
                            {
                                combobox.SelectedIndex = panelno - 2;
                                player = (Player) combobox.SelectedItem;
                            }
                        }
                        if (computerplayers != null && combobox.SelectedItem != null)
                        {
                            if (computerplayers.Count > 0)
                            {
                                player = (Player) combobox.SelectedItem;
                                if (player.IsComputer)
                                {
                                    if (combobox.Items.Contains(computerplayers[0]))
                                    {
                                        combobox.SelectedIndex = combobox.Items.IndexOf(computerplayers[0]);
                                        player = (Player) combobox.SelectedItem;
                                        computerplayers.RemoveAt(0);
                                    }
                                }
                            }
                        }
                    }
                    if (panel.Controls["GroupBoxPlayer" + panelno.ToString()].Controls["textBoxPlayer" + panelno.ToString() + "Name"] != null)
                    {
                        if (panelno > 1)
                        {
                            System.Windows.Forms.TextBox textbox = (System.Windows.Forms.TextBox) panel.Controls["GroupBoxPlayer" + panelno.ToString()].Controls["textBoxPlayer" + panelno.ToString() + "Name"];
                            if (player != null)
                                textbox.Text = player.Name;
                            else
                                textbox.Text = String.Empty;
                        }
                    }
                    if (panel.Controls["GroupBoxPlayer" + panelno.ToString()].Controls["textBoxPlayer" + panelno.ToString() + "Capital"] != null)
                    {
                        System.Windows.Forms.TextBox textbox = (System.Windows.Forms.TextBox) panel.Controls["GroupBoxPlayer" + panelno.ToString()].Controls["textBoxPlayer" + panelno.ToString() + "Capital"];
                        if (player != null)
                            textbox.Text = player.Capital.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                        else
                            textbox.Text = String.Empty;
                    }
                    if (panel.Controls["GroupBoxPlayer" + panelno.ToString()].Controls["textBoxPlayer" + panelno.ToString() + "DepositValue"] != null)
                    {
                        System.Windows.Forms.TextBox textbox = (System.Windows.Forms.TextBox) panel.Controls["GroupBoxPlayer" + panelno.ToString()].Controls["textBoxPlayer" + panelno.ToString() + "DepositValue"];
                        if (player != null)
                            textbox.Text = player.Deposit.Value.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                        else
                            textbox.Text = String.Empty;
                    }
                    if (panel.Controls["GroupBoxPlayer" + panelno.ToString()].Controls["textBoxPlayer" + panelno.ToString() + "Value"] != null)
                    {
                        System.Windows.Forms.TextBox textbox = (System.Windows.Forms.TextBox) panel.Controls["GroupBoxPlayer" + panelno.ToString()].Controls["textBoxPlayer" + panelno.ToString() + "Value"];
                        if (player != null)
                            textbox.Text = player.Value.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                        else
                            textbox.Text = String.Empty;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePlayerInformations()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                foreach (Player player in Game.Players)
                {
                    string showcompany = string.Empty;
                    if (player.Company.Length > 0)
                        showcompany = "&" + player.Company;
                    if (this.toolStripMenuItemDeposit.DropDownItems.Count > 0)
                    {
                        if (showcompany.Length > 0 && !player.IsYou)
                        {
                            bool found = false;
                            for (int i = 0; i < this.toolStripMenuItemDeposit.DropDownItems.Count && !found; i++)
                            {
                                found = ((Player) this.toolStripMenuItemDeposit.DropDownItems[i].Tag == player);
                                if (found)
                                {
                                    if (showcompany != this.toolStripMenuItemDeposit.DropDownItems[i].Text)
                                    {
                                        this.toolStripMenuItemDeposit.DropDownItems[i].Text = showcompany;
                                        if (((System.Windows.Forms.ToolStripMenuItem) this.toolStripMenuItemDeposit.DropDownItems[i]).Checked)
                                        {
                                            foreach (System.Windows.Forms.ColumnHeader ch in this.listViewStocks.Columns)
                                            {
                                                if (ch.Tag.Equals(player))
                                                {
                                                    ch.Text = player.Company;
                                                    ch.AutoResize(System.Windows.Forms.ColumnHeaderAutoResizeStyle.HeaderSize);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (!found)
                            {
                                System.Windows.Forms.ToolStripMenuItem tsmi = new System.Windows.Forms.ToolStripMenuItem(showcompany);
                                tsmi.CheckOnClick = true;
                                tsmi.Tag = player;
                                tsmi.Click += new System.EventHandler(this.toolStripMenuItemDeposit_Click);
                                this.toolStripMenuItemDeposit.DropDownItems.Add(tsmi);
                            }
                        }
                    }
                    else if (showcompany.Length > 0 && !player.IsYou)
                    {
                        System.Windows.Forms.ToolStripMenuItem tsmi = new System.Windows.Forms.ToolStripMenuItem(showcompany);
                        tsmi.CheckOnClick = true;
                        tsmi.Tag = player;
                        tsmi.Click += new System.EventHandler(this.toolStripMenuItemDeposit_Click);
                        this.toolStripMenuItemDeposit.DropDownItems.Add(tsmi);
                    }
                }
                if (this.toolStripMenuItemDeposit.DropDownItems.Count > 0)
                {
                    for (int i = this.toolStripMenuItemDeposit.DropDownItems.Count - 1; i >= 0; i--)
                    {
                        if (!Game.Players.Contains((Player) this.toolStripMenuItemDeposit.DropDownItems[i].Tag))
                        {
                            System.Windows.Forms.ToolStripMenuItem tsmi = (System.Windows.Forms.ToolStripMenuItem) this.toolStripMenuItemDeposit.DropDownItems[i];
                            if (tsmi.Checked)
                            {
                                tsmi.Checked = false;
                                this.toolStripMenuItemDeposit_Click(tsmi, new System.EventArgs());
                            }
                            this.toolStripMenuItemDeposit.DropDownItems.RemoveAt(i);
                        }
                    }
                }
                Players computerplayers = (Players) Game.Players.Clone();
                computerplayers.Sort();
                this.UpdatePlayerInformations(this.panelPlayer1, computerplayers);
                this.UpdatePlayerInformations(this.panelPlayer2, computerplayers);
                this.UpdatePlayerInformations(this.panelPlayer3, computerplayers);
                this.UpdatePlayerInformations(this.panelPlayer4, computerplayers);
                if (this.StockForms.Count > 0)
                {
                    foreach (StockForm stockform in this.StockForms)
                    {
                        if (stockform.Visible)
                            stockform.UpdatePlayerInformations();
                    }
                }
                if (this.StatisticsForms.Count > 0)
                {
                    foreach (StatisticsForm statisticsform in this.StatisticsForms)
                    {
                        if (statisticsform.Visible)
                            statisticsform.UpdatePlayerInformations();
                    }
                }
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void ResetInformations()
        {
            try
            {
                while (StockForms.Count > 0)
                {
                    StockForm stockform = StockForms[0];
                    StockForms.Remove(stockform);
                    if (stockform.Visible)
                        stockform.Close();
                    stockform.Dispose();
                }
                while (StatisticsForms.Count > 0)
                {
                    StatisticsForm statisticsform = StatisticsForms[0];
                    StatisticsForms.Remove(statisticsform);
                    if (statisticsform.Visible)
                        statisticsform.Close();
                    statisticsform.Dispose();
                }
                if (OldFileName.Length > 0)
                {
                    string s = this.toolStripMenuItemSave.Text;
                    if (s.IndexOf(" (" + System.IO.Path.GetFileName(OldFileName) + ')') >= 0)
                        s = s.Substring(0, s.IndexOf(" (" + System.IO.Path.GetFileName(OldFileName) + ')'));
                    this.toolStripMenuItemSave.Text = s;
                    OldFileName = null;
                }
                if (Game.FileName.Length > 0)
                {
                    string s = this.toolStripMenuItemSave.Text;
                    if (s.IndexOf(" (" + System.IO.Path.GetFileName(Game.FileName) + ')') >= 0)
                        s = s.Substring(0, s.IndexOf(" (" + System.IO.Path.GetFileName(Game.FileName) + ')'));
                    this.toolStripMenuItemSave.Text = s;
                }
                for (int i = this.listViewStocks.Columns.Count - 1; i >= 0; i--)
                {
                    if (this.listViewStocks.Columns[i].Tag is Player)
                    {
                        this.listViewStocks.Columns.Remove(this.listViewStocks.Columns[i]);
                        foreach (System.Windows.Forms.ListViewItem lvi in this.listViewStocks.Items)
                            lvi.SubItems.Remove(lvi.SubItems[i]);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private bool BeforeSeverStart()
        {
            try
            {
                if (System.Windows.Forms.MessageBox.Show(this, "Nyt netværksspil?", ProductName, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    ResetInformations();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                throw ex;
            }
            return false;
        }

        private void AfterServerStart()
        {
            try
            {
                GrayItems();
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private bool BeforeServerStop()
        {
            try
            {
                if (System.Windows.Forms.MessageBox.Show(this, "Afslut netværksspil?", ProductName, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    ResetInformations();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                throw ex;
            }
            return false;
        }

        private void AfterServerStop()
        {
            try
            {
                GrayItems();
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private string GetServerInformation()
        {
            try
            {
                return "Server for " + ProductName + " på " + System.Environment.MachineName;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private bool BeforeClientConnect()
        {
            try
            {
                if (System.Windows.Forms.MessageBox.Show(this, "Tilslut netværksspil?", ProductName, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    ResetInformations();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                throw ex;
            }
            return false;
        }

        private void AfterClientConnect()
        {
            try
            {
                if (ClientConnected)
                {
                    while (this.toolStripMenuItemDeposit.DropDownItems.Count > 0)
                        this.toolStripMenuItemDeposit.DropDownItems.Clear();
                    while (this.comboBoxStockIndex.Items.Count > 0)
                        this.comboBoxStockIndex.Items.Clear();
                    while (this.textBoxPlayer1Company.DataBindings.Count > 0)
                        this.textBoxPlayer1Company.DataBindings.Clear();
                    this.textBoxPlayer1Company.DataBindings.Add(new System.Windows.Forms.Binding("Text", Game.CurrentPlayer, "Company"));
                    while (this.textBoxPlayer1Name.DataBindings.Count > 0)
                        this.textBoxPlayer1Name.DataBindings.Clear();
                    this.textBoxPlayer1Name.DataBindings.Add(new System.Windows.Forms.Binding("Text", Game.CurrentPlayer, "Name"));
                    while (this.listViewStocks.Items.Count > 0)
                        this.listViewStocks.Items.Clear();
                    while (this.comboBoxPlayer2Company.Items.Count > 0)
                        this.comboBoxPlayer2Company.Items.Clear();
                    while (this.comboBoxPlayer3Company.Items.Count > 0)
                        this.comboBoxPlayer3Company.Items.Clear();
                    while (this.comboBoxPlayer4Company.Items.Count > 0)
                        this.comboBoxPlayer4Company.Items.Clear();
                }
                GrayItems();
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private bool BeforeClientDisconnect()
        {
            try
            {
                if (System.Windows.Forms.MessageBox.Show(this, "Afbryd netværksspil?", ProductName, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    ResetInformations();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                throw ex;
            }
            return false;
        }

        private void AfterClientDisconnect()
        {
            try
            {
                GrayItems();
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void OnPlayerConnected(Player player)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                throw ex;
            }
        }

        private void OnPlayerDisconnected(Player player)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (this.toolStripMenuItemDeposit.DropDownItems.Count > 0)
                {
                    foreach (System.Windows.Forms.ToolStripMenuItem menuitem in this.toolStripMenuItemDeposit.DropDownItems)
                    {
                        if (menuitem.Checked && menuitem.Tag.Equals(player))
                        {
                            menuitem.Checked = false;
                            this.toolStripMenuItemDeposit_Click(menuitem, new System.EventArgs());
                        }
                    }
                }
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                throw ex;
            }
        }

        private ServerInformation SelectServer(ServerInformations serverinformations)
        {
            try
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                ServerInformation si = null;
                SelectForm selectform = new SelectForm("Vælg server", "Servere", serverinformations, this.imageListLarge, this.imageListSmall, 1);
                if (selectform.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    if (selectform.SelectedItems.Count > 0)
                        si = (ServerInformation)selectform.SelectedItems[0];
                }
                selectform.Dispose();
                this.Update();
                if (this.Cursor != System.Windows.Forms.Cursors.WaitCursor)
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                return si;
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.WaitCursor)
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                throw ex;
            }
        }

        private void GrayItems()
        {
            try
            {
                this.toolStripMenuItemNewGame.Enabled = !ServerRunning && !ClientConnected;
                this.toolStripMenuItemOpen.Enabled = !ServerRunning && !ClientConnected;
                this.toolStripMenuItemSave.Enabled = !ServerRunning && !ClientConnected;
                this.toolStripMenuItemSaveAs.Enabled = !ServerRunning && !ClientConnected;
                this.toolStripMenuItemTrade.Enabled = false;
                this.toolStripSeparatorPause.Visible = !ClientConnected;
                this.toolStripMenuItemPause.Visible = !Game.IsPaused && !ClientConnected;
                this.toolStripMenuItemContinue.Visible = Game.IsPaused && !ClientConnected;
                this.toolStripMenuItemServer.Enabled = !ClientConnected;
                this.toolStripMenuItemServer.Checked = ServerRunning;
                this.toolStripMenuItemClient.Enabled = !ServerRunning;
                this.toolStripMenuItemClient.Checked = ClientConnected;
                if (this.listViewStocks.Items.Count > 0)
                {
                    this.toolStripMenuItemTrade.Enabled = (this.listViewStocks.SelectedItems.Count > 0);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private bool SaveAs()
        {
            try
            {
                bool cancel = false;
                System.Windows.Forms.SaveFileDialog fd = new System.Windows.Forms.SaveFileDialog();
                fd.Filter = "Gemte spil (*.wsg)|*.wsg|Alle filer (*.*)|*.*";
                fd.FilterIndex = 0;
                switch (fd.ShowDialog())
                {
                    case System.Windows.Forms.DialogResult.OK:
                        Game.Save(fd.FileName);
                        break;
                    default:
                        cancel = true;
                        break;
                }
                fd.Dispose();
               return cancel;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private bool Save()
        {
            try
            {
                bool cancel = false;
                if (Game.FileName != String.Empty)
                    Game.Save();
                else
                    cancel = SaveAs();
                return cancel;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (AskToSaveOnClose)
                {
                    if (ServerRunning)
                    {
                        switch (System.Windows.Forms.MessageBox.Show(this, "Afslut netværksspil?", ProductName, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question))
                        {
                            case System.Windows.Forms.DialogResult.Yes:
                                e.Cancel = false;
                                break;
                            default:
                                e.Cancel = true;
                                break;
                        }
                    }
                    else if (ClientConnected)
                    {
                        switch (System.Windows.Forms.MessageBox.Show(this, "Afbryd netværksspil?", ProductName, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question))
                        {
                            case System.Windows.Forms.DialogResult.Yes:
                                e.Cancel = false;
                                break;
                            default:
                                e.Cancel = true;
                                break;
                        }
                    }
                    else
                    {
                        switch (System.Windows.Forms.MessageBox.Show(this, "Gem spillet?", ProductName, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question))
                        {
                            case System.Windows.Forms.DialogResult.Yes:
                                e.Cancel = Save();
                                break;
                            case System.Windows.Forms.DialogResult.No:
                                e.Cancel = false;
                                break;
                            case System.Windows.Forms.DialogResult.Cancel:
                                e.Cancel = true;
                                break;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                e.Cancel = true;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            try
            {
                this.panelPlayer1.Width = (this.panelPlayer1And2.Width / 2);
                this.panelPlayer3.Width = (this.panelPlayer3And4.Width / 2);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                Game.Reset();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog fd = new System.Windows.Forms.OpenFileDialog();
                fd.Filter = "Gemte spil (*.wsg)|*.wsg|Alle filer (*.*)|*.*";
                fd.FilterIndex = 0;
                fd.Multiselect = false;
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Game.Load(fd.FileName);
                }
                fd.Dispose();
            }
            catch (VersionNotSupportedException)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                System.Windows.Forms.MessageBox.Show(this, "Versionen af det gemte spil er ikke supporteret.", ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                AskToSaveOnClose = false;
                this.Close();
            }
        }

        private void toolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

        }

        private void toolStripMenuItemSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                SaveAs();
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is System.Windows.Forms.ToolStripMenuItem)
                {
                    System.Windows.Forms.ToolStripMenuItem tsmi = (System.Windows.Forms.ToolStripMenuItem) sender;
                    Player player = (Player) tsmi.Tag;
                    bool found = false;
                    int column = 0;
                    for (column = 0; column < this.listViewStocks.Columns.Count && !found; column++)
                    {
                        if (this.listViewStocks.Columns[column].Tag is Player)
                            found = ((Player) this.listViewStocks.Columns[column].Tag == player);
                    }
                    switch (tsmi.CheckState)
                    {
                        case System.Windows.Forms.CheckState.Checked:
                            if (!found)
                            {
                                System.Windows.Forms.ColumnHeader ch = new System.Windows.Forms.ColumnHeader();
                                ch.Name = "OtherDeposit";
                                ch.Text = player.Company;
                                ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                                ch.Tag = player;
                                this.listViewStocks.Columns.Insert(this.listViewStocks.Columns.Count - 1, ch);
                                if (this.listViewStocks.Items.Count > 0)
                                {
                                    foreach (System.Windows.Forms.ListViewItem lvi in this.listViewStocks.Items)
                                    {
                                        System.Windows.Forms.ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                                        lvsi.Name = ch.Name;
                                        lvsi.Tag = ch.Tag;
                                        lvi.SubItems.Insert(lvi.SubItems.Count - 1, lvsi);
                                    }
                                }
                                UpdateStockInformations();
                            }
                            break;
                        default:
                            if (found)
                            {
                                this.listViewStocks.Columns.RemoveAt(column - 1);
                                if (this.listViewStocks.Items.Count > 0)
                                {
                                    foreach (System.Windows.Forms.ListViewItem lvi in this.listViewStocks.Items)
                                        lvi.SubItems.RemoveAt(column - 1);
                                }
                                UpdateStockInformations();
                            }
                            break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        
        private void toolStripMenuItemValueLineGraph_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticsForm statisticsform = new StatisticsForm(this, GraphType.Line, ((System.Windows.Forms.ToolStripMenuItem) sender).Text.Replace("&", null), Game.Players, Game.CurrentPlayer, (Player) this.comboBoxPlayer2Company.SelectedItem, (Player) this.comboBoxPlayer3Company.SelectedItem, (Player) this.comboBoxPlayer4Company.SelectedItem);
                this.StatisticsForms.Add(statisticsform);
                statisticsform.Show(this);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemValueBarGraph_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticsForm statisticsform = new StatisticsForm(this, GraphType.Bar, ((System.Windows.Forms.ToolStripMenuItem)sender).Text.Replace("&", null), Game.Players, Game.CurrentPlayer, (Player)this.comboBoxPlayer2Company.SelectedItem, (Player)this.comboBoxPlayer3Company.SelectedItem, (Player)this.comboBoxPlayer4Company.SelectedItem);
                this.StatisticsForms.Add(statisticsform);
                statisticsform.Show(this);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemPause_Click(object sender, EventArgs e)
        {
            try
            {
                Game.Pause();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemContinue_Click(object sender, EventArgs e)
        {
            try
            {
                Game.Continue();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (Server == null)
                {
                    Server = new Server(Game, this);
                    Server.BeforeStartEvent = this.BeforeSeverStart;
                    Server.AfterStartEvent = this.AfterServerStart;
                    Server.BeforeStopEvent = this.BeforeServerStop;
                    Server.AfterStopEvent = this.AfterServerStop;
                    Server.GetServerInformationEvent = this.GetServerInformation;
                    Server.OnPlayerConnectedEvent = this.OnPlayerConnected;
                    Server.OnPlayerDisconnectedEvent = this.OnPlayerDisconnected;
                }
                if (this.toolStripMenuItemServer.Checked)
                {
                    Server.Stop();
                }
                else
                {
                    Server.Start();
                }
                this.toolStripMenuItemServer.Checked = Server.Running;
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (Client == null)
                {
                    Client = new Client(Game, this);
                    Client.BeforeConnectEvent = this.BeforeClientConnect;
                    Client.AfterConnectEvent = this.AfterClientConnect;
                    Client.BeforeDisconnectEvent = this.BeforeClientDisconnect;
                    Client.AfterDisconnectEvent = this.AfterClientDisconnect;
                    Client.SelectServerEvent = this.SelectServer;
                    Client.OnPlayerConnectedEvent = this.OnPlayerConnected;
                    Client.OnPlayerDisconnectedEvent = this.OnPlayerDisconnected;
                }
                if (this.toolStripMenuItemClient.Checked)
                {
                    Client.Disconnect();
                }
                else
                {
                    Client.Connect();
                }
                this.toolStripMenuItemClient.Checked = Client.Connected;
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                switch (ex.ErrorCode)
                {
                    case (int) System.Net.Sockets.SocketError.HostUnreachable:
                        System.Windows.Forms.MessageBox.Show(this, "Ingen servere tilgængelige på netværket.", ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        break;
                    default:
                        System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.MessageBox.Show(this, ProductName + "\nVersion: " + ProductVersion + "\n\nUdviklingsteam:\n" + CompanyName, "Om " + ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void comboBoxStockIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.listViewStocks.BeginUpdate();
                while (this.listViewStocks.Items.Count > 0)
                    this.listViewStocks.Items.Clear();
                this.listViewStocks.EndUpdate();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                UpdateStockInformations();
                GrayItems();
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void listViewStocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GrayItems();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void listViewStocks_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.listViewStocks.Items.Count > 0 && this.listViewStocks.SelectedItems.Count > 0)
                {
                    foreach (System.Windows.Forms.ListViewItem lvi in this.listViewStocks.SelectedItems)
                    {
                        StockForm stockform = new StockForm(this, (Stock) lvi.Tag, Game.CurrentPlayer, Game.MarketState);
                        this.StockForms.Add(stockform);
                        stockform.Show(this);
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void listViewStocks_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.listViewStocks.BeginUpdate();
                ListViewItemComparerMethod method = ListViewItemComparerMethod.Unknown;
                if (this.listViewStocks.Columns[e.Column].Tag is Player)
                    method = ListViewItemComparerMethod.Integer;
                else
                    method = (ListViewItemComparerMethod) this.listViewStocks.Columns[e.Column].Tag;
                System.Windows.Forms.SortOrder sortorder = System.Windows.Forms.SortOrder.None;
                switch (method)
                {
                    case ListViewItemComparerMethod.String:
                        sortorder = System.Windows.Forms.SortOrder.Ascending;
                        break;
                    case ListViewItemComparerMethod.Double:
                    case ListViewItemComparerMethod.Integer:
                        sortorder = System.Windows.Forms.SortOrder.Descending;
                        break;
                }
                if (this.listViewStocks.ListViewItemSorter != null)
                {
                    ListViewItemComparer lvic = (ListViewItemComparer) this.listViewStocks.ListViewItemSorter;
                    lvic.ColumnToSort = e.Column;
                    lvic.Method = method;
                    lvic.SortOrder = sortorder;
                    this.listViewStocks.Sort();
                }
                else
                    this.listViewStocks.ListViewItemSorter = new ListViewItemComparer(e.Column, method, sortorder);
                this.listViewStocks.EndUpdate();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                GrayItems();
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void panelPlayer_Resize(object sender, EventArgs e)
        {
            try
            {
                
                if (sender is System.Windows.Forms.Panel)
                {
                    System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel) sender;
                    int delta_w = panel.Width - (int) panel.Tag;
                    if (panel.Controls.Count > 0 && delta_w != 0)
                    {
                        foreach (System.Windows.Forms.Control control in panel.Controls)
                        {
                            if (control is System.Windows.Forms.GroupBox)
                            {
                                if (control.Controls.Count > 0)
                                {
                                    foreach (System.Windows.Forms.Control subcontrol in control.Controls)
                                    {
                                        if (subcontrol is System.Windows.Forms.Label)
                                        {
                                            if (subcontrol.Name.Substring(subcontrol.Name.Length - 7) == "Capital")
                                            {
                                                subcontrol.Location = new System.Drawing.Point(subcontrol.Location.X + delta_w, subcontrol.Location.Y);
                                            }
                                            else if (subcontrol.Name.Substring(subcontrol.Name.Length - 5) == "Value")
                                            {
                                                subcontrol.Location = new System.Drawing.Point(subcontrol.Location.X + delta_w, subcontrol.Location.Y);
                                            }
                                        }
                                        else if (subcontrol is System.Windows.Forms.TextBox)
                                        {
                                            if (subcontrol.Name.Substring(subcontrol.Name.Length - 7) == "Capital")
                                            {
                                                subcontrol.Location = new System.Drawing.Point(subcontrol.Location.X + delta_w, subcontrol.Location.Y);
                                            }
                                            else if (subcontrol.Name.Substring(subcontrol.Name.Length - 5) == "Value")
                                            {
                                                subcontrol.Location = new System.Drawing.Point(subcontrol.Location.X + delta_w, subcontrol.Location.Y);
                                            }
                                            else
                                                subcontrol.Width += delta_w;
                                        }
                                        else if (subcontrol is System.Windows.Forms.ComboBox)
                                        {
                                            subcontrol.Width += delta_w;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    panel.Tag = panel.Width;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void comboBoxPlayerCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.UpdatePlayerInformations((System.Windows.Forms.Panel) ((System.Windows.Forms.ComboBox) sender).Parent.Parent, null);
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}