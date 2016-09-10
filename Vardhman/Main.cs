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
        e_AccountHead,
        e_EmptyBill,
        e_ItemTypeMerge,
        e_NewLedger,
        e_ManualRecepit,
        e_ManualBilling,
        e_PriceList,
        e_Deletion,
        e_Ledger
    };
    public partial class Main : Form
    {
        Billing_dataentry bill;
        Recepit recepit;
        Account_Head account;
        emptybill empty;

        ITEM_TYPE_MERGE itemTypeMerge;
        new_ledger newLedger;
        ManualRecepit manualRecepit;
        ManualBilling manualBilling;
        Price_List priceList;
        Deletion deletion;
        Ledger_showall ledger;
        public void init_container(Vardhman.childContainer c)
        {
            switch(c)
            {
                case childContainer.e_Billing:
                    bill = null;
                    bill = new Billing_dataentry();
                    bill.MdiParent = this;
                    break;
                case childContainer.e_Recepit:
                    recepit = null;
                    recepit = new Recepit();
                    recepit.MdiParent = this;
                    break;
                case childContainer.e_AccountHead:
                    account = null;
                    account = new Account_Head();
                    account.MdiParent = this;
                    break;
                case childContainer.e_EmptyBill:
                    empty = null;
                    empty = new emptybill();
                    empty.MdiParent = this;
                    break;
                case childContainer.e_ItemTypeMerge:
                    itemTypeMerge = new ITEM_TYPE_MERGE();
                    itemTypeMerge.MdiParent = this;
                    break;
                case childContainer.e_NewLedger:
                    newLedger = new new_ledger();
                    newLedger.MdiParent = this;
                    break;
                case childContainer.e_ManualRecepit:
                    manualRecepit = new ManualRecepit();
                    manualRecepit.MdiParent = this;
                    break;
                case childContainer.e_ManualBilling:
                    manualBilling = new ManualBilling();
                    manualBilling.MdiParent = this;
                    break;
                case childContainer.e_PriceList:
                    priceList = new Price_List();
                    priceList.MdiParent = this;
                    break;
                case childContainer.e_Deletion:
                    deletion = new Deletion();
                    deletion.MdiParent = this;
                    break;
                case childContainer.e_Ledger:
                    ledger = new Ledger_showall();
                    ledger.MdiParent = this;
                    break;
            }
            panel1.Show();
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
            init_container(childContainer.e_Billing);
            init_container(childContainer.e_Recepit);
            init_container(childContainer.e_AccountHead);
            init_container(childContainer.e_EmptyBill);
            init_container(childContainer.e_ItemTypeMerge);
            init_container(childContainer.e_NewLedger);
            init_container(childContainer.e_ManualRecepit);
            init_container(childContainer.e_ManualBilling);
            init_container(childContainer.e_PriceList);
            init_container(childContainer.e_Deletion);
            init_container(childContainer.e_Ledger);
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
            recepit.Show();
            recepit.BringToFront();
            recepit.WindowState = FormWindowState.Maximized;
            panel1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
                account.Show();
                account.BringToFront();
                account.WindowState = FormWindowState.Maximized;
                panel1.Hide();            
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            empty.Show();
            empty.BringToFront();
            empty.WindowState = FormWindowState.Maximized;
            panel1.Hide();
        }
        private void Ledger()
        {
            panel1.Visible = false;
            panel1.Visible = false;
            ledger.Show();
            ledger.BringToFront();
            ledger.WindowState = FormWindowState.Maximized;
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ledger();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ledger();
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
            panel1.Visible = false;
            deletion.BringToFront();
            deletion.Show();
            deletion.WindowState = FormWindowState.Maximized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            priceList.BringToFront();
            priceList.Show();
            priceList.WindowState = FormWindowState.Maximized;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            manualBilling.BringToFront();
            manualBilling.Show();
            manualBilling.WindowState = FormWindowState.Maximized;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            manualRecepit.BringToFront();
            manualRecepit.Show();
            manualRecepit.WindowState = FormWindowState.Maximized;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            newLedger.BringToFront();
            newLedger.Show();
            newLedger.WindowState = FormWindowState.Maximized;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            itemTypeMerge.BringToFront();
            itemTypeMerge.Show();
            itemTypeMerge.WindowState = FormWindowState.Maximized;
        }
    }
}