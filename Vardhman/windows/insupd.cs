using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class insupd : Form
    {
        public Boolean update,ok;
        public insupd()
        {
            InitializeComponent();
        }

        private void insupd_Load(object sender, EventArgs e)
        {
            update = true;
            button1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ok = true;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ok = false;
            this.Hide();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            update = checkBox2.Checked;
        }
    }
}