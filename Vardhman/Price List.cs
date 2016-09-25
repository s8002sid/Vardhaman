using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vardhman.db;
/*Price List is running a sql strord procedure for Inserting/Updating Item entry.
  To avoid taking all these things in to consideration, we just made all relevant
  tables empty. So whenever next time someone request for these tables, they will
  get re-populated. This can also be taken care by just inserting values to datatable
  However, by this operation our database and datatable will become inconsistent.*/
namespace Vardhman
{
    public partial class Price_List : Form
    {
        public db.MainInternal internalData = null;
        public Price_List()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Price_List_Load(object sender, EventArgs e)
        {
            if (internalData == null)
                this.internalData = ((Main)this.MdiParent).getInternalData();
            clear();
        }
        private string append_code(string name, string rate)
        {
            string coded;
            string name_without_code;
            string code;
            string name1 = name;
            detect_code(name, out name_without_code, out code);
            name = name_without_code;
            coded = "";
            if (!calculate_code(rate, out coded))
                coded = "";
            name = name.Trim();
            coded = coded.Trim();
            if (name != "" && coded != "")
                coded = name + " " + coded;
            if (name != "" && coded == "")
                coded = name;
            if (coded == "")
                coded = name1;
            return coded;
        }

        private bool calculate_code(string rate, out string code)
        {
            float floterate;
            code = "";
            if (!float.TryParse(rate, out floterate))
                return false;
            string[] numbers = rate.Split('.');
            if (numbers.Length > 0)
                numbers[0] = (Convert.ToInt32(numbers[0]) + 100).ToString();
            if (numbers.Length == 1)
                code = "5" + numbers[0] + "5";
            else if (numbers.Length == 2)
            {
                if (numbers[1].Length == 0)
                    numbers[1] = "";
                else if (numbers[1].Length == 1)
                {
                    if (numbers[1] != "0")
                        numbers[1] = numbers[1] + "0";
                    else
                        numbers[1] = "";
                }
                else
                {
                    if (!(numbers[1][0] == '0' && numbers[1][1] == '0'))
                        numbers[1] = numbers[1].Substring(0, 2);
                    else
                        numbers[1] = "";
                }
                code = "5" + numbers[0] + numbers[1] + "5";
            }
            else
                return false;
            return true;
        }
        private void detect_code(string name, out string name_without_code, out string code)
        {
            name = name.Trim();
            string[] codedstring = name.Split(' ');
            string laststring = codedstring[codedstring.Length - 1];
            name_without_code = "";
            code = "";
            if (laststring.Length >= 3 && laststring[0] == '5' && laststring[laststring.Length - 1] == '5')
            {
                for (int i = 0; i < codedstring.Length - 1; i++)
                {
                    name_without_code += codedstring[i];
                    if (i != codedstring.Length - 1)
                        name_without_code += " ";
                }
            }
            else
            {
                name_without_code = name;
            }
        }

