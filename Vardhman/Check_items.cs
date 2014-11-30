using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class Check_items : Form
    {
        DataGridViewCellStyle def = new DataGridViewCellStyle();
        DataGridViewCellStyle nu = new DataGridViewCellStyle();
        DataGridViewCellStyle red = new DataGridViewCellStyle();
        public Check_items()
        {
            InitializeComponent();
        }

        private void Check_items_Load(object sender, EventArgs e)
        {

        }
        public void gettable(DataTable dt)
        {
            nu.BackColor =Color.FromArgb(162, 164, 244);
            def.BackColor = Color.White;
            red.BackColor = Color.Red;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int z = dataGridView1.Rows.Add();
                dataGridView1.Rows[z].Cells["Company"].Value = dt.Rows[i]["Company"];
                dataGridView1.Rows[z].Cells["Group"].Value = dt.Rows[i]["Group"];
                dataGridView1.Rows[z].Cells["Item"].Value = dt.Rows[i]["Item"];
                dataGridView1.Rows[z].Cells["itemdetail"].Value = dt.Rows[i]["Itemdetail"];
                dataGridView1.Rows[z].Cells["Quantity"].Value = dt.Rows[i]["Quantity"];
                dataGridView1.Rows[z].Cells["Meter"].Value = dt.Rows[i]["Meter"];
                dataGridView1.Rows[z].DefaultCellStyle = def;
            }
            dataGridView1.Sort(dataGridView1.Columns["Group"], ListSortDirection.Ascending);
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            try
            {
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle == nu)
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle = def;
                else
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle = nu;
            }
            catch
            {

            }
            else if(e.ColumnIndex == 1)
            try
            {
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle == nu || dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle == def)
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle = red;
                else
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle = def;
            }
            catch
            { }
        
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null && (bool)dataGridView1.Rows[e.RowIndex].Cells[1].Value == true)
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle = red;
                else if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null && (bool)dataGridView1.Rows[e.RowIndex].Cells[0].Value == true)
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle = nu;
                else
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle = def;
            }
        }

        
        
    }
}