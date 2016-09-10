using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class Password : Form
    {
        public string Passwd;
        public Password()
        {
            InitializeComponent();
        }

        private void Password_Load(object sender, EventArgs e)
        {
            Passwd = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Passwd = textBox1.Text;
        }
    }
}