using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class interest_caculator : Form
    {
        public interest_caculator()
        {
            InitializeComponent();
        }

        private void interest_caculator_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Type");
            dt.Columns.Add("Detail");
            dt.Columns.Add("Bill");
            dt.Columns.Add("Recepit");
            dt.Columns.Add("Days");
            dt.Columns.Add("Interest");
            //DataGridViewComboBoxColumn Column1=new System.Windows.Forms.DataGridViewComboBoxColumn();;
            //Column1.HeaderText = "Column1";
            //Column1.Items.AddRange(new object[] {
            //"Bill",
            //"Recepit",
            //"RecepitBank",
            //"Chk Bounse Panelty"});
            //Column1.Name = "Column1";
            //dt.Columns.Add(Column1);
            //dataGridView1.DataSource = dt;
        }
    }
}