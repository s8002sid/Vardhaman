using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class new_ledger : Form
    {
        Connection con = new Connection();
        public new_ledger()
        {
            InitializeComponent();
        }
        DateTime datefrom, dateto;
        DateTime maxdateto;
        string name;
        string city;
        string group;
        int level;
        private void new_ledger_Load(object sender, EventArgs e)
        {
            con.connent();
            name = "";
            city = "";
            group = "";
            level = 1;
            DataTable dt = con.getTable("exec get_current_financial_year");
            datefrom = getstartdate(DateTime.Now);
            dateto = getenddate(DateTime.Now);

            dateTimePicker1.Value = datefrom;
            dateTimePicker2.Value = dateto;
            label11.Text = getlabel();

            maxdateto = dateto;
            home("");
            la();
        }
        private string getmonth(int month)
        {
            switch (month)
            {
                case 1: return "Jan";
                case 2: return "Feb";
                case 3: return "Mar";
                case 4: return "Apr";
                case 5: return "May";
                case 6: return "Jun";
                case 7: return "Jul";
                case 8: return "Aug";
                case 9: return "Sep";
                case 10: return "Oct";
                case 11: return "Nov";
                case 12: return "Dec";
                default: return "";
            }
        }
        private string getlabel()
        {
            int type = gettype();
            string a = getmonth(dateTimePicker1.Value.Month) + " " + dateTimePicker1.Value.Year.ToString();
            string b = getmonth(dateTimePicker2.Value.Month) + " " + dateTimePicker2.Value.Year.ToString();
            return a + "-" + b;
        }
        private DateTime getstartdate(DateTime date)
        {
            int type = gettype();
            if (type == 0)
                return new DateTime(date.Year, date.Month, 1);
            else if (type == 1)
            {
                if (date.Month >= 4 && date.Month < 7)
                {
                    return new DateTime(date.Year, 4, 1);
                }
                else if (date.Month >= 7 && date.Month < 10)
                {
                    return new DateTime(date.Year, 7, 1);
                }
                else if (date.Month >= 10)
                {
                    return new DateTime(date.Year, 10, 1);
                }
                else
                {
                    return new DateTime(date.Year, 1, 1);
                }
            }
            else if (type == 2)
            {
                if (date.Month >= 4 && date.Month < 10)
                    return new DateTime(date.Year, 4, 1);
                else if (date.Month >= 10)
                    return new DateTime(date.Year, 10, 1);
                else
                    return new DateTime(date.Year - 1, 10, 1);
            }
            else
            {
                if (date.Month >= 4)
                    return new DateTime(date.Year, 4, 1);
                else
                    return new DateTime(date.Year - 1, 4, 1);
            }
        }
        private DateTime getenddate(DateTime date)
        {
            int type = gettype();
            int days;
            if (type == 0)
            {
                days = DateTime.DaysInMonth(date.Year, date.Month);
                return new DateTime(date.Year, date.Month, days);
            }
            else if (type == 1)
            {
                if (date.Month >= 4 && date.Month < 7)
                {
                    return new DateTime(date.Year, 6, 30);
                }
                else if (date.Month >= 7 && date.Month < 10)
                {
                    return new DateTime(date.Year, 9, 30);
                }
                else if (date.Month >= 10)
                {
                    return new DateTime(date.Year, 12, 31);
                }
                else
                {
                    return new DateTime(date.Year, 3, 31);
                }
            }
            else if (type == 2)
            {
                if (date.Month >= 4 && date.Month < 10)
                    return new DateTime(date.Year, 9, 30);
                else if (date.Month >= 10)
                    return new DateTime(date.Year + 1, 3, 31);
                else
                    return new DateTime(date.Year, 3, 31);

            }
            else if (type == 3)
            {
                if (date.Month >= 4)
                    return new DateTime(date.Year + 1, 3, 31);
                else
                    return new DateTime(date.Year, 3, 31);
            }
            return DateTime.MinValue;
        }
        private void home(string name)
        {
            clear();
            DataTable dt = con.getTable(string.Format("exec create_group_closebalance '{0}','{1}%'", dateTimePicker2.Text,name));
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d = dateTimePicker1.Value.AddDays(-1);

            dateTimePicker1.Value = getstartdate(d);
            dateTimePicker2.Value = getenddate(d);
            label11.Text = getlabel();
            if (level == 3)
                ledger();
            if (level == 2)
                level2(textBox1.Text);
            if (level == 1)
                home(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime d = dateTimePicker2.Value.AddDays(1);

            dateTimePicker1.Value = getstartdate(d);
            dateTimePicker2.Value = getenddate(d);

            label11.Text = getlabel();

            if (level == 3)
                ledger();
            if (level == 2)
                level2(textBox1.Text);
            if (level == 1)
                home(textBox1.Text);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (level == 1)
            {
                string city = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboBox3.Text = city;
                comboBox1.Text = "";
                level2("%");
                level++;
                textBox1.Text = "";
                group = city;
                la();
            }
            else if (level == 2)
            {
                //string name, city;
                name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                city = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox1.Text = name;
                comboBox3.Text = city;
                label11.Text = datefrom.Year.ToString() + "-" + dateto.Year.ToString();
                textBox1.Text = "";
                ledger();
                level++;
                textBox1.Text = "";

                dateTimePicker1.Value = datefrom;
                dateTimePicker2.Value = dateto;
                label11.Text = getlabel();
                lb();
            }
            //else if (level == 3)
            //{
                
            //    level++;
            //}

        }
        private int gettype()
        {
            if (radioButton1.Checked == true)
                return 0;
            else if (radioButton2.Checked == true)
                return 1;
            else if (radioButton3.Checked == true)
                return 2;
            else
                return 3;
        }
        private void ledger()
        {
            if (textBox2.Text == "")
                return;
            if (textBox3.Text == "")
                return;
            float a;
            int b;
            if (!int.TryParse(textBox2.Text, out b) || !float.TryParse(textBox3.Text, out a))
                return;
            DataTable ledger = con.getTable(string.Format("select dbo.inddatevar(date) as date1,transtype,detail,exp,payment,recepit from ledger_showall where n ='{0}' and c = '{1}' order by date", comboBox1.Text, comboBox3.Text));
            intrest_calculation ic = new intrest_calculation(ledger);
            ic.calculate(gettype(), dateTimePicker3.Value, double.Parse(textBox3.Text), int.Parse(textBox2.Text),dateTimePicker1.Value,dateTimePicker2.Value);

            DataTable dt = con.getTable(string.Format("select isnull(sum(isnull(payment,0)),0) - isnull(sum(isnull(recepit,0)),0) from ledger_showall where n = '{0}' and c = '{1}' and date < dbo.indvardate('{2}')",comboBox1.Text,comboBox3.Text, dateTimePicker1.Text.ToString().Split(Convert.ToChar(" "))[0]));
            textBox4.Text = dt.Rows[0][0].ToString();
            dt = con.getTable(string.Format("select isnull(sum(isnull(payment,0)),0) - isnull(sum(isnull(recepit,0)),0) from ledger_showall where n = '{0}' and c = '{1}' and date <= dbo.indvardate('{2}')",comboBox1.Text,comboBox3.Text,dateTimePicker2.Text.ToString().Split(Convert.ToChar(" "))[0]));
            textBox10.Text = dt.Rows[0][0].ToString();
            string res;
            Supporter.set_two_digit_precision(ic.openint.ToString(),out res);
            textBox5.Text = res;
            dt = con.getTable(string.Format("select date,transtype,detail1 as detail,exp,payment,recepit,days,intrest from printledger where dbo.indvardate(date) between dbo.indvardate('{0}') and dbo.indvardate('{1}') order by dbo.indvardate(date)", dateTimePicker1.Text.ToString().Split(Convert.ToChar(" "))[0], dateTimePicker2.Text.ToString().Split(Convert.ToChar(" "))[0]));
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            calculatetotal();
        }
        private void calculatetotal()
        {
            double payment, receipt, intrest, openbalance, openintrest, closingbalance, closingintrest;
            payment = 0;
            receipt = 0;
            intrest = 0;
            //4,5,7
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                payment += getdoublevalue(i, 4);
                receipt += getdoublevalue(i, 5);
                intrest += getdoublevalue(i, 7);
            }
            double.TryParse(textBox4.Text, out openbalance);
            double.TryParse(textBox5.Text, out openintrest);
            closingbalance = payment - receipt;
            closingintrest = intrest + double.Parse(textBox5.Text);
            string result;
            Supporter.set_two_digit_precision(payment.ToString(), out result);
            textBox6.Text = result;
            Supporter.set_two_digit_precision(receipt.ToString(), out result);
            textBox7.Text = result;
            Supporter.set_two_digit_precision(intrest.ToString(), out result);
            textBox8.Text = result;
            Supporter.set_two_digit_precision(closingintrest.ToString(), out result);
            textBox9.Text = result;
            Supporter.set_two_digit_precision(closingbalance.ToString(), out result);
            textBox10.Text = result;
        }
        private double getdoublevalue(int row, int col)
        {
            if (dataGridView1.Rows[row].Cells[col].Value == null)
                return 0;
            double d;
            if (!double.TryParse(dataGridView1.Rows[row].Cells[col].Value.ToString(), out d))
                return 0;
            return d;
        }
        private void level2(string name)
        {
            clear();
            DataTable dt = con.getTable(string.Format("exec create_city_closebalance '{0}','{1}','{2}%'", dateTimePicker2.Text, comboBox3.Text,name));
            dataGridView1.DataSource = dt;
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void clear()
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (level == 3)
            {
                if (group == "")
                    return;
                level--;
                comboBox3.Text = group;
                comboBox1.Text = "";
                level2("%");
                textBox1.Text = "";
            }
            else if (level == 2)
            {
                home("");
                level = 1;
                //comboBox1.Text = "Name";
                //comboBox3.Text = "City";
            }
            //home("");
            //level = 1;
            //label4.Text = "Name";
            //label5.Text = "City";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (level == 1)
            {
                home(textBox1.Text);
            }
            else if (level == 2)
            {
                level2(textBox1.Text);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (level == 3)
                ledger();
            if (level == 2)
                level2(textBox1.Text);
            if (level == 1)
                home(textBox1.Text);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (level == 3)
            {
                if (DateTime.Compare(dateTimePicker3.Value, dateTimePicker2.Value) > 0)
                    dateTimePicker3.Value = dateTimePicker2.Value;
                else
                    dateTimePicker3.Value = DateTime.Now;
                ledger();
            }
            if (level == 2)
                level2(textBox1.Text);
            if (level == 1)
                home(textBox1.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            float a;
            if (textBox3.Text == "")
                return;
            if (!float.TryParse(textBox3.Text,out a))
                return;
            if (level == 3)
                ledger();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (level == 3)
                ledger();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            if (level == 3)
                ledger();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (level == 1)
            {
                if (group == "")
                    return;
                level++;
                comboBox3.Text = group;
                comboBox1.Text = "";
                level2("%");
                textBox1.Text = "";
            }
            else if (level == 2)
            {
                if (name == "" && city == "")
                    return;
                comboBox1.Text = name;
                comboBox3.Text = city;
                label11.Text = datefrom.Year.ToString() + "-" + dateto.Year.ToString();
                textBox1.Text = "";
                ledger();
                level++;
                textBox1.Text = "";

                dateTimePicker1.Value = datefrom;
                dateTimePicker2.Value = dateto;
                label11.Text = getlabel();
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if(level == 3)
            calculatetotal();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            save(0);
        }
        private void save(int button)
        {
            if (level != 3)
            {
                con.exeNonQurey("delete from groupbalance");
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string name, bal,place;
                    if (level == 1)
                    {
                        name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        bal = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        place = "City Wise Debtors List";
                    }
                    else
                    {
                        name = dataGridView1.Rows[i].Cells[0].Value.ToString() + " " + dataGridView1.Rows[i].Cells[1].Value.ToString();
                        bal = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        place = comboBox3.Text + " Debtors List";
                    }
                    if (bal == "")
                        bal = "NULL";
                    con.exeNonQurey(string.Format("insert into groupbalance values('{0}',{1},'{2}')", name, bal,place));
                }
                Report_Viewercs rv = new Report_Viewercs();
                rv.loadrpt("groupbalance");
                rv.ShowDialog();
            }
            else
            {
                con.exeNonQurey("delete from printledger");
                con.exeNonQurey("delete from ledgerdetail");
                string name, city, datefrom, dateto, caldays, intper, caldate, openbal, openint, payment;
                string recepit, intrest, closingbal, closeint;

                name = comboBox1.Text + "    " + comboBox3.Text;
                city = comboBox3.Text;
                datefrom = dateTimePicker1.Text.ToString().Split(Convert.ToChar(" "))[0];
                dateto = dateTimePicker2.Text.ToString().Split(Convert.ToChar(" "))[0];
                caldays = textBox2.Text;
                int x;
                if (caldays == "")
                    caldays = "60";
                if (!int.TryParse(caldays, out x))
                    caldays = "60";
                intper = validatedouble(textBox3.Text);

                caldate = dateTimePicker3.Text.ToString().Split(Convert.ToChar(" "))[0];
                openbal = validatedouble(textBox4.Text);
                openint = validatedouble(textBox5.Text);
                payment = textBox6.Text;
                recepit = validatedouble(textBox7.Text);
                intrest = textBox8.Text;
                closeint = validatedouble(textBox9.Text);
                closingbal = validatedouble(textBox10.Text);

                con.exeNonQurey(string.Format("insert into ledgerdetail values('{0}','{1}','{2}','{3}',{4},{5},'{6}',{7},{8},{9},{10},{11},{12},{13})", name, city, datefrom, dateto, caldays, intper, caldate, openbal, openint, payment, recepit, intrest, closingbal, closeint));
                string nam = comboBox1.Text + " " + comboBox3.Text;
                if(button == 1 && textBox5.Text != "0.00")
                con.exeNonQurey(string.Format("insert into printledger(date,detail,exp,payment,recepit,days,intrest,name) values('{0}','{1}',{2},{3},{4},{5},{6},'{7}')",
                    dateTimePicker1.Text.ToString().Split(Convert.ToChar(" "))[0],
                    "Due Int. upto " + dateTimePicker3.Text.ToString().Split(Convert.ToChar(" "))[0],
                    "NULL",
                    "NULL",
                    "NULL",
                    "NULL",
                    openint,
                    nam));

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string ldate = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string ldetail =transtype(dataGridView1.Rows[i].Cells[1].Value.ToString()) + "  " + dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string lexp = getdatagridvalue(i, 3);
                    string lpayment = getdatagridvalue(i, 4);
                    string lrecepit = getdatagridvalue(i, 5);
                    string ldays = getdatagridvalue(i, 6);
                    string lintrest = getdatagridvalue(i, 7);
                    con.exeNonQurey(string.Format("insert into printledger(date,detail,exp,payment,recepit,days,intrest,name) values('{0}','{1}',{2},{3},{4},{5},{6},'{7}')", ldate, ldetail, lexp, lpayment, lrecepit, ldays, lintrest, nam));
                }
                if (button == 0)
                {
                    Report_Viewercs rv = new Report_Viewercs();
                    rv.loadrpt("newledger");
                    rv.ShowDialog();
                }
                else
                {
                    Report_Viewercs rv = new Report_Viewercs();
                    rv.loadrpt("intrestledger");
                    rv.ShowDialog();
                    
                }
            }
        }
        private string transtype(string x)
        {
            switch (x.ToLower().Trim())
            {
                case "bill": return "Bill No.";
                case "recepit": return "Receipt No.";
                case "receipt": return "Receipt No.";
                case "opening balance": return "Opening Balance";
                case "recepitbank": return "Receipt No.";
                case "chk bounse": return "Bounced Check No.";
                case "chk bounse panelty": return "Bounce Panelty of Check No.";
            }
            return x;
        }
        private string validatedouble(string x)
        {
            double d;
            if (x == "" || !double.TryParse(x, out d))
                return "0.00";
            return x;
        }
        private string getdatagridvalue(int row, int col)
        {
            if (dataGridView1.Rows[row].Cells[col].Value == null)
                return "NULL";
            double d;
            if (!double.TryParse(dataGridView1.Rows[row].Cells[col].Value.ToString(), out d))
                return "NULL";
            return d.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            save(1);
        }
        private DateTime converttodate(string date)//from indian format to vs format
        {
            string[] s = date.Split('/');
            return new DateTime(Convert.ToInt32(s[2]), Convert.ToInt32(s[1]), Convert.ToInt32(s[0]));
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            DateTime d;
            try
            {
                d = converttodate(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value.ToString());
            }
            catch
            {
                d = dateTimePicker3.Value;
            }
            dateTimePicker1.Value = getstartdate(d);
            dateTimePicker2.Value = getenddate(d);
            label11.Text = getlabel();
            if (level == 3)
                ledger();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            DateTime d;
            try
            {
                d = converttodate(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value.ToString());
            }
            catch
            {
                d = dateTimePicker3.Value;
            }
            dateTimePicker1.Value = getstartdate(d);
            dateTimePicker2.Value = getenddate(d);
            label11.Text = getlabel();
            if (level == 3)
                ledger();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DateTime d;
            try
            {
                d = converttodate(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value.ToString());
            }
            catch
            {
                d = dateTimePicker3.Value;
            }
            dateTimePicker1.Value = getstartdate(d);
            dateTimePicker2.Value = getenddate(d);
            label11.Text = getlabel();
            if (level == 3)
                ledger();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DateTime d;
            try
            {
                d = converttodate(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value.ToString());
            }
            catch
            {
                d = dateTimePicker3.Value;
            }
            dateTimePicker1.Value = getstartdate(d);
            dateTimePicker2.Value = getenddate(d);
            label11.Text = getlabel();
            if (level == 3)
                ledger();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            string x = comboBox1.Text;
            string y = comboBox3.Text;
            comboBox1.DataSource = con.getTable("select name from customer");
            comboBox1.DisplayMember = "name";
            comboBox3.DataSource = con.getTable("select distinct(city) as city from customer");
            comboBox3.DisplayMember = "city";
            comboBox1.Text = x;
            comboBox3.Text = y;
        }

        private void comboBox3_Enter(object sender, EventArgs e)
        {
            string x = comboBox1.Text;
            string y = comboBox3.Text;
            //comboBox1.DataSource = con.getTable("select name from customer");
            //comboBox1.DisplayMember = "name";
            comboBox3.DataSource = con.getTable(string.Format("select distinct(city) as city from customer where name = '{0}'",x));
            comboBox3.DisplayMember = "city";
            //comboBox1.Text = x;
            //comboBox3.Text = y;
        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" && comboBox3.Text == "")
                return;
            level = 3;

            name = comboBox1.Text;
            city = comboBox3.Text;

            group = con.exesclr(string.Format("select min([group]) as [group] from line where city = '{0}'", city));

            comboBox1.Text = name;
            comboBox3.Text = city;
            label11.Text = datefrom.Year.ToString() + "-" + dateto.Year.ToString();
            textBox1.Text = "";
            ledger();

            dateTimePicker1.Value = datefrom;
            dateTimePicker2.Value = dateto;
            label11.Text = getlabel();
            lb();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (level == 3)
            {
                if (group == "")
                    return;
                level--;
                comboBox3.Text = group;
                comboBox1.Text = "";
                level2("%");
                textBox1.Text = "";

                comboBox1.Text = "";
            }
            else if (level == 2)
            {
                home("");
                level = 1;
                //comboBox1.Text = "Name";
                //comboBox3.Text = "City";

                comboBox3.Text = "";
            }
            la();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (level == 1)
            {
                if (group == "")
                    return;
                level++;
                comboBox3.Text = group;
                comboBox1.Text = "";
                level2("%");
                textBox1.Text = "";
                la();
            }
            else if (level == 2)
            {
                if (name == "" && city == "")
                    return;
                comboBox1.Text = name;
                comboBox3.Text = city;
                label11.Text = datefrom.Year.ToString() + "-" + dateto.Year.ToString();
                textBox1.Text = "";
                ledger();
                level++;
                textBox1.Text = "";

                dateTimePicker1.Value = datefrom;
                dateTimePicker2.Value = dateto;
                label11.Text = getlabel();

                comboBox1.Text = name;
                comboBox3.Text = city;
                lb();
            }
        }
        private void la()
        {
            splitContainer3.Panel2Collapsed = true;
            groupBox2.Visible = false;
            panel1.Visible = false;
            splitContainer5.Panel2Collapsed = false;
        }
        private void lb()
        {
            if (checkBox1.Checked == false)
            {
                groupBox2.Visible = false;
                splitContainer4.Panel1Collapsed = true;
                splitContainer5.Panel2Collapsed = true;
                splitContainer3.Panel2Collapsed = false;
                panel1.Visible = true;
            }
            else
                lbadvance();
        }
        private void lbadvance()
        {
            groupBox2.Visible = true;
            splitContainer4.Panel1Collapsed = false;
            splitContainer5.Panel2Collapsed = true;
            splitContainer3.Panel2Collapsed = false;
            panel1.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                lbadvance();
            }
            else
            {
                lb();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                textBox5.Text = "0.00";
                calculatetotal();
            }
        }

        private void new_ledger_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main m = (Main)(this.MdiParent);
            m.init_container(childContainer.e_NewLedger);
        }
    }
}
