using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class toteler : Form
    {
        public toteler()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("Total" , "Total");
            }
            else
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("A","A");
                dataGridView1.Columns.Add("B","B");
                dataGridView1.Columns.Add("Total" , "Total");
                dataGridView1.Columns[2].ReadOnly = true;
            }
        }

        private void toteler_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
        private void basic()
        {
            double total = 0.0;
            DataGridViewRow dr;
            for(int i = 0 ; i <dataGridView1.Rows.Count-1;i++)
            {
                dr = dataGridView1.Rows[i];
                double d;
                try
                {
                d = Convert.ToDouble(dr.Cells[0].Value.ToString());
                }
                catch
                {
                    d = 0;
                    dataGridView1.Rows[i].Cells[0].Value = "";
                }
                total +=d;
            }
            textBox1.Text = roundOff.round(total);
        }
        private void enhanced()
        {
            double total1 = 0.0 , total2 = 0.0 , total3 = 0.0;
            DataGridViewRow dr;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dr = dataGridView1.Rows[i];
                double d1 , d2 , multiply;
                try
                {
                    d1 = Convert.ToDouble(dr.Cells[0].Value.ToString());
                    
                }
                catch
                {
                    d1 = 0;
                    dataGridView1.Rows[i].Cells[0].Value = "";
                    
                }
                try
                {
                    d2 = Convert.ToDouble(dr.Cells[1].Value.ToString());
                }
                catch
                {
                    d2 = 0;
                    dataGridView1.Rows[i].Cells[1].Value = "";
                }
                multiply = d1 * d2;
                total1 += d1;
                total2 += d2;
                total3 += multiply;
                dataGridView1.Rows[i].Cells[2].Value = roundOff.round(multiply);
            }
            textBox1.Text = roundOff.round(total1);
            textBox2.Text = roundOff.round(total2);
            textBox3.Text = roundOff.round(total3);
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButton1.Checked == true)
                basic();
            else
                enhanced();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (radioButton2.Checked == true)
            //{
            //    int row = e.RowIndex;
            //    int col = e.ColumnIndex;
            //    if (col == 0)
            //    {
            //        dataGridView1.Rows[row].Cells[0].Selected = false;
            //        dataGridView1.Rows[row].Cells[1].Selected = true;
            //    }
            //    else
            //    {
            //        dataGridView1.Rows[row].Cells[1].Selected = false;
            //        dataGridView1.Rows[row + 1].Cells[0].Selected = true;
            //    }
                
            //}

        }
    }
}