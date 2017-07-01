using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class ItemTypeEdit : Form
    {
        public ItemTypeEdit()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        private void ItemTypeEdit_Load(object sender, EventArgs e)
        {
            con.connent();
            dataGridView1.DataSource = con.getTable("select id as ID, typename as ItemName, hsnCode as HSNCode from itemtype");
            if (dataGridView1.Columns.Count == 3)
            {
                dataGridView1.Columns["ID"].ReadOnly = true;
                dataGridView1.Columns["ItemName"].ReadOnly = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                con.exeNonQurey(String.Format("update itemtype set hsnCode = '{0}' where id = {1}", 
                    row.Cells["HSNCode"].Value.ToString(), row.Cells["ID"].Value.ToString()));
            }
            MessageBox.Show("All Data Saved Successfully", "Data Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ItemTypeEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main m = (Main)(this.MdiParent);
            m.init_container(childContainer.e_ItemTypeEdit);
        }
    }
}