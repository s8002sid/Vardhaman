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
    public partial class Deletion : Form
    {
        Connection con = new Connection();
        public db.MainInternal internalData = null;
        public Deletion()
        {
            InitializeComponent();
        }

        private void Deletion_Load(object sender, EventArgs e)
        {
            con.connent();
            if (internalData == null)
                this.internalData = ((Main)this.MdiParent).getInternalData();
            label1.Text = "Bill Deletion";
            fill();
        }
        private void fill()
        {
            DataTable dt = null;
            if (radioButton1.Checked == true)
            {
                dt = internalData.customer.get(new e_columns[] { e_columns.e_name, e_columns.e_city }, 
                                                e_db_operation.e_getAll, 
                                                string.Format("name like('{0}%')", textBox1.Text),
                                                "name asc");
                label1.Text = "Account Deletion";
                splitContainer1.Panel1.BackColor = Color.LightBlue;
            }
            else if (radioButton2.Checked == true)
            {
                dt = internalData.viewBillMaster.get(new e_columns[] {e_columns.e_name,
                                                                        e_columns.e_city,
                                                                        e_columns.e_billno,
                                                                        e_columns.e_inddate,
                                                                        e_columns.e_total,
                                                                        e_columns.e_expenses,
                                                                        e_columns.e_grandtotal},
                                                                        e_db_operation.e_getAll,
                                                                        string.Format("name like('{0}%')", textBox1.Text),
                                                                        "billno asc");
                dt.Columns[internalData.viewBillMaster.column_to_str(e_columns.e_inddate)].ColumnName = "date";
                label1.Text = "Bill Deletion";
                splitContainer1.Panel1.BackColor = Color.LightCoral;
            }
            else if (radioButton3.Checked == true)
            {
                dt = internalData.viewRecepit.get(new e_columns[] { e_columns.e_name,
                                                                    e_columns.e_city,
                                                                    e_columns.e_recepitno,
                                                                    e_columns.e_inddate,
                                                                    e_columns.e_amount,
                                                                    e_columns.e_total,
                                                                    e_columns.e_bank,
                                                                    e_columns.e_bank_city,
                                                                    e_columns.e_checknumber},
                                                                    e_db_operation.e_getAll,
                                                                    string.Format("name like('{0}%')", textBox1.Text),
                                                                    "recepitno asc");
                dt.Columns[internalData.viewRecepit.column_to_str(e_columns.e_inddate)].ColumnName = "date";
                dt.Columns[internalData.viewRecepit.column_to_str(e_columns.e_total)].ColumnName = "grandtotal";
                dt.Columns[internalData.viewRecepit.column_to_str(e_columns.e_amount)].ColumnName = "total";
                dt.Columns[internalData.viewRecepit.column_to_str(e_columns.e_bank)].ColumnName = "bank name";
                label1.Text = "Recepit Deletion";
                splitContainer1.Panel1.BackColor = Color.LightGoldenrodYellow;
            }
            else if (radioButton4.Checked == true)
            {
                dt = internalData.viewCBE.get(new e_columns[] {e_columns.e_date,
                                                            e_columns.e_name,
                                                            e_columns.e_city,
                                                            e_columns.e_bank_name,
                                                            e_columns.e_bank_city,
                                                            e_columns.e_checkno,
                                                            e_columns.e_bounce_charge,
                                                            e_columns.e_recepitno,
                                                            e_columns.e_id},
                                                            e_db_operation.e_getAll,
                                                            string.Format("name like('{0}%')", textBox1.Text),
                                                            "name asc");
                label1.Text = "Chk Bounce Entry Deletion";
                splitContainer1.Panel1.BackColor = Color.LightSeaGreen;
            }
            dataGridView1.DataSource = dt;
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fill();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Password p = new Password();
            if (p.ShowDialog() == DialogResult.Cancel)
                return;
            string passwd = p.Passwd;
            string value1, value2;
            string storedpass = internalData.passsword.getPassword();
            if (storedpass != passwd)
            {
                MessageBox.Show("Password donot match");
                return;
            }
            if (radioButton1.Checked == true)
            {
                value1 = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["name"].Value.ToString();
                value2 = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["city"].Value.ToString();
                MessageBox.Show("Account deleted Successfully");
            }
            else if (radioButton2.Checked == true)
            {
                value1 = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["billno"].Value.ToString();
                con.exeNonQurey(string.Format("exec bill_del {0}", value1));
                internalData.viewBillMaster.delete(value1);
                con.exeNonQurey(string.Format("exec insert_deletion_history 'Bill',{0}", value1));
                MessageBox.Show("Bill Deleted Successfully");
            }
            else if (radioButton3.Checked == true)
            {
                value1 = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["recepitno"].Value.ToString();
                con.exeNonQurey(string.Format("delete from recepit where recepitno = {0}", value1));
                internalData.viewRecepit.delete(value1);
                con.exeNonQurey(string.Format("exec insert_deletion_history 'Receipt',{0}", value1));
                MessageBox.Show("Recepit Deleted Successfully");
            }
            else if (radioButton4.Checked == true)
            {
                value1 = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id"].Value.ToString();
                con.exeNonQurey(string.Format("delete from check_bounse_entry where id = {0}" , value1));
                MessageBox.Show("Check bounce entery deleted successfully");
            }
            create_backup.create();
            fill();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fill();
        }

        private void Deletion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main m = (Main)(this.MdiParent);
            m.init_container(childContainer.e_Deletion);
        }
    }
}