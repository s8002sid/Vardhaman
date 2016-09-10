using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Vardhman
{
    public partial class Customer_Entry : Form
    {
        Connection con = new Connection();
        public Customer_Entry()
        {
            InitializeComponent();
        }

        private void Company_Entry_Load(object sender, EventArgs e)
        {
            filldata();
            con.connent();
            string x = comboBox1.Text, y = comboBox2.Text;
            DataTable dt = con.getTable("select city , state from place");
            comboBox1.DataSource = dt;
            comboBox2.DataSource = dt;
            comboBox1.DisplayMember = "city";
            comboBox2.DisplayMember = "state";
            comboBox1.Text = x;
            comboBox2.Text = y;
            textBox1.Focus();
        }
        private void filldata()
        {
            
            DataSet ds = con.dsentry("select * from get_company", "get_company");
            //dataGridView1.DataSource = ds.Tables[0];
            con.disconnect();
        }
        public void capture(string name, string city, string state)
        {
            textBox1.Text = name;
            comboBox1.Text = city;
            comboBox2.Text = state;
            getdetail();
            textBox1.Focus();
        }
        private void getdetail()
        {
            if (textBox1.Text == "" && comboBox1.Text == "" && comboBox2.Text == "")
                return;
            SqlDataReader dr = con.exereader(string.Format("select name , openbalance , date , address , city , state , pincode , phno_1 , phno_2 , note from company_detail where name = '{0}' and city = '{1}' and state = '{2}'",textBox1.Text , comboBox1.Text , comboBox2.Text));
            dr.Read();
            textBox1.Text = dr[0].ToString();
            textBox3.Text = dr[1].ToString();
            dateTimePicker1.Text = dr[2].ToString();
            textBox2.Text = dr[3].ToString();
            comboBox1.Text = dr[4].ToString();
            comboBox2.Text = dr[5].ToString();
            textBox5.Text = dr[6].ToString();
            textBox6.Text = dr[7].ToString();
            textBox7.Text = dr[8].ToString();
            textBox8.Text = dr[9].ToString();
            dr.Close();
            con.closereader();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string param = "";
                string address = "";
                if (textBox2.Text == "")
                    address = "NULL,";
                else
                    address = "'" + textBox2.Text + "',";
                param += "'" + textBox1.Text + "',";
                param += address;
                param += "'" + textBox3.Text + "',";
                //param += "'" + textBox4.Text + "',";
                param += "'" + textBox5.Text + "',";
                param += "'" + textBox6.Text + "',";
                param += "'" + textBox7.Text + "',";
                param += "'" + textBox8.Text + "'";
                con.exesclr("exec insert_company " + param);
                MessageBox.Show("Company Saved Successfully");
                filldata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            getdetail();
        }
        public void getcustomer(string name , string city)
        {
            string x = con.exesclr(string.Format("select isnull(max(id),'0') from customer where name = '{0}' and city = '{1}'", name, city));
            if (x == "0")
            {
                textBox1.Text = name;

                return;
            }
                
        }
    }
}