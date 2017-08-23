using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace Vardhman
{
    public partial class Report_Viewercs : Form
    {
        public string name, city , datefrom , dateto , open , close;
        public Report_Viewercs()
        {
            InitializeComponent();
        }

        private void Report_Viewercs_Load(object sender, EventArgs e)
        {
            //loadrpt("worg");
        }
        public void loadrpt(string rptname)
        {
            ReportDocument report1;
            dataset_billing ds = new dataset_billing();
            // = new SqlDataAdapter();
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();
            Connection connection = new Connection();
            str = connection.connectionstring();
            //str.DataSource = @".\sqlexpress1";
            //str.InitialCatalog = "vardhman";
            //str.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(str.ConnectionString);
            con.Open();
            if (rptname == "worg1")
            {
                billreportworg_fill();
                //SqlCommand cmd = new SqlCommand("select * from temp_bill_detail ", con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(ds.Tables["Billdetail"]);
                //cmd = new SqlCommand("select * from temp_bill_master" , con);
                //da = new SqlDataAdapter(cmd);
                //da.Fill(ds.Tables["billmaster"]);
                //cmd = new SqlCommand("select billid , [group] , item  , qty , meter , rate , amt , isrg  from temp_bill_detail" , con);
                //da = new SqlDataAdapter(cmd);
                //da.Fill(ds.Tables["Billdetail1"]);

                //Connection connn = new Connection();
                //connn.connent();
                //DataTable dt = connn.getTable("select customer , city from temp_bill_master");
                //string cust, city;
                //cust = dt.Rows[0][0].ToString(); city = dt.Rows[0][1].ToString();
                //connn.disconnect();
                //cmd = new SqlCommand(string.Format("exec closingbalcal '{0}' , '{1}' , '{2}'" , DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() , cust , city), con);
                //da = new SqlDataAdapter(cmd);
                //da.Fill(ds.Tables["Closingbalance"]);


                //    report1 = new billreportworg();
                //    report1.SetDataSource(ds);
                //    crystalReportViewer1.ReportSource = report1;

            }
            else if (rptname == "worg2")
                billreportworg_fill2();
            else if (rptname == "smallbill")
                billreportworg_smallBill();
            else if (rptname == "recepit")
            {
                ledger_recepit_summary_rpt ds2 = new ledger_recepit_summary_rpt();
                SqlCommand cmd = new SqlCommand("select * from temp_recepit", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds2.Tables["Recepit"]);

                report1 = new recepit_border_chk();
                report1.SetDataSource(ds2);
                crystalReportViewer1.ReportSource = report1;
            }
            else if (rptname == "recepitbank")
            {
                ledger_recepit_summary_rpt ds2 = new ledger_recepit_summary_rpt();
                SqlCommand cmd = new SqlCommand("select * from temp_recepit", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds2.Tables["Recepit"]);

                report1 = new recepit_check();
                report1.SetDataSource(ds2);
                crystalReportViewer1.ReportSource = report1;
            }
            else if (rptname == "Ledger")
            {
                ledger_recepit_summary_rpt ds2 = new ledger_recepit_summary_rpt();
                SqlCommand cmd = new SqlCommand(String.Format("select name , dbo.inddatevar(date) as date1 , detail , exp, payment, recepit, date as date_orig from ledger where name = '{0}' order by date", name + " " + city), con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds2.Tables["Ledger"]);

                cmd = new SqlCommand(String.Format("select '{0}' as openbalance , '{1}' as closebalance", open, close), con);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds2.Tables["balance"]);
                report1 = new report_Ledger();
                report1.SetDataSource(ds2);
                crystalReportViewer1.ReportSource = report1;
            }
            else if (rptname == "newledger")
            {
                ledger_recepit_summary_rpt ds2 = new ledger_recepit_summary_rpt();
                SqlCommand cmd = new SqlCommand("select name , date as date1 , detail , exp, payment, recepit, dbo.indvardate(date) as date_orig from printledger", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds2.Tables["Ledger"]);

                cmd = new SqlCommand("select openbalance ,closingbal as closebalance from ledgerdetail", con);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds2.Tables["balance"]);
                report1 = new report_Ledger();
                report1.SetDataSource(ds2);
                crystalReportViewer1.ReportSource = report1;
            }
            else if (rptname == "intrestledger")
            {
                dataset_newledger dsnl = new dataset_newledger();
                SqlCommand cmd = new SqlCommand("select date , detail , exp, payment, recepit,days,intrest from printledger", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsnl.Tables["printledger"]);

                cmd = new SqlCommand("select name,city, datefrom,dateto, calculationdays as caldays, intrestper, calculationdate as caldate, openbalance as openbal, openintrest as openint , payment, recepit, intrest, closingbal as closebal, closingint as closeint from ledgerdetail", con);
                da = new SqlDataAdapter(cmd);
                da.Fill(dsnl.Tables["ledgerdetail"]);
                report_intrest_ledger reportx = new report_intrest_ledger();
                reportx.SetDataSource(dsnl);
                crystalReportViewer1.ReportSource = reportx;
            }
            else if (rptname == "Summary")
            {
                ledger_recepit_summary_rpt ds3 = new ledger_recepit_summary_rpt();
                SqlCommand cmd = new SqlCommand(String.Format("select name , dbo.inddatevar(date) as date1 , detail , exp, payment, recepit, expense, cd, vat, date as date_orig, transport from summary where date between dbo.indvardate('{0}') and dbo.indvardate('{1}') order by date , id , detail", datefrom, dateto), con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds3.Tables["Ledger"]);

                cmd = new SqlCommand(String.Format("select dbo.inddatevar(dbo.indvardate('{0}')) as datefrom ,dbo.inddatevar(dbo.indvardate('{1}')) as dateto ", datefrom, dateto), con);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds3.Tables["Datebetween"]);

                report1 = new Report_summary();
                report1.SetDataSource(ds3);
                crystalReportViewer1.ReportSource = report1;
            }
            else if (rptname == "groupbalance")
            {
                dataset_newledger dsnl = new dataset_newledger();
                SqlCommand cmdnl = new SqlCommand("select name,balance,place from groupbalance", con);
                SqlDataAdapter danl = new SqlDataAdapter(cmdnl);
                danl.Fill(dsnl.Tables["groupbalance"]);

                rpt_grp_balance rnl = new rpt_grp_balance();
                rnl.SetDataSource(dsnl);
                crystalReportViewer1.ReportSource = rnl;
            }
            
        }
        private dataset_billing getBillingDataset()
        {
            dataset_billing ds = new dataset_billing();
            // = new SqlDataAdapter();
            SqlConnectionStringBuilder str = new SqlConnectionStringBuilder();
            Connection connection = new Connection();
            str = connection.connectionstring();
            //str.DataSource = @".\sqlexpress1";
            //str.InitialCatalog = "vardhman";
            //str.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(str.ConnectionString);
            con.Open();
            //filling bill detail
            SqlCommand cmd = new SqlCommand("select * from temp_bill_detail where isrg = 0", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds.Tables["Billdetail"]);
            cmd = new SqlCommand("select * from temp_bill_master", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds.Tables["billmaster"]);
            cmd = new SqlCommand("select billid , [group] , item  , qty , meter , rate , amt , isrg  from temp_bill_detail where isrg = 0", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds.Tables["Billdetail1"]);

            //filling rg table

            cmd = new SqlCommand("select billid , [group] , item  , qty , meter , rate , amt , isrg  from temp_bill_detail where isrg = 1", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds.Tables["Billdetail_Rg"]);

            //fill isrg table
            cmd = new SqlCommand("exec dose_temp_contain_rg", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds.Tables["rgdetail"]);


            Connection connn = new Connection();
            connn.connent();
            DataTable dt = connn.getTable("select customer , city from temp_bill_master");
            string cust, city;
            cust = dt.Rows[0][0].ToString(); city = dt.Rows[0][1].ToString();
            connn.disconnect();
            cmd = new SqlCommand(string.Format("exec closingbalcal '{0}' , '{1}' , '{2}'", DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(), cust, city), con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds.Tables["Closingbalance"]);
            return ds;
        }
        private void billreportworg_fill()
        {
            dataset_billing billingDS = getBillingDataset();
            ReportDocument report1 = new billreportworg();
            //report1 = new billreportOriginal();
            report1.SetDataSource(billingDS);
            crystalReportViewer1.ReportSource = report1;
        }
        private void billreportworg_fill2()
        {
            dataset_billing billingDS = getBillingDataset();
            //report1 = new billreportworg();
            ReportDocument report1 = new billreportOriginal();
            report1.SetDataSource(billingDS);
            crystalReportViewer1.ReportSource = report1;
        }

        private void billreportworg_smallBill()
        {
            dataset_billing billingDS = getBillingDataset();
            //report1 = new billreportworg();
            ReportDocument report1 = new smallbill();
            report1.SetDataSource(billingDS);
            crystalReportViewer1.ReportSource = report1;
        }
    }
}