using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class line_grp : Form
    {
        public line_grp()
        {
            InitializeComponent();
        }

        private void line_grp_Load(object sender, EventArgs e)
        {
            line_group_creation lgc = new line_group_creation();
            lgc.check4allgroup();
        }
    }
}
