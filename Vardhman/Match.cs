using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class Match : Form
    {
        bool setbydgv;
        public Match()
        {
            InitializeComponent();
        }
        private DataTable dt;

        public DataTable Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        string output;

        public string Output
        {
            get { return output; }
            set { output = value; }
        }
        private void Match_Load(object sender, EventArgs e)
        {
            setbydgv = false;
            if (dt == null)
            {
                setbydgv = false;
                this.Close();
                return;
            }
            
            foreach (DataRow dr in dt.Rows)
            {
                dgv_link.Rows.Add(dr[0].ToString() , dr[2].ToString());

            }
            
        }

        private void Match_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (setbydgv == false)
                Output = "";
        }

        private void dgv_link_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            setbydgv = true;
            Output = dgv_link.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setbydgv = false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Output = null;
            setbydgv = true;
            setbydgv = true;
            this.Close();
        }

        private void Match_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgv_link.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Up)
                {

                    int total = dgv_link.Rows.Count;
                    int current = 1;
                    if (dgv_link.SelectedRows.Count == 0)
                    {
                        if (dgv_link.CurrentCell != null)
                        {
                            current = dgv_link.CurrentCell.RowIndex;
                            dgv_link.Rows[current].Selected = false;
                        }
                        else
                            current = 1;
                    }
                    else if (dgv_link.SelectedRows[0].Index == 0)
                    {
                        current = total;
                        dgv_link.Rows[0].Selected = false;
                    }
                    else
                    {
                        current = dgv_link.SelectedRows[0].Index;
                        dgv_link.Rows[current].Selected = false;
                    }
                    dgv_link.Rows[(current - 1) % total].Selected = true;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    int total = dgv_link.Rows.Count;
                    int current;
                    if (dgv_link.SelectedRows.Count == 0)
                        current = 0;
                    else
                    {
                        current = dgv_link.SelectedRows[0].Index;
                        dgv_link.Rows[current].Selected = false;
                    }
                    dgv_link.Rows[(current + 1) % total].Selected = true;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (dgv_link.SelectedRows.Count != 0)
                {
                    if (dgv_link.SelectedRows.Count == 0)
                        return;
                    setbydgv = true;
                    output = dgv_link.SelectedRows[0].Cells[0].Value.ToString();
                }
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                setbydgv = false;
                this.Close();
            }
        }
    }
}
