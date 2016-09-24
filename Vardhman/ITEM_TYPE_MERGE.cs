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
            string x = cmb_fromType.Text;
            cmb_fromType.DataSource = internalData.itemType.get(new e_columns[] { e_columns.e_typename }, e_db_operation.e_getUnique);
            cmb_fromType.DisplayMember = internalData.itemType.column_to_str(e_columns.e_typename);
            cmb_fromType.Text = x;
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            string x = cmb_toType.Text;
            cmb_toType.DataSource = internalData.itemType.get(new e_columns[] { e_columns.e_typename }, e_db_operation.e_getUnique);
            cmb_toType.DisplayMember = internalData.itemType.column_to_str(e_columns.e_typename);
            cmb_toType.Text = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            internalData.itemType.merge(new e_columns[] { e_columns.e_typename,
                                                            e_columns.e_to_typename},
                                            new string[] {  cmb_fromType.Text,
                                                            cmb_toType.Text}); 
            MessageBox.Show("Done");
            cmb_fromType.Text = "";
            cmb_toType.Text = "";
            cmb_fromType.Focus();
            cmb_fromType.Select();
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
