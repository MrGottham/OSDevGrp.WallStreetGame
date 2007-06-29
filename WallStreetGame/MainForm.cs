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
        private Game _Game = null;

        public MainForm()
        {
            InitializeComponent();
            try
            {
                _Game = new Game();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}