using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class Item_Update_Popup : Form
    {
        public Item_Update_Popup()
        {
            InitializeComponent();
        }

        private void Item_Update_Popup_Load(object sender, EventArgs e)
        {
            
        }
        private void clear()
        {
            Connection con = new Connection();
            con.connent();
            cbo_company.DataSource = con.getTable("select name from company");
            cbo_company.DisplayMember = "name";
            cbo_company.Text = "";
            cbo_item_type.DataSource = con.getTable("select typename from itemtype");
            cbo_item_type.DisplayMember = "typename";
            con.disconnect();
            cbo_item_type.Text = "";
            txt_item_name.Text = "";
            txt_rate.Text = "";
            lbl_id.Text = "";
            cbo_company.Focus();
            cbo_company.Select();
        }
        public void load(string company , string type , string name , string rate , string id)
        {
            clear();
            cbo_company.Text = company;
            cbo_item_type.Text = type;
            txt_item_name.Text = name;
            txt_rate.Text = rate;
            lbl_id.Text = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.connent();
            con.exeNonQurey(string.Format("delete from item where id = {0}" , lbl_id.Text));
            MessageBox.Show("Item deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.disconnect();
            this.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.connent();
            string rate = "0.00";
            if(txt_rate.Text != "")
                rate = txt_rate.Text;
            string result = con.exesclr(string.Format("exec update_item_from_id '{0}' , '{1}' , '{2}' , {3} , {4}", cbo_company.Text, cbo_item_type.Text, txt_item_name.Text, rate, lbl_id.Text));
            if (result == "0")
            {
                MessageBox.Show("Item dosenot Exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo_company.Focus();
            }
            else
            {
                MessageBox.Show("Item Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void Item_Update_Popup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cbo_company_TextChanged(object sender, EventArgs e)
        {
            cbo_company.Text = cbo_company.Text.ToUpper();
        }

        private void cbo_item_type_TextChanged(object sender, EventArgs e)
        {
            cbo_item_type.Text = cbo_item_type.Text.ToUpper();
        }
    }
}
