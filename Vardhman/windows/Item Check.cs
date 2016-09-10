using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Vardhman
{
    public partial class Item_Check : Form
    {
        bool flag;
        bool editflag;
        public ArrayList al = new ArrayList();
        public Item_Check()
        {
            InitializeComponent();
        }
        DataGridViewCellStyle red = new DataGridViewCellStyle();
        DataGridViewCellStyle green = new DataGridViewCellStyle();
        DataGridViewCellStyle yellow = new DataGridViewCellStyle();
        private void Item_Check_Load(object sender, EventArgs e)
        {
            flag = false;
            editflag = true;
            //Connection con = new Connection();
            red.BackColor = Color.FromArgb(250, 66, 56);
            green.BackColor = Color.FromArgb(30, 251, 30);
            yellow.BackColor = Color.FromArgb(245, 227, 103);
            /*con.connent();
            dgv_item_check.DataSource = con.getTable("select 'check' , * from view_inventory");
            con.disconnect();
            for (int i = 1; i < dgv_item_check.Columns.Count; i++)
                dgv_item_check.Columns[i].ReadOnly= true;
            for (int i = 0; i < dgv_item_check.Rows.Count; i++)
            {
                dgv_item_check.Rows[i].Cells[0].Value = "Uncheck";
            }
            dgv_item_check.InvalidateRow(0);*/
        }
        public void set_item_check_datatable(DataTable dt , string accountname , string city)
        {
            if(dt.Columns.Count != 9)
                MessageBox.Show("Invalid table passed" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Warning);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_item_check.Rows.Add();
                dgv_item_check.Rows[i].Cells["check"].Value = dt.Rows[i][0].ToString();
                dgv_item_check.Rows[i].Cells["company"].Value = dt.Rows[i][1].ToString();
                dgv_item_check.Rows[i].Cells["itemtype"].Value = dt.Rows[i][2].ToString();
                dgv_item_check.Rows[i].Cells["itemname"].Value = dt.Rows[i][3].ToString();
                dgv_item_check.Rows[i].Cells["itemdetail"].Value = dt.Rows[i][4].ToString();
                dgv_item_check.Rows[i].Cells["quantity"].Value = dt.Rows[i][5].ToString();
                dgv_item_check.Rows[i].Cells["meter"].Value = dt.Rows[i][6].ToString();
                dgv_item_check.Rows[i].Cells["rate"].Value = dt.Rows[i][7].ToString();
                dgv_item_check.Rows[i].Cells["ID"].Value = dt.Rows[i][8].ToString();
            }
            dgv_item_check.Sort(dgv_item_check.Columns[2], ListSortDirection.Ascending);
            lbl_acc_name.Text = accountname;
            lbl_city.Text = city;
        }
        private void dgv_item_check_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (get_grid_value(e.RowIndex, 0) == "Check")
                {
                    dgv_item_check.Rows[e.RowIndex].DefaultCellStyle = green;
                    dgv_item_check.Rows[e.RowIndex].Cells[0].Value = "Check";
                    flag = true;
                }
                else if (get_grid_value(e.RowIndex, 0) == "Uncheck")
                {
                    dgv_item_check.Rows[e.RowIndex].DefaultCellStyle = yellow;
                    flag = true;
                }
                else if (get_grid_value(e.RowIndex, 0) == "Error")
                {
                    dgv_item_check.Rows[e.RowIndex].DefaultCellStyle = red;
                    flag = true;
                }
            }
            /*else
            {
                Connection con = new Connection();
                con.connent();
                con.exeNonQurey(string.Format("exec insert_item_check {0} , '{1}' , '{2}' , '{3}' , '{4}' , {5} , {6} , {7} , {8}" , get_grid_changed_value(e.RowIndex , e.ColumnIndex) , ));
                con.disconnect();
            }*/
            
        }
        private string get_grid_value(int row, string col)
        {
            if (row<0 || dgv_item_check.Rows[row].Cells[col].Value == null || dgv_item_check.Rows.Count <= row)
                return "";
            return dgv_item_check.Rows[row].Cells[col].Value.ToString();
        }
        private string get_grid_value(int row, int col)
        {
            if (row<0 || col<0 || dgv_item_check.Rows.Count<=row || dgv_item_check.Columns.Count<=col || dgv_item_check.Rows[row].Cells[col].Value == null)
                return "";
            return dgv_item_check.Rows[row].Cells[col].Value.ToString();
        }
        private string get_grid_changed_value(int row, int col)
        {
            if (row < 0 || col < 0 || dgv_item_check.Rows.Count <= row || dgv_item_check.Columns.Count <= col || dgv_item_check.Rows[row].Cells[col].FormattedValue == null)
                return "";
            return dgv_item_check.Rows[row].Cells[col].EditedFormattedValue.ToString();
        }

        private void dgv_item_check_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            if (get_grid_value(e.RowIndex, 0) == "Check")
            {
                dgv_item_check.Rows[e.RowIndex].Cells[0].Value = "Error";
            }
            else if (get_grid_value(e.RowIndex, 0) == "Uncheck")
            {
                dgv_item_check.Rows[e.RowIndex].Cells[0].Value = "Check"; ;
            }
            else if (get_grid_value(e.RowIndex, 0) == "Error")
            {
                dgv_item_check.Rows[e.RowIndex].Cells[0].Value = "Uncheck";
            }


            /*if (get_grid_value(e.RowIndex, 0) == "Check")
            {
                dgv_item_check.Rows[e.RowIndex].DefaultCellStyle = green;
                dgv_item_check.Rows[e.RowIndex].Cells[0].Value = "Check";
                flag = true;
            }
            else if (get_grid_value(e.RowIndex, 0) == "Uncheck")
            {
                dgv_item_check.Rows[e.RowIndex].DefaultCellStyle = yellow;
                flag = true;
            }
            else if (get_grid_value(e.RowIndex, 0) == "Error")
            {
                dgv_item_check.Rows[e.RowIndex].DefaultCellStyle = red;
                flag = true;
            }*/
        }

        private void dgv_item_check_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (flag == true)
            {
                dgv_item_check.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                flag = false;
            }

        }
        private void dgv_item_check_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (get_grid_value(e.RowIndex, 0) != "")
                editflag = true;
        }
        public void load_data()
        {
            Connection con = new Connection();
            con.connent();
            DataTable dt = con.getTable("select status , item_company , item_type , item_name , item_detail , quantity , meter , rate , id from item_check");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_item_check.Rows.Add();
                dgv_set_item(i , 0 , dt.Rows[i][0].ToString());
                dgv_set_item(i , 0 , dt.Rows[i][1].ToString());
                dgv_set_item(i, 0, dt.Rows[i][2].ToString());
                dgv_set_item(i, 0, dt.Rows[i][3].ToString());
                dgv_set_item(i, 0, dt.Rows[i][4].ToString());
                dgv_set_item(i, 0, dt.Rows[i][5].ToString());
                dgv_set_item(i, 0, dt.Rows[i][6].ToString());
                dgv_set_item(i, 0, dt.Rows[i][7].ToString());
                dgv_set_item(i, 0, dt.Rows[i][8].ToString());
            }

        }
        private void dgv_set_item(int row, int column, string value)
        {
            dgv_item_check.Rows[row].Cells[column].Value = value;
        }
        private void dgv_set_item(int row, string column, string value)
        {
            dgv_item_check.Rows[row].Cells[column].Value = value;
        }

        private void dgv_item_check_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Item_Check_FormClosing(object sender, FormClosingEventArgs e)
        {
            for(int i = 0; i < dgv_item_check.Rows.Count; i++)
            {
                if (dgv_item_check.Rows[i].Cells[0].Value.ToString() == "Error" || dgv_item_check.Rows[i].Cells[0].Value.ToString() == "Uncheck")
                    al.Add(Convert.ToInt32(dgv_item_check.Rows[i].Cells["ID"].Value.ToString()));
                
            }
        }

        private void dgv_item_check_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            if (get_grid_value(e.RowIndex, 0) == "Check")
            {
                dgv_item_check.Rows[e.RowIndex].Cells[0].Value = "Error";
            }
            else if (get_grid_value(e.RowIndex, 0) == "Uncheck")
            {
                dgv_item_check.Rows[e.RowIndex].Cells[0].Value = "Check"; ;
            }
            else if (get_grid_value(e.RowIndex, 0) == "Error")
            {
                dgv_item_check.Rows[e.RowIndex].Cells[0].Value = "Uncheck";
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_search.Text.Trim() == "")
            {
                for (int i = 0; i < dgv_item_check.Rows.Count; i++)
                    dgv_item_check.Rows[i].Visible = true;
            }
            for (int i = 0; i < dgv_item_check.Rows.Count; i++)
            {
                if
                    (
                        dgv_item_check.Rows[i].Cells["company"].Value.ToString().ToLower().Contains(txt_search.Text.ToLower()) ||
                        dgv_item_check.Rows[i].Cells["itemtype"].Value.ToString().ToLower().Contains(txt_search.Text.ToLower()) ||
                        dgv_item_check.Rows[i].Cells["itemname"].Value.ToString().ToLower().Contains(txt_search.Text.ToLower())
                    )
                {
                    dgv_item_check.Rows[i].Visible = true;
                }
                else
                    dgv_item_check.Rows[i].Visible = false;

            }
        }
    }
}
