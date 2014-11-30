using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class new_type_name_ : Form
    {
        public bool is_Button_Ok_Clicked;
        public string new_type;
        public new_type_name_()
        {
            InitializeComponent();
        }

        private void new_type_name__Load(object sender, EventArgs e)
        {
            is_Button_Ok_Clicked = false;
            new_type = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            is_Button_Ok_Clicked = true;
            new_type = textBox1.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
