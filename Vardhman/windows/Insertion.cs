using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class Insertion : Form
    {
        string customer_name, t_name , t_price;
        DataTable item = new DataTable();
        Color insert, update;
        public Insertion()
        {
            InitializeComponent();
        }

        private void Insertion_Load(object sender, EventArgs e)
        {
            item.Columns.Add("name");
            item.Columns.Add("price");
            item.Columns.Add("flag");
            insert = new Color();
            insert = Color.Green;
            update = new Color();
            update = Color.Orange;
            
        }
        public void data(string cust_name , string tn , string tpr , DataTable dt)
        {
            customer_name = cust_name;
            t_name = tn;
            t_price = tpr;
            item = dt;
        }
    }
}