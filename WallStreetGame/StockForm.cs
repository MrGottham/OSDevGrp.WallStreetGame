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
        private Game _Game = null;
        private Stock _Stock = null;

        public StockForm(MainForm mainform, Game game, Stock stock) : base()
        {
            InitializeComponent();
            try
            {
                MainForm = mainform;
                Game = game;
                Stock = stock;
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
                UpdateStockInformations();
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

        public void UpdateStockInformations()
        {
            try
            {
                System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
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
    }
}