using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class Transport : Form
    {
        Connection con = new Connection();
        public Transport()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.exeNonQurey("exec insert_transport '" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "'," + textBox2.Text + ",'" + textBox3.Text + "'") ;
        }

        private void Transport_Load(object sender, EventArgs e)
        {
            con.connent();
            DataSet ds = con.dsentry("select city , state from place" , "place");
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "city";
            comboBox1.SelectedIndex = -1;
            //ds = con.dsentry("select state from place", "place");
            comboBox2.DataSource = ds.Tables[0];
            comboBox2.DisplayMember = "state";
            comboBox2.SelectedIndex = -1;
            textBox1.Focus();
            textBox1.Select();
        }

        private void Transport_FormClosed(object sender, FormClosedEventArgs e)
        {
            con.disconnect();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = roundOff.round(textBox2.Text);
        }
    }
}