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
    public partial class ListManualBills : Form
    {
        ManualBilling bde;
        string billno;
        public db.MainInternal internalData = null;
        public ListManualBills(MainInternal t_internalData)
        {
            InitializeComponent();
            internalData = t_internalData;
        }

        private void form_billprint_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = internalData.viewManualBillMaster.get(new e_columns[] { e_columns.e_name, e_columns.e_city, e_columns.e_billno, e_columns.e_id },
                                                                        e_db_operation.e_getAll, "", "billno desc");
            dataGridView1.Columns[3].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = internalData.viewManualBillMaster.get(new e_columns[] { e_columns.e_name, e_columns.e_city, e_columns.e_billno, e_columns.e_id },
                                                                            e_db_operation.e_getAll,
                                                                            string.Format("Convert(billno,'System.String') like ('%{0}%') or name like ('%{0}%')", textBox1.Text) ,
                                                                            "billno desc");
            dataGridView1.Columns[3].Visible = false;
        }
        public void getbde(ManualBilling b)
        {
            bde = b;
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            bde.getbill(Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value.ToString()));
            //returns id of bill
            this.Close();
        }
    }
}