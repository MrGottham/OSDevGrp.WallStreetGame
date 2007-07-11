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