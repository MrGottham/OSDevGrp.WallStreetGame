namespace OSDevGrp.WallStreetGame
{
    partial class StockForm
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
            if (disposing && (LineGraph != null))
            {
                LineGraph.Dispose();
                LineGraph = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockForm));
            this.panelStockInformations = new System.Windows.Forms.Panel();
            this.groupBoxStockInformations = new System.Windows.Forms.GroupBox();
            this.panelStockGraph = new System.Windows.Forms.Panel();
            this.panelStockTexts = new System.Windows.Forms.Panel();
            this.textBoxStockAvailable = new System.Windows.Forms.TextBox();
            this.labelStockAvailable = new System.Windows.Forms.Label();
            this.textBoxStockPriceDifferenceProcent = new System.Windows.Forms.TextBox();
            this.textBoxStockPriceDifference = new System.Windows.Forms.TextBox();
            this.labelStockPriceDifference = new System.Windows.Forms.Label();
            this.textBoxStockPrice = new System.Windows.Forms.TextBox();
            this.labelStockPrice = new System.Windows.Forms.Label();
            this.comboBoxStockIndexes = new System.Windows.Forms.ComboBox();
            this.labelStockIndexes = new System.Windows.Forms.Label();
            this.textBoxStockName = new System.Windows.Forms.TextBox();
            this.labelStockName = new System.Windows.Forms.Label();
            this.panelTrade = new System.Windows.Forms.Panel();
            this.panelTradeInformations = new System.Windows.Forms.Panel();
            this.groupBoxTradeInformations = new System.Windows.Forms.GroupBox();
            this.textBoxTradeCountValue = new System.Windows.Forms.TextBox();
            this.numericUpDownTradeCount = new System.Windows.Forms.NumericUpDown();
            this.labelTradeCount = new System.Windows.Forms.Label();
            this.radioButtonTradeSell = new System.Windows.Forms.RadioButton();
            this.radioButtonTradeBuy = new System.Windows.Forms.RadioButton();
            this.textBoxPlayerDepositContent = new System.Windows.Forms.TextBox();
            this.labelPlayerDepositContent = new System.Windows.Forms.Label();
            this.textBoxPlayerCapital = new System.Windows.Forms.TextBox();
            this.labelPlayerCapital = new System.Windows.Forms.Label();
            this.panelTradeButtons = new System.Windows.Forms.Panel();
            this.labelTradeBrokerage = new System.Windows.Forms.Label();
            this.textBoxTradeBrokerage = new System.Windows.Forms.TextBox();
            this.textBoxTradeBrokeragePrice = new System.Windows.Forms.TextBox();
            this.labelTradeTotal = new System.Windows.Forms.Label();
            this.textBoxTradeTotal = new System.Windows.Forms.TextBox();
            this.buttonTradeOK = new System.Windows.Forms.Button();
            this.buttonTradeCancel = new System.Windows.Forms.Button();
            this.panelStockInformations.SuspendLayout();
            this.groupBoxStockInformations.SuspendLayout();
            this.panelStockTexts.SuspendLayout();
            this.panelTrade.SuspendLayout();
            this.panelTradeInformations.SuspendLayout();
            this.groupBoxTradeInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTradeCount)).BeginInit();
            this.panelTradeButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStockInformations
            // 
            this.panelStockInformations.Controls.Add(this.groupBoxStockInformations);
            this.panelStockInformations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStockInformations.Location = new System.Drawing.Point(0, 0);
            this.panelStockInformations.Name = "panelStockInformations";
            this.panelStockInformations.Size = new System.Drawing.Size(390, 339);
            this.panelStockInformations.TabIndex = 0;
            // 
            // groupBoxStockInformations
            // 
            this.groupBoxStockInformations.Controls.Add(this.panelStockGraph);
            this.groupBoxStockInformations.Controls.Add(this.panelStockTexts);
            this.groupBoxStockInformations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStockInformations.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStockInformations.Name = "groupBoxStockInformations";
            this.groupBoxStockInformations.Size = new System.Drawing.Size(390, 339);
            this.groupBoxStockInformations.TabIndex = 0;
            this.groupBoxStockInformations.TabStop = false;
            // 
            // panelStockGraph
            // 
            this.panelStockGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStockGraph.Location = new System.Drawing.Point(3, 16);
            this.panelStockGraph.Name = "panelStockGraph";
            this.panelStockGraph.Size = new System.Drawing.Size(384, 184);
            this.panelStockGraph.TabIndex = 0;
            this.panelStockGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.panelStockGraph_Paint);
            // 
            // panelStockTexts
            // 
            this.panelStockTexts.Controls.Add(this.textBoxStockAvailable);
            this.panelStockTexts.Controls.Add(this.labelStockAvailable);
            this.panelStockTexts.Controls.Add(this.textBoxStockPriceDifferenceProcent);
            this.panelStockTexts.Controls.Add(this.textBoxStockPriceDifference);
            this.panelStockTexts.Controls.Add(this.labelStockPriceDifference);
            this.panelStockTexts.Controls.Add(this.textBoxStockPrice);
            this.panelStockTexts.Controls.Add(this.labelStockPrice);
            this.panelStockTexts.Controls.Add(this.comboBoxStockIndexes);
            this.panelStockTexts.Controls.Add(this.labelStockIndexes);
            this.panelStockTexts.Controls.Add(this.textBoxStockName);
            this.panelStockTexts.Controls.Add(this.labelStockName);
            this.panelStockTexts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStockTexts.Location = new System.Drawing.Point(3, 200);
            this.panelStockTexts.Name = "panelStockTexts";
            this.panelStockTexts.Size = new System.Drawing.Size(384, 136);
            this.panelStockTexts.TabIndex = 1;
            // 
            // textBoxStockAvailable
            // 
            this.textBoxStockAvailable.Location = new System.Drawing.Point(84, 111);
            this.textBoxStockAvailable.Name = "textBoxStockAvailable";
            this.textBoxStockAvailable.Size = new System.Drawing.Size(150, 20);
            this.textBoxStockAvailable.TabIndex = 10;
            // 
            // labelStockAvailable
            // 
            this.labelStockAvailable.AutoSize = true;
            this.labelStockAvailable.Location = new System.Drawing.Point(9, 114);
            this.labelStockAvailable.Name = "labelStockAvailable";
            this.labelStockAvailable.Size = new System.Drawing.Size(53, 13);
            this.labelStockAvailable.TabIndex = 9;
            this.labelStockAvailable.Text = "Frie aktier";
            // 
            // textBoxStockPriceDifferenceProcent
            // 
            this.textBoxStockPriceDifferenceProcent.Location = new System.Drawing.Point(240, 85);
            this.textBoxStockPriceDifferenceProcent.Name = "textBoxStockPriceDifferenceProcent";
            this.textBoxStockPriceDifferenceProcent.Size = new System.Drawing.Size(60, 20);
            this.textBoxStockPriceDifferenceProcent.TabIndex = 8;
            // 
            // textBoxStockPriceDifference
            // 
            this.textBoxStockPriceDifference.Location = new System.Drawing.Point(84, 85);
            this.textBoxStockPriceDifference.Name = "textBoxStockPriceDifference";
            this.textBoxStockPriceDifference.Size = new System.Drawing.Size(150, 20);
            this.textBoxStockPriceDifference.TabIndex = 7;
            // 
            // labelStockPriceDifference
            // 
            this.labelStockPriceDifference.AutoSize = true;
            this.labelStockPriceDifference.Location = new System.Drawing.Point(9, 88);
            this.labelStockPriceDifference.Name = "labelStockPriceDifference";
            this.labelStockPriceDifference.Size = new System.Drawing.Size(21, 13);
            this.labelStockPriceDifference.TabIndex = 6;
            this.labelStockPriceDifference.Text = "+/-";
            // 
            // textBoxStockPrice
            // 
            this.textBoxStockPrice.Location = new System.Drawing.Point(84, 59);
            this.textBoxStockPrice.Name = "textBoxStockPrice";
            this.textBoxStockPrice.Size = new System.Drawing.Size(150, 20);
            this.textBoxStockPrice.TabIndex = 5;
            // 
            // labelStockPrice
            // 
            this.labelStockPrice.AutoSize = true;
            this.labelStockPrice.Location = new System.Drawing.Point(9, 62);
            this.labelStockPrice.Name = "labelStockPrice";
            this.labelStockPrice.Size = new System.Drawing.Size(28, 13);
            this.labelStockPrice.TabIndex = 4;
            this.labelStockPrice.Text = "Kurs";
            // 
            // comboBoxStockIndexes
            // 
            this.comboBoxStockIndexes.FormattingEnabled = true;
            this.comboBoxStockIndexes.Location = new System.Drawing.Point(84, 32);
            this.comboBoxStockIndexes.Name = "comboBoxStockIndexes";
            this.comboBoxStockIndexes.Size = new System.Drawing.Size(291, 21);
            this.comboBoxStockIndexes.TabIndex = 3;
            // 
            // labelStockIndexes
            // 
            this.labelStockIndexes.AutoSize = true;
            this.labelStockIndexes.Location = new System.Drawing.Point(9, 35);
            this.labelStockIndexes.Name = "labelStockIndexes";
            this.labelStockIndexes.Size = new System.Drawing.Size(33, 13);
            this.labelStockIndexes.TabIndex = 2;
            this.labelStockIndexes.Text = "Index";
            // 
            // textBoxStockName
            // 
            this.textBoxStockName.Location = new System.Drawing.Point(84, 6);
            this.textBoxStockName.Name = "textBoxStockName";
            this.textBoxStockName.Size = new System.Drawing.Size(291, 20);
            this.textBoxStockName.TabIndex = 1;
            // 
            // labelStockName
            // 
            this.labelStockName.AutoSize = true;
            this.labelStockName.Location = new System.Drawing.Point(9, 9);
            this.labelStockName.Name = "labelStockName";
            this.labelStockName.Size = new System.Drawing.Size(31, 13);
            this.labelStockName.TabIndex = 0;
            this.labelStockName.Text = "Aktie";
            // 
            // panelTrade
            // 
            this.panelTrade.Controls.Add(this.panelTradeInformations);
            this.panelTrade.Controls.Add(this.panelTradeButtons);
            this.panelTrade.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTrade.Location = new System.Drawing.Point(0, 339);
            this.panelTrade.Name = "panelTrade";
            this.panelTrade.Size = new System.Drawing.Size(390, 205);
            this.panelTrade.TabIndex = 1;
            // 
            // panelTradeInformations
            // 
            this.panelTradeInformations.Controls.Add(this.groupBoxTradeInformations);
            this.panelTradeInformations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTradeInformations.Location = new System.Drawing.Point(0, 0);
            this.panelTradeInformations.Name = "panelTradeInformations";
            this.panelTradeInformations.Size = new System.Drawing.Size(390, 168);
            this.panelTradeInformations.TabIndex = 0;
            // 
            // groupBoxTradeInformations
            // 
            this.groupBoxTradeInformations.Controls.Add(this.textBoxTradeTotal);
            this.groupBoxTradeInformations.Controls.Add(this.labelTradeTotal);
            this.groupBoxTradeInformations.Controls.Add(this.textBoxTradeBrokeragePrice);
            this.groupBoxTradeInformations.Controls.Add(this.textBoxTradeBrokerage);
            this.groupBoxTradeInformations.Controls.Add(this.labelTradeBrokerage);
            this.groupBoxTradeInformations.Controls.Add(this.textBoxTradeCountValue);
            this.groupBoxTradeInformations.Controls.Add(this.numericUpDownTradeCount);
            this.groupBoxTradeInformations.Controls.Add(this.labelTradeCount);
            this.groupBoxTradeInformations.Controls.Add(this.radioButtonTradeSell);
            this.groupBoxTradeInformations.Controls.Add(this.radioButtonTradeBuy);
            this.groupBoxTradeInformations.Controls.Add(this.textBoxPlayerDepositContent);
            this.groupBoxTradeInformations.Controls.Add(this.labelPlayerDepositContent);
            this.groupBoxTradeInformations.Controls.Add(this.textBoxPlayerCapital);
            this.groupBoxTradeInformations.Controls.Add(this.labelPlayerCapital);
            this.groupBoxTradeInformations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTradeInformations.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTradeInformations.Name = "groupBoxTradeInformations";
            this.groupBoxTradeInformations.Size = new System.Drawing.Size(390, 168);
            this.groupBoxTradeInformations.TabIndex = 0;
            this.groupBoxTradeInformations.TabStop = false;
            // 
            // textBoxTradeCountValue
            // 
            this.textBoxTradeCountValue.Location = new System.Drawing.Point(228, 90);
            this.textBoxTradeCountValue.Name = "textBoxTradeCountValue";
            this.textBoxTradeCountValue.Size = new System.Drawing.Size(150, 20);
            this.textBoxTradeCountValue.TabIndex = 8;
            // 
            // numericUpDownTradeCount
            // 
            this.numericUpDownTradeCount.Location = new System.Drawing.Point(134, 91);
            this.numericUpDownTradeCount.Name = "numericUpDownTradeCount";
            this.numericUpDownTradeCount.Size = new System.Drawing.Size(88, 20);
            this.numericUpDownTradeCount.TabIndex = 7;
            this.numericUpDownTradeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownTradeCount.ThousandsSeparator = true;
            this.numericUpDownTradeCount.ValueChanged += new System.EventHandler(this.numericUpDownTradeCount_ValueChanged);
            // 
            // labelTradeCount
            // 
            this.labelTradeCount.AutoSize = true;
            this.labelTradeCount.Location = new System.Drawing.Point(84, 93);
            this.labelTradeCount.Name = "labelTradeCount";
            this.labelTradeCount.Size = new System.Drawing.Size(31, 13);
            this.labelTradeCount.TabIndex = 6;
            this.labelTradeCount.Text = "Antal";
            // 
            // radioButtonTradeSell
            // 
            this.radioButtonTradeSell.AutoSize = true;
            this.radioButtonTradeSell.Location = new System.Drawing.Point(172, 66);
            this.radioButtonTradeSell.Name = "radioButtonTradeSell";
            this.radioButtonTradeSell.Size = new System.Drawing.Size(85, 17);
            this.radioButtonTradeSell.TabIndex = 5;
            this.radioButtonTradeSell.TabStop = true;
            this.radioButtonTradeSell.Text = "&Sælge aktier";
            this.radioButtonTradeSell.UseVisualStyleBackColor = true;
            this.radioButtonTradeSell.CheckedChanged += new System.EventHandler(this.radioButtonTradeSell_CheckedChanged);
            // 
            // radioButtonTradeBuy
            // 
            this.radioButtonTradeBuy.AutoSize = true;
            this.radioButtonTradeBuy.Location = new System.Drawing.Point(87, 66);
            this.radioButtonTradeBuy.Name = "radioButtonTradeBuy";
            this.radioButtonTradeBuy.Size = new System.Drawing.Size(79, 17);
            this.radioButtonTradeBuy.TabIndex = 4;
            this.radioButtonTradeBuy.TabStop = true;
            this.radioButtonTradeBuy.Text = "&Købe aktier";
            this.radioButtonTradeBuy.UseVisualStyleBackColor = true;
            this.radioButtonTradeBuy.CheckedChanged += new System.EventHandler(this.radioButtonTradeBuy_CheckedChanged);
            // 
            // textBoxPlayerDepositContent
            // 
            this.textBoxPlayerDepositContent.Location = new System.Drawing.Point(87, 40);
            this.textBoxPlayerDepositContent.Name = "textBoxPlayerDepositContent";
            this.textBoxPlayerDepositContent.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayerDepositContent.TabIndex = 3;
            // 
            // labelPlayerDepositContent
            // 
            this.labelPlayerDepositContent.AutoSize = true;
            this.labelPlayerDepositContent.Location = new System.Drawing.Point(12, 43);
            this.labelPlayerDepositContent.Name = "labelPlayerDepositContent";
            this.labelPlayerDepositContent.Size = new System.Drawing.Size(69, 13);
            this.labelPlayerDepositContent.TabIndex = 2;
            this.labelPlayerDepositContent.Text = "Aktier i depot";
            // 
            // textBoxPlayerCapital
            // 
            this.textBoxPlayerCapital.Location = new System.Drawing.Point(87, 14);
            this.textBoxPlayerCapital.Name = "textBoxPlayerCapital";
            this.textBoxPlayerCapital.Size = new System.Drawing.Size(150, 20);
            this.textBoxPlayerCapital.TabIndex = 1;
            // 
            // labelPlayerCapital
            // 
            this.labelPlayerCapital.AutoSize = true;
            this.labelPlayerCapital.Location = new System.Drawing.Point(12, 17);
            this.labelPlayerCapital.Name = "labelPlayerCapital";
            this.labelPlayerCapital.Size = new System.Drawing.Size(39, 13);
            this.labelPlayerCapital.TabIndex = 0;
            this.labelPlayerCapital.Text = "Kapital";
            // 
            // panelTradeButtons
            // 
            this.panelTradeButtons.Controls.Add(this.buttonTradeCancel);
            this.panelTradeButtons.Controls.Add(this.buttonTradeOK);
            this.panelTradeButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTradeButtons.Location = new System.Drawing.Point(0, 168);
            this.panelTradeButtons.Name = "panelTradeButtons";
            this.panelTradeButtons.Size = new System.Drawing.Size(390, 37);
            this.panelTradeButtons.TabIndex = 1;
            // 
            // labelTradeBrokerage
            // 
            this.labelTradeBrokerage.AutoSize = true;
            this.labelTradeBrokerage.Location = new System.Drawing.Point(84, 119);
            this.labelTradeBrokerage.Name = "labelTradeBrokerage";
            this.labelTradeBrokerage.Size = new System.Drawing.Size(44, 13);
            this.labelTradeBrokerage.TabIndex = 9;
            this.labelTradeBrokerage.Text = "Kurtage";
            // 
            // textBoxTradeBrokerage
            // 
            this.textBoxTradeBrokerage.Location = new System.Drawing.Point(134, 116);
            this.textBoxTradeBrokerage.Name = "textBoxTradeBrokerage";
            this.textBoxTradeBrokerage.Size = new System.Drawing.Size(88, 20);
            this.textBoxTradeBrokerage.TabIndex = 10;
            // 
            // textBoxTradeBrokeragePrice
            // 
            this.textBoxTradeBrokeragePrice.Location = new System.Drawing.Point(228, 116);
            this.textBoxTradeBrokeragePrice.Name = "textBoxTradeBrokeragePrice";
            this.textBoxTradeBrokeragePrice.Size = new System.Drawing.Size(150, 20);
            this.textBoxTradeBrokeragePrice.TabIndex = 11;
            // 
            // labelTradeTotal
            // 
            this.labelTradeTotal.AutoSize = true;
            this.labelTradeTotal.Location = new System.Drawing.Point(84, 144);
            this.labelTradeTotal.Name = "labelTradeTotal";
            this.labelTradeTotal.Size = new System.Drawing.Size(31, 13);
            this.labelTradeTotal.TabIndex = 12;
            this.labelTradeTotal.Text = "Total";
            // 
            // textBoxTradeTotal
            // 
            this.textBoxTradeTotal.Location = new System.Drawing.Point(228, 141);
            this.textBoxTradeTotal.Name = "textBoxTradeTotal";
            this.textBoxTradeTotal.Size = new System.Drawing.Size(150, 20);
            this.textBoxTradeTotal.TabIndex = 13;
            // 
            // buttonTradeOK
            // 
            this.buttonTradeOK.Location = new System.Drawing.Point(222, 6);
            this.buttonTradeOK.Name = "buttonTradeOK";
            this.buttonTradeOK.Size = new System.Drawing.Size(75, 23);
            this.buttonTradeOK.TabIndex = 0;
            this.buttonTradeOK.Text = "&OK";
            this.buttonTradeOK.UseVisualStyleBackColor = true;
            this.buttonTradeOK.Click += new System.EventHandler(this.buttonTradeOK_Click);
            // 
            // buttonTradeCancel
            // 
            this.buttonTradeCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonTradeCancel.Location = new System.Drawing.Point(303, 6);
            this.buttonTradeCancel.Name = "buttonTradeCancel";
            this.buttonTradeCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonTradeCancel.TabIndex = 1;
            this.buttonTradeCancel.Text = "&Annullér";
            this.buttonTradeCancel.UseVisualStyleBackColor = true;
            this.buttonTradeCancel.Click += new System.EventHandler(this.buttonTradeCancel_Click);
            // 
            // StockForm
            // 
            this.AcceptButton = this.buttonTradeOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonTradeCancel;
            this.ClientSize = new System.Drawing.Size(390, 544);
            this.Controls.Add(this.panelStockInformations);
            this.Controls.Add(this.panelTrade);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StockForm";
            this.Text = "Aktie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockForm_FormClosing);
            this.panelStockInformations.ResumeLayout(false);
            this.groupBoxStockInformations.ResumeLayout(false);
            this.panelStockTexts.ResumeLayout(false);
            this.panelStockTexts.PerformLayout();
            this.panelTrade.ResumeLayout(false);
            this.panelTradeInformations.ResumeLayout(false);
            this.groupBoxTradeInformations.ResumeLayout(false);
            this.groupBoxTradeInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTradeCount)).EndInit();
            this.panelTradeButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStockInformations;
        private System.Windows.Forms.Panel panelTrade;
        private System.Windows.Forms.GroupBox groupBoxStockInformations;
        private System.Windows.Forms.Panel panelStockTexts;
        private System.Windows.Forms.Panel panelStockGraph;
        private System.Windows.Forms.TextBox textBoxStockName;
        private System.Windows.Forms.Label labelStockName;
        private System.Windows.Forms.ComboBox comboBoxStockIndexes;
        private System.Windows.Forms.Label labelStockIndexes;
        private System.Windows.Forms.TextBox textBoxStockPrice;
        private System.Windows.Forms.Label labelStockPrice;
        private System.Windows.Forms.TextBox textBoxStockPriceDifference;
        private System.Windows.Forms.Label labelStockPriceDifference;
        private System.Windows.Forms.TextBox textBoxStockPriceDifferenceProcent;
        private System.Windows.Forms.Label labelStockAvailable;
        private System.Windows.Forms.TextBox textBoxStockAvailable;
        private System.Windows.Forms.Panel panelTradeInformations;
        private System.Windows.Forms.GroupBox groupBoxTradeInformations;
        private System.Windows.Forms.TextBox textBoxPlayerDepositContent;
        private System.Windows.Forms.Label labelPlayerDepositContent;
        private System.Windows.Forms.TextBox textBoxPlayerCapital;
        private System.Windows.Forms.Label labelPlayerCapital;
        private System.Windows.Forms.Panel panelTradeButtons;
        private System.Windows.Forms.RadioButton radioButtonTradeSell;
        private System.Windows.Forms.RadioButton radioButtonTradeBuy;
        private System.Windows.Forms.TextBox textBoxTradeCountValue;
        private System.Windows.Forms.NumericUpDown numericUpDownTradeCount;
        private System.Windows.Forms.Label labelTradeCount;
        private System.Windows.Forms.TextBox textBoxTradeBrokerage;
        private System.Windows.Forms.Label labelTradeBrokerage;
        private System.Windows.Forms.TextBox textBoxTradeBrokeragePrice;
        private System.Windows.Forms.TextBox textBoxTradeTotal;
        private System.Windows.Forms.Label labelTradeTotal;
        private System.Windows.Forms.Button buttonTradeCancel;
        private System.Windows.Forms.Button buttonTradeOK;
    }
}