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

        private Game _Game = null;

        public MainForm()
        {
            InitializeComponent();
            try
            {
                Game = new Game();
                Game.BeforeResetEvent = this.BeforeReset;
                Game.AfterResetEvent = this.AfterReset;
                this.Text = PRODUCT_NAME;
                this.abortToolStripMenuItem.Text = this.abortToolStripMenuItem.Text + " " + PRODUCT_NAME;
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void abortToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}