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
    public partial class ManualBilling : Form
    {
        bool manual;
        AutoCompleteStringCollection src = new AutoCompleteStringCollection();
        Connection con = new Connection();
        int changed, company;
        int bill;
        int callmetercal;
        public ManualBilling()
        {
            InitializeComponent();
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            splitContainer2.Panel1Collapsed = true;
            manual = false;
            con.connent();
            company = 1;
            manual = false;
            changed = 0;
            callmetercal = 0;
            DataGridViewCellStyle cs = new DataGridViewCellStyle();
            clear();
            //comboBox1.DataSource = con.getTable("select name from customer");
            //comboBox1.DisplayMember = "name";
            //comboBox1.Text = "";
            //comboBox3.DataSource = con.getTable("select distinct(city) as city from customer");
            //comboBox3.DisplayMember = "city";
            //comboBox3.Text = "";
            //textBox6.Text = "2";
            //textBox2.Text = con.exesclr("exec maxbillno");
            cs.BackColor = Color.FromArgb(162,164, 244);
            dataGridView1.AlternatingRowsDefaultCellStyle = cs;
            dataGridView2.AlternatingRowsDefaultCellStyle = cs;
            company = 0;
            //MessageBox.Show(Vardhman.App_Code.number.num2text(12345));
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string x = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText;
            if (x == "Company" || x == "Group" || x == "Item")
            {
                TextBox t = (TextBox)e.Control;
                t.AutoCompleteCustomSource = getAutocompletedata(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentRow.Index);
                t.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                t.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                try
                {
                    TextBox t = (TextBox)e.Control;
                    t.AutoCompleteCustomSource = null;
                    t.AutoCompleteMode = AutoCompleteMode.None;
                    t.AutoCompleteSource = AutoCompleteSource.None;
                }
                catch
                {
                }
            }
        }
        private void c_CheckedChanged(object sender, EventArgs e)
        {
            total();
        }
        private AutoCompleteStringCollection getAutocompletedata(int column, int row)
        {
            string col0, col1, col2, type = "";
            try { col0 = dataGridView1.Rows[row].Cells["Company"].Value.ToString(); }
            catch { col0 = ""; }

            try { col1 = dataGridView1.Rows[row].Cells["Group"].Value.ToString(); }
            catch { col1 = ""; }

            try { col2 = dataGridView1.Rows[row].Cells["Item"].Value.ToString(); }
            catch { col2 = ""; }
            
            type = dataGridView1.Columns[column].HeaderText.ToUpper();
            src.Clear();
            if (type != "COMPANY" && type != "GROUP" && type != "ITEM")
                return src;
            string param = "";
            param += "'" + type + "',";
            param += "'" + col0 + "',";
            param += "'" + col1 + "',";
            param += "'" + col2 + "'";
            try
            {
                SqlDataReader dr = con.exereader("exec get_autocomplete " + param);
                while (dr.Read())
                {
                    src.Add(dr[0].ToString());
                }
                con.closereader();
                dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                src = null;
            }
            return src;
        }
        private void Billing_Leave(object sender, EventArgs e)
        {
            con.disconnect();
        }
        private void amtCalculation(int row)
        {
            if (row == -1)
                return;
            double qty, meter, rate, quantity, amount;
            if(callmetercal == 0)
                meterCal(row);
            callmetercal = 0;
            try { qty = Convert.ToDouble(dataGridView1.Rows[row].Cells["Quantity"].Value.ToString()); }
            catch { qty = 0; dataGridView1.Rows[row].Cells["Quantity"].Value = ""; }
            try { meter = Convert.ToDouble(dataGridView1.Rows[row].Cells["Meter"].Value.ToString()); }
            catch { meter = 0; dataGridView1.Rows[row].Cells["Meter"].Value = ""; }

            try { rate = Convert.ToDouble(dataGridView1.Rows[row].Cells["Rate"].Value.ToString()); }
            catch { rate = 0; dataGridView1.Rows[row].Cells["Rate"].Value = ""; }
            if (meter != 0)
                quantity = meter;
            else
                quantity = qty;
            amount = quantity * rate;
            dataGridView1.Rows[row].Cells["Amount"].Value = roundOff.round(amount);
            total();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string x = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            if (x == "Quantity" || x == "Rate" || x == "Meter")
                amtCalculation(e.RowIndex);
            string cellValue;
            try
            {
                cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            catch
            {
                cellValue = "";
            }
                if (x == "Item Details" && cellValue.Trim() != "")
            {
                meterCal(e.RowIndex);
            }
            if (x == "Item")
            {
                string company, group, item;
                try
                {
                    company = dataGridView1.Rows[e.RowIndex].Cells["Company"].Value.ToString();
                }
                catch
                {
                    company = "";
                }
                try
                {
                    group = dataGridView1.Rows[e.RowIndex].Cells["Group"].Value.ToString();
                }
                catch
                {group = "";
                }
                try
                {
                    item = dataGridView1.Rows[e.RowIndex].Cells["Item"].Value.ToString();
                }
                catch
                {
                    item= "";
                }
                string rate = con.exesclr(string.Format("exec get_price '{0}','{1}','{2}'", company, group, item));
                if (rate == "-1")
                {
                    try{
                        string xyz;
                        Supporter.set_zero(dataGridView1.Rows[e.RowIndex].Cells["Rate"].Value.ToString() , out xyz);
                        rate = xyz;
                    }
                    catch
                    {
                        rate = "0.00";
                    }
                }
                try
                {
                    string[] itemforrate = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Split(Convert.ToChar(" "));
                    double tagrate = RateCalculation.rateCalc(itemforrate);
                    string xyz;
                    if (tagrate != 0)
                    {
                        Supporter.set_zero(tagrate.ToString(), out xyz);
                        dataGridView1.Rows[e.RowIndex].Cells["Rate"].Value = xyz;
                    }
                    else
                    {
                        Supporter.set_zero(rate ,out xyz);
                        dataGridView1.Rows[e.RowIndex].Cells["Rate"].Value = xyz;
                    }
                }
                catch
                {

                }
            }
        }
        private void meterCal(int r)
        {
            Calcmeterdetail detail = new Calcmeterdetail();
            detail.qty = ""; detail.meter = "";
            string meter , group , company , item , qty = "", meter_dg = "";
            if (dataGridView1.Rows[r].Cells["Note"].Value != null)
                meter = dataGridView1.Rows[r].Cells["Note"].Value.ToString();
            else
                return;
            if (dataGridView1.Rows[r].Cells["Company"].Value != null)
                company = dataGridView1.Rows[r].Cells["Company"].Value.ToString();
            else company = "";
            if (dataGridView1.Rows[r].Cells["Group"].Value != null)
                group = dataGridView1.Rows[r].Cells["Group"].Value.ToString();
            else
                group = "";
            if (dataGridView1.Rows[r].Cells["Item"].Value != null)
                item = dataGridView1.Rows[r].Cells["Item"].Value.ToString();
            else
                item = "";
            if (dataGridView1.Rows[r].Cells["Quantity"].Value != null)
                qty = dataGridView1.Rows[r].Cells["Quantity"].Value.ToString();
            if (dataGridView1.Rows[r].Cells["Meter"].Value != null)
                meter_dg = dataGridView1.Rows[r].Cells["Meter"].Value.ToString();

            detail.calc(meter,company ,group ,item ,qty , meter_dg);
            changed = 1;
            if(detail.qty.Trim() != "")
            dataGridView1.Rows[r].Cells["Quantity"].Value = detail.qty;
            changed = 1;
            if(detail.meter.Trim()!="")
            dataGridView1.Rows[r].Cells["Meter"].Value = detail.meter;
            callmetercal = 1;
            amtCalculation(r);
            changed = 0;
        }
        private void comboBox2_Enter(object sender, EventArgs e)
        {
            string x = comboBox2.Text;
            DataSet ds = con.dsentry("select distinct(name) as name from transport where name is not null and name <> ''", "transport");
            comboBox2.DataSource = ds.Tables[0];
            comboBox2.DisplayMember = "name";
            comboBox2.Text = x;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == 8 || e.KeyChar == 9 || e.KeyChar == 10 || e.KeyChar == 11 || e.KeyChar == 12 || e.KeyChar == 46 || (e.KeyChar >= 48 && e.KeyChar <= 57)))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == 8 || e.KeyChar == 9 || e.KeyChar == 10 || e.KeyChar == 11 || e.KeyChar == 12 || (e.KeyChar >= 48 && e.KeyChar <= 57)))
                e.Handled = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (changed == 1)
            {
                changed = 0;
                return;
            }
                string x = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                if (x == "Rate")
                    try
                    {
                        string xyz;
                        Supporter.set_zero(dataGridView1.Rows[e.RowIndex].Cells["Rate"].Value.ToString(), out xyz);
                        dataGridView1.Rows[e.RowIndex].Cells["Rate"].Value = xyz;
                    }
                    catch { }
                if (x == "Quantity" || x == "Meter" || x == "Rate")
                    amtCalculation(e.RowIndex);
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    try
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                    }
                    catch { }
                }
        if (x == "Amount")
            total();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to clear all item in this window? this will delete all item in this window and changes will remain unchanged" , "Warning" , MessageBoxButtons.OKCancel , MessageBoxIcon.Warning ) == DialogResult.OK)
                clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "X")
                {
                    string y = "";
                    if (dataGridView1.CurrentRow.Cells["Company"].Value != null)
                        y += dataGridView1.CurrentRow.Cells["Company"].Value.ToString() + " ";
                    if (dataGridView1.CurrentRow.Cells["Group"].Value != null)
                        y += dataGridView1.CurrentRow.Cells["Group"].Value.ToString() + " ";
                    if (dataGridView1.CurrentRow.Cells["Item"].Value != null)
                        y += dataGridView1.CurrentRow.Cells["Item"].Value.ToString() + " ";
                    try
                    {
                        if (MessageBox.Show("Are you sure that you want to delete item " + y, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                    }
                    catch { }
                }
            }
            catch
            {

            }
        }
        private void total()
        {
            double total = 0,expper,exp,trans,grandtotal , rg;
            if (textBox9.Text == "")
                rg = 0;
            else rg = Convert.ToDouble(textBox9.Text);
            if (splitContainer2.Panel1Collapsed == false)
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[8].Value != null)
                    {
                        total += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value.ToString());
                    }
                }
            else
            {
                string xyz;
                Supporter.set_two_digit_precision(textBox3.Text, out xyz);
                total = Convert.ToDouble(xyz);
            }
            double total1 = total;
            total -= rg;
            if (textBox6.Text != "")
                expper = Convert.ToDouble(textBox6.Text);
            else
                expper = 0;
            if (manual == false)
                exp = Convert.ToDouble(roundOff.round(total * expper / 100));
            else
            {
                string abc;
                Supporter.set_two_digit_precision(textBox4.Text, out abc);
                exp = Convert.ToDouble(abc);
            }
            if (textBox1.Text == "")
                trans = 0;
            else
                trans = Convert.ToDouble(textBox1.Text);
            if (rad_cd.Checked == true)
            {
                grandtotal =Convert.ToDouble(roundOff.round(Convert.ToString(total - exp + trans)));
            }
            else
                grandtotal =Convert.ToDouble(roundOff.round(Convert.ToString(total + exp + trans)));
            textBox3.Text = roundOff.round(total1);
            if (rad_cd.Checked == true)
                textBox4.Text = roundOff.withpoint(Convert.ToString(Math.Abs(grandtotal - total - trans )));
            else
                textBox4.Text = roundOff.withpoint(Convert.ToString(Math.Abs((grandtotal-total-trans ))));
            textBox1.Text = roundOff.withpoint(trans.ToString());
            textBox5.Text =roundOff.withpoint(grandtotal.ToString());
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            total();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            total();
            if (checkBox1.Checked == true)
            {
                lbl_exp_per.Text = "CD%";
                lbl_exp.Text = "CD";
            }
            else
            {
                lbl_exp.Text = "EXP";
                lbl_exp_per.Text = "EXP%";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string name = "";
            //if (comboBox1.Text == "System.Data.DataRowView")
            //    return;
            //DataTable dt = con.getTable(string.Format("exec get_duplicate '{0}'", comboBox1.Text));
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow dr = dt.Rows[0];
            //    if (dr[0].ToString() == "0")
            //        return;
            //    name += "Name: " + dr[0].ToString() + " City:" + dr[1].ToString() + Environment.NewLine;
            //}
            //MessageBox.Show("There are duplicate customers with same name " + Environment.NewLine + name, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Billno cannot be empty");
                textBox2.Focus();
                return;
            }
            if (button1.Text == "Save")
            {
                string date = dateTimePicker1.Text;
                string x = con.exesclr(string.Format("exec check_manual_billno {0} , '{1}'" , textBox2.Text , date));
                if (x != "0" && x != "1")
                {
                    MessageBox.Show("Billnumber already in use");
                    //textBox2.Text = x;
                }
                else if (x == "0")
                    return;
            }
            string abc = "0";
            if (button1.Text != "Save")
                abc = "1";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x = con.exesclr(string.Format("exec get_transportcharge'{0}' , '{1}'", comboBox3.Text, comboBox2.Text));
            if (x != "0")
            {
                textBox1.Text = x;
                total();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private int chkb4save()
        {
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("cannot save Billno is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("cannot save Total is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            if (textBox6.Text == "")
                textBox6.Text = "0.00";
            //if (textBox6.Text.Trim() == "")
            //{
            //    MessageBox.Show("cannot save Expense Percent is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return 0;
            //}
            if (comboBox1.Text.Trim() == "" || comboBox3.Text.Trim() == "")
            {
                MessageBox.Show("cannot save Custmer name / city is inorrect");
                return 0;
            }
            if (textBox4.Text.Trim() == "")
            {
                MessageBox.Show("cannot save Expenses is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            if (textBox5.Text.Trim() == "")
            {
                textBox5.Text = "0.00";
            }
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("cannot save Grand Total is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            string correction = "";
            int flag = 1;
            DataGridViewCellStyle red = new DataGridViewCellStyle();
            DataGridViewCellStyle white = new DataGridViewCellStyle();
            DataGridViewCellStyle voilet = new DataGridViewCellStyle();
            red.BackColor = Color.Red;
            bool error = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells["Quantity"].Value == null || dataGridView1.Rows[i].Cells["Quantity"].Value.ToString().Trim() == "" || dataGridView1.Rows[i].Cells["Quantity"].Value.ToString().Trim() == "0")
                {
                    flag = 0;
                    try
                    {
                        correction += dataGridView1.Rows[i].Cells["Company"].Value.ToString() + " ";
                    }
                    catch { }
                    try
                    {
                        correction += dataGridView1.Rows[i].Cells["Group"].Value.ToString() + " ";
                    }
                    catch { }
                    try
                    {
                        correction += dataGridView1.Rows[i].Cells["Item"].Value.ToString() + " ";
                    }
                    catch { }
                    correction+= "Quantity Undefined";
                    correction+= Environment.NewLine;
                    dataGridView1.Rows[i].DefaultCellStyle = red;
                    error = true;
                }
                else if (dataGridView1.Rows[i].Cells["Rate"].Value == null || dataGridView1.Rows[i].Cells["Rate"].Value.ToString().Trim() == "" || dataGridView1.Rows[i].Cells["Rate"].Value.ToString().Trim() == "0" || dataGridView1.Rows[i].Cells["Rate"].Value.ToString().Trim() == "0.00")
                {
                    flag = 0;
                    try
                    {
                        correction += dataGridView1.Rows[i].Cells["Company"].Value.ToString() + " ";
                    }
                    catch { }
                    try
                    {
                        correction += dataGridView1.Rows[i].Cells["Group"].Value.ToString() + " ";
                    }
                    catch { }
                    try
                    {
                        correction += dataGridView1.Rows[i].Cells["Item"].Value.ToString() + " ";
                    }
                    catch { }
                    correction += "Rate is incorrect";
                    correction += Environment.NewLine;
                    dataGridView1.Rows[i].DefaultCellStyle = red;
                    error = true;
                }
            }
            if (error == true)
            {
                if (MessageBox.Show("There are some error in the item entry marked by red are you sure to continue save / print??", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return 0;
            }
            if (correction != "")
            {
                label16.Visible = true;
                label16.BackColor = Color.Red;
                label16.ForeColor = Color.Red;
                return 0;
            }
            label16.Visible = true;
            label16.BackColor = Color.Green;
            label16.ForeColor = Color.Green;
            //MessageBox.Show(correction, "Corrections Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            total();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                amtCalculation(i);
            }
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Billnumber cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                textBox2.Select();
                return 0;
            }
            string date = dateTimePicker1.Text;
            string x = con.exesclr(string.Format("exec check_manual_billno {0} , '{1}'" , textBox2.Text , date));
            if (button1.Text == "Save")
            {
                if (x != "0" && x != "1")
                {
                    MessageBox.Show("Billnumber already in use");
                    return 0;
                    //textBox2.Text = x;
                }
            }
            else if (x == "0" && button1.Text != "Save")
            {
                MessageBox.Show("Bill Number dosenot exists");
                return 0;
            }
            string abc = "0";
            if (button1.Text != "Save")
                abc = "1";
            return 1;
        }
        private int save()
        {
            if (chkb4save() == 0)
            {
                label16.Visible = true;
                label16.BackColor = Color.Red;
                label16.ForeColor = Color.Red;
                return 0;
            }
            label16.Visible = true;
            label16.BackColor = Color.Green;
            label16.ForeColor = Color.Green;
            if (button1.Text == "Save")
            {
                insupd ins = new insupd();
                ins.ShowDialog();
                Boolean update = ins.update;
                Boolean ok = ins.ok;
                if (ok == false)
                    return 0;
                string type;
                if (checkBox1.Checked == false)
                    type = "NET AMOUNT TO PAY";
                else
                    type = "PAID BY CASH";
                string rgtotal = "0.00";
                if (textBox9.Text.Trim() != "")
                    rgtotal = textBox9.Text.Trim();
                string iscd;
                if (rad_exp.Checked == true)
                    iscd = "0";
                else
                    iscd = "1";
                string z = con.exesclr(string.Format("exec add_manual_bill_master'{0}' , '{1}' , '{2}' ,  {3} , {4} , {5} , {6} , '{7}' , {8} , '{9}' , {10} , '{11}' , '{12}' , '{13}' , {14} , {15}", comboBox1.Text.Trim(), comboBox3.Text.Trim(), dateTimePicker1.Text.ToString().Trim().Split(Convert.ToChar(" "))[0], textBox2.Text.Trim(), textBox3.Text.Trim(), textBox6.Text.Trim(), textBox4.Text.Trim(), comboBox2.Text.Trim(), textBox1.Text.Trim(), textBox8.Text.Trim(), textBox5.Text.Trim(), textBox7.Text.Trim(), type , textBox10.Text , rgtotal , iscd));
                if (z == "0")
                {
                    MessageBox.Show("Company not created first create the company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    company = 1;
                    return 0;
                }
                else if (z == "-1")
                {
                    MessageBox.Show("Bill Number is already in use", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string company, group, item, meterdetail, qty, meter, rate, amount, metercount, upd;
                    try { company = dataGridView1.Rows[i].Cells["Company"].Value.ToString().Trim(); }
                    catch { company = ""; }
                    try { group = dataGridView1.Rows[i].Cells["Group"].Value.ToString().Trim(); }
                    catch { group = ""; }
                    try { item = dataGridView1.Rows[i].Cells["Item"].Value.ToString().Trim(); }
                    catch { item = ""; }
                    try { meterdetail = dataGridView1.Rows[i].Cells["Note"].Value.ToString().Trim(); }
                    catch { meterdetail = ""; }
                    try { qty = dataGridView1.Rows[i].Cells["Quantity"].Value.ToString().Trim(); }
                    catch { qty = ""; }
                    try { meter = dataGridView1.Rows[i].Cells["Meter"].Value.ToString().Trim(); }
                    catch { meter = ""; }
                    try { rate = dataGridView1.Rows[i].Cells["Rate"].Value.ToString().Trim(); }
                    catch { rate = ""; }
                    try { amount = dataGridView1.Rows[i].Cells["Amount"].Value.ToString().Trim(); }
                    catch { amount = ""; }
                    try { if (dataGridView1.Rows[i].Cells["meter"].Value == null || dataGridView1.Rows[i].Cells["meter"].Value.ToString() == "" )metercount = "NO"; else metercount = "YES"; }
                    catch { metercount = "NO"; }
                    upd = update.ToString();
                    con.exeNonQurey(string.Format("exec add_manual_item {0} , '{1}' , '{2}' , '{3}' , '{4}' , {5} , '{6}' , {7} , {8} , '{9}' , '{10}' , {11}", textBox2.Text.Trim(), company, group, item, meterdetail, qty, meter, rate, amount, metercount.Trim(), upd, "0"));
                }
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    string item, qty, rate, amount;
                    try { item = dataGridView2.Rows[i].Cells[0].Value.ToString().Trim(); }
                    catch { item = ""; }
                    try { qty = dataGridView2.Rows[i].Cells[1].Value.ToString().Trim(); }
                    catch { qty = ""; }
                    try { rate = dataGridView2.Rows[i].Cells[2].Value.ToString().Trim(); }
                    catch { rate = ""; }
                    try { amount = dataGridView2.Rows[i].Cells[3].Value.ToString().Trim(); }
                    catch { amount = ""; }
                    con.exeNonQurey(string.Format("exec add_manual_item {0} , '{1}' , '{2}' , '{3}' , '{4}' , {5} , '{6}' , {7} , {8} , '{9}' , '{10}' , {11}", textBox2.Text.Trim(), "", "", item, "", qty, "", rate, amount, "", "false", "1"));
                }
                create_backup.create();
                MessageBox.Show("Bill Saved Successfully", "Saved Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.exeNonQurey(string.Format("exec temp_manual_bill_allocate {0} , '{1}'", textBox2.Text , dateTimePicker1.Text));
                clear();
                return 1;
            }
            else
            {
                insupd ins = new insupd();
                ins.ShowDialog();
                Boolean update = ins.update;
                Boolean ok = ins.ok;
                if (ok == false)
                    return 0;
                string type;
                if (checkBox1.Checked == false)
                    type = "NET AMOUNT TO PAY";
                else
                    type = "PAID BY CASH";
                string rgtotal = "0.00";
                if (textBox9.Text != "")
                    rgtotal = textBox9.Text;
                string iscd;
                if (rad_exp.Checked == true)
                    iscd = "0";
                else
                    iscd = "1";
                string z = con.exesclr(string.Format("exec upd_manual_bill_master'{0}' , '{1}' , '{2}' ,  {3} , {4} , {5} , {6} , '{7}' , {8} , '{9}' , {10} , '{11}' , '{12}' , {13} , '{14}' , {15} , {16}", comboBox1.Text.Trim(), comboBox3.Text.Trim(), dateTimePicker1.Text.ToString().Trim().Split(Convert.ToChar(" "))[0], textBox2.Text.Trim(), textBox3.Text.Trim(), textBox6.Text.Trim(), textBox4.Text.Trim(), comboBox2.Text.Trim(), textBox1.Text.Trim(), textBox8.Text.Trim(), textBox5.Text.Trim(), textBox7.Text.Trim(), type , rgtotal , textBox10.Text , lblid.Text , iscd));
                if (z == "0")
                {
                    MessageBox.Show("Company not created first create the company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    company = 1;
                    return 0;
                }
                else if (z == "-1")
                {
                    MessageBox.Show("Bill Number dosenot exists cannot save data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
                con.exeNonQurey(string.Format("exec del_manual_billdetail {0} , '{1}'" , textBox2.Text , dateTimePicker1.Text));
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string company, group, item, meterdetail, qty, meter, rate, amount, metercount, upd;
                    try { company = dataGridView1.Rows[i].Cells["Company"].Value.ToString().Trim(); }
                    catch { company = ""; }
                    try { group = dataGridView1.Rows[i].Cells["Group"].Value.ToString().Trim(); }
                    catch { group = ""; }
                    try { item = dataGridView1.Rows[i].Cells["Item"].Value.ToString().Trim(); }
                    catch { item = ""; }
                    try { meterdetail = dataGridView1.Rows[i].Cells["Note"].Value.ToString().Trim(); }
                    catch { meterdetail = ""; }
                    try { qty = dataGridView1.Rows[i].Cells["Quantity"].Value.ToString().Trim(); }
                    catch { qty = ""; }
                    try { meter = dataGridView1.Rows[i].Cells["Meter"].Value.ToString().Trim(); }
                    catch { meter = ""; }
                    try { rate = dataGridView1.Rows[i].Cells["Rate"].Value.ToString().Trim(); }
                    catch { rate = ""; }
                    try { amount = dataGridView1.Rows[i].Cells["Amount"].Value.ToString().Trim(); }
                    catch { amount = ""; }
                    try { if (dataGridView1.Rows[i].Cells["meter"].Value != null)metercount = "NO"; else metercount = "YES"; }
                    catch { metercount = "yes"; }
                    upd = update.ToString();
                    con.exeNonQurey(string.Format("exec add_manual_item {0} , '{1}' , '{2}' , '{3}' , '{4}' , {5} , '{6}' , {7} , {8} , '{9}' , '{10}' , {11}", textBox2.Text.Trim(), company, group, item, meterdetail, qty, meter, rate, amount, metercount, upd, "0"));
                }
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    string item, qty, rate, amount;
                    try { item = dataGridView2.Rows[i].Cells[0].Value.ToString().Trim(); }
                    catch { item = ""; }
                    try { qty = dataGridView2.Rows[i].Cells[1].Value.ToString().Trim(); }
                    catch { qty = ""; }
                    try { rate = dataGridView2.Rows[i].Cells[2].Value.ToString().Trim(); }
                    catch { rate = ""; }
                    try { amount = dataGridView2.Rows[i].Cells[3].Value.ToString().Trim(); }
                    catch { amount = ""; }
                    con.exeNonQurey(string.Format("exec add_manual_item {0} , '{1}' , '{2}' , '{3}' , '{4}' , {5} , '{6}' , {7} , {8} , '{9}' , '{10}' , {11}", textBox2.Text.Trim(), "", "", item, "", qty, "", rate, amount, "", "false", "1"));
                }

                MessageBox.Show("Bill Updated Successfully", "Saved Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.exeNonQurey(string.Format("exec temp_manual_bill_allocate {0} , '{1}'", textBox2.Text , dateTimePicker1.Text));
                clear();
                return 1;
            }
            return 1;
        }
        private void clear()
        {
            button11.Enabled = false;
            dateTimePicker1.Enabled = true;
            comboBox1.DataSource = con.getTable("select name from customer where (name !='' or name is not null) and type = 'CUSTOMER'");
            comboBox1.DisplayMember = "name";
            comboBox1.Text = "";
            label16.Visible = false;
            company = 0;
            comboBox3.DataSource = con.getTable("select distinct(city) as city from customer where city !='' or city is not null");
            comboBox3.DisplayMember = "city";
            comboBox3.Text = "";
            textBox2.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            checkBox1.Checked = false;
            textBox9.Text = "0.00";
            textBox6.Text = "2.00";
            rad_cd.Checked = false;
            rad_exp.Checked = true;
            textBox7.Text = "";
            comboBox2.DataSource = con.getTable("select name from transport");
            comboBox2.DisplayMember = "name";
            comboBox2.Text = "";
            textBox8.Text = "";
            textBox3.Text = "0.00";
            textBox4.Text = "0.00";
            textBox1.Text = "0.00";
            textBox10.Text = "";
            textBox5.Text = "0.00";
            button1.Text = "Save";
            button2.Text = "Print and Save";
            textBox2.ReadOnly = false;
            dateTimePicker1.Enabled = true;
            comboBox1.Select();
            comboBox1.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            rgcal();
        }
        private void rgcal()
        {
            double qty, rate, amount, totalamt = 0;
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                try { qty = Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value.ToString()); }
                catch { return; }
                try { rate = Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value.ToString()); }
                catch { return; }
                amount = qty * rate;
                totalamt += amount;
                dataGridView2.Rows[i].Cells[3].Value = roundOff.withpoint(amount.ToString());
            }
            textBox9.Text = roundOff.withpoint(totalamt.ToString());
        }
        private void button7_Click(object sender, EventArgs e)
        {
            splitContainer3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            splitContainer3.Visible = true;
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            rgcal();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            total();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            string name = "";
            if (comboBox1.Text == "System.Data.DataRowView")
                return;
            DataTable dt = con.getTable(string.Format("exec get_duplicate '{0}'", comboBox1.Text));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (dr[0].ToString() == "0")
                    return;
                name += "Name: " + dr[0].ToString() + " City:" + dr[1].ToString() + Environment.NewLine;
            }
            MessageBox.Show("There are duplicate customers with same name " + Environment.NewLine + name, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (textBox7.Text == "")
                textBox7.Text = "SELF";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = save();
            if (company == 0 && x == 1)
            {
                Report_Viewercs RP = new Report_Viewercs();

                RP.loadrpt("worg");
                RP.Show();
            }
            company = 0;
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            string x = comboBox1.Text;
            comboBox1.DataSource = con.getTable("select distinct(name) as name from customer where (name !='' or name is not null) and type = 'CUSTOMER'");
            comboBox1.DisplayMember = "name";
            comboBox1.Text = x;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            total();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //if (textBox2.Text.Trim() == "")
            //{
            //    MessageBox.Show("Billnumber cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    textBox2.Focus();
            //    textBox2.Select();
            //    return;
            //}
         }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string x = dataGridView1.Columns[e.ColumnIndex].HeaderText,y;
            try
            {
                y = dataGridView1.Rows[e.RowIndex].Cells["group"].Value.ToString();
            }
            catch
            {
                y = "";
            }
            if ((x == "Group" || x == "Item") && y == "")
            {
                try
                {
                    dataGridView1.Rows[e.RowIndex].Cells["group"].Value = dataGridView1.Rows[e.RowIndex - 1].Cells["group"].Value.ToString();
                }
                catch { }
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_Enter(object sender, EventArgs e)
        {
            string combo = comboBox3.Text;
            comboBox3.DataSource = con.getTable(string.Format("select distinct(city) as city from customer where name = '{0}' and city <> ''" , comboBox1.Text));
            comboBox3.DisplayMember = "city";
            if(combo != "")
            comboBox3.Text = combo;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Account_Head ah = new Account_Head();
            ah.getdetail(comboBox1.Text, comboBox3.Text);
            ah.ShowDialog();
            ah.BringToFront();
        }

        private void Billing_dataentry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(dataGridView1.Rows.Count>1)
            if (MessageBox.Show("Are you sure you want to close this make sure that all unsaved data will be lost", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                e.Cancel = true;
        }
        public void getbill(int num)
        {
            bill = num;
            dateTimePicker1.Enabled = false;
            lblid.Text = bill.ToString();
            if (dataGridView1.Rows.Count > 1)
            if (MessageBox.Show("All unsaved data will be lost did you want to continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;
            clear();
            textBox2.ReadOnly = true;
            DataTable dt = con.getTable(string.Format("select name , city , date as date , total , expensesper , expenses , transport , transportcharge , transportnumber , grandtotal , through , paymenttype , note , rgtotal , billno from view_manual_bill_master where id = '{0}'", bill.ToString()));
            string rgtotal , name, city, date, total, expensesper, expenses, transport, transportcharge, transportnumber, grandtotal, through, paymenttype;
            name = dt.Rows[0][0].ToString();
            city = dt.Rows[0][1].ToString();
            date = dt.Rows[0][2].ToString();
            total = dt.Rows[0][3].ToString();
            expensesper = dt.Rows[0][4].ToString();
            expenses = dt.Rows[0][5].ToString();
            transport = dt.Rows[0][6].ToString();
            transportcharge = dt.Rows[0][7].ToString();
            transportnumber = dt.Rows[0][8].ToString();
            grandtotal = dt.Rows[0][9].ToString();
            through = dt.Rows[0][10].ToString();
            paymenttype = dt.Rows[0][11].ToString();
            textBox10.Text = dt.Rows[0][12].ToString();
            rgtotal = dt.Rows[0][13].ToString();
            textBox9.Text = rgtotal;
            comboBox1.Text = name;
            comboBox3.Text = city;
            textBox7.Text = through;
            button1.Text = "Update";
            button2.Text = "Print and Update";
            textBox2.Text = dt.Rows[0][14].ToString();
            dateTimePicker1.Text = date;
            //grandtotal - transportcharge - total - <0
            if (paymenttype == "NET AMOUNT TO PAY")
                checkBox1.Checked = false;
            else
                checkBox1.Checked = true;
            textBox6.Text = expensesper;
            comboBox2.Text = transport;
            textBox8.Text = transportnumber;
            textBox3.Text = total;
            textBox4.Text = expenses;
            textBox1.Text = transportcharge;
            textBox5.Text = grandtotal;
            if (is_cd(grandtotal, total, rgtotal, transportcharge))
                rad_cd.Checked = true;
            else
                rad_exp.Checked = true;
            DataTable dtitem = con.getTable(string.Format("select isnull(company , '') as company , isnull([group] , '') as [group] , isnull(item , '') as item , isnull(meterdetail , '') as meterdetail , isnull(qty , 0) as qty , meter , rate , amount , isrg from manual_bill_detail where billid = '{0}'", bill.ToString()));
            double rgamt = 0;
            for (int i = 0; i < dtitem.Rows.Count; i++)
            {
                
                if (dtitem.Rows[i][8].ToString() == "False")
                {
                    int z = dataGridView1.Rows.Add();
                    changed = 1;
                    dataGridView1.Rows[z].Cells["Company"].Value = dtitem.Rows[i][0].ToString();
                    changed = 1;
                    dataGridView1.Rows[z].Cells["Group"].Value = dtitem.Rows[i][1].ToString();
                    changed = 1;
                    dataGridView1.Rows[z].Cells["Item"].Value = dtitem.Rows[i][2].ToString();
                    changed = 1; 
                    dataGridView1.Rows[z].Cells["Note"].Value = dtitem.Rows[i][3].ToString();
                    changed = 1;
                    dataGridView1.Rows[z].Cells["Quantity"].Value = dtitem.Rows[i][4].ToString();
                    changed = 1;
                    dataGridView1.Rows[z].Cells["Meter"].Value = dtitem.Rows[i][5].ToString();
                    changed = 1;
                    dataGridView1.Rows[z].Cells["Rate"].Value = dtitem.Rows[i][6].ToString();
                    changed = 1;
                    dataGridView1.Rows[z].Cells["Amount"].Value = dtitem.Rows[i][7].ToString();
                    changed = 1;
                }
                else
                {
                    int z1 = dataGridView2.Rows.Add();
                    dataGridView2.Rows[z1].Cells["RGItem"].Value = dtitem.Rows[i][2].ToString();
                    dataGridView2.Rows[z1].Cells["RGQty"].Value = dtitem.Rows[i][4].ToString();
                    dataGridView2.Rows[z1].Cells["RGRate"].Value = dtitem.Rows[i][6].ToString();
                    dataGridView2.Rows[z1].Cells["RGamount"].Value = dtitem.Rows[i][7].ToString();
                    rgamt = rgamt + Convert.ToDouble(dtitem.Rows[i][7].ToString());
                }
                changed = 0;
            }
            //textBox9.Text = rgamt.ToString();
            textBox2.ReadOnly = true;
            //dateTimePicker1.Enabled = false;
        }
        private bool is_cd(string grandtotal, string total, string rgtotal, string transportcharge)
        {
            string gtot , tot , rgtot , trans;
            Supporter.set_two_digit_precision(grandtotal, out gtot);
            Supporter.set_two_digit_precision(total, out tot);
            Supporter.set_two_digit_precision(rgtotal, out rgtot);
            Supporter.set_two_digit_precision(transportcharge, out trans);
            float g, t, r, tr;
            g = float.Parse(gtot);
            t = float.Parse(tot);
            r = float.Parse(rgtot);
            tr = float.Parse(trans);
            if (g - t + r - tr >= 0)
                return false;
            else
                return true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ListManualBills l = new ListManualBills();
            l.getbde(this);
            l.ShowDialog();
            l.BringToFront();
            button11.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*Check_items ci = new Check_items();
            DataTable dt = new DataTable();
            dt.Columns.Add("Company");
            dt.Columns.Add("Group");
            dt.Columns.Add("Item");
            dt.Columns.Add("Itemdetail");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Meter");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dt.Rows.Add();
                try
                {
                    dt.Rows[i]["Company"] = dataGridView1.Rows[i].Cells["Company"].Value.ToString();
                }
                catch
                {
                    dt.Rows[i]["Company"] = "";
                }
                try
                {
                    dt.Rows[i]["Group"] = dataGridView1.Rows[i].Cells["Group"].Value.ToString();
                }
                catch
                {
                    dt.Rows[i]["Group"] = "" ;
                }
                try
                {
                    dt.Rows[i]["Item"] = dataGridView1.Rows[i].Cells["Item"].Value.ToString();
                }
                catch
                {
                    dt.Rows[i]["Item"] = "";
                } try
                {
                    dt.Rows[i]["Itemdetail"] = dataGridView1.Rows[i].Cells["Note"].Value.ToString();
                }
                catch
                {
                    dt.Rows[i]["Itemdetail"] = "";
                }
                try
                {
                    dt.Rows[i]["Quantity"] = dataGridView1.Rows[i].Cells["Quantity"].Value.ToString();
                }
                catch
                {
                    dt.Rows[i]["Quantity"] = "";
                } 
                try
                {
                    dt.Rows[i]["Meter"] = dataGridView1.Rows[i].Cells["Meter"].Value.ToString();
                }
                catch
                {
                    dt.Rows[i]["Meter"] = "";
                }
            }
            ci.gettable(dt);
            ci.Show();*/
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("check");
            dt1.Columns.Add("company");
            dt1.Columns.Add("itemtype");
            dt1.Columns.Add("itemname");
            dt1.Columns.Add("itemdetail");
            dt1.Columns.Add("quantity");
            dt1.Columns.Add("meter");
            dt1.Columns.Add("rate");
            dt1.Columns.Add("id");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dt1.Rows.Add();
                dt1.Rows[i]["check"] = "Uncheck";
                dt1.Rows[i]["company"] = get_bill_body_cell_value(i, "Company");
                dt1.Rows[i]["itemtype"] = get_bill_body_cell_value(i, "Group");
                dt1.Rows[i]["itemname"] = get_bill_body_cell_value(i, "Item");
                dt1.Rows[i]["itemdetail"] = get_bill_body_cell_value(i, "Note");
                dt1.Rows[i]["quantity"] = get_bill_body_cell_value(i, "Quantity");
                dt1.Rows[i]["meter"] = get_bill_body_cell_value(i, "Meter");
                dt1.Rows[i]["rate"] = get_bill_body_cell_value(i, "Rate");
                dt1.Rows[i]["id"] = i.ToString();
            }
            Item_Check ic = new Item_Check();
            ic.set_item_check_datatable(dt1 , comboBox1.Text , comboBox3.Text);
            ic.WindowState = FormWindowState.Maximized;
            ic.ShowDialog();
            DataGridViewCellStyle red = new DataGridViewCellStyle();
            red.BackColor = Color.Red;
            DataGridViewCellStyle white = new DataGridViewCellStyle();
            DataGridViewCellStyle silver = new DataGridViewCellStyle();
            silver.BackColor = Color.FromArgb(162, 164, 244);
            white.BackColor = Color.White;
            for (int i = 0; i < ic.al.Count; i++)
            {
                dataGridView1.Rows[(int)ic.al[i]].DefaultCellStyle = red;
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (!ic.al.Contains(i))
                {
                    if (i % 2 == 0)
                        dataGridView1.Rows[i].DefaultCellStyle = white;
                    else
                        dataGridView1.Rows[i].DefaultCellStyle = silver;
                }
            }
            if (ic.al.Count != 0)
                label16.BackColor = Color.Red;
            else
                label16.BackColor = Color.Green;

        }
        private string get_bill_body_cell_value(int i, string x)
        {
            if (dataGridView1.Rows[i].Cells[x].Value == null)
                return "";
            return dataGridView1.Rows[i].Cells[x].Value.ToString();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text = con.exesclr("exec maxbillno");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            total();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                amtCalculation(i);
            }
        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
                textBox7.Text = "SELF";
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            DataTable dt = con.getTable("select distinct(through) as through from bill_master where through <> '' and through is not null");
            AutoCompleteStringCollection autostr = new AutoCompleteStringCollection();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                autostr.Add(dt.Rows[i][0].ToString());
            }
            textBox7.AutoCompleteCustomSource = autostr;
            if (textBox7.Text == "")
                textBox7.Text = "SELF";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_cd.Checked == true)
            {
                lbl_exp.Text = "CD";
                lbl_exp_per.Text = "CD%";
            }
            else
            {
                lbl_exp.Text = "EXP";
                lbl_exp_per.Text = "EXP%";
            }
            total();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Are you sure you want to delete \nbill number = {0} \nCustomername = {1} \nCity = {2}", textBox2.Text, comboBox1.Text, comboBox3.Text), "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
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
            con.exeNonQurey(string.Format("delete from manual_bill_detail where billid = {0}" , lblid.Text));
            con.exeNonQurey(string.Format("delete from manual_bill_master where id = {0}" , lblid.Text));
            MessageBox.Show("Bill Deleted");
            clear();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            manual = true;
            total();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel1Collapsed == true)
                splitContainer2.Panel1Collapsed = false;
            else
                splitContainer2.Panel1Collapsed = true;
        }

        private void textBox4_Leave_1(object sender, EventArgs e)
        {
            manual = true;
            total();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim() != "")
                manual = false;
            else
                manual = true;
            total();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            total();
        }
    }
}