        private void btn_append_rate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_item_entry.Rows.Count - 1; i++)
            {
                string itemname = get_dgv_value(i , "itemname");
                string rate = get_dgv_value(i , "rate");
                string code = append_code(itemname , rate);
                set_dgv_value(i, "itemname", code);
            }

        }
        private string get_dgv_value(int row, string col)
        {
            if (!check_row_col(row, col))
                return "";
            if (dgv_item_entry.Rows[row].Cells[col].Value == null)
                return "";
            return dgv_item_entry.Rows[row].Cells[col].Value.ToString();
        }
        private void set_dgv_value(int row, string col , string value)
        {
            if (!check_row_col(row, col))
                return;
            dgv_item_entry.Rows[row].Cells[col].Value = value;
        }
        private bool check_row_col(int row, string col)
        {
            if (row > dgv_item_entry.Rows.Count - 1)
                return false;
            bool flag = false;
            for (int i = 0; i < dgv_item_entry.Columns.Count; i++)
                if (dgv_item_entry.Columns[i].Name == col)
                {
                    flag = true;
                    break;
                }
            if (flag == false)
                return false;
            return true;
        }

        private void btn_remove_code_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_item_entry.Rows.Count - 1; i++)
            {
                string itemname = get_dgv_value(i, "itemname");
                string name;
                string code;
                detect_code(itemname, out name, out code);
                set_dgv_value(i, "itemname", name);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            cbo_company.DataSource = internalData.company.get(new e_columns[] { e_columns.e_name }, e_db_operation.e_getUnique, "name is not null and name <> ''");
            cbo_company.DisplayMember = internalData.company.column_to_str(e_columns.e_name);
            cbo_company.Text = "";

            cbo_type.DataSource = internalData.itemType.get(new e_columns[] { e_columns.e_typename }, e_db_operation.e_getUnique, "typename is not null and typename <> ''");
            cbo_type.DisplayMember = internalData.itemType.column_to_str(e_columns.e_typename);
            cbo_type.Text = "";
            dgv_item_entry.Rows.Clear();
        }

        private void dgv_item_entry_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox name = (TextBox)e.Control;
            if (dgv_item_entry.SelectedCells[0].ColumnIndex != 0)
            {
                name.AutoCompleteMode = AutoCompleteMode.None;
                name.AutoCompleteSource = AutoCompleteSource.None;
                return;
            }
            
            AutoCompleteStringCollection acs = new AutoCompleteStringCollection();
            DataTable dt = internalData.itemDetail.get(new e_columns[] { e_columns.e_item_name },
                                                       e_db_operation.e_getUnique,
                                                       string.Format("[Item Name] <> '' and [Item Name] is not null and Company like('{0}%') and  [Type Name] like('{1}%') ",
                                                            cbo_company.Text.Trim(),
                                                            cbo_type.Text.Trim()));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                acs.Add(dt.Rows[i][0].ToString());
            }
            name.AutoCompleteCustomSource = acs;
            name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void dgv_item_entry_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                calculate_rate(e.RowIndex, e.ColumnIndex);
            }
            else if (e.ColumnIndex == 1)
            {
                append_amount(e.RowIndex, e.ColumnIndex);
            }
        }

        private void append_amount(int row, int col)
        {
            string rate = get_dgv_value(row, "rate");
            set_dgv_value(row, "rate", Vardhman.roundOff.withpoint(rate));
        }

        private void calculate_rate(int row, int col)
        {
            if(get_dgv_value(row , "rate").Trim() != "")
                return;
            string company = cbo_company.Text.Trim();
            string type = cbo_company.Text.Trim();
            string name = get_dgv_value(row, "itemname");
            double rate = internalData.itemDetail.getPrice(company, type, name);
            if (rate == -1)
                return;
            set_dgv_value(row, "rate",Vardhman.roundOff.withpoint(rate.ToString()));
        }

        private void dgv_item_entry_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                set_dgv_value(e.RowIndex, "itemname", get_dgv_value(e.RowIndex, "itemname").ToUpper());
            }
        }

        private void cbo_type_Leave(object sender, EventArgs e)
        {
            ComboBox x = (ComboBox)sender;
            x.Text = x.Text.ToUpper();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save Item?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                return;
            string company = cbo_company.Text.Trim();
            string type = cbo_type.Text.Trim();
            string query = "";
            for (int i = 0; i < dgv_item_entry.Rows.Count - 1; i++)
            {
                string name = get_dgv_value(i , "itemname");
                string rate = get_dgv_value(i , "rate");
                if(name.Trim() == "")
                    continue;
                if(rate.Trim() == "")
                    rate = "0.00";
                query += string.Format("exec insert_item '{0}' , '{1}' , '{2}' , {3};", company, type, name, rate);
                query += string.Format("exec vtdurg.dbo.insert_item '{0}' , '{1}' , '{2}' , {3};", company, type, name, rate);
            }
            Connection con = new Connection();
            con.connent();
            con.exeNonQurey(query);
            con.disconnect();
            internalData.company.emptyTable();
            internalData.itemType.emptyTable();
            internalData.itemDetail.emptyTable();
            MessageBox.Show("Item Saved / Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear();
        }

        private void Price_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main m = (Main)(this.MdiParent);
            m.init_container(childContainer.e_PriceList);
        }
    }
}
