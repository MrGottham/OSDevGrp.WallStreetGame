using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OSDevGrp.WallStreetGame
{
    public partial class StockForm : Form
    {
        private MainForm  _MainForm = null;
        private Stock _Stock = null;
        private Player _Player = null;
        private MarketState _MarketState = null;
        private DepositContent _DepositContent = null;
        private LineGraph _LineGraph = null;

        public StockForm(MainForm mainform, Stock stock, Player player, MarketState marketstate) : base()
        {
            InitializeComponent();
            try
            {
                MainForm = mainform;
                Stock = stock;
                Player = player;
                MarketState = marketstate;
                LineGraph = new LineGraph(this.labelStockName.Location.X, this.labelStockName.Location.Y, this.panelStockGraph.Width - (this.labelStockName.Location.X * 2), this.panelStockGraph.Height - (this.labelStockName.Location.Y * 2), this.panelStockGraph.BackColor);
                LineGraph.IsCurrency = true;
                LineGraph.XMin = 0;
                LineGraph.XMax = Stock.PriceHistory.Capacity;
                LineGraph.GridLineStepX = (LineGraph.XMax - LineGraph.XMin) / 5;
                System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                this.Text = this.Text + ": " + Stock.Name;
                this.textBoxStockName.ReadOnly = true;
                this.textBoxStockName.TabStop = false;
                this.textBoxStockName.Text = stock.Name;
                this.comboBoxStockIndexes.DisplayMember = "Name";
                this.comboBoxStockIndexes.TabStop = false;
                if (Stock.StockIndexes.Count > 0)
                {
                    foreach (StockIndex stockindex in Stock.StockIndexes.Values)
                    {
                        this.comboBoxStockIndexes.Items.Add(stockindex);
                    }
                }
                if (this.comboBoxStockIndexes.Items.Count > 0)
                    this.comboBoxStockIndexes.SelectedIndex = 0;
                this.textBoxStockPrice.ReadOnly = true;
                this.textBoxStockPrice.TabStop = false;
                this.textBoxStockPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.labelStockPriceDifference.Text = nfi.PositiveSign + "/" + nfi.NegativeSign;
                this.textBoxStockPriceDifference.ReadOnly = true;
                this.textBoxStockPriceDifference.TabStop = false;
                this.textBoxStockPriceDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxStockPriceDifferenceProcent.ReadOnly = true;
                this.textBoxStockPriceDifferenceProcent.TabStop = false;
                this.textBoxStockPriceDifferenceProcent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxStockAvailable.ReadOnly = true;
                this.textBoxStockAvailable.TabStop = false;
                this.textBoxStockAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayerCapital.ReadOnly = true;
                this.textBoxPlayerCapital.TabStop = false;
                this.textBoxPlayerCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxPlayerDepositContent.ReadOnly = true;
                this.textBoxPlayerDepositContent.TabStop = false;
                this.textBoxPlayerDepositContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.radioButtonTradeBuy.Checked = true;
                this.textBoxTradeCountValue.ReadOnly = true;
                this.textBoxTradeCountValue.TabStop = false;
                this.textBoxTradeCountValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxTradeBrokerage.ReadOnly = true;
                this.textBoxTradeBrokerage.TabStop = false;
                this.textBoxTradeBrokerage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxTradeBrokeragePrice.ReadOnly = true;
                this.textBoxTradeBrokeragePrice.TabStop = false;
                this.textBoxTradeBrokeragePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.textBoxTradeTotal.ReadOnly = true;
                this.textBoxTradeTotal.TabStop = false;
                this.textBoxTradeTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.numericUpDownTradeCount.Select();
                UpdateStockInformations();
                UpdatePlayerInformations();
                UpdateTradeInformations();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public MainForm MainForm
        {
            get
            {
                return _MainForm;
            }
            private set
            {
                _MainForm = value;
            }
        }

        public Stock Stock
        {
            get
            {
                return _Stock;
            }
            private set
            {
                _Stock = value;
            }
        }

        public Player Player
        {
            get
            {
                return _Player;
            }
            private set
            {
                _Player = value;
            }
        }

        public MarketState MarketState
        {
            get
            {
                return _MarketState;
            }
            private set
            {
                _MarketState = value;
            }
        }

        public DepositContent DepositContent
        {
            get
            {
                if (_DepositContent == null)
                {
                    if (!Player.Deposit.TryGetValue(Stock.Id, out _DepositContent))
                        _DepositContent = null;
                }
                return _DepositContent;
            }
        }

        private LineGraph LineGraph
        {
            get
            {
                return _LineGraph;
            }
            set
            {
                _LineGraph = value;
            }
        }

        private void GrayItems()
        {
            try
            {
                this.radioButtonTradeBuy.Enabled = (Stock.Available > 0);
                if (this.radioButtonTradeBuy.Checked && !this.radioButtonTradeBuy.Enabled)
                    this.radioButtonTradeBuy.Checked = false;
                if (DepositContent != null)
                    this.radioButtonTradeSell.Enabled = (DepositContent.Count > 0);
                else
                    this.radioButtonTradeSell.Enabled = false;
                if (this.radioButtonTradeSell.Checked && !this.radioButtonTradeSell.Enabled)
                    this.radioButtonTradeSell.Checked = false;
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
                System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                System.Globalization.RegionInfo ri = System.Globalization.RegionInfo.CurrentRegion;
                this.panelStockGraph.Refresh();
                this.textBoxStockPrice.Text = Stock.Price.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                this.textBoxStockPriceDifference.Text = Stock.PriceDifference.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                this.textBoxStockPriceDifferenceProcent.Text = Stock.PriceDifferenceProcent.ToString("n", nfi) + " " + nfi.PercentSymbol;
                this.textBoxStockAvailable.Text = Stock.Available.ToString("#,##0", nfi);
                UpdateTradeInformations();
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
                System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                System.Globalization.RegionInfo ri = System.Globalization.RegionInfo.CurrentRegion;
                this.textBoxPlayerCapital.Text = Player.Capital.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                if (DepositContent != null)
                    this.textBoxPlayerDepositContent.Text = DepositContent.Count.ToString("#,##0", nfi);
                else
                    this.textBoxPlayerDepositContent.Text = string.Empty;
                GrayItems();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateTradeInformations()
        {
            try
            {
                System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                System.Globalization.RegionInfo ri = System.Globalization.RegionInfo.CurrentRegion;
                int max = 0;
                if (this.radioButtonTradeBuy.Checked)
                {
                    if (Player.Capital / Stock.CalculatePrice(1) > int.MaxValue)
                        max = int.MaxValue;
                    else
                        max = (int) System.Math.Floor(Player.Capital / Stock.CalculatePrice(1));
                    while (Player.Capital < Stock.CalculatePrice(max) + Stock.CalculateBrokerage(MarketState, max))
                        max--;
                    if (max > Stock.Available)
                        max = Stock.Available;
                }
                else if (this.radioButtonTradeSell.Checked)
                {
                    if (DepositContent != null)
                        max = DepositContent.Count;
                }
                this.numericUpDownTradeCount.Minimum = 0;
                if (this.numericUpDownTradeCount.Value > max)
                    this.numericUpDownTradeCount.Value = max;
                this.numericUpDownTradeCount.Maximum = max;
                this.textBoxTradeCountValue.Text = Stock.CalculatePrice((int) this.numericUpDownTradeCount.Value).ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                this.textBoxTradeBrokerage.Text = MarketState.Brokerage.ToString("n", nfi) + " " + nfi.PercentSymbol;
                this.textBoxTradeBrokeragePrice.Text = Stock.CalculateBrokerage(MarketState, (int) this.numericUpDownTradeCount.Value).ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                if (this.radioButtonTradeBuy.Checked)
                {
                    double d = Stock.CalculatePrice((int)this.numericUpDownTradeCount.Value) + Stock.CalculateBrokerage(MarketState, (int)this.numericUpDownTradeCount.Value);
                    this.textBoxTradeTotal.Text = d.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                }
                else if (this.radioButtonTradeSell.Checked)
                {
                    double d = Stock.CalculatePrice((int)this.numericUpDownTradeCount.Value) - Stock.CalculateBrokerage(MarketState, (int)this.numericUpDownTradeCount.Value);
                    this.textBoxTradeTotal.Text = d.ToString("n", nfi) + " " + ri.ISOCurrencySymbol;
                }
                else
                    this.textBoxTradeTotal.Text = string.Empty;
                GrayItems();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void StockForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MainForm.StockForms.Count > 0)
                {
                    while (MainForm.StockForms.Contains(this))
                        MainForm.StockForms.Remove(this);
                }
                e.Cancel = false;
            }
            catch (System.Exception ex)
            {
                e.Cancel = true;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, MainForm.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void panelStockGraph_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                LineGraph.YMin = (float) Stock.PriceHistory.Min;
                LineGraph.YMin -= System.Math.Round((LineGraph.YMin / 100) * 5, 0);
                LineGraph.YMin -= LineGraph.YMin % 100;
                LineGraph.YMax = (float) Stock.PriceHistory.Max;
                LineGraph.YMax += System.Math.Round((LineGraph.YMax / 100) * 5, 0);
                LineGraph.YMax += 100 - (LineGraph.YMax % 100);
                LineGraph.XMin = 0;
                LineGraph.XMax = Stock.PriceHistory.Count - 1 > LineGraph.XMin + 1 ? Stock.PriceHistory.Count - 1: LineGraph.XMin + 1;
                LineGraph.GridLineStepY = (LineGraph.YMax - LineGraph.YMin) / 4;
                LineGraph.Clear(e);
                LineGraph.Grid(e);
                LineGraph.Graph(e, Stock.PriceHistory);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void radioButtonTradeBuy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.numericUpDownTradeCount.Value = 0;
                UpdateTradeInformations();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, MainForm.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void radioButtonTradeSell_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.numericUpDownTradeCount.Value = 0;
                UpdateTradeInformations();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, MainForm.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void numericUpDownTradeCount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateTradeInformations();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, MainForm.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void buttonTradeOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.radioButtonTradeBuy.Checked)
                {
                    if (DepositContent != null)
                    {
                        Player.Buy(DepositContent, MarketState, (int) this.numericUpDownTradeCount.Value);
                        MainForm.UpdateStockInformations();
                        MainForm.UpdatePlayerInformations();
                    }
                }
                else if (this.radioButtonTradeSell.Checked)
                {
                    if (DepositContent != null)
                    {
                        Player.Sell(DepositContent, MarketState, (int)this.numericUpDownTradeCount.Value);
                        MainForm.UpdateStockInformations();
                        MainForm.UpdatePlayerInformations();
                    }
                }
                this.Close();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, MainForm.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void buttonTradeCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, MainForm.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}