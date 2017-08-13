using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vardhman.db;
namespace Vardhman
{
    public partial class Account_Head : Form
    {
        public db.MainInternal internalData = null;
        public Account_Head()
        {
            InitializeComponent();
        }

        private void Account_Head_Load(object sender, EventArgs e)
        {
            string x = cmb_city.Text;
            if (internalData == null)
                this.internalData = ((Main)this.MdiParent).getInternalData();
            cmb_city.DataSource = internalData.customer.get(new e_columns[] { e_columns.e_city }, e_db_operation.e_getUnique);
            cmb_city.DisplayMember = internalData.customer.column_to_str(e_columns.e_city);
            cmb_city.Text = x;
            panel_buttons.Location = new Point(85, 286);

        }

        private void cmb_acnttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_acnttype.Text == "BANK")
            {
                panel_bank_detail.Visible = true;
                txt_bank_acnt_no.Focus();
                txt_bank_acnt_no.Select();
            }
            else
                panel_bank_detail.Visible = false;
        }

        private void cmb_acnttype_Leave(object sender, EventArgs e)
        {
            if (cmb_acnttype.Text == "BANK")
            {
                panel_bank_detail.Visible = true;
                txt_bank_acnt_no.Select();
                txt_bank_acnt_no.Focus();
            }
            else if (cmb_acnttype.Text == "")
                cmb_acnttype.Text = "CUSTOMER";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            txt_acntname.ReadOnly = false;
            splt_customer_search.Visible = false;
            cmb_city.Enabled = true;
            btn_save.Text = "Save";
            lblid.Text = "";

            cmb_city.DataSource = internalData.customer.get(new e_columns[] { e_columns.e_city }, e_db_operation.e_getUnique);
            cmb_city.DisplayMember = internalData.customer.column_to_str(e_columns.e_city);
            dtp_balancedate.Value = DateTime.Now;
            txt_acntname.Text = "";
            txt_note.Text = "";
            txt_address.Text = "";
            txt_pincode.Text = "";
            txt_phno_1.Text = "";
            txt_phno_2.Text = "";
            txt_openbal.Text = "";
            txt_bank_acnt_no.Text = "";
            cmb_acnttype.Text = "";
            cmb_bank_acnt_type.Text = "";
            cmb_city.Text = "";
            txt_acntname.Focus();
            txt_acntname.Select();
        }
        private void txt_openbal_Leave(object sender, EventArgs e)
        {
            txt_openbal.Text = roundOff.withpoint(txt_openbal.Text);
            if (txt_openbal.Text == "0.00")
            {
                dtp_balancedate.Focus();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            save();
            clear();
        }
        private void save()
        {
            string open = txt_openbal.Text;
            if (open == "")
                open = "0.00";

            line_group_creation lgc = new line_group_creation();
            lgc.check(cmb_city.Text.ToLower());

            if (btn_save.Text == "Save")
            {
                if (chknamewidspace() == 0)
                {
                    MessageBox.Show("Account alreadt exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                internalData.customer.add(new e_columns[] { e_columns.e_name,
                                                            e_columns.e_note,
                                                            e_columns.e_address,
                                                            e_columns.e_city,
                                                            e_columns.e_pincode,
                                                            e_columns.e_phno_1,
                                                            e_columns.e_phno_2,
                                                            e_columns.e_openbalance,
                                                            e_columns.e_date,
                                                            e_columns.e_type,
                                                            e_columns.e_accountnumber,
                                                            e_columns.e_accounttype,
                                                            e_columns.e_select},
                                            new string[] {  txt_acntname.Text.Trim(), 
                                                            txt_note.Text, 
                                                            txt_address.Text, 
                                                            cmb_city.Text, 
                                                            txt_pincode.Text, 
                                                            txt_phno_1.Text, 
                                                            txt_phno_2.Text, 
                                                            open, 
                                                            dtp_balancedate.Text.ToString().Split(Convert.ToChar(" "))[0], 
                                                            cmb_acnttype.Text, 
                                                            txt_bank_acnt_no.Text, 
                                                            cmb_bank_acnt_type.Text, 
                                                            "1"});
                clear();
                MessageBox.Show("items Saved successfully");
            }
            else
            {
                internalData.customer.update(new e_columns[] { e_columns.e_name,
                                                            e_columns.e_note,
                                                            e_columns.e_address,
                                                            e_columns.e_city,
                                                            e_columns.e_pincode,
                                                            e_columns.e_phno_1,
                                                            e_columns.e_phno_2,
                                                            e_columns.e_openbalance,
                                                            e_columns.e_date,
                                                            e_columns.e_type,
                                                            e_columns.e_accountnumber,
                                                            e_columns.e_accounttype,
                                                            e_columns.e_id},
                                            new string[] {  txt_acntname.Text.Trim(), 
                                                            txt_note.Text, 
                                                            txt_address.Text, 
                                                            cmb_city.Text, 
                                                            txt_pincode.Text, 
                                                            txt_phno_1.Text, 
                                                            txt_phno_2.Text, 
                                                            open, 
                                                            dtp_balancedate.Text.ToString().Split(Convert.ToChar(" "))[0], 
                                                            cmb_acnttype.Text, 
                                                            txt_bank_acnt_no.Text, 
                                                            cmb_bank_acnt_type.Text, 
                                                            lblid.Text});
                clear();
                MessageBox.Show("items Updated successfully");
            }
        }

        private void chk_advanceentry_CheckedChanged(object sender, EventArgs e)
        {
            panel_advanced_entry.Visible = chk_advanceentry.Checked;
            if (chk_advanceentry.Checked == true)
            {
                panel_advanced_entry.Location = new Point(6, 288);
                panel_buttons.Location = new Point(62, 662);
            }
            else
            {
                panel_buttons.Location = new Point(85, 286);
            }
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            dgv_list_customer.DataSource = internalData.customer.get(new e_columns[] {e_columns.e_name, e_columns.e_city}, e_db_operation.e_getAll);
            splt_customer_search.Visible = true;
        }

        private void dgv_list_customer_DoubleClick(object sender, EventArgs e)
        {
            string name, city;
            name = dgv_list_customer.Rows[dgv_list_customer.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            city = dgv_list_customer.Rows[dgv_list_customer.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            DataTable dt = internalData.customer.get(new e_columns[] {e_columns.e_name,
                                                        e_columns.e_note,
                                                        e_columns.e_address,
                                                        e_columns.e_city,
                                                        e_columns.e_pincode,
                                                        e_columns.e_phno_1,
                                                        e_columns.e_phno_2,
                                                        e_columns.e_openbalance,
                                                        e_columns.e_date,
                                                        e_columns.e_type,
                                                        e_columns.e_accountnumber,
                                                        e_columns.e_accounttype,
                                                        e_columns.e_id}, e_db_operation.e_getAll, 
                                                        string.Format("name='{0}' and city='{1}'", name, city));

            txt_acntname.Text = dt.Rows[0][0].ToString();
            cmb_city.Text = dt.Rows[0][3].ToString();
            cmb_acnttype.Text = dt.Rows[0][9].ToString();
            txt_openbal.Text = dt.Rows[0][7].ToString();
            dtp_balancedate.Text = dt.Rows[0][8].ToString();
            txt_address.Text = dt.Rows[0][2].ToString();
            txt_pincode.Text = dt.Rows[0][4].ToString();
            txt_phno_1.Text = dt.Rows[0][5].ToString();
            txt_phno_2.Text = dt.Rows[0][6].ToString();
            txt_note.Text = dt.Rows[0][1].ToString();
            txt_bank_acnt_no.Text = dt.Rows[0][10].ToString();
            cmb_bank_acnt_type.Text = dt.Rows[0][11].ToString();
            lblid.Text = dt.Rows[0][12].ToString();
            splt_customer_search.Visible = true;
            btn_save.Text = "Update";
            //textBox1.ReadOnly = true;
            //comboBox4.Enabled = false;
        }

        private void txt_search_cust_TextChanged(object sender, EventArgs e)
        {
            dgv_list_customer.DataSource = internalData.customer.get(new e_columns[] {e_columns.e_name, 
                                                                                    e_columns.e_city},
                                                                                    e_db_operation.e_getAll, 
                                                                                    string.Format("name like('{0}%')", txt_search_cust.Text));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            splt_customer_search.Visible = false;
        }
        public void getdetail(string name, string city, MainInternal internalData)
        {
            
            DataTable max_id = internalData.customer.get(new e_columns[] { e_columns.e_id }, e_db_operation.e_getAll, string.Format("name = '{0}' and city = '{1}'", name, city));
            if (max_id.Rows.Count == 0 || (name.Trim() == "" && city.Trim() == ""))
            {
                txt_acntname.Text = name;
                cmb_city.Text = city;
                cmb_acnttype.Text = "CUSTOMER";
                txt_openbal.Focus();
                txt_openbal.Select();
                return;
            }
            DataTable dt = internalData.customer.get(new e_columns[] { e_columns.e_name,
                                                                        e_columns.e_note,
                                                                        e_columns.e_address,
                                                                        e_columns.e_city,
                                                                        e_columns.e_pincode,
                                                                        e_columns.e_phno_1,
                                                                        e_columns.e_phno_2,
                                                                        e_columns.e_openbalance,
                                                                        e_columns.e_debcredit,
                                                                        e_columns.e_date,
                                                                        e_columns.e_type,
                                                                        e_columns.e_accounttype,
                                                                        e_columns.e_accountnumber,
                                                                        e_columns.e_id},
                                                                        e_db_operation.e_getAll,
                                                                        string.Format("name = '{0}' and city = '{1}'", name, city));

            txt_acntname.Text = dt.Rows[0][0].ToString();
            //string abc = comboBox4.Text;
            cmb_city.Text = dt.Rows[0][3].ToString();
            //comboBox4.Text = abc;
            txt_openbal.Text = dt.Rows[0][7].ToString();
            dtp_balancedate.Text = dt.Rows[0][9].ToString();
            txt_address.Text = dt.Rows[0][2].ToString();
            txt_pincode.Text = dt.Rows[0][4].ToString();
            txt_phno_1.Text = dt.Rows[0][5].ToString();
            txt_phno_2.Text = dt.Rows[0][6].ToString();
            txt_note.Text = dt.Rows[0][1].ToString();
            txt_bank_acnt_no.Text = dt.Rows[0][12].ToString();
            cmb_acnttype.Text = dt.Rows[0][10].ToString();
            cmb_bank_acnt_type.Text = dt.Rows[0][11].ToString();
            lblid.Text = dt.Rows[0][13].ToString();
            splt_customer_search.Visible = true;
            btn_save.Text = "Update";
            txt_acntname.ReadOnly = true;
            cmb_city.Enabled = false;
        }

        private int chknamewidspace()
        {
            DataTable dt = internalData.customer.get(new e_columns[] { e_columns.e_name, e_columns.e_city }, e_db_operation.e_getAll);

            string abox = txt_acntname.Text.Replace(" ", "");
            string bbox = cmb_city.Text.Replace(" ", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string a = dt.Rows[i][0].ToString().Replace(" ", "");
                string b = dt.Rows[i][1].ToString().Replace(" ", "");
                if ((a == abox) && (b == bbox))
                    return 0;

            }

            return 1;
        }

        private void txt_acntname_Leave(object sender, EventArgs e)
        {
            if (txt_acntname.Text == "" || btn_save.Text != "Save")
                return;
            DataTable dt = internalData.customer.get(new e_columns[] { e_columns.e_name }, e_db_operation.e_getUnique);
            string x = Supporter.compare(txt_acntname.Text, dt, 3);
            if (x != "")
            {
                txt_acntname.Text = ""; txt_acntname.Focus();
            }
        }

        private void Account_Head_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main m = (Main)(this.MdiParent);
            if (m != null)
                m.init_container(childContainer.e_AccountHead);
        }

        private void caps_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }
        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == 8 || e.KeyChar == 9 || e.KeyChar == 10 || e.KeyChar == 11 || e.KeyChar == 12 || e.KeyChar == 46 || (e.KeyChar >= 48 && e.KeyChar <= 57)))
                e.Handled = true;
        }
    }
}