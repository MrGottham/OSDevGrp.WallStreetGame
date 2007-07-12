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
        private LineGraph _LineGraph = null;

        public StockForm(MainForm mainform, Stock stock, Player player) : base()
        {
            InitializeComponent();
            try
            {
                MainForm = mainform;
                Stock = stock;
                Player = player;
                LineGraph = new LineGraph(this.labelStockName.Location.X, this.labelStockName.Location.Y, this.panelStockGraph.Width - (this.labelStockName.Location.X * 2), this.panelStockGraph.Height - (this.labelStockName.Location.Y * 2), this.panelStockGraph.BackColor);
                LineGraph.IsCurrency = true;
                LineGraph.XMin = 0;
                LineGraph.XMax = Stock.PriceHistory.Capacity;
                LineGraph.GridLineStepX = (LineGraph.XMax - LineGraph.XMin) / 5;
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
                this.labelStockPriceDifference.Text = System.Globalization.NumberFormatInfo.CurrentInfo.PositiveSign + "/" + System.Globalization.NumberFormatInfo.CurrentInfo.NegativeSign;
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
                UpdateStockInformations();
                UpdatePlayerInformations();
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

        public void UpdateStockInformations()
        {
            try
            {
                System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                this.panelStockGraph.Refresh();
                this.textBoxStockPrice.Text = Stock.Price.ToString("n", nfi) + " " + System.Globalization.RegionInfo.CurrentRegion.ISOCurrencySymbol;
                this.textBoxStockPriceDifference.Text = Stock.PriceDifference.ToString("n", nfi) + " " + System.Globalization.RegionInfo.CurrentRegion.ISOCurrencySymbol;
                this.textBoxStockPriceDifferenceProcent.Text = Stock.PriceDifferenceProcent.ToString("n", nfi) + " " + nfi.PercentSymbol;
                this.textBoxStockAvailable.Text = Stock.Available.ToString("#,##0", nfi);
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
                DepositContent content = null;
                System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                this.textBoxPlayerCapital.Text = Player.Capital.ToString("n", nfi) + " " + System.Globalization.RegionInfo.CurrentRegion.ISOCurrencySymbol;
                if (Player.Deposit.TryGetValue(Stock.Id, out content))
                    this.textBoxPlayerDepositContent.Text = content.Count.ToString("#,##0", nfi);
                else
                    this.textBoxPlayerDepositContent.Text = string.Empty;
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
                LineGraph.GridLineStepY = (LineGraph.YMax - LineGraph.YMin) / 4;
                LineGraph.Clear(e);
                LineGraph.Grid(e);
//                LineGraph.Graph(e, System.Drawing.Color.Blue, (float) 0.5, Stock.PriceHistory);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}