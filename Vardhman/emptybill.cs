using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class emptybill : Form
    {
        public emptybill()
        {
            InitializeComponent();
        }

        private void emptybill_Load(object sender, EventArgs e)
        {
            string x = "select  'b' , billno from bill_master where customer is null union select 'r' , recepitno from recepit where customerid is null";
            Connection con = new Connection();
            dataGridView1.DataSource = con.getTable(x);
        }
    }
}