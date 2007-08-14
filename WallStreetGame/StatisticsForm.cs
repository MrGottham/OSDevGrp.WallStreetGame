using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OSDevGrp.WallStreetGame
{
    public partial class StatisticsForm : Form
    {
        private MainForm _MainForm = null;
        private GraphType _GraphType = GraphType.Line;
        private LineGraph _LineGraph = null;
        private BarGraph _BarGraph = null;

        private struct MinAndMax<T>
        {
            public T Min;
            public T Max;
        }

        public StatisticsForm(MainForm mainform, GraphType graphtype, string header, Players players, Player player1, Player player2, Player player3, Player player4) : base()
        {
            InitializeComponent();
            try
            {
                MainForm = mainform;
                GraphType = graphtype;
                switch (GraphType)
                {
                    case GraphType.Line:
                        LineGraph = new LineGraph(this.panelGraph.Location.X, this.panelGraph.Location.Y, this.panelGraph.Width - (this.panelGraph.Location.X * 2), this.panelGraph.Height - (this.panelGraph.Location.Y * 2), this.panelGraph.BackColor);
                        LineGraph.IsCurrency = true;
                        LineGraph.AdjustToRight = true;
                        break;
                    case GraphType.Bar:
                        BarGraph = new BarGraph(this.panelGraph.Location.X, this.panelGraph.Location.Y, this.panelGraph.Width - (this.panelGraph.Location.X * 2), this.panelGraph.Height - (this.panelGraph.Location.Y * 2), this.panelGraph.BackColor);
                        BarGraph.IsCurrency = true;
                        BarGraph.NoOfBars = 4;
                        BarGraph.XMargin = 60;
                        BarGraph.BarSpace = 20;
                        break;
                }
                this.Text = header;
                this.checkBoxPlayer1.ForeColor = System.Drawing.Color.Blue;
                this.checkBoxPlayer1.Enabled = false;
                this.checkBoxPlayer1.Checked = false;
                this.textBoxPlayer1.ReadOnly = true;
                this.textBoxPlayer1.TabStop = false;
                if (player1 != null)
                {
                    this.checkBoxPlayer1.Enabled = true;
                    this.checkBoxPlayer1.Checked = true;
                    this.textBoxPlayer1.Text = player1.Company;
                    this.textBoxPlayer1.Tag = player1;
                }
                this.checkBoxPlayer2.ForeColor = System.Drawing.Color.Red;
                this.checkBoxPlayer2.Checked = false;
                this.comboBoxPlayer2.DisplayMember = "Company";
                Player[] p2 = new Player[players.Count];
                players.CopyTo(p2);
                this.comboBoxPlayer2.DataSource = p2;
                if (player2 != null)
                {
                    this.checkBoxPlayer2.Checked = true;
                    this.comboBoxPlayer2.SelectedItem = player2;
                }
                this.checkBoxPlayer3.ForeColor = System.Drawing.Color.Green;
                this.checkBoxPlayer3.Checked = false;
                this.comboBoxPlayer3.DisplayMember = "Company";
                Player[] p3 = new Player[players.Count];
                players.CopyTo(p3);
                this.comboBoxPlayer3.DataSource = p3;
                if (player3 != null)
                {
                    this.checkBoxPlayer3.Checked = true;
                    this.comboBoxPlayer3.SelectedItem = player3;
                }
                this.checkBoxPlayer4.ForeColor = System.Drawing.Color.Yellow;
                this.checkBoxPlayer4.Checked = false;
                this.comboBoxPlayer4.DisplayMember = "Company";
                Player[] p4 = new Player[players.Count];
                players.CopyTo(p4);
                this.comboBoxPlayer4.DataSource = p4;
                if (player4 != null)
                {
                    this.checkBoxPlayer4.Checked = true;
                    this.comboBoxPlayer4.SelectedItem = player4;
                }
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

        public GraphType GraphType
        {
            get
            {
                return _GraphType;
            }
            private set
            {
                _GraphType = value;
            }
        }

        public LineGraph LineGraph
        {
            get
            {
                return _LineGraph;
            }
            private set
            {
                _LineGraph = value;
            }
        }

        public BarGraph BarGraph
        {
            get
            {
                return _BarGraph;
            }
            private set
            {
                _BarGraph = value;
            }
        }

        public void UpdatePlayerInformations()
        {
            try
            {
                this.panelGraph.Refresh();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private MinAndMax<double> GetMinAndMax(MinAndMax<double> mam, double min, double max)
        {
            try
            {
                if (mam.Min < 0)
                    mam.Min = min;
                else if (mam.Min > min)
                    mam.Min = min;
                if (mam.Max < 0)
                    mam.Max = max;
                else if (mam.Max < max)
                    mam.Max = max;
                return mam;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private MinAndMax<double> GetMinAndMax(int fun, MinAndMax<double> mam, DoubleHistory history)
        {
            try
            {
                switch (fun)
                {
                    case 1:
                        mam = GetMinAndMax(mam, history.Min, history.Max);
                        break;
                    case 2:
                        mam = GetMinAndMax(mam, 0, history.Count);
                        break;
                }
                return mam;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void StatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MainForm.StatisticsForms.Count > 0)
                {
                    while (MainForm.StatisticsForms.Contains(this))
                        MainForm.StatisticsForms.Remove(this);
                }
                e.Cancel = false;
            }
            catch (System.Exception ex)
            {
                e.Cancel = true;
                System.Windows.Forms.MessageBox.Show(this, ex.Message, MainForm.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void panelGraph_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                MinAndMax<double> value_mam;
                value_mam.Min = -1;
                value_mam.Max = -1;
                MinAndMax<double> count_mam;
                count_mam.Min = -1;
                count_mam.Max = -1;
                if (this.checkBoxPlayer1.Checked && this.textBoxPlayer1.Tag != null)
                {
                    switch (GraphType)
                    {
                        case GraphType.Bar:
                            value_mam = GetMinAndMax(value_mam, 0, ((Player) this.textBoxPlayer1.Tag).Value * 1.10);
                            break;
                        default:
                            value_mam = GetMinAndMax(1, value_mam, ((Player) this.textBoxPlayer1.Tag).ValueHistory);
                            count_mam = GetMinAndMax(2, count_mam, ((Player) this.textBoxPlayer1.Tag).ValueHistory);
                            break;
                    }
                }
                if (this.checkBoxPlayer2.Checked && this.comboBoxPlayer2.SelectedIndex >= 0)
                {
                    switch (GraphType)
                    {
                        case GraphType.Bar:
                            value_mam = GetMinAndMax(value_mam, 0, ((Player) this.comboBoxPlayer2.SelectedItem).Value * 1.10);
                            break;
                        default:
                            value_mam = GetMinAndMax(1, value_mam, ((Player) this.comboBoxPlayer2.SelectedItem).ValueHistory);
                            count_mam = GetMinAndMax(2, count_mam, ((Player) this.comboBoxPlayer2.SelectedItem).ValueHistory);
                            break;
                    }
                }
                if (this.checkBoxPlayer3.Checked && this.comboBoxPlayer3.SelectedIndex >= 0)
                {
                    switch (GraphType)
                    {
                        case GraphType.Bar:
                            value_mam = GetMinAndMax(value_mam, 0, ((Player) this.comboBoxPlayer3.SelectedItem).Value * 1.10);
                            break;
                        default:
                            value_mam = GetMinAndMax(1, value_mam, ((Player) this.comboBoxPlayer3.SelectedItem).ValueHistory);
                            count_mam = GetMinAndMax(2, count_mam, ((Player) this.comboBoxPlayer3.SelectedItem).ValueHistory);
                            break;
                    }
                }
                if (this.checkBoxPlayer4.Checked && this.comboBoxPlayer4.SelectedIndex >= 0)
                {
                    switch (GraphType)
                    {
                        case GraphType.Bar:
                            value_mam = GetMinAndMax(value_mam, 0, ((Player) this.comboBoxPlayer4.SelectedItem).Value * 1.10);
                            break;
                        default:
                            value_mam = GetMinAndMax(1, value_mam, ((Player) this.comboBoxPlayer4.SelectedItem).ValueHistory);
                            count_mam = GetMinAndMax(2, count_mam, ((Player) this.comboBoxPlayer4.SelectedItem).ValueHistory);
                            break;
                    }
                }
                if (value_mam.Min < 0)
                    value_mam.Min = 0;
                else if (value_mam.Min > 0)
                {
                    value_mam.Min -= System.Math.Round((value_mam.Min / 1000) * 5, 0);
                    value_mam.Min -= value_mam.Min % 1000;
                }
                if (value_mam.Max < 0)
                    value_mam.Max = 0;
                else if (value_mam.Max > 0)
                {
                    value_mam.Max += System.Math.Round((value_mam.Max / 1000) * 5, 0);
                    value_mam.Max += 1000 - (value_mam.Max % 1000);
                }
                switch (GraphType)
                {
                    case GraphType.Line:
                        LineGraph.XMin = (float) count_mam.Min;
                        LineGraph.XMax = (float) count_mam.Max;
                        LineGraph.YMin = (float)value_mam.Min;
                        LineGraph.YMax = (float) value_mam.Max;
                        LineGraph.GridLineStepX = System.Math.Floor((LineGraph.XMax - LineGraph.XMin) / 5);
                        LineGraph.GridLineStepY = System.Math.Floor((LineGraph.YMax - LineGraph.YMin) / 5);
                        LineGraph.Clear(e);
                        LineGraph.Grid(e);
                        LineGraph.GraphWidth = 2;
                        if (this.checkBoxPlayer4.Checked && this.comboBoxPlayer4.SelectedIndex >= 0)
                        {
                            LineGraph.GraphColor = this.checkBoxPlayer4.ForeColor;
                            LineGraph.Graph(e, ((Player) this.comboBoxPlayer4.SelectedItem).ValueHistory);
                        }
                        if (this.checkBoxPlayer3.Checked && this.comboBoxPlayer3.SelectedIndex >= 0)
                        {
                            LineGraph.GraphColor = this.checkBoxPlayer3.ForeColor;
                            LineGraph.Graph(e, ((Player) this.comboBoxPlayer3.SelectedItem).ValueHistory);
                        }
                        if (this.checkBoxPlayer2.Checked && this.comboBoxPlayer2.SelectedIndex >= 0)
                        {
                            LineGraph.GraphColor = this.checkBoxPlayer2.ForeColor;
                            LineGraph.Graph(e, ((Player) this.comboBoxPlayer2.SelectedItem).ValueHistory);
                        }
                        if (this.checkBoxPlayer1.Checked && this.textBoxPlayer1.Tag != null)
                        {
                            LineGraph.GraphColor = this.checkBoxPlayer1.ForeColor;
                            LineGraph.Graph(e, ((Player) this.textBoxPlayer1.Tag).ValueHistory);
                        }
                        break;
                    case GraphType.Bar:
                        BarGraph.YMin = (float) value_mam.Min;
                        BarGraph.YMax = (float) value_mam.Max;
                        BarGraph.GridLineStepY = System.Math.Floor((BarGraph.YMax - BarGraph.YMin) / 5);
                        BarGraph.Clear(e);
                        BarGraph.Grid(e);
                        if (this.checkBoxPlayer1.Checked && this.textBoxPlayer1.Tag != null)
                        {
                            BarGraph.BarBrush = System.Drawing.Brushes.Blue;
                            BarGraph.Bar(e, 0, ((Player) this.textBoxPlayer1.Tag).Value);
                        }
                        if (this.checkBoxPlayer2.Checked && this.comboBoxPlayer2.SelectedIndex >= 0)
                        {
                            BarGraph.BarBrush = System.Drawing.Brushes.Red;
                            BarGraph.Bar(e, 1, ((Player) this.comboBoxPlayer2.SelectedItem).Value);
                        }
                        if (this.checkBoxPlayer3.Checked && this.comboBoxPlayer3.SelectedIndex >= 0)
                        {
                            BarGraph.BarBrush = System.Drawing.Brushes.Green;
                            BarGraph.Bar(e, 2, ((Player) this.comboBoxPlayer3.SelectedItem).Value);
                        }
                        if (this.checkBoxPlayer4.Checked && this.comboBoxPlayer4.SelectedIndex >= 0)
                        {
                            BarGraph.BarBrush = System.Drawing.Brushes.Yellow;
                            BarGraph.Bar(e, 3, ((Player) this.comboBoxPlayer4.SelectedItem).Value);
                        }
                        break;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void checkBoxPlayer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                UpdatePlayerInformations();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, MainForm.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void comboBoxPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdatePlayerInformations();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, MainForm.ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
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
