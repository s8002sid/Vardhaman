using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class create_group : Form
    {
        public create_group()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.connent();
            if (textBox1.Text == "")
                return;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                con.exeNonQurey(string.Format("insert into line(city,[group]) values('{0}','{1}')", dataGridView1.SelectedRows[i].Cells[0].Value.ToString(), textBox1.Text.Trim().ToUpper()));
            }
            DataTable dt = con.getTable("select distinct city from customer where city not in (select city from line) union select distinct(c) from ledger_showall where c not in(select city from line)");
            dataGridView1.DataSource = dt;
            dt = con.getTable("select distinct([group]) from line");
            dataGridView2.DataSource = dt;
            con.disconnect();
        }

        private void create_group_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.connent();
            DataTable dt = con.getTable("select distinct(city) from customer where city not in (select city from line) union select distinct(c) from ledger_showall where c not in(select city from line)");
            dataGridView1.DataSource = dt;

            dt = con.getTable("select distinct([group]) from line");
            dataGridView2.DataSource = dt;
            con.disconnect();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch
            {

            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's' || e.KeyChar == 'S')
            {
                Connection con = new Connection();
                con.connent();
                if (textBox1.Text == "")
                    return;
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    con.exeNonQurey(string.Format("insert into line(city,[group]) values('{0}','{1}')", dataGridView1.SelectedRows[i].Cells[0].Value.ToString(), textBox1.Text.Trim().ToUpper()));
                }
                DataTable dt = con.getTable("select distinct city from customer where city not in (select city from line) union select distinct(c) from ledger_showall where c not in(select city from line)");
                dataGridView1.DataSource = dt;
                dt = con.getTable("select distinct([group]) from line");
                dataGridView2.DataSource = dt;
                con.disconnect();
            }
        }
    }
}
