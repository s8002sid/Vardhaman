using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class list_bills : Form
    {
        Connection con = new Connection();
        Billing_dataentry bde;
        string billno;
        public db.MainInternal internalData = null;
        public list_bills(db.MainInternal t_internalData)
        {
            InitializeComponent();
            internalData = t_internalData;
        }

        private void form_billprint_Load(object sender, EventArgs e)
        {
            con.connent();
            dataGridView1.DataSource = con.getTable("select name , city , billno from view_bill_master order by billno desc");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(textBox1.Text);
                dataGridView1.DataSource = con.getTable(string.Format("select name , city , billno from view_bill_master where billno like('{0}%') order by billno desc" , textBox1.Text));
            }
            catch
            {
                string y = textBox1.Text;
                dataGridView1.DataSource = con.getTable(string.Format("select name , city , billno from view_bill_master where name like('{0}%') order by billno desc", textBox1.Text));
            }
        }
        public void getbde(Billing_dataentry b)
        {
            bde = b;
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            bde.getbill(Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value.ToString()));
            this.Close();
        }
    }
}