using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class ITEM_TYPE_MERGE : Form
    {
        public ITEM_TYPE_MERGE()
        {
            InitializeComponent();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            string x = comboBox1.Text;
            Connection con = new Connection();
            con.connent();
            DataTable dt = con.getTable("select distinct(typename) as typename from itemtype");
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "typename";
            con.disconnect();
            comboBox1.Text = x;
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            string x = comboBox2.Text;
            Connection con = new Connection();
            con.connent();
            DataTable dt = con.getTable("select distinct(typename) as typename from itemtype");
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "typename";
            con.disconnect();
            comboBox2.Text = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.connent();
            con.exeNonQurey(string.Format("exec PROC_ITEM_TYPE_MERGE '{0}','{1}'", comboBox1.Text, comboBox2.Text));
            con.disconnect();
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
    }
}
