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
    public partial class list_bills : Form
    {
        Billing_dataentry bde;
        string billno;
        public db.MainInternal internalData = null;
        public list_bills(db.MainInternal t_internalData)
        {
            InitializeComponent();
            internalData = t_internalData;
        }

        private void form_billprint_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = internalData.viewBillMaster.get(new e_columns[] { e_columns.e_name, e_columns.e_city, e_columns.e_billno },
                                                                        e_db_operation.e_getAll, "", "billno desc");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = internalData.viewBillMaster.get(new e_columns[] { e_columns.e_name, e_columns.e_city, e_columns.e_billno },
                                                                            e_db_operation.e_getAll,
                                                                            "billno like ('{0}%') or name like ('{0}%')", "billno desc");
        }
        public void getbde(Billing_dataentry b)
        {
            bde = b;
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            bde.getbill(Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value.ToString()));
            this.Close();
        }
    }
}