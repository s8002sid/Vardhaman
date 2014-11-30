using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class Item_Type : Form
    {
        Connection con = new Connection();
        public Item_Type()
        {
            InitializeComponent();
        }

        private void Type_Load(object sender, EventArgs e)
        {
            con.connent();
            fill();
        }
        private void fill()
        {
            DataSet ds = con.dsentry("select typename as [Type Name] , shortcut as [Short Name] , id as [Item ID] from itemtype order by typename", "typename");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[4].ReadOnly = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            insert();
        }
        private void insert()
        {
            if (textBox1.Text != "")
            {
                con.exeNonQurey("insert into itemtype(typename , shortcut) values('" + textBox1.Text + "','" + textBox2.Text + "')");
                //con.disconnect();
                MessageBox.Show("Type Saved Suddessfully");
                fill();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
                textBox1.Select();

            }
            else
            {
                MessageBox.Show("Textbox Cannot Be Empty");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void Type_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (MessageBox.Show("Are you sure to delete this item?", "Warnimg", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string x = con.exesclr("exec delete_type '" + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "'");
                    if (x == "0")
                        MessageBox.Show("Item Type cannot be deleted as it is being used by any Item");
                    else
                    {
                        MessageBox.Show("Item Deleted Successfully");
                        fill();
                    }
                }
            }
            else if (e.ColumnIndex == 1)
            {
                string name = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string shortcut = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string id = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                con.exeNonQurey("update itemtype set typename = '" + name + "', shortcut = '" + shortcut + "' where id = " + id);
                MessageBox.Show("Record Updated Successfully");
                fill();
            }
        }

        private void Type_Leave(object sender, EventArgs e)
        {
            con.disconnect();
        }
    }
}