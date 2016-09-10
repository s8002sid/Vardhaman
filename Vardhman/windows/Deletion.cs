using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    public partial class Deletion : Form
    {
        Connection con = new Connection();
        public Deletion()
        {
            InitializeComponent();
        }

        private void Deletion_Load(object sender, EventArgs e)
        {
            con.connent();
            label1.Text = "Bill Deletion";
            fill();
        }
        private void fill()
        {
            DataTable dt = null;
            if (radioButton1.Checked == true)
            {
                dt = con.getTable(string.Format("select name , city from customer where name like('{0}%') order by name" , textBox1.Text));
                label1.Text = "Account Deletion";
                splitContainer1.Panel1.BackColor = Color.LightBlue;
            }
            else if (radioButton2.Checked == true)
            {
                dt = con.getTable(string.Format("select name , city , billno , dbo.inddatevar(date) as date , total , expenses , grandtotal from view_bill_master where name like('{0}%') order by billno", textBox1.Text));
                label1.Text = "Bill Deletion";
                splitContainer1.Panel1.BackColor = Color.LightCoral;
            }
            else if (radioButton3.Checked == true)
            {
                dt = con.getTable(string.Format("select name , city , recepitno , dbo.inddatevar(date) as date , amount as total , cd , total as grandtotal , bank as [bank name] , bank_city , checknumber from view_recepit where name like('{0}%') order by recepitno", textBox1.Text));
                label1.Text = "Recepit Deletion";
                splitContainer1.Panel1.BackColor = Color.LightGoldenrodYellow;
            }
            else if (radioButton4.Checked == true)
            {
                dt = con.getTable(string.Format("select date , name , city , bank_name , bank_city , checkno , bounce_charge , recepitno , id from view_cbe where  name like('{0}%') order by name", textBox1.Text));
                label1.Text = "Chk Bounce Entry Deletion";
                splitContainer1.Panel1.BackColor = Color.LightSeaGreen;
            }
            dataGridView1.DataSource = dt;
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fill();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Password p = new Password();
            if (p.ShowDialog() == DialogResult.Cancel)
                return;
            string passwd = p.Passwd;
            string value1, value2;
            string storedpass = con.exesclr("select min(passwd) as password from password_");
            if (storedpass != passwd)
            {
                MessageBox.Show("Password donot match");
                return;
            }
            if (radioButton1.Checked == true)
            {
                value1 = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["name"].Value.ToString();
                value2 = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["city"].Value.ToString();
                MessageBox.Show("Account deleted Successfully");
            }
            else if (radioButton2.Checked == true)
            {
                value1 = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["billno"].Value.ToString();
                con.exeNonQurey(string.Format("exec bill_del {0}", value1));
                con.exeNonQurey(string.Format("exec insert_deletion_history 'Bill',{0}", value1));
                MessageBox.Show("Bill Deleted Successfully");
            }
            else if (radioButton3.Checked == true)
            {
                value1 = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["recepitno"].Value.ToString();
                con.exeNonQurey(string.Format("delete from recepit where recepitno = {0}", value1));
                con.exeNonQurey(string.Format("exec insert_deletion_history 'Receipt',{0}", value1));
                MessageBox.Show("Recepit Deleted Successfully");
            }
            else if (radioButton4.Checked == true)
            {
                value1 = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id"].Value.ToString();
                con.exeNonQurey(string.Format("delete from check_bounse_entry where id = {0}" , value1));
                MessageBox.Show("Check bounce entery deleted successfully");
            }
            create_backup.create();
            fill();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fill();
        }
    }
}