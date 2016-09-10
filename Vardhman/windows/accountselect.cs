using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class accountselect : Form
    {
        Connection con = new Connection();
        public string name, city;
        public accountselect()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("please fill both fields");
                return;
            }
            name = comboBox1.Text;
            city = comboBox2.Text;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con.connent();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            string x = comboBox1.Text;
            comboBox1.DataSource = con.getTable("select distinct(name) as name from customer");
            comboBox1.DisplayMember = "name";
            comboBox1.Text = x;
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            string x = comboBox2.Text;
            comboBox2.DataSource = con.getTable("select distinct(city) as city from customer");
            comboBox2.DisplayMember = "city";
            comboBox2.Text = x;
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            string str = "";
            if (comboBox1.Text == "")
                return;
            str = con.exesclr(string.Format("select isnull(min(name) , '0') from customer where name  = '{0}'", comboBox1.Text));
            if (str == "0")
            {
                MessageBox.Show("Select name dosenot exists in created accounts", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                comboBox1.Select();
            }
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            string str = "";

            if (comboBox1.Text == "")
            {
                if (comboBox2.Text == "")
                    return;
                str = con.exesclr(string.Format("select isnull(min(city) , '0') from customer where city  = '{0}'", comboBox2.Text));
                if (str == "0")
                {
                    MessageBox.Show("Select city dosenot exists in created accounts", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox2.Focus();
                    comboBox2.Select();
                }
            }
            else
            {
                str = con.exesclr(string.Format("select isnull(min(city) , '0') from customer where city  = '{0}' and name = '{1}'", comboBox2.Text , comboBox1.Text));
                if (str == "0")
                {
                    MessageBox.Show("Select Account dosenot exists in created accounts", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox2.Focus();
                    comboBox2.Select();
                }
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }
    }
}