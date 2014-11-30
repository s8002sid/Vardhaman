using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class item_update_popup_no_insert : Form
    {
        public item_update_popup_no_insert()
        {
            InitializeComponent();
        }
        public string company, type, name, rate;
        private void item_update_popup_no_insert_Load(object sender, EventArgs e)
        {
            company = type = name = "";
            rate = "0.00";
            Connection con = new Connection();
            cbo_company.DataSource = con.getTable("select name from company");
            cbo_company.DisplayMember = "name";
            cbo_item_type.DataSource = con.getTable("select typename from itemtype");
            cbo_item_type.DisplayMember = "typename";
            con.disconnect();
            cbo_company.Focus();
            cbo_company.Select();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            company = cbo_company.Text;
            type = cbo_item_type.Text;
            name = txt_item_name.Text;
            rate = txt_rate.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
