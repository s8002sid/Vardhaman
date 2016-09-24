using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vardhman.db;

namespace Vardhman
{
    public partial class ITEM_TYPE_MERGE : Form
    {
        public db.MainInternal internalData = null;
        public ITEM_TYPE_MERGE()
        {
            InitializeComponent();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            string x = comboBox1.Text;
            comboBox1.DataSource = internalData.itemType.get(new e_columns[] { e_columns.e_typename }, e_db_operation.e_getUnique);
            comboBox1.DisplayMember = internalData.itemType.column_to_str(e_columns.e_typename);
            comboBox1.Text = x;
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            string x = comboBox2.Text;
            comboBox2.DataSource = internalData.itemType.get(new e_columns[] { e_columns.e_typename }, e_db_operation.e_getUnique);
            comboBox2.DisplayMember = internalData.itemType.column_to_str(e_columns.e_typename);
            comboBox2.Text = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            internalData.itemType.merge(new e_columns[] { e_columns.e_typename,
                                                            e_columns.e_to_typename},
                                            new string[] {  comboBox1.Text,
                                                            comboBox2.Text}); 
            MessageBox.Show("Done");
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Focus();
            comboBox1.Select();
        }

        private void ITEM_TYPE_MERGE_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Location =new Point( this.Width / 2 - groupBox1.Width / 2, this.Height / 2 - groupBox1.Height / 2);
        }

        private void ITEM_TYPE_MERGE_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main m = (Main)(this.MdiParent);
            m.init_container(childContainer.e_ItemTypeMerge);
        }

        private void ITEM_TYPE_MERGE_Load(object sender, EventArgs e)
        {
            if (internalData == null)
                this.internalData = ((Main)this.MdiParent).getInternalData();
        }
    }
}
