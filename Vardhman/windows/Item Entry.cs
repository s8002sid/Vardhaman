using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Vardhman
{
    public partial class Item_Entry : Form
    {
        Connection con = new Connection();
        public Item_Entry()
        {
            InitializeComponent();
        }

        private void Item_Entry_Load(object sender, EventArgs e)
        {
            con.connent();
            company();
            type();
            item();
            dataGridView3.Columns[7].ReadOnly = true;

            panel1.Location = Panel_Company.Location;
            panel1visible(3);
            textBox4.Focus();
            textBox4.Select();
        }
        private void panel1visible(int x)
        {
            if (x == 1)
            {
                panel1.Visible = true;
                Panel_Company.Visible = false;
            }
            else if (x == 2)
            {
                panel1.Visible = false;
                Panel_Company.Visible = true;
            }
            else
            {
                panel1.Visible = false;
                Panel_Company.Visible = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string x = con.exesclr("exec add_item '" + textBox2.Text + "'," + label6.Text + "," + textBox3.Text + ",'" + textBox5.Text + "','" + textBox6.Text + "'");
            if (x == "0")
                MessageBox.Show("Item of given company Already Exists");
            else
            {
                MessageBox.Show("Iten Saved Successfully");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox2.Focus();
                textBox2.Select();
            }
            item();
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            company();
            panel1visible(2);

        }
        private void company()
        {
            DataSet ds;
            if(textBox1.Text == "")
                ds = con.dsentry("select id, [name] as [Company name] from company order by [name] asc" , "company");
            else
                ds = con.dsentry("select id , [name] as [Company name] from company where [name] like('%" + textBox1.Text + "%') order by [name] asc" , "company");
            dataGridView1.DataSource = ds.Tables[0];

        }
        private void type()
        {
            DataSet ds;
            if (textBox7.Text == "")
                ds = con.dsentry("select typename as [Type] from itemtype order by typename asc", "itemtype");
            else
                ds = con.dsentry("select typename as [Type] from itemtype where typename like('%" + textBox7.Text + "%') order by typename asc", "itemtype");
            dataGridView2.DataSource = ds.Tables[0];

        }
        private void item()
        {
            DataSet ds = con.dsentry("select [item name] , Company , Price , Note , [Type Name] , id from item_detail" , "item_detail");
            dataGridView3.DataSource = ds.Tables[0];
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            company();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            label6.Text = dr.Cells[0].Value.ToString();
            textBox4.Text =  dr.Cells[1].Value.ToString();
            textBox4.SelectAll();
            textBox4.Focus();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                label6.Text = dr.Cells[0].Value.ToString();
                textBox4.Text = dr.Cells[1].Value.ToString();
                textBox4.Select();
                textBox4.Focus();
                textBox4.SelectAll();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up)
                    e.Handled = true;
                if (e.KeyCode == Keys.Down)
                {
                    int x, y;
                    x = dataGridView1.SelectedRows[0].Index;
                    y = calcnext(false, dataGridView1.Rows.Count - 1, x);
                    dataGridView1.Rows[x].Selected = false;
                    dataGridView1.Rows[y].Selected = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    int x, y;
                    x = dataGridView1.SelectedRows[0].Index;
                    y = calcnext(true, dataGridView1.Rows.Count - 1, x);
                    dataGridView1.Rows[x].Selected = false;
                    dataGridView1.Rows[y].Selected = true;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    label6.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    textBox4.Focus();
                    textBox4.SelectAll();
                }
                
            }
            catch { }
                
        }
        private int calcnext(Boolean up , int max , int current)
        {
            if (up == true)
            {
                if(current == 0)
                    return max;
                else return current-1;
            }
            else
            {
                if (current == max)
                    return 0;
                else
                    return current + 1;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            company();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox4.Text;
            company();
            textBox4.Focus();
            //Connection con = new Connection();
            //con.connent();
            //DataSet ds;
            //ds = con.dsentry("select id , [name] as [Company name] from company where [name] like('%" + textBox4.Text + "%') order by [name] asc", "company");
            //dataGridView1.DataSource = ds.Tables[0];
            //con.disconnect();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            panel1visible(3);
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            textBox5.Text = dr.Cells[0].Value.ToString();
            textBox5.SelectAll();
            textBox5.Focus();
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewRow dr = dataGridView2.SelectedRows[0];
                textBox5.Text = dr.Cells[0].Value.ToString();
                textBox5.SelectAll();
                textBox5.Focus();
            }
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            //type();
            panel1visible(1);
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up)
                    e.Handled = true;
                if (e.KeyCode == Keys.Down)
                {
                    int x, y;
                    x = dataGridView2.SelectedRows[0].Index;
                    y = calcnext(false, dataGridView2.Rows.Count - 1, x);
                    dataGridView2.Rows[x].Selected = false;
                    dataGridView2.Rows[y].Selected = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    int x, y;
                    x = dataGridView2.SelectedRows[0].Index;
                    y = calcnext(true, dataGridView2.Rows.Count - 1, x);
                    dataGridView2.Rows[x].Selected = false;
                    dataGridView2.Rows[y].Selected = true;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow dr = dataGridView2.SelectedRows[0];
                    textBox5.Text = dr.Cells[0].Value.ToString();
                    textBox5.SelectAll();
                    textBox5.Focus();
                }
            }
            catch { }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            panel1visible(3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            type();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Item_Type t = new Item_Type();
            t.ShowDialog();
            type();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            panel1visible(3);
        }

        
        private Boolean hasPeriod(string x)
        {
            if(x.Contains("."))
                return true;
            else
                return false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Back || (!hasPeriod(textBox3.Text) && e.KeyChar == 46)))
                e.Handled = true;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.Text = roundOff.round(textBox3.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = textBox5.Text;
            type();

        }

        private void Item_Entry_Leave(object sender, EventArgs e)
        {
            con.disconnect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox4.Focus();
            textBox4.Select();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (MessageBox.Show("Are you sure to DELETE?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.exeNonQurey("delete from item where id = " + dataGridView3.SelectedRows[0].Cells[8].Value.ToString());
                    MessageBox.Show("Item Deleted");
                    item();
                }                              
            }
            else if (e.ColumnIndex == 1)
            {
                //con.exeNonQurey("update item set 
            }
        }

        private void dataGridView3_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                Panel_Company.Visible = true;
                panel1.Visible = false;
            }
        }
        
    }
}