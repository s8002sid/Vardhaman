using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class dateselection : Form
    {
        public string datefrom, dateto;
        public dateselection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datefrom = dateTimePicker1.Text.ToString().Split(Convert.ToChar(" "))[0];
            dateto = dateTimePicker2.Text.ToString().Split(Convert.ToChar(" "))[0];
        }

        private void dateselection_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Focus();
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}