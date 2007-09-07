using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OSDevGrp.WallStreetGame
{
    public partial class SelectForm : Form
    {
        private System.Collections.Generic.List<ISelectable> _SelectedItems = null;

        public SelectForm(string header, string columntext, ISelectables list) : this(header, columntext, list, null, null, 0)
        {
        }

        public SelectForm(string header, string columntext, ISelectables list, System.Windows.Forms.ImageList largeimages, System.Windows.Forms.ImageList smallimages, int imageindex) : base()
        {
            InitializeComponent();
            try
            {
                SelectedItems = new System.Collections.Generic.List<ISelectable>();
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Text = header;
                this.listViewList.AutoArrange = true;
                this.listViewList.FullRowSelect = true;
                this.listViewList.GridLines = false;
                this.listViewList.MultiSelect = false;
                if (largeimages != null)
                    this.listViewList.LargeImageList = largeimages;
                if (smallimages != null)
                    this.listViewList.SmallImageList = smallimages;
                this.listViewList.Columns.Add(new System.Windows.Forms.ColumnHeader());
                this.listViewList.Columns[this.listViewList.Columns.Count - 1].Text = columntext;
                this.listViewList.Columns[this.listViewList.Columns.Count - 1].Width = -1;
                foreach (ISelectable selectable in list.GetSelectables())
                {
                    System.Windows.Forms.ListViewItem lvi = new ListViewItem(selectable.GetSelectText(), imageindex);
                    lvi.Tag = selectable;
                    this.listViewList.Items.Add(lvi);
                }
                switch (this.listViewList.View)
                {
                    case System.Windows.Forms.View.Details:
                        this.listViewList.AutoResizeColumns(System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent);
                        break;
                    default:
                        this.listViewList.ArrangeIcons();
                        break;
                }
                if (this.listViewList.Items.Count > 0)
                {
                    this.listViewList.Items[0].Selected = true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.Windows.Forms.View ListView
        {
            get
            {
                return this.listViewList.View;
            }
            set
            {
                this.listViewList.View = value;
                switch (this.listViewList.View)
                {
                    case System.Windows.Forms.View.Details:
                        this.listViewList.AutoResizeColumns(System.Windows.Forms.ColumnHeaderAutoResizeStyle.ColumnContent);
                        break;
                    default:
                        this.listViewList.ArrangeIcons();
                        break;
                }
            }
        }

        public System.Collections.Generic.List<ISelectable> SelectedItems
        {
            get
            {
                return _SelectedItems;
            }
            private set
            {
                _SelectedItems = value;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listViewList.SelectedItems.Count > 0)
                {
                    foreach (System.Windows.Forms.ListViewItem lvi in this.listViewList.SelectedItems)
                    {
                        if (lvi.Tag is ISelectable)
                            SelectedItems.Add((ISelectable) lvi.Tag);
                    }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this, ex.Message, ProductName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}