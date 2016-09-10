using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class Account_Head : Form
    {
        Connection con = new Connection();
        public Account_Head()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Account_Head_Load(object sender, EventArgs e)
        {
            con.connent();
            string x = comboBox4.Text;
            comboBox4.DataSource = con.getTable("select distinct(city) as city from customer");
            comboBox4.DisplayMember = "city";
            comboBox4.Text = x;
            panel2.Location = new Point(85, 337);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "BANK")
            {
                panel1.Visible = true;
                textBox9.Focus();
                textBox9.Select();
            }
            else
                panel1.Visible = false;
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "BANK")
            {
                panel1.Visible = true;
                textBox9.Select();
                textBox9.Focus();
            }
            else if (comboBox1.Text == "")
                comboBox1.Text = "CUSTOMER";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            textBox1.ReadOnly = false;
            splitContainer1.Visible = false;
            comboBox4.Enabled = true;
            button1.Text = "Save";
            lblid.Text = "";

            comboBox4.DataSource = con.getTable("select distinct(city) as city from customer");
            comboBox4.DisplayMember = "city";
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Text = "";
            textBox11.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
            textBox1.Focus();
            textBox1.Select();
        }
        private void textBox7_Leave(object sender, EventArgs e)
        {
            textBox7.Text = roundOff.withpoint(textBox7.Text);
            if (textBox7.Text == "0.00")
            {
                dateTimePicker1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
            clear();
        }
        private void save()
        {
            //if (textBox1.Text == "" || comboBox1.Text == "" || textBox7.Text == "" || comboBox3.Text == "" || dateTimePicker1.Value.ToString() == "")
            //{
            //    MessageBox.Show("Plase fill all basic entry", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (!(comboBox1.Text == "CUSTOMER" || comboBox1.Text == "BANK" || comboBox1.Text == "ASSESTS" || comboBox1.Text == "EXPENSES" || comboBox1.Text == "INCOME" || comboBox1.Text == "LIABILITY" || comboBox1.Text == "SALARY"))
            //{
            //MessageBox.Show("Please select account type from dropdown list", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //comboBox1.Select();
            //comboBox1.Focus();
            //return;
            //}
            string open = textBox7.Text;
            if (open == "")
                open = "0.00";

            line_group_creation lgc = new line_group_creation();
            lgc.check(comboBox4.Text.ToLower());

            if (button1.Text == "Save")
            {
                if (chknamewidspace() == 0)
                {
                    MessageBox.Show("Account alreadt exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                con.exeNonQurey(string.Format("exec add_customer '{0}' , '{1}' , '{2}' , '{3}' , '{4}' , '{5}' , '{6}' , {7}  , '{8}' , '{9}' , '{10}' , '{11}' , {12}", textBox1.Text.Trim(), textBox11.Text, textBox2.Text, comboBox4.Text, textBox4.Text, textBox5.Text, textBox6.Text, open, dateTimePicker1.Text.ToString().Split(Convert.ToChar(" "))[0], comboBox1.Text, textBox9.Text, comboBox2.Text, "1"));
                clear();
                MessageBox.Show("items Saved successfully");
            }
            else
            {
                con.exeNonQurey(string.Format("exec update_customer '{0}' , '{1}' , '{2}' , '{3}' , '{4}' , '{5}' , '{6}' , {7}  , '{8}' , '{9}' , '{10}' , '{11}' , {12}", textBox1.Text.Trim(), textBox11.Text, textBox2.Text, comboBox4.Text, textBox4.Text, textBox5.Text, textBox6.Text, open, dateTimePicker1.Text.ToString().Split(Convert.ToChar(" "))[0], comboBox1.Text, textBox9.Text, comboBox2.Text, lblid.Text));
                clear();
                MessageBox.Show("items Updated successfully");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = checkBox1.Checked;
            if (checkBox1.Checked == true)
            {
                panel3.Location = new Point(6, 339);
                panel2.Location = new Point(62, 669);
            }
            else
            {
                panel2.Location = new Point(85, 337);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.getTable("select name , city from customer");
            splitContainer1.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string name, city;
            name = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            city = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            DataTable dt = con.getTable(string.Format("select name , note , address , city , pincode , phno_1 , phno_2 , openbalance  , date , type , accountnumber , accounttype , id from customer where name = '{0}' and city = '{1}'", name, city));
            textBox1.Text = dt.Rows[0][0].ToString();
            comboBox4.Text = dt.Rows[0][3].ToString();
            comboBox1.Text = dt.Rows[0][9].ToString();
            textBox7.Text = dt.Rows[0][7].ToString();
            dateTimePicker1.Text = dt.Rows[0][8].ToString();
            textBox2.Text = dt.Rows[0][2].ToString();
            textBox4.Text = dt.Rows[0][4].ToString();
            textBox5.Text = dt.Rows[0][5].ToString();
            textBox6.Text = dt.Rows[0][6].ToString();
            textBox11.Text = dt.Rows[0][1].ToString();
            textBox9.Text = dt.Rows[0][10].ToString();
            comboBox2.Text = dt.Rows[0][11].ToString();
            lblid.Text = dt.Rows[0][12].ToString();
            splitContainer1.Visible = true;
            button1.Text = "Update";
            //textBox1.ReadOnly = true;
            //comboBox4.Enabled = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.getTable(string.Format("select name , city from customer where name like('{0}%')", textBox3.Text));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            splitContainer1.Visible = false;
        }
        public void getdetail(string name, string city)
        {
            con.connent();
            string x = con.exesclr(string.Format("select isnull(max(id),'0') from customer where name = '{0}' and city = '{1}'", name, city));
            if (x == "0")
            {
                textBox1.Text = name;
                comboBox4.Text = city;
                comboBox1.Text = "CUSTOMER";
                textBox7.Focus();
                textBox7.Select();
                con.disconnect();
                return;
            }
            DataTable dt = con.getTable(string.Format("select name , note , address , city , pincode , phno_1 , phno_2 , openbalance , debcredit , dbo.inddatevar(date) , type , accountnumber , accounttype from customer where name = '{0}' and city = '{1}'", name, city));
            textBox1.Text = dt.Rows[0][0].ToString();
            string abc = comboBox4.Text;
            comboBox4.Text = dt.Rows[0][3].ToString();
            comboBox4.Text = abc;
            comboBox1.Text = dt.Rows[0][9].ToString();
            textBox7.Text = dt.Rows[0][7].ToString();
            dateTimePicker1.Text = dt.Rows[0][8].ToString();
            textBox2.Text = dt.Rows[0][2].ToString();
            textBox4.Text = dt.Rows[0][4].ToString();
            textBox5.Text = dt.Rows[0][5].ToString();
            textBox6.Text = dt.Rows[0][6].ToString();
            textBox11.Text = dt.Rows[0][1].ToString();
            textBox9.Text = dt.Rows[0][10].ToString();
            comboBox2.Text = dt.Rows[0][11].ToString();
            splitContainer1.Visible = true;
            button1.Text = "Update";
            textBox1.ReadOnly = true;
            comboBox4.Enabled = false;
            con.disconnect();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == 8 || e.KeyChar == 9 || e.KeyChar == 10 || e.KeyChar == 11 || e.KeyChar == 12 || e.KeyChar == 46 || (e.KeyChar >= 48 && e.KeyChar <= 57)))
                e.Handled = true;
        }
        private int chknamewidspace()
        {
            DataTable dt = con.getTable("select name , city from customer");

            string abox = textBox1.Text.Replace(" ", "");
            string bbox = comboBox4.Text.Replace(" ", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string a = dt.Rows[i][0].ToString().Replace(" ", "");
                string b = dt.Rows[i][1].ToString().Replace(" ", "");
                if ((a == abox) && (b == bbox))
                    return 0;

            }

            return 1;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || button1.Text != "Save")
                return;
            string query = "select name from customer";
            string x = Supporter.compare(textBox1.Text, query, 3);
            if (x != "")
            {
                textBox1.Text = ""; textBox1.Focus();
            }
        }
    }
}