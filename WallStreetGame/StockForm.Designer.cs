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
            this.panelTrade = new System.Windows.Forms.Panel();
            this.groupBoxStockInformations = new System.Windows.Forms.GroupBox();
            this.panelStockGraph = new System.Windows.Forms.Panel();
            this.panelStockTexts = new System.Windows.Forms.Panel();
            this.labelStockName = new System.Windows.Forms.Label();
            this.textBoxStockName = new System.Windows.Forms.TextBox();
            this.labelStockIndexes = new System.Windows.Forms.Label();
            this.comboBoxStockIndexes = new System.Windows.Forms.ComboBox();
            this.labelStockPrice = new System.Windows.Forms.Label();
            this.textBoxStockPrice = new System.Windows.Forms.TextBox();
            this.labelStockPriceDifference = new System.Windows.Forms.Label();
            this.textBoxStockPriceDifference = new System.Windows.Forms.TextBox();
            this.textBoxStockPriceDifferenceProcent = new System.Windows.Forms.TextBox();
            this.labelStockAvailable = new System.Windows.Forms.Label();
            this.textBoxStockAvailable = new System.Windows.Forms.TextBox();
            this.panelStockInformations.SuspendLayout();
            this.groupBoxStockInformations.SuspendLayout();
            this.panelStockTexts.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStockInformations
            // 
            this.panelStockInformations.Controls.Add(this.groupBoxStockInformations);
            this.panelStockInformations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStockInformations.Location = new System.Drawing.Point(0, 0);
            this.panelStockInformations.Name = "panelStockInformations";
            this.panelStockInformations.Size = new System.Drawing.Size(390, 329);
            this.panelStockInformations.TabIndex = 0;
            // 
            // panelTrade
            // 
            this.panelTrade.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTrade.Location = new System.Drawing.Point(0, 329);
            this.panelTrade.Name = "panelTrade";
            this.panelTrade.Size = new System.Drawing.Size(390, 135);
            this.panelTrade.TabIndex = 1;
            // 
            // groupBoxStockInformations
            // 
            this.groupBoxStockInformations.Controls.Add(this.panelStockGraph);
            this.groupBoxStockInformations.Controls.Add(this.panelStockTexts);
            this.groupBoxStockInformations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStockInformations.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStockInformations.Name = "groupBoxStockInformations";
            this.groupBoxStockInformations.Size = new System.Drawing.Size(390, 329);
            this.groupBoxStockInformations.TabIndex = 0;
            this.groupBoxStockInformations.TabStop = false;
            // 
            // panelStockGraph
            // 
            this.panelStockGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStockGraph.Location = new System.Drawing.Point(3, 16);
            this.panelStockGraph.Name = "panelStockGraph";
            this.panelStockGraph.Size = new System.Drawing.Size(384, 174);
            this.panelStockGraph.TabIndex = 0;
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
            this.panelStockTexts.Location = new System.Drawing.Point(3, 190);
            this.panelStockTexts.Name = "panelStockTexts";
            this.panelStockTexts.Size = new System.Drawing.Size(384, 136);
            this.panelStockTexts.TabIndex = 1;
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
            // textBoxStockName
            // 
            this.textBoxStockName.Location = new System.Drawing.Point(68, 6);
            this.textBoxStockName.Name = "textBoxStockName";
            this.textBoxStockName.Size = new System.Drawing.Size(307, 20);
            this.textBoxStockName.TabIndex = 1;
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
            // comboBoxStockIndexes
            // 
            this.comboBoxStockIndexes.FormattingEnabled = true;
            this.comboBoxStockIndexes.Location = new System.Drawing.Point(68, 32);
            this.comboBoxStockIndexes.Name = "comboBoxStockIndexes";
            this.comboBoxStockIndexes.Size = new System.Drawing.Size(307, 21);
            this.comboBoxStockIndexes.TabIndex = 3;
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
            // textBoxStockPrice
            // 
            this.textBoxStockPrice.Location = new System.Drawing.Point(68, 59);
            this.textBoxStockPrice.Name = "textBoxStockPrice";
            this.textBoxStockPrice.Size = new System.Drawing.Size(150, 20);
            this.textBoxStockPrice.TabIndex = 5;
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
            // textBoxStockPriceDifference
            // 
            this.textBoxStockPriceDifference.Location = new System.Drawing.Point(68, 85);
            this.textBoxStockPriceDifference.Name = "textBoxStockPriceDifference";
            this.textBoxStockPriceDifference.Size = new System.Drawing.Size(150, 20);
            this.textBoxStockPriceDifference.TabIndex = 7;
            // 
            // textBoxStockPriceDifferenceProcent
            // 
            this.textBoxStockPriceDifferenceProcent.Location = new System.Drawing.Point(224, 85);
            this.textBoxStockPriceDifferenceProcent.Name = "textBoxStockPriceDifferenceProcent";
            this.textBoxStockPriceDifferenceProcent.Size = new System.Drawing.Size(60, 20);
            this.textBoxStockPriceDifferenceProcent.TabIndex = 8;
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
            // textBoxStockAvailable
            // 
            this.textBoxStockAvailable.Location = new System.Drawing.Point(68, 111);
            this.textBoxStockAvailable.Name = "textBoxStockAvailable";
            this.textBoxStockAvailable.Size = new System.Drawing.Size(150, 20);
            this.textBoxStockAvailable.TabIndex = 10;
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 464);
            this.Controls.Add(this.panelStockInformations);
            this.Controls.Add(this.panelTrade);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockForm";
            this.Text = "Aktie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockForm_FormClosing);
            this.panelStockInformations.ResumeLayout(false);
            this.groupBoxStockInformations.ResumeLayout(false);
            this.panelStockTexts.ResumeLayout(false);
            this.panelStockTexts.PerformLayout();
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
    }
}