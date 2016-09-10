using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class ListManualBills : Form
    {
        Connection con = new Connection();
        ManualBilling bde;
        string billno;
        public ListManualBills()
        {
            InitializeComponent();
        }

        private void form_billprint_Load(object sender, EventArgs e)
        {
            con.connent();
            dataGridView1.DataSource = con.getTable("select name , city , billno , id from view_manual_bill_master order by billno desc");
            dataGridView1.Columns[3].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(textBox1.Text);
                dataGridView1.DataSource = con.getTable(string.Format("select name , city , billno , id from view_manual_bill_master where billno like('{0}%') order by billno desc" , textBox1.Text));
                dataGridView1.Columns[3].Visible = false;
            }
            catch
            {
                string y = textBox1.Text;
                dataGridView1.DataSource = con.getTable(string.Format("select name , city , billno , id from view_manual_bill_master where name like('{0}%') order by billno desc", textBox1.Text));
                dataGridView1.Columns[3].Visible = false;
            }
        }
        public void getbde(ManualBilling b)
        {
            bde = b;
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            bde.getbill(Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value.ToString()));
            //returns id of bill
            this.Close();
        }
    }
}