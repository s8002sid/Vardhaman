using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class ManualRecepit : Form
    {
        Connection con = new Connection();
        int company;
        public ManualRecepit()
        {
            InitializeComponent();
        }

        private void Recepit_Load(object sender, EventArgs e)
        {
            con.connent();
            company = 0;
            panel2.Location = new Point(173, 290);
            splitContainer1.Location = new Point(168, 109);
            clear();
        }
        private void clear()
        {
            button6.Enabled = true;
            textBox1.Text = "";
            comboBox1.DataSource = con.getTable("select distinct(name) as name from customer where type = 'CUSTOMER' and name is not null");
            company = 0;
            comboBox1.DisplayMember = "name";
            comboBox2.DataSource = con.getTable("select distinct(city) as city from customer where type = 'CUSTOMER' and city <> '' and city is not null");
            comboBox2.DisplayMember = "city";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.DataSource = con.getTable("select name from customer where type = 'BANK'");
            comboBox3.DisplayMember = "name";
            comboBox3.Text = "";
            splitContainer1.Visible = false;
            button2.Text = "Print and Save";
            button1.Text = "Save";
            textBox1.ReadOnly = false;
            panel4.Visible = false;
            textBox8.Text = "";
            textBox9.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox20.Text = "";
            textBox1.Focus();
            textBox1.Select();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel3.Visible = true;
                panel2.Location = new Point(173, 400);
            }
            else
            {
                panel3.Visible = false;
                panel2.Location = new Point(173, 290);
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            total();
        }
        private void total()
        {

            textBox2.Text = roundOff.withpoint(textBox2.Text);
            double amount, cd;
            if (textBox4.Text != "")
                amount = Convert.ToDouble(textBox4.Text);
            else
                amount = 0.00;
            textBox2.Text = textBox4.Text;
            if (textBox3.Text == "")
                return;
            cd = Convert.ToDouble(textBox3.Text);
            textBox4.Text = roundOff.withpoint(Convert.ToString(amount));
            textBox3.Text = roundOff.withpoint(Convert.ToString(cd));
            textBox2.Text = roundOff.withpoint(Convert.ToString(amount - cd));
            textBox5.Text = Vardhman.App_Code.number.num2text(Convert.ToInt32(amount));
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            total();
        }
        private void fill()
        {
            if (textBox8.Text == "")
                return;
            DataTable dt = con.getTable(string.Format("exec get_manual_billdetail '{0}' , '{1}'", textBox8.Text, dateTimePicker1.Text.ToString().Split(Convert.ToChar(" "))[0]));
            if (dt.Rows[0][0].ToString() == "0")
                return;
            else
            {
                textBox10.Text = dt.Rows[0][1].ToString();
                textBox11.Text = dt.Rows[0][2].ToString();
                textBox12.Text = dt.Rows[0][3].ToString();
                textBox13.Text = dt.Rows[0][4].ToString();
                textBox14.Text = dt.Rows[0][5].ToString();
                textBox15.Text = dt.Rows[0][6].ToString();
                textBox16.Text = dt.Rows[0][7].ToString();
                textBox17.Text = dt.Rows[0][8].ToString();
                textBox18.Text = dt.Rows[0][9].ToString();
                panel4.Visible = true;
                //if (comboBox1.Text == "")
                //    comboBox1.Text = textBox10.Text;
                //if (comboBox2.Text == "")
                //    comboBox2.Text = textBox11.Text;
                //if (textBox2.Text == "")
                //    textBox2.Text = textBox13.Text;
                //expensecal(textBox18.Text, textBox14.Text);
            }
        }
        private void textBox8_Leave(object sender, EventArgs e)
        {
            fill();
        }
        private void expensecal(string datediff , string exp1)
        {
            int diff = Convert.ToInt32(datediff);
            if(diff<0)
                return ;
            double exp = Convert.ToDouble(exp1), calexp = 0 ;
            if (diff <= 15)
                calexp = exp * 2;
            else if (diff > 15 && diff <= 30)
                calexp = exp;
            else if (diff > 30)
                calexp = 0;
            textBox3.Text = roundOff.withpoint(calexp.ToString());
            double amt;
            if (calexp != 0 && textBox17.Text != "")
            {
                amt = Convert.ToDouble(textBox17.Text);
                textBox4.Text = roundOff.withpoint(Convert.ToString(amt));
            }
            else total();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar =Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fill();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                panel4.Visible = false;
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
            }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            chkrecepitno();
            fill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 9 || e.KeyChar == 10 || e.KeyChar == 11 || e.KeyChar == 12 || e.KeyChar == 46))
                e.Handled = true;
        }
        private int save()
        {
            int cuttent;
                cuttent = Convert.ToInt32(textBox1.Text);
                if (textBox1.Text == "" || comboBox2.Text == "" || comboBox1.Text == "" || textBox4.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Please fill all fields", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
                if (textBox3.Text == "")
                    textBox3.Text = "0.00";
                string zero = "null", four = "null", five = "null", six = "null", ten = "null";
                if (textBox1.Text != "")
                    zero = textBox1.Text;
                if (textBox2.Text != "")
                    four = textBox2.Text;
                if (textBox3.Text != "")
                    five = textBox3.Text;
                if (textBox4.Text != "")
                    six = textBox4.Text;
                if (textBox8.Text != "")
                    ten = textBox8.Text;
                string abc = dateTimePicker1.Text;
                string x;
                if (button1.Text == "Save") 
                x = con.exesclr(string.Format("exec add_manual_recepit {0} , '{1}' , '{2}' , '{3}' , {4} , {5} , {6} , '{7}' , '{8}' , '{9}' , '{10}' , '{11}'", zero, dateTimePicker1.Text.ToString().Split(Convert.ToChar(" "))[0], comboBox1.Text, comboBox2.Text, four, five, six, comboBox3.Text, textBox6.Text, ten, textBox9.Text , textBox20.Text));
                else
                x = con.exesclr(string.Format("exec upd_manual_recepit {0} , '{1}' , '{2}' , '{3}' , {4} , {5} , {6} , '{7}' , '{8}' , '{9}' , '{10}' , '{11}' , {12}", zero, dateTimePicker1.Text.ToString().Split(Convert.ToChar(" "))[0], comboBox1.Text, comboBox2.Text, four, five, six, comboBox3.Text, textBox6.Text, ten, textBox9.Text , textBox20.Text , lblid.Text));
                if (x == "0")
                {
                    MessageBox.Show("Invalid customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox1.Focus(); comboBox1.Select();
                    company = 1;
                }
                else if (x == "1")
                {
                    MessageBox.Show("Invalid Bank name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox3.Focus(); comboBox3.Select();
                    company = 1;
                }
                else
                {
                    if (button1.Text == "Save")
                    {
                        MessageBox.Show("Recepit Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    MessageBox.Show("Recepit Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox1.Focus(); comboBox1.Select();
                    con.exeNonQurey("delete from temp_recepit");
                    string zero1 = "null", four1 = "null", five1 = "null", six1 = "null", ten1 = "null";
                    if (textBox1.Text != "")
                        zero1 = textBox1.Text;
                    if (textBox2.Text != "")
                        four1 = textBox2.Text;
                    if (textBox3.Text != "")
                        five1 = textBox3.Text;
                    if (textBox4.Text != "")
                        six1 = textBox4.Text;
                    if (textBox8.Text != "")
                        ten1 = textBox8.Text;
                    if (ten1.ToLower() == "null")
                        ten1 = "    ------";
                    create_backup.create();
                    con.exeNonQurey(string.Format("insert into temp_recepit(recepitno , date , customername , city , amount , cd , total , bankname , checknumber , rupeeword , billno , through , manualrecepit , note) values({0} ,'{1}' ,'{2}'  ,'{3}' , {4},{5},{6},'{7}','{8}' , '{9}' , '{10}' , '{11}' , '' , '{12}' )", zero1, dateTimePicker1.Text.ToString().Split(Convert.ToChar(Convert.ToChar(" ")))[0], comboBox1.Text + " " + comboBox2.Text, comboBox2.Text, four1, five1, six1, comboBox3.Text, textBox6.Text, textBox5.Text, ten1, textBox9.Text , textBox20.Text));
                    clear();
                }
                return 1;
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            string x = comboBox2.Text;
            if (comboBox1.Text == "")
                return;
            comboBox2.DataSource = con.getTable(string.Format("select distinct(city) as city from customer where name = '{0}' and city <> ''" , comboBox1.Text));
            comboBox2.DisplayMember = "city";
            //if(x!="")
            //comboBox2.Text = x;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox5.Text = Vardhman.App_Code.number.num2text(Convert.ToInt32(Convert.ToDouble(textBox4.Text)));
            }
            catch { }
            try
            {
                double val =Convert.ToDouble(textBox4.Text);
                double maxRecepit = VatGst.MaxRecepitAmount(dateTimePicker1.Value);
                if (val > maxRecepit)
                    MessageBox.Show(String.Format("Amount exceeded limit its above {0}", maxRecepit));
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x =save();
            if (company == 0 && x == 1)
            {
                Report_Viewercs rpt = new Report_Viewercs();
                //if (checkBox1.Checked == false)
                    rpt.loadrpt("recepit");
                //else
                    //rpt.loadrpt("recepitbank");
                rpt.Show();
            }
            company = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }
        private void chkrecepitno()
        {
            if (button1.Text == "Update")
                return;
            string date, number;
            date = dateTimePicker1.Text.ToString().Split(Convert.ToChar(Convert.ToChar(" ")))[0];
            number = textBox1.Text;
            if (number.Trim() == "")
                return;
            DataTable dt = con.getTable(string.Format("exec chk_manual_recepitno {0} , '{1}'", number, date));
            if (dt.Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("Recepit Number entered is not valid");
                return;
            }
            else if (dt.Rows[0][0].ToString() == "1")
                return;
            MessageBox.Show(string.Format("Date should be between {0} and {1}", dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString()));

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            chkrecepitno();
        }

        private void Recepit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit all your unsaved data will be lost", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            Main m = (Main)(this.MdiParent);
            m.init_container(childContainer.e_ManualRecepit);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.getTable("select recepitno , name , city , id from view_manual_recepit order by recepitno desc");
            dataGridView1.Columns[3].Visible = false;
            splitContainer1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            splitContainer1.Visible = false;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.getTable(string.Format("select recepitno , name , city , id from view_manual_recepit where name like('{0}%') order by recepitno desc" , textBox19.Text));
            dataGridView1.Columns[3].Visible = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                button1.Text = "Update";
                DataTable dt = con.getTable(string.Format("select recepitno , date , name , city , amount , cd , total , isnull(bank , '') , isnull(bank_city , '') , isnull(checknumber , '') , isnull(billno , '') , isnull(through , '') from view_manual_recepit where id = {0}", dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString()));
                lblid.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
                textBox1.Text = dt.Rows[0][0].ToString();
                dateTimePicker1.Text = dt.Rows[0][1].ToString();
                comboBox1.Text = dt.Rows[0][2].ToString();
                comboBox2.Text = dt.Rows[0][3].ToString();
                textBox2.Text = dt.Rows[0][4].ToString();
                textBox3.Text = dt.Rows[0][5].ToString();
                textBox4.Text = dt.Rows[0][6].ToString();
                    textBox7.Text = "";
                if (dt.Rows[0][7].ToString() != "")
                    checkBox1.Checked = true;

                comboBox3.Text = dt.Rows[0][7].ToString();
                textBox6.Text = dt.Rows[0][9].ToString();
                textBox8.Text = dt.Rows[0][10].ToString();
                if (textBox8.Text.ToLower() == "null")
                    textBox8.Text = "";
                textBox9.Text = dt.Rows[0][11].ToString();
                textBox5.Text = Vardhman.App_Code.number.num2text(Convert.ToInt32(Convert.ToDouble(dt.Rows[0][6].ToString())));
                splitContainer1.Visible = false;
                button2.Text = "Print and Update";
                textBox1.ReadOnly = true;
                button6.Enabled = true;
            }
            catch
            {

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            AutoCompleteStringCollection str1 = new AutoCompleteStringCollection();
            DataTable dt = con.getTable("select distinct(through) from recepit where through <> '' and through is not null");
            for(int i = 0;i<dt.Rows.Count;i++)
                str1.Add(dt.Rows[i][0].ToString());
            textBox9.AutoCompleteCustomSource = str1;
            textBox9.Text = "SELF";
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            string x = comboBox3.Text;
            comboBox3.DataSource = con.getTable("select name from customer where type = 'BANK'");
            comboBox3.DisplayMember = "name";
            comboBox3.Text = "";
            comboBox3.Text = x;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 9 || e.KeyChar == 10 || e.KeyChar == 11 || e.KeyChar == 12 || e.KeyChar == 46))
                e.Handled = true;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            total();
            textBox4.Text = roundOff.withpoint(textBox4.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox5.Text = Vardhman.App_Code.number.num2text(Convert.ToInt32(Convert.ToDouble(textBox4.Text)));
            }
            catch { }
            try
            {
                double val = Convert.ToDouble(textBox4.Text);
                double maxRecepit = VatGst.MaxRecepitAmount(dateTimePicker1.Value);
                if (val > maxRecepit)
                    MessageBox.Show(String.Format("Amount exceeded limit its above {0}", maxRecepit));
            }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Are you sure you want to delete \nbill number = {0} \nCustomername = {1} \nCity = {2}", textBox2.Text, comboBox1.Text, comboBox2.Text), "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
                return;
            Password p = new Password();
            if (p.ShowDialog() == DialogResult.Cancel)
                return;
            string passwd = p.Passwd;
            string value1, value2;
            string storedpass = con.exesclr("select min(passwd) as password from password_");
            if (storedpass != passwd)
            {
                MessageBox.Show("Password donot match");
                return;
            }
            con.exeNonQurey(string.Format("delete from manual_recepit where id = {0}", lblid.Text));
            //con.exeNonQurey(string.Format("delete from manual_bill_master id = {0}", lblid.Text));
            clear();
        }
    }
}