namespace OSDevGrp.WallStreetGame
{
    partial class StatisticsForm
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
            if (disposing && (BarGraph != null))
            {
                BarGraph.Dispose();
                BarGraph = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            this.panelPlayersInformations = new System.Windows.Forms.Panel();
            this.groupBoxPlayersInformations = new System.Windows.Forms.GroupBox();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.panelGraphPlayers = new System.Windows.Forms.Panel();
            this.comboBoxPlayer4 = new System.Windows.Forms.ComboBox();
            this.checkBoxPlayer4 = new System.Windows.Forms.CheckBox();
            this.comboBoxPlayer3 = new System.Windows.Forms.ComboBox();
            this.checkBoxPlayer3 = new System.Windows.Forms.CheckBox();
            this.comboBoxPlayer2 = new System.Windows.Forms.ComboBox();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.checkBoxPlayer1 = new System.Windows.Forms.CheckBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelPlayersInformations.SuspendLayout();
            this.groupBoxPlayersInformations.SuspendLayout();
            this.panelGraphPlayers.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPlayersInformations
            // 
            this.panelPlayersInformations.Controls.Add(this.groupBoxPlayersInformations);
            this.panelPlayersInformations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayersInformations.Location = new System.Drawing.Point(0, 0);
            this.panelPlayersInformations.Name = "panelPlayersInformations";
            this.panelPlayersInformations.Size = new System.Drawing.Size(390, 506);
            this.panelPlayersInformations.TabIndex = 0;
            // 
            // groupBoxPlayersInformations
            // 
            this.groupBoxPlayersInformations.Controls.Add(this.panelGraph);
            this.groupBoxPlayersInformations.Controls.Add(this.panelGraphPlayers);
            this.groupBoxPlayersInformations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPlayersInformations.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPlayersInformations.Name = "groupBoxPlayersInformations";
            this.groupBoxPlayersInformations.Size = new System.Drawing.Size(390, 506);
            this.groupBoxPlayersInformations.TabIndex = 0;
            this.groupBoxPlayersInformations.TabStop = false;
            // 
            // panelGraph
            // 
            this.panelGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraph.Location = new System.Drawing.Point(3, 16);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(384, 371);
            this.panelGraph.TabIndex = 0;
            this.panelGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGraph_Paint);
            // 
            // panelGraphPlayers
            // 
            this.panelGraphPlayers.Controls.Add(this.comboBoxPlayer4);
            this.panelGraphPlayers.Controls.Add(this.checkBoxPlayer4);
            this.panelGraphPlayers.Controls.Add(this.comboBoxPlayer3);
            this.panelGraphPlayers.Controls.Add(this.checkBoxPlayer3);
            this.panelGraphPlayers.Controls.Add(this.comboBoxPlayer2);
            this.panelGraphPlayers.Controls.Add(this.checkBoxPlayer2);
            this.panelGraphPlayers.Controls.Add(this.textBoxPlayer1);
            this.panelGraphPlayers.Controls.Add(this.checkBoxPlayer1);
            this.panelGraphPlayers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelGraphPlayers.Location = new System.Drawing.Point(3, 387);
            this.panelGraphPlayers.Name = "panelGraphPlayers";
            this.panelGraphPlayers.Size = new System.Drawing.Size(384, 116);
            this.panelGraphPlayers.TabIndex = 1;
            // 
            // comboBoxPlayer4
            // 
            this.comboBoxPlayer4.FormattingEnabled = true;
            this.comboBoxPlayer4.Location = new System.Drawing.Point(64, 86);
            this.comboBoxPlayer4.Name = "comboBoxPlayer4";
            this.comboBoxPlayer4.Size = new System.Drawing.Size(311, 21);
            this.comboBoxPlayer4.TabIndex = 7;
            this.comboBoxPlayer4.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayer_SelectedIndexChanged);
            // 
            // checkBoxPlayer4
            // 
            this.checkBoxPlayer4.AutoSize = true;
            this.checkBoxPlayer4.Location = new System.Drawing.Point(9, 88);
            this.checkBoxPlayer4.Name = "checkBoxPlayer4";
            this.checkBoxPlayer4.Size = new System.Drawing.Size(42, 17);
            this.checkBoxPlayer4.TabIndex = 6;
            this.checkBoxPlayer4.Text = "G&ul";
            this.checkBoxPlayer4.UseVisualStyleBackColor = true;
            this.checkBoxPlayer4.CheckedChanged += new System.EventHandler(this.checkBoxPlayer_CheckedChanged);
            // 
            // comboBoxPlayer3
            // 
            this.comboBoxPlayer3.FormattingEnabled = true;
            this.comboBoxPlayer3.Location = new System.Drawing.Point(64, 59);
            this.comboBoxPlayer3.Name = "comboBoxPlayer3";
            this.comboBoxPlayer3.Size = new System.Drawing.Size(311, 21);
            this.comboBoxPlayer3.TabIndex = 5;
            this.comboBoxPlayer3.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayer_SelectedIndexChanged);
            // 
            // checkBoxPlayer3
            // 
            this.checkBoxPlayer3.AutoSize = true;
            this.checkBoxPlayer3.Location = new System.Drawing.Point(9, 61);
            this.checkBoxPlayer3.Name = "checkBoxPlayer3";
            this.checkBoxPlayer3.Size = new System.Drawing.Size(49, 17);
            this.checkBoxPlayer3.TabIndex = 4;
            this.checkBoxPlayer3.Text = "&Grøn";
            this.checkBoxPlayer3.UseVisualStyleBackColor = true;
            this.checkBoxPlayer3.CheckedChanged += new System.EventHandler(this.checkBoxPlayer_CheckedChanged);
            // 
            // comboBoxPlayer2
            // 
            this.comboBoxPlayer2.FormattingEnabled = true;
            this.comboBoxPlayer2.Location = new System.Drawing.Point(64, 32);
            this.comboBoxPlayer2.Name = "comboBoxPlayer2";
            this.comboBoxPlayer2.Size = new System.Drawing.Size(311, 21);
            this.comboBoxPlayer2.TabIndex = 3;
            this.comboBoxPlayer2.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayer_SelectedIndexChanged);
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(9, 36);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(46, 17);
            this.checkBoxPlayer2.TabIndex = 2;
            this.checkBoxPlayer2.Text = "&Rød";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer_CheckedChanged);
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(64, 6);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(311, 20);
            this.textBoxPlayer1.TabIndex = 1;
            // 
            // checkBoxPlayer1
            // 
            this.checkBoxPlayer1.AutoSize = true;
            this.checkBoxPlayer1.Location = new System.Drawing.Point(9, 6);
            this.checkBoxPlayer1.Name = "checkBoxPlayer1";
            this.checkBoxPlayer1.Size = new System.Drawing.Size(41, 17);
            this.checkBoxPlayer1.TabIndex = 0;
            this.checkBoxPlayer1.Text = "&Blå";
            this.checkBoxPlayer1.UseVisualStyleBackColor = true;
            this.checkBoxPlayer1.CheckedChanged += new System.EventHandler(this.checkBoxPlayer_CheckedChanged);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 506);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(390, 38);
            this.panelButtons.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(303, 6);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "&Luk";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // StatisticsForm
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(390, 544);
            this.Controls.Add(this.panelPlayersInformations);
            this.Controls.Add(this.panelButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StatisticsForm";
            this.Text = "Statistik";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatisticsForm_FormClosing);
            this.panelPlayersInformations.ResumeLayout(false);
            this.groupBoxPlayersInformations.ResumeLayout(false);
            this.panelGraphPlayers.ResumeLayout(false);
            this.panelGraphPlayers.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPlayersInformations;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.GroupBox groupBoxPlayersInformations;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Panel panelGraphPlayers;
        private System.Windows.Forms.CheckBox checkBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.ComboBox comboBoxPlayer2;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.ComboBox comboBoxPlayer4;
        private System.Windows.Forms.CheckBox checkBoxPlayer4;
        private System.Windows.Forms.ComboBox comboBoxPlayer3;
        private System.Windows.Forms.CheckBox checkBoxPlayer3;
        private System.Windows.Forms.Button buttonClose;
    }
}