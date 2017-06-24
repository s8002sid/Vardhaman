using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class Ledger_showall : Form
    {
        Connection con = new Connection();
        public Ledger_showall()
        {
            InitializeComponent();
        }

        private void Ledger_showall_Load(object sender, EventArgs e)
        {
            con.connent();
            comboBox1.DataSource = con.getTable("select distinct(name) as name from customer union select distinct(n) as name from ledger_showall");
            comboBox1.DisplayMember = "name";
            comboBox1.Text = "";
            comboBox2.DataSource = con.getTable("select distinct(city) as city from customer");
            comboBox2.DisplayMember = "city";
            comboBox2.Text = "";

        }
        private void intrest()
        {
            textBox5.Text =roundOff.round(con.exesclr(string.Format("exec cal_interest {0} , '{1}' , '{2}'" , textBox6.Text , comboBox1.Text , comboBox2.Text)));
        }
        private void ledgerfill()
        {
            string x = con.exesclr(string.Format("select isnull(min(name),'0') from ledger_showall where name = '{0}' + ' ' + '{1}'", comboBox1.Text, comboBox2.Text));
            if (x == "0")
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
                //MessageBox.Show("Selected Customer Dosenot exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                    dataGridView1.Rows.Remove(dr);
                return;
            }
            dataGridView1.DataSource = con.getTable(string.Format("select dbo.inddatevar(date) as [date of trans], transtype , detail , exp , payment as bill, recepit , id from ledger_showall where name = '{0}' order by date , transtype ,detail", comboBox1.Text + " " + comboBox2.Text));
            if(comboBox1.Text.Trim() != "CASH")
            {
            DataTable dt = con.getTable(string.Format("exec openclosebal '{0}' , '{1}' , '{2}'", DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(), comboBox1.Text, comboBox2.Text));
            //textBox1.Text = dt.Rows[0][1].ToString();
            textBox2.Text = Convert.ToString(Convert.ToDouble(dt.Rows[0][0].ToString()) - Convert.ToDouble(dt.Rows[0][1].ToString()));
            }
            else
            {
                //textBox1.Text = "0.00";
                textBox2.Text = "0.00";
            }
            dataGridView1.Columns["id"].Visible = false;
            double payment = 0, recipt = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                double pay , rec;
                try
                {
                    pay = Convert.ToDouble(dataGridView1.Rows[i].Cells["bill"].Value.ToString());
                }
                catch
                {
                    pay = 0;
                }
                try
                {
                    rec = Convert.ToDouble(dataGridView1.Rows[i].Cells["recepit"].Value.ToString());
                }
                catch
                {
                    rec = 0;
                }
                payment += pay;
                recipt += rec;
            }
            textBox3.Text = roundOff.withpoint(payment.ToString());
            if (comboBox1.Text.Trim() != "CASH")
            {
                textBox2.Text = roundOff.withpoint(Convert.ToString(payment - recipt));
                textBox4.Text = roundOff.withpoint(recipt.ToString());
            }
            else
            {
                textBox4.Text = payment.ToString();
                textBox2.Text = "0.00";
            }
            intrest();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            comboBox2.DataSource = con.getTable(string.Format("select distinct(city) as city from customer where name = '{0}'", comboBox1.Text));
            comboBox2.DisplayMember = "city";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ledgerfill();
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            ledgerfill();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Report_Viewercs rv;
            string x = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["transtype"].Value.ToString();
            string y = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id"].Value.ToString();
            if (x == "Bill")
            {
                string billno = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Detail"].Value.ToString();
                string date = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["date of trans"].Value.ToString();
                DateTime datevar = DateTime.ParseExact(date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (billno[0] == 'M')
                {
                    billno = billno.Substring(1);
                    con.exeNonQurey(string.Format("exec temp_manual_bill_allocate {0} , '{1}', '{2}'", billno, date, VatGst.CurrentTaxStr(datevar)));
                }
                else
                {
                    con.exeNonQurey(string.Format("exec temp_bill_allocate {0}, '{1}'", billno, VatGst.CurrentTaxStr(datevar)));
                }
                rv = new Report_Viewercs();
                rv.loadrpt("worg1");
                rv.ShowDialog();
            }
            if (x == "Recepit")
            {
                string recepitno = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["detail"].Value.ToString();
                DataTable dt;
                if(recepitno[0] == 'M')
                {
                    recepitno = recepitno.Substring(1);
                    string date = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["date of trans"].Value.ToString();
                    string query = "select recepitno , dbo.inddatevar(date) as date , name , city , amount , cd , total , billno , through , '' as manualrecepit , note from view_manual_recepit where recepitno = {0} and date = dbo.indvardate('{1}')";
                    query += " union select manualrecepit as recepitno , dbo.inddatevar(date) as date , name , city , amount , cd , total , billno , through , '' as manualrecepit , note from view_recepit where manualrecepit like('%{0}%')";
                    dt = con.getTable(string.Format(query, recepitno , date));
                }
                else
                dt = con.getTable(string.Format("select recepitno , dbo.inddatevar(date) as date , name , city , amount , cd , total , billno , through , manualrecepit , note from view_recepit where recepitno = {0}" , recepitno));
                string rupeeword = "";
                Vardhman.App_Code.number.num2text(Convert.ToInt32(Convert.ToDouble(dt.Rows[0][6].ToString())));
                con.exeNonQurey("delete from temp_recepit");
                if (dt.Rows[0][9].ToString() == "0")
                    dt.Rows[0][9] = "";
                if (dt.Rows[0][7].ToString() == "0" || dt.Rows[0][7].ToString().Trim() == "" || dt.Rows[0][7].ToString().ToLower() == "null")
                    dt.Rows[0][7] = "    -----";
                rupeeword = Vardhman.App_Code.number.num2text(Convert.ToInt32(Convert.ToDouble(dt.Rows[0][6].ToString())));
                con.exeNonQurey(string.Format("insert into temp_recepit(recepitno , date , customername , city , amount , cd , total , rupeeword , billno , through , manualrecepit , note) values({0} ,dbo.inddatevar(dbo.indvardate('{1}')) ,'{2}'  ,'{3}' , {4},{5},{6},'{7}','{8}' , '{9}' , '{10}' , '{11}' )", dt.Rows[0][0], dt.Rows[0][1], dt.Rows[0][2] + " " + dt.Rows[0][3], dt.Rows[0][3], dt.Rows[0][4], dt.Rows[0][5], dt.Rows[0][6], rupeeword, dt.Rows[0][7], dt.Rows[0][8], dt.Rows[0][9] , dt.Rows[0][10]));
                rv = new Report_Viewercs();
                rv.loadrpt("recepit");
                rv.ShowDialog();
            }
            if (x == "Chk Bounse")
            {

            }
            if (x == "Chk Bounse Panelty")
            {

            }
            if (x == "RecepitBank")
            {
                string recepitno = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id"].Value.ToString();
                DataTable dt = con.getTable(string.Format("select recepitno , dbo.inddatevar(date) as date , name , city , amount , cd , total , billno , through , bank  , checknumber from view_recepit where id = {0} ", recepitno));
                string rupeeword = "";
                Vardhman.App_Code.number.num2text(Convert.ToInt32(Convert.ToDouble(dt.Rows[0][6].ToString())));
                con.exeNonQurey("delete from temp_recepit");
                con.exeNonQurey(string.Format("insert into temp_recepit(recepitno , date , customername , city , amount , cd , total , rupeeword , billno , through , bankname , checknumber ) values({0} ,dbo.inddatevar(dbo.indvardate('{1}')) ,'{2}'  ,'{3}' , {4},{5},{6},'{7}',{8} , '{9}' , '{10}' , '{11}')", dt.Rows[0][0], dt.Rows[0][1], dt.Rows[0][2], dt.Rows[0][3], dt.Rows[0][4], dt.Rows[0][5], dt.Rows[0][6], rupeeword, dt.Rows[0][7], dt.Rows[0][8] , dt.Rows[0][9] , dt.Rows[0][10]));
                rv = new Report_Viewercs();
                rv.loadrpt("recepitbank");
                rv.ShowDialog();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!((e.KeyChar>=48 && e.KeyChar<=57) || (e.KeyChar>=8 && e.KeyChar<=12) || e.KeyChar == '.'))
                e.Handled = true;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            textBox6.Text = roundOff.withpoint(textBox6.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            intrest();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report_Viewercs rp = new Report_Viewercs();
            rp.open = "0.00";
            rp.close = textBox2.Text;
            rp.name = comboBox1.Text;
            rp.city = comboBox2.Text;
            rp.loadrpt("Ledger");
            rp.ShowDialog();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            string x = comboBox1.Text;
            comboBox1.DataSource = con.getTable("select distinct(name) as name from customer union select distinct(n) from ledger_showall");
            comboBox1.DisplayMember = "name";
            comboBox1.Text = x;
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            comboBox2.DataSource = con.getTable(string.Format("select distinct(city) as city from customer where name = '{0}'", comboBox1.Text));
            comboBox2.DisplayMember = "city";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string abc;
        }

        private void Ledger_showall_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main m = (Main)(this.MdiParent);
            m.init_container(childContainer.e_Ledger);
        }
    }
}