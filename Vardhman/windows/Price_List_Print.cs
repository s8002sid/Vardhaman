using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class Price_List_Print : Form
    {
        int x;
        DataTable dtx1 , dtx2;
        public Price_List_Print()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BackgroundWorker a = new BackgroundWorker();
            a.DoWork += new DoWorkEventHandler(backgroundWorker2_DoWork);
            a.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker2_RunWorkerCompleted);
            a.RunWorkerAsync();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                rollup_datagrid(true);
            else if (e.KeyCode == Keys.Down)
                rollup_datagrid(false);
        }
        
        private void Price_List_Print_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.connent();
            dataGridView1.DataSource = con.getTable("select Company , [Type Name] , [Item Name] , Price as Rate , id from item_detail order by [Type Name] , Price");
            con.exeNonQurey("delete from price_list_print");
            DataGridViewCellStyle dgv = new DataGridViewCellStyle();
            dgv.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.ForeColor = Color.Black;
            dataGridView1.Columns[3].DefaultCellStyle = dgv;
            dataGridView1.Columns[4].Visible = false;
            txt_company.Focus();
            txt_company.Select();
        }
        #region datagridview 1 functions
        private DataTable get_data()
        {
            string company = "%", type = "%", name = "%", rate = "%";
            if (txt_company.Text != "Company")
                company = txt_company.Text.Trim() + "%";
            if (txt_type.Text != "Type")
                type = txt_type.Text.Trim() + "%";
            if (txt_name.Text != "Name")
                name = txt_name.Text.Trim() + "%";
            //if (txt_rate.Text != "Rate")
                //rate = txt_rate.Text.Trim() + "%";
            Connection con = new Connection();
            con.connent();
            DataTable dt = con.getTable(string.Format("select Company , [Type Name] , [Item Name] , Price as Rate , id from item_detail where id not in(select id from price_list_print) and company like('{0}') and [Type Name] like('{1}') and [Item Name] like '{2}' and price like('{3}') order by [Type Name] , Price", company, type, name, rate));
            con.disconnect();
            return dt;
        }
        private void rollup_datagrid(bool a)
        {
            int pos;
            if (a)
            {
                //roll up
                if (dataGridView1.SelectedCells.Count == 0)
                    pos = 0;
                else
                    pos = round_up(dataGridView1.SelectedCells[0].RowIndex, dataGridView1.Rows.Count);
            }
            else
            {
                //roll down
                if (dataGridView1.SelectedCells.Count == 0)
                    pos = 0;
                else
                    pos = round_down(dataGridView1.SelectedCells[0].RowIndex, dataGridView1.Rows.Count);
            }
            dataGridView1.SelectedRows[0].Selected = false;
            dataGridView1.Rows[pos].Selected = true;
        }
        private int round_up(int now, int max)
        {
            if (now == -1)
                return 0;
            return (max + now - 1) % max;
        }
        private int round_down(int now, int max)
        {
            if (now == -1)
                return 0;
            return (now + 1) % max;
        }
        private void item_update_box()
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            string company, type, name, rate, id;
            int row = dataGridView1.SelectedRows[0].Index;
            company = get_value(row, 0);
            type = get_value(row, 1);
            name = get_value(row, 2);
            rate = get_value(row, 3);
            id = get_value(row, 4);
            Item_Update_Popup iup = new Item_Update_Popup();
            iup.load(company, type, name, rate, id);
            iup.ShowDialog();
            dataGridView1.DataSource = get_data();
            if (dataGridView1.Rows.Count >= row)
                dataGridView1.Rows[row].Selected = true;
            else if (dataGridView1.Rows.Count == row - 1)
                dataGridView1.Rows[row - 1].Selected = true;
            else
                dataGridView1.Rows[0].Selected = true;
        }
        private string get_value(int row, int col)
        {
            if (dataGridView1.Rows[row].Cells[col].Value == null)
                return "";
            return dataGridView1.Rows[row].Cells[col].Value.ToString();
        }
        #endregion

        /*/////////////////////////////////////////////////////////////////////*/

        #region datagridview 2 functions
        private DataTable get_data2()
        {
            string company = "%", type = "%", name = "%", rate = "%";
            if (txt_company2.Text != "Company")
                company = txt_company2.Text.Trim() + "%";
            if (txt_type2.Text != "Type")
                type = txt_type2.Text.Trim() + "%";
            if (txt_name2.Text != "Name")
                name = txt_name2.Text.Trim() + "%";
            //if (txt_rate.Text != "Rate")
                //rate = txt_rate.Text.Trim() + "%";
            Connection con = new Connection();
            con.connent();
            DataTable dt = con.getTable(string.Format("select Company , type , name , Rate , id from price_list_print where company like('{0}') and type like('{1}') and name like '{2}' and rate like('{3}') order by name , rate", company, type, name, rate));
            con.disconnect();
            return dt;
        }
        private void rollup_datagrid2(bool a)
        {
            int pos;
            if (a)
            {
                //roll up
                if (dataGridView2.SelectedCells.Count == 0)
                    pos = 0;
                else
                    pos = round_up(dataGridView2.SelectedCells[0].RowIndex, dataGridView1.Rows.Count);
            }
            else
            {
                //roll down
                if (dataGridView2.SelectedCells.Count == 0)
                    pos = 0;
                else
                    pos = round_down(dataGridView2.SelectedCells[0].RowIndex, dataGridView1.Rows.Count);
            }
            dataGridView2.SelectedRows[0].Selected = false;
            dataGridView2.Rows[pos].Selected = true;
        }
        private string get_value2(int row, int col)
        {
            if (dataGridView2.Rows[row].Cells[col].Value == null)
                return "";
            return dataGridView2.Rows[row].Cells[col].Value.ToString();
        }
        #endregion

        #region Button Clicks
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            item_update_box();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.connent();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int j = dataGridView1.SelectedRows[i].Index;
                string company = get_value(j , 0);
                string type = get_value(j , 1);
                string name = get_value(j , 2);
                string rate = get_value(j , 3);
                string id = get_value(j, 4);
                con.exeNonQurey(string.Format("insert into price_list_print values({0} , '{1}' , '{2}' , '{3}' , {4})", id, company, type, name, rate));
            }
            con.disconnect();
            load_datagrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            x = 1;
            backgroundWorker1.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.connent();
            for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
            {
                int j = dataGridView2.SelectedRows[i].Index;
                string company = get_value2(j, 0);
                string type = get_value2(j, 1);
                string name = get_value2(j, 2);
                string rate = get_value2(j, 3);
                string id = get_value2(j, 4);
                con.exeNonQurey(string.Format("delete from price_list_print where id = {0}", id));
            }
            con.disconnect();
            load_datagrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            x = 2;
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion
        private void load_datagrid()
        {
            Connection con = new Connection();
            con.connent();
            dataGridView1.DataSource = con.getTable("select Company , [Type Name] , [Item Name] , Price as Rate , id from item_detail where id not in(select id from price_list_print) order by [Type Name] , Price");
            dataGridView2.DataSource = con.getTable("select company , type , name , rate ,id from price_list_print order by type , rate");
            dataGridView1.Columns[4].Visible = false;
            dataGridView2.Columns[4].Visible = false;
            DataGridViewCellStyle dgv = new DataGridViewCellStyle();
            dgv.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.ForeColor = Color.Black;
            dataGridView1.Columns[3].DefaultCellStyle = dgv;
            dataGridView2.DefaultCellStyle = dgv;
            con.disconnect();
        }

        private void txt_company2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                rollup_datagrid2(true);
            else if (e.KeyCode == Keys.Down)
                rollup_datagrid2(false);
        }

        private void txt_company2_TextChanged(object sender, EventArgs e)
        {
            BackgroundWorker a = new BackgroundWorker();
            a.DoWork += new DoWorkEventHandler(backgroundWorker3_DoWork);
            a.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker3_RunWorkerCompleted);
            a.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (x == 1)
            {
                Connection con = new Connection();
                con.connent();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    int j = i;
                    backgroundWorker1.ReportProgress(Convert.ToInt32(Math.Ceiling ((100.00 * i) / dataGridView1.Rows.Count)));
                    string company = get_value(j, 0);
                    string type = get_value(j, 1);
                    string name = get_value(j, 2);
                    string rate = get_value(j, 3);
                    string id = get_value(j, 4);
                    con.exeNonQurey(string.Format("insert into price_list_print values({0} , '{1}' , '{2}' , '{3}' , {4})", id, company, type, name, rate));
                }
                con.disconnect();
            }
            else
            {
                Connection con = new Connection();
                con.connent();
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    int j = i;
                    backgroundWorker1.ReportProgress(Convert.ToInt32(Math.Ceiling((100.00 * i) / dataGridView2.Rows.Count)));
                    string company = get_value2(j, 0);
                    string type = get_value2(j, 1);
                    string name = get_value2(j, 2);
                    string rate = get_value2(j, 3);
                    string id = get_value2(j, 4);
                    con.exeNonQurey(string.Format("delete from price_list_print where id = {0}", id));
                }
                con.disconnect();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            load_datagrid();
            progressBar1.Visible = false;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report_Viewercs rp = new Report_Viewercs();
            rp.loadrpt("pricelist");
            rp.ShowDialog();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string company = "%", type = "%", name = "%", rate = "%";
            if (txt_company.Text != "Company")
                company = txt_company.Text.Trim() + "%";
            if (txt_type.Text != "Type")
                type = txt_type.Text.Trim() + "%";
            if (txt_name.Text != "Name")
                name = txt_name.Text.Trim() + "%";
            //if (txt_rate.Text != "Rate")
                //rate = txt_rate.Text.Trim() + "%";
            Connection con = new Connection();
            con.connent();
            DataTable dt = con.getTable(string.Format("select Company , [Type Name] , [Item Name] , Price as Rate , id from item_detail where id not in(select id from price_list_print) and company like('{0}') and [Type Name] like('{1}') and [Item Name] like '{2}' and price like('{3}') order by [Type Name] , Price", company, type, name, rate));
            con.disconnect();
            dtx1 = dt;
            
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            string company = "%", type = "%", name = "%", rate = "%";
            if (txt_company2.Text != "Company")
                company = txt_company2.Text.Trim() + "%";
            if (txt_type2.Text != "Type")
                type = txt_type2.Text.Trim() + "%";
            if (txt_name2.Text != "Name")
                name = txt_name2.Text.Trim() + "%";
            //if (txt_rate.Text != "Rate")
            //rate = txt_rate.Text.Trim() + "%";
            Connection con = new Connection();
            con.connent();
            DataTable dt = con.getTable(string.Format("select Company , type , name , Rate , id from price_list_print where company like('{0}') and type like('{1}') and name like '{2}' and rate like('{3}') order by name , rate", company, type, name, rate));
            con.disconnect();
            dtx2 = dt;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled != true) 
            dataGridView1.DataSource = dtx1;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled != true)
                dataGridView2.DataSource = dtx2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 10)
            {
                MessageBox.Show("cannot delete more than 10 items at a time");
                return;
            }
            if (MessageBox.Show("Are you sure to delete these items?", "sure", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            Connection con = new Connection();
            con.connent();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                string id = get_value2(i, 4);
                con.exeNonQurey(string.Format("delete from item where id = {0}", id));
            }
            con.exeNonQurey("delete from price_list_print");
            load_datagrid();
            con.disconnect();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 10)
            {
                MessageBox.Show("cannot Merge more than 10 items at a time");
                return;
            }
            if (MessageBox.Show("Are you sure to Merge these items?", "sure", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            item_update_popup_no_insert ntn = new item_update_popup_no_insert();
            if (ntn.ShowDialog() == DialogResult.OK)
            {
                string company, type, name, rate;
                company = ntn.company;
                type = ntn.type;
                name = ntn.name;
                rate = ntn.rate;
                float x;
                if (rate == "" || !float.TryParse(rate, out x))
                    rate = "0.00";
                Connection con = new Connection();
                con.connent();
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    string id = get_value2(i, 4);
                    con.exeNonQurey(string.Format("delete from item where id = {0}", id));
                }
                con.exeNonQurey("delete from price_list_print");
                con.exeNonQurey(string.Format("exec insert_item '{0}' , '{1}' , '{2}' , {3}", company, type, name, rate));
                load_datagrid();
            }
        }
    }
}
