using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Vardhman
{
    public enum childContainer
    {
        e_Billing,
        e_Recepit,
        e_Account_Head,
        e_ItemEntry
    };
    public partial class Main : Form
    {
        Billing_dataentry bill;
        Recepit recepit;
        Account_Head account;
        emptybill empty = new emptybill();
        Item_Entry item;
        public void dispose_container(Vardhman.childContainer c)
        {
            switch(c)
            {
                case childContainer.e_Billing:
                    bill = null;
                    bill = new Billing_dataentry();
                    bill.MdiParent = this;
                    break;
            }
        }
        public Main()
        {
            InitializeComponent();
        }

        private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(this.Width / 2 - pictureBox1.Width / 2, this.Height / 2 - pictureBox1.Height / 2);
            btn_empty_bill.Location = new Point(this.Width-btn_empty_bill.Width*2, this.Height-btn_empty_bill.Height*3);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(this.Width / 2 - pictureBox1.Width / 2, this.Height / 2 - pictureBox1.Height / 2);
            btn_empty_bill.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            bill = new Billing_dataentry();
            bill.MdiParent = this;
            recepit = new Recepit();
            recepit.MdiParent = this;
            account = new Account_Head();
            account.MdiParent = this;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackgroundImage = global::Vardhman.Properties.Resources.hover;            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackgroundImage = global::Vardhman.Properties.Resources.simple;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            btn_empty_bill.BackgroundImage = global::Vardhman.Properties.Resources.pressed;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            btn_empty_bill.BackgroundImage = global::Vardhman.Properties.Resources.normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bill.Show();
            bill.BringToFront();
            bill.WindowState = FormWindowState.Maximized;
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                recepit.Show();
                recepit.BringToFront();
                recepit.WindowState = FormWindowState.Maximized;
                panel1.Visible = false;
            }
            catch
            {
                recepit = new Recepit(); 
                recepit.MdiParent = this; 
                recepit.Show();
                recepit.BringToFront();
                recepit.WindowState = FormWindowState.Maximized;
                panel1.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                account.Show();
                account.BringToFront();
                account.WindowState = FormWindowState.Maximized;
                panel1.Hide();
            }
            catch
            {
                account = new Account_Head();
                account.MdiParent = this;
                account.Show();
                panel1.Visible = false;
                account.WindowState = FormWindowState.Maximized;
                panel1.BringToFront();
            }
            
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                empty.ShowDialog();
            }
            catch
            {
                empty = new emptybill();
                empty.ShowDialog();
            }
        }
        private void ledger()
        {
            //accountselect frm = new accountselect();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    Report_Viewercs rp = new Report_Viewercs();
            //    rp.name = frm.name;
            //    rp.city = frm.city;
            //    rp.loadrpt("Ledger");
            //    rp.ShowDialog();
            //}
            panel1.Visible = false;
            Ledger_showall ls = new Ledger_showall();
            ls.MdiParent = this;
            panel1.Visible = false;
            ls.Show();
            ls.BringToFront();
            ls.WindowState = FormWindowState.Maximized;
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ledger();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ledger();
        }
        private void summary()
        {
            dateselection frm = new dateselection();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Report_Viewercs rp = new Report_Viewercs();
                rp.datefrom = frm.datefrom;
                rp.dateto = frm.dateto;
                rp.loadrpt("Summary");
                rp.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            summary();
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            summary();
        }
        private void autobackup()
        {
            Connection con = new Connection();
            con.connent();
            string x = con.exesclr("exec chk_autobackuppath");
            if (x == "0")
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string activedir = folderBrowserDialog1.SelectedPath;
                con.exeNonQurey(string.Format("insert into autobackuppath([path]) values('{0}')", activedir));
                string folder = DateTime.Now.Day.ToString() + '_' + DateTime.Now.Month + '_' + DateTime.Now.Year;
                string newpath = Path.Combine(activedir, folder);
                if (!Directory.Exists(newpath))
                    Directory.CreateDirectory(newpath);
                string filepath = Path.Combine(newpath, "fullbackup.bak");
                if (!File.Exists(filepath))
                    con.exeNonQurey(string.Format("exec full_backup '{0}'", filepath));
            }
            else
            {

                string activedir = con.exesclr("select max([path]) as path from autobackuppath");;
                string folder = DateTime.Now.Day.ToString() + '_' + DateTime.Now.Month + '_' + DateTime.Now.Year;
                string newpath = Path.Combine(activedir, folder);
                if (!Directory.Exists(newpath))
                    Directory.CreateDirectory(newpath);
                string filepath = Path.Combine(newpath, "fullbackup.bak");
                if (!File.Exists(filepath))
                    con.exeNonQurey(string.Format("exec full_backup '{0}'", filepath));
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                item.MdiParent = this;
                item.WindowState = FormWindowState.Maximized;
                panel1.Visible = false;
                item.Show();
                item.BringToFront();
            }
            catch
            {
                item = new Item_Entry();
                item.MdiParent = this;
                panel1.Visible = false;
                item.WindowState = FormWindowState.Maximized;
                item.Show();
                item.BringToFront();
            }
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string x = folderBrowserDialog1.SelectedPath;
            string filename = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year + DateTime.Now.Hour.ToString() + DateTime.Now.Minute + DateTime.Now.Second;
            string path = Path.Combine(x, filename + ".bak");
            Connection con = new Connection();
            con.connent();
            con.exeNonQurey(string.Format("exec full_backup '{0}'" , path));
            MessageBox.Show("Backup Completed with filename in format date , month , year , hour , min , sec", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.disconnect();
        }

        private void recoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("for recovery we will first backup database select location for backup");
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            
            string x = folderBrowserDialog1.SelectedPath;
            string filename = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year + DateTime.Now.Hour.ToString() + DateTime.Now.Minute + DateTime.Now.Second;
            string path = Path.Combine(x, filename + ".bak");

            SqlConnectionStringBuilder str;
            SqlConnection conn;
            str = new SqlConnectionStringBuilder();
            str.DataSource = @".\sqlexpress";
            str.InitialCatalog = "master";
            str.IntegratedSecurity = true;
            conn = new SqlConnection(str.ConnectionString);
            conn.Open();
            SqlCommand cmd;
            cmd = new SqlCommand(string.Format("BACKUP DATABASE vardhman TO DISK = '{0}'", path) , conn);
            cmd.ExecuteNonQuery();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            x = openFileDialog1.FileName;
            cmd = new SqlCommand(string.Format("RESTORE DATABASE vardhman FROM DISK = '{0}'", x) , conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Restore Completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Deletion d = new Deletion();
            panel1.Visible = false;
            d.BringToFront();
            d.MdiParent = this;
            d.Show();
            d.WindowState = FormWindowState.Maximized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Price_List d = new Price_List();
            panel1.Visible = false;
            d.BringToFront();
            d.MdiParent = this;
            d.Show();
            d.WindowState = FormWindowState.Maximized;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ManualBilling d = new ManualBilling();
            panel1.Visible = false;
            d.BringToFront();
            d.MdiParent = this;
            d.Show();
            d.WindowState = FormWindowState.Maximized;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ManualRecepit d = new ManualRecepit();
            panel1.Visible = false;
            d.BringToFront();
            d.MdiParent = this;
            d.Show();
            d.WindowState = FormWindowState.Maximized;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new_ledger d = new new_ledger();
            panel1.Visible = false;
            d.BringToFront();
            d.MdiParent = this;
            d.Show();
            d.WindowState = FormWindowState.Maximized;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ITEM_TYPE_MERGE d = new ITEM_TYPE_MERGE();
            panel1.Visible = false;
            d.BringToFront();
            d.MdiParent = this;
            d.Show();
            d.WindowState = FormWindowState.Maximized;
        }
    }
}