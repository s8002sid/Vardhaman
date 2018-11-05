using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class PendingReceivavles : Form
    {
        Connection con = new Connection();
        public PendingReceivavles()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Int32 result;
            bool retVal = Int32.TryParse(textBox1.Text.ToString(), out result);

            if ( !retVal)
            {
                MessageBox.Show("Please enter an integer", "Incorrect value", MessageBoxButtons.OK);
                textBox1.SelectAll();
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillEntry();
        }

        private void PendingReceivavles_Load(object sender, EventArgs e)
        {
            con.connent();
            FillEntry();
        }
        private void FillEntry()
        {
            String query = String.Format("select name, sum(payment)-sum(recepit) as balance from ledger_showall " +
                            "where (transtype = 'Bill' and date < Getdate()-{0}) or (transtype = 'Recepit') " +
                            "group by name having sum(payment)-sum(recepit) > 0 order by balance desc", textBox1.Text);
            DataTable dt = con.getTable(query);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.exeNonQurey("delete from groupbalance");
            string name, balance;
            string place = "Pending Reciveables";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                balance = dataGridView1.Rows[i].Cells[1].Value.ToString();
                if (balance == "")
                    balance = "NULL";
                con.exeNonQurey(string.Format("insert into groupbalance values('{0}',{1},'{2}')", name, balance, place));
            }
            Report_Viewercs rv = new Report_Viewercs();
            rv.loadrpt("groupbalance");
            rv.ShowDialog();
        }
    }
}