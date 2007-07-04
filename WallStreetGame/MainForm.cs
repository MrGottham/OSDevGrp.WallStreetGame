using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OSDevGrp.WallStreetGame
{
    public partial class MainForm : Form
    {
        private const string PRODUCT_NAME = "Aktiespillet";

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
                                int x_i = int.Parse(x_s, System.Globalization.NumberStyles.AllowThousands, nfi);
                                string y_s = y_lvi.SubItems[ColumnToSort].Text;
                                int y_p = y_s.IndexOf(' ');
                                if (y_p >= 0)
                                {
                                    y_s = y_s.Substring(0, y_p);
                                }
                                int y_i = int.Parse(y_s, System.Globalization.NumberStyles.AllowThousands, nfi);
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
                                double x_d = double.Parse(x_s, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint, nfi);
                                string y_s = y_lvi.SubItems[ColumnToSort].Text;
                                int y_p = y_s.IndexOf(' ');
                                if (y_p >= 0)
                                {
                                    y_s = y_s.Substring(0, y_p);
                                }
                                double y_d = double.Parse(y_s, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint, nfi);
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

        public MainForm()
        {
            InitializeComponent();
            try
            {
                Game = new Game();
                Game.BeforeResetEvent = this.BeforeReset;
                Game.AfterResetEvent = this.AfterReset;
                Game.UpdateStockInformationsEvent = this.UpdateStockInformations;
                Game.UpdatePlayerInformationsEvent = this.UpdatePlayerInformations;
                this.Text = PRODUCT_NAME;
                this.toolStripMenuItemAbout.Text = this.toolStripMenuItemAbout.Text + " " + PRODUCT_NAME;
                this.comboBoxStockIndex.Items.Clear();
                this.comboBoxStockIndex.DisplayMember = "Name";
                if (Game.StockIndexes.Count > 0)
                {
                    foreach (StockIndex stockindex in Game.StockIndexes.Values)
                        this.comboBoxStockIndex.Items.Add(stockindex);
                }
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
                ch.Text = System.Globalization.NumberFormatInfo.CurrentInfo.PositiveSign + "/" + System.Globalization.NumberFormatInfo.CurrentInfo.NegativeSign;
                ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                ch.Tag = ListViewItemComparerMethod.Double;
                this.listViewStocks.Columns.Add(ch);
                ch = new System.Windows.Forms.ColumnHeader();
                ch.Name = "PriceDifferenceProcent";
                ch.Text = System.Globalization.NumberFormatInfo.CurrentInfo.PercentSymbol;
                ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                ch.Tag = ListViewItemComparerMethod.Double;
                this.listViewStocks.Columns.Add(ch);
                ch = new System.Windows.Forms.ColumnHeader();
                ch.Name = "Available";
                ch.Text = "Frie aktier";
                ch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                ch.Tag = ListViewItemComparerMethod.Integer;
                this.listViewStocks.Columns.Add(ch);
                if (this.comboBoxStockIndex.Items.Count > 0)
                    this.comboBoxStockIndex.SelectedItem = this.comboBoxStockIndex.Items[0];
                GrayItems();
            }
            catch (System.Exception ex)
            {
                throw ex;
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

        private bool BeforeReset()
        {
            try
            {
                if (System.Windows.Forms.MessageBox.Show(this, "Nyt spil?", PRODUCT_NAME, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
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
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateStockInformations()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                StockIndex stockindex = (StockIndex) this.comboBoxStockIndex.SelectedItem;
                if (stockindex != null)
                {
                    System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                    this.labelAverage.Text = stockindex.PriceAverage.ToString("n", nfi) + " " + System.Globalization.RegionInfo.CurrentRegion.ISOCurrencySymbol;
                    if (this.listViewStocks.Items.Count > 0)
                    {
                        this.listViewStocks.BeginUpdate();
                        foreach (System.Windows.Forms.ListViewItem lvi in this.listViewStocks.Items)
                        {
                            Stock stock = (Stock) lvi.Tag;
                            switch (lvi.Name)
                            {
                                case "Price":
                                    lvi.Text = stock.Price.ToString("n", nfi) + " " + System.Globalization.RegionInfo.CurrentRegion.ISOCurrencySymbol;
                                    break;
                                case "PriceDifference":
                                    lvi.Text = stock.PriceDifference.ToString("n", nfi) + " " + System.Globalization.RegionInfo.CurrentRegion.ISOCurrencySymbol;
                                    break;
                                case "PriceDifferenceProcent":
                                    lvi.Text = stock.PriceDifferenceProcent.ToString("n", nfi) + " " + System.Globalization.NumberFormatInfo.CurrentInfo.PercentSymbol;
                                    break;
                                case "Available":
                                    lvi.Text = stock.Available.ToString("#,##0", nfi);
                                    break;
                            }
                            if (lvi.SubItems.Count > 0)
                            {
                                foreach (System.Windows.Forms.ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                                {
                                    switch (lvsi.Name)
                                    {
                                        case "Price":
                                            lvsi.Text = stock.Price.ToString("n", nfi) + " " + System.Globalization.RegionInfo.CurrentRegion.ISOCurrencySymbol;
                                            break;
                                        case "PriceDifference":
                                            lvsi.Text = stock.PriceDifference.ToString("n", nfi) + " " + System.Globalization.RegionInfo.CurrentRegion.ISOCurrencySymbol;
                                            break;
                                        case "PriceDifferenceProcent":
                                            lvsi.Text = stock.PriceDifferenceProcent.ToString("n", nfi) + " " + System.Globalization.NumberFormatInfo.CurrentInfo.PercentSymbol;
                                            break;
                                        case "Available":
                                            lvsi.Text = stock.Available.ToString("#,##0", nfi);
                                            break;
                                    }
                                }
                            }
                        }
                        this.listViewStocks.AutoResizeColumns(System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent);
                        this.listViewStocks.EndUpdate();
                    }
                    else if (stockindex.Stocks.Count > 0 && this.listViewStocks.Columns.Count > 0)
                    {
                        this.listViewStocks.BeginUpdate();
                        foreach (Stock stock in stockindex.Stocks.Values)
                        {
                            System.Windows.Forms.ListViewItem lvi = null;
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
                                            lvi = new System.Windows.Forms.ListViewItem(stock.Price.ToString("n", nfi) + " " + System.Globalization.RegionInfo.CurrentRegion.ISOCurrencySymbol, 0);
                                            lvi.Name = ch.Name;
                                            break;
                                        case "PriceDifference":
                                            lvi = new System.Windows.Forms.ListViewItem(stock.PriceDifference.ToString("n", nfi) + " " + System.Globalization.RegionInfo.CurrentRegion.ISOCurrencySymbol, 0);
                                            lvi.Name = ch.Name;
                                            break;
                                        case "PriceDifferenceProcent":
                                            lvi = new System.Windows.Forms.ListViewItem(stock.PriceDifferenceProcent.ToString("n", nfi) + " " + System.Globalization.NumberFormatInfo.CurrentInfo.PercentSymbol, 0);
                                            lvi.Name = ch.Name;
                                            break;
                                        case "Available":
                                            lvi = new System.Windows.Forms.ListViewItem(stock.Available.ToString("#,##0", nfi), 0);
                                            lvi.Name = ch.Name;
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
                                            lvsi.Text = stock.Price.ToString("n", nfi) + " " + System.Globalization.RegionInfo.CurrentRegion.ISOCurrencySymbol;
                                            lvsi.Name = ch.Name;
                                            break;
                                        case "PriceDifference":
                                            lvsi.Text = stock.PriceDifference.ToString("n", nfi) + " " + System.Globalization.RegionInfo.CurrentRegion.ISOCurrencySymbol;
                                            lvsi.Name = ch.Name;
                                            break;
                                        case "PriceDifferenceProcent":
                                            lvsi.Text = stock.PriceDifferenceProcent.ToString("n", System.Globalization.NumberFormatInfo.CurrentInfo) + " " + System.Globalization.NumberFormatInfo.CurrentInfo.PercentSymbol;
                                            lvsi.Name = ch.Name;
                                            break;
                                        case "Available":
                                            lvsi.Text = stock.Available.ToString("#,##0", nfi);
                                            lvsi.Name = ch.Name;
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
                        this.listViewStocks.AutoResizeColumns(System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent);
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
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                if (this.Cursor != System.Windows.Forms.Cursors.Default)
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, PRODUCT_NAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void UpdatePlayerInformations()
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
                System.Windows.Forms.MessageBox.Show(this, ex.Message, PRODUCT_NAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void GrayItems()
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                throw ex;
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
                System.Windows.Forms.MessageBox.Show(this, ex.Message, PRODUCT_NAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                System.Windows.Forms.MessageBox.Show(this, ex.Message, PRODUCT_NAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.MessageBox.Show(this, PRODUCT_NAME + "\nVersion: " + this.ProductVersion + "\n\nUdviklingsteam:\n" + this.CompanyName, "About", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, PRODUCT_NAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                System.Windows.Forms.MessageBox.Show(this, ex.Message, PRODUCT_NAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void listViewStocks_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.listViewStocks.BeginUpdate();
                ListViewItemComparerMethod method = (ListViewItemComparerMethod) this.listViewStocks.Columns[e.Column].Tag;
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
                System.Windows.Forms.MessageBox.Show(this, ex.Message, PRODUCT_NAME, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}