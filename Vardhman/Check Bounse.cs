using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class Check_Bounse : Form
    {
        Connection con = new Connection();
        int company;
        public Check_Bounse()
        {
            InitializeComponent();
        }

        private void Check_Bounse_Load(object sender, EventArgs e)
        {
            con.connent();
            company = 0;
            clear();
        }
        private void clear()
        {
            textBox3.Text = con.exesclr("select isnull(max(recepitno) , 0) + 1 from check_bounse_entry");
            comboBox1.DataSource = con.getTable("select distinct(name) as name from customer where type = 'CUSTOMER'");
            comboBox1.DisplayMember = "name";
            comboBox1.Text = "";
            comboBox2.DataSource = con.getTable("select distinct(city) as city from customer where type = 'CUSTOMER'");
            comboBox2.DisplayMember = "city";
            comboBox2.Text = "";
            comboBox3.DataSource = con.getTable("select distinct(name) as name from customer where type = 'BANK'");
            comboBox3.DisplayMember = "name";
            comboBox3.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
            textBox1.Text = "";
            comboBox1.Focus(); comboBox1.Select();
        }
        private void save()
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox2.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please fill all empty fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                comboBox1.Select();
                return;
            }
            string x = con.exesclr(string.Format("exec add_checkbounceentyr '{0}' , '{1}' , '{2}' , {3} , '{4}' , '{5}' , {6} , {7}", comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox2.Text, textBox6.Text, dateTimePicker1.Text.ToString().Split(Convert.ToChar(Convert.ToChar(" ")))[0] , textBox1.Text , textBox3.Text));
            if (x == "0")
            {
                MessageBox.Show("Invalid customer detail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                comboBox1.Select();
                company = 0;
            }
            else if (x == "1")
            {
                MessageBox.Show("Invalid Bank detail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox3.Focus();
                comboBox3.Select();
            }
            else
            {
                MessageBox.Show("Item Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 8 && e.KeyChar <= 12)))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = roundOff.withpoint(textBox2.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = roundOff.withpoint(textBox1.Text);
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            comboBox2.DataSource = con.getTable(string.Format("select distinct(city) as city from customer where type = 'CUSTOMER' and name = '{0}'", comboBox1.Text));
            comboBox2.DisplayMember = "city";
        }
    }
}