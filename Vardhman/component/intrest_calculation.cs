using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Vardhman
{
    class intrest_calculation
    {
        DataTable dt;

        public DataTable Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        public double total1, grandtotal1, intresttotal1,openint;
        public intrest_calculation(DataTable dt1)
        {
            dt = dt1;
        }
        private string two_length_string(string day)
        {
            if (day.Length == 1)
                return "0" + day;
            else
                return day;
        }
        private DateTime converttodate(string date)//from indian format to vs format
        {
            string[] s = date.Split('/');
            return new DateTime(Convert.ToInt32(s[2]), Convert.ToInt32(s[1]), Convert.ToInt32(s[0]));
        }
        public void calculate(int type,DateTime caldate,double percent,int caldays,DateTime opendate,DateTime closedate)
        {
            //System.Windows.Forms.MessageBox.Show(gap_in_financial_year(new DateTime(2011, 4, 1), new DateTime(2013, 4, 1),0).ToString());
            //type 0 month
            //type 1 quater
            //type 2 halfyearly
            //type 3 1 yearly
            double calintrest = 0;
            Connection con = new Connection();
            con.connent();
            con.exeNonQurey("delete from printledger");
            if (Dt.Rows.Count == 0)
                return;
            DateTime date = converttodate(Dt.Rows[0][0].ToString());
            
            DateTime amountdate;
            double amount = 0;
            DateTime prevdate,curdate;
            prevdate = getdate(0);
            double total = 0;
            
            double calint2 = 0;
            double calint3 = 0;
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                curdate = getdate(i);
                DateTime pd1 = prevdate;


                //-----------------------------------------------------------------------------------

                int abc = gap_in_financial_year(prevdate, curdate,type);

                DateTime p = prevdate;
                int xyz = abc;
                while (abc != 0)
                {
                    DateTime d = getstartdate(getenddate(p, type).AddDays(1), type);
                    p = d;
                    amount = amount + calint2;
                    calint3 += calint2 + intrest(d, calint3+calint2, caldate, percent, caldays, type, "Opening balance");
                    if (DateTime.Compare(d, opendate) <= 0)
                    {
                        openint = calint3;// +intrest(d, calint3, caldate, percent, caldays, type, "Closing intrest"); 
                        //openint = calintrest + intrest(d, calintrest, caldate, percent, caldays, type, "Closing intrest"); ;
                    }

                    //if (DateTime.Compare(d, opendate) < 0 && xyz == 1)
                    //{
                    //    openint = calint3;//+ intrest(d, calint3, caldate, percent, caldays, type, "Closing intrest"); ;
                    //    //openint = calintrest;// +intrest(d, calintrest, caldate, percent, caldays, type, "Closing intrest"); ;
                    //}

                    //calint3 += calint2 + intrest(d, total, caldate, percent, caldays, type, "Opening balance");

                    double ci1 = calintrest;
                    calintrest = calintrest + intrest(d, amount, caldate, percent, caldays, type, "Opening balance");

                    int a = getenddate(d, type).Subtract(d).Days + 1;
                    int b = caldate.Subtract(d).Days + 1;
                    if (b < a)
                        a = b;

                    string res;
                    Supporter.set_two_digit_precision(total.ToString(), out res);
                    string date11 = two_length_string(d.Day.ToString()) + "/" + two_length_string(d.Month.ToString()) + "/" + d.Year.ToString();
                    if(res!="0.00")
                    con.exeNonQurey(string.Format("insert into printledger(date,detail,exp,payment,recepit,days,intrest,transtype,detail1) values('{0}','{1}',{2},{3},{4},{5},{6},'Opening balance',NULL)",
                        date11, "Opening Balance", "NULL", res, "NULL",
                        a.ToString(),
                        intrest(d, total, caldate, percent, caldays, type, "Opening balance")));
                    calint2 = intrest(d, total, caldate, percent, caldays, type, "Opening balance");
                    


                    abc--;
                }

                //-----------------------------------------------------------------------------------


                //int abc = gap_in_financial_year(prevdate, curdate,type);
                //bool xyz = false;
                //if (abc == 1)
                //    xyz = true;
                //while(abc!=0)
                //{
                //    amount = amount + calintrest;

                //    calintrest += intrest(getstartdate(curdate, type), amount, caldate, percent, caldays, type, "Opening balance");
                //    pd1 = getstartdate(getenddate(pd1,type).AddDays(1),type);
                //    DateTime d = getstartdate(pd1, type);

                //    int a = getnextdate(getenddate(d,type), type).Subtract(d).Days + 1;
                //    int b = caldate.Subtract(d).Days + 1;
                //    if (b < a)
                //        a = b;
                //    string res;
                //    Supporter.set_two_digit_precision(total.ToString(), out res);
                //    string date11 = two_length_string(d.Day.ToString()) + "/" + two_length_string(d.Month.ToString()) + "/" + d.Year.ToString();
                //    con.exeNonQurey(string.Format("insert into printledger(date,detail,exp,payment,recepit,days,intrest,transtype,detail1) values('{0}','{1}',{2},{3},{4},{5},{6},'Opening balance',NULL)",
                //        date11, "Opening Balance", "NULL", res, "NULL",
                //        a.ToString(),                        
                //        intrest(getstartdate(curdate, type), total, caldate, percent, caldays, type, "Opening balance")));
                //    Supporter.set_two_digit_precision((amount - total).ToString(), out res);

                //    if (DateTime.Compare(d, opendate) < 0)
                //    {
                //        openint = calintrest + intrest(d, calintrest, caldate, percent, caldays, type, "Closing intrest"); ;
                //    }
                //    //curdate = getstartdate(getenddate(curdate, type).AddDays(1), type);
                //    abc--;
                //}

                {

                    int a = getnextdate(curdate, type).Subtract(getdate(i)).Days + 1;
                    int b = caldate.Subtract(getdate(i)).Days + 1;
                    if (b < a)
                        a = b;
                    if (Dt.Rows[i][1].ToString() == "Bill")
                        a -= 60;
                    double d = intrest(getdate(i), amount, caldate, percent, caldays, type, "Opening balance");
                    con.exeNonQurey(string.Format("insert into printledger(date,detail,exp,payment,recepit,days,intrest,transtype,detail1) values('{0}','{1}',{2},{3},{4},{5},{6},'{7}','{8}')",
                        Dt.Rows[i][0], Dt.Rows[i][1].ToString() + "--" + Dt.Rows[i][2].ToString(), getnullstr(i, 3),
                        getnullstr(i, 4), getnullstr(i, 5),
                        a.ToString(),
                        intrest(getdate(i), getamount(i), caldate, percent, caldays, type, Dt.Rows[i][1].ToString()), Dt.Rows[i][1].ToString(), Dt.Rows[i][2].ToString()));
                    
                }
                amountdate = converttodate(Dt.Rows[i][0].ToString());
                amount += getamount(i);
                total = total + getamount(i);
                calintrest += intrest(getdate(i), getamount(i), caldate, percent, caldays, type, Dt.Rows[i][1].ToString());
                calint2 += intrest(getdate(i), getamount(i), caldate, percent, caldays, type, Dt.Rows[i][1].ToString());
                if (DateTime.Compare(curdate, opendate) < 0)
                {
                    double x = intrest(getstartdate(getenddate(curdate,type),type),calintrest,caldate,percent,caldays,type,"Closing intrest");
                    openint = calintrest + intrest(getstartdate(getenddate(curdate,type),type),calintrest,caldate,percent,caldays,type,"Closing intrest");
                }
                prevdate = curdate;
            }
            
            //=======================================================

            int abc1 = gap_in_financial_year(converttodate(dt.Rows[dt.Rows.Count-1][0].ToString()), caldate, type);

            DateTime p1 = converttodate(dt.Rows[dt.Rows.Count - 1][0].ToString());
            int xyz1 = abc1;
            while (abc1 != 0)
            {
                DateTime d = getstartdate(getenddate(p1, type).AddDays(1), type);
                p1 = d;
                amount = amount + calint2;

                double ci1 = calintrest;
                calintrest = calintrest + intrest(d, amount, caldate, percent, caldays, type, "Opening balance");

                int a = getenddate(d, type).Subtract(d).Days + 1;
                int b = caldate.Subtract(d).Days + 1;
                if (b < a)
                    a = b;

                string res;
                Supporter.set_two_digit_precision(total.ToString(), out res);
                string date11 = two_length_string(d.Day.ToString()) + "/" + two_length_string(d.Month.ToString()) + "/" + d.Year.ToString();
                if(res!="0.00")
                con.exeNonQurey(string.Format("insert into printledger(date,detail,exp,payment,recepit,days,intrest,transtype,detail1) values('{0}','{1}',{2},{3},{4},{5},{6},'Opening balance',NULL)",
                    date11, "Opening Balance", "NULL", res, "NULL",
                    a.ToString(),
                    intrest(d, total, caldate, percent, caldays, type, "Opening balance")));
                calint2 = intrest(d, total, caldate, percent, caldays, type, "Opening balance");
                if (DateTime.Compare(d, opendate) <= 0 && xyz1 > 1)
                {
                    openint = ci1 + intrest(d, ci1, caldate, percent, caldays, type, "Closing intrest"); ;
                }

                if (DateTime.Compare(d, opendate) < 0 && xyz1 == 1)
                {
                    openint = calintrest;// +intrest(d, calintrest, caldate, percent, caldays, type, "Closing intrest"); ;
                }


                abc1--;
            }

            //=======================================================
            con.disconnect();
            total1 = total;
            grandtotal1 = amount;
            intresttotal1 = calintrest;
            int aaaa = DateTime.Compare(getstartdate(caldate, type), getstartdate(getdate(dt.Rows.Count - 1), type));


            //if ((DateTime.Compare(getstartdate(caldate, type), getstartdate(getdate(dt.Rows.Count - 1),type)) > 0) && (DateTime.Compare(getstartdate(caldate,type),getstartdate(opendate,type)) == 0))
            //{
            //    DateTime d = getstartdate(caldate, type);
            //    string date11 = two_length_string(d.Day.ToString()) + "/" + two_length_string(d.Month.ToString()) + "/" + d.Year.ToString();
            //    string bal = total.ToString();
            //    int diff = caldate.Subtract(d).Days;
            //    con.connent();
            //    con.exeNonQurey(string.Format("insert into printledger(date,detail,exp,payment,recepit,days,intrest,transtype,detail1) values('{0}','{1}',{2},{3},{4},{5},{6},'Opening balance',NULL)",
            //                date11, "Opening Balance", "NULL", bal, "NULL",
            //                diff.ToString(),
            //                intrest(d,Convert.ToDouble(bal), caldate, percent, caldays, type, "Opening balance")));
            //    con.disconnect();

            //    openint = (calintrest) + intrest(d, (calintrest), caldate, percent, caldays, type, "Closing intrest");
            //}
        }
        //private DateTime converttodate(string date)//from indian format to vs format
        //{
        //    string[] s = date.Split('/');
        //    return new DateTime(Convert.ToInt32(s[2]), Convert.ToInt32(s[1]), Convert.ToInt32(s[0]));
        //}
        //private void newfinyearcalculation(DateTime prevdate, DateTime caldate, int type, DateTime caldate, double percent, int caldays, DateTime opendate, DateTime closedate,double amount,double calintrest,out double newamount,out double newintrest,out DateTime newprevdate,out double newcalintrest)
        //{
        //    newamount = amount;
        //    newintrest = intrest;

        //    int abc = gap_in_financial_year(prevdate, curdate,type);

        //    DateTime p = prevdate;

        //    while (abc != 0)
        //    {
        //        DateTime d = getstartdate(getenddate(p, type).AddDays(1), type);
        //        p = d;
        //        amount = amount + calintrest;
        //        calintrest = calintrest + intrest(getstartdate(d, type), amount, caldate, percent, caldays, type, "Opening balance");

        //        int a = getenddate(d, type).Subtract(d).Days + 1;
        //        int b = caldate.Subtract(d).Days + 1;
        //        if (b < a)
        //            a = b;


        //    }

        //    newprevdate = p;
        //    newamount = amount;
        //    newcalintrest = calintrest;
        //}

        private int gap_in_financial_year(DateTime date1, DateTime date2, int type)
        {
            if (DateTime.Compare(date1, date2) < 0)
            {
                DateTime temp;
                temp = date1;
                date1 = date2;
                date2 = temp;
            }
            if (DateTime.Compare(getstartdate(date1, type), getstartdate(date2, type)) == 0)
                return 0;
            int i = 0;
            while (true)
            {
                i++;
                date2 = getstartdate(getenddate(date2, type).AddDays(1), type);
                if (DateTime.Compare(getstartdate(date1, type), getstartdate(date2, type)) == 0)
                    return i;
            }
            return 0;
        }
        private DateTime getenddate(DateTime date,int type)
        {
            int days;
            if (type == 0)
            {
                days = DateTime.DaysInMonth(date.Year, date.Month);
                return new DateTime(date.Year, date.Month, days);
            }
            else if (type == 1)
            {
                if (date.Month >= 4 && date.Month < 7)
                {
                    return new DateTime(date.Year, 6, 30);
                }
                else if (date.Month >= 7 && date.Month < 10)
                {
                    return new DateTime(date.Year, 9, 30);
                }
                else if (date.Month >= 10)
                {
                    return new DateTime(date.Year, 12, 31);
                }
                else
                {
                    return new DateTime(date.Year, 3, 31);
                }
            }
            else if (type == 2)
            {
                if (date.Month >= 4 && date.Month < 10)
                    return new DateTime(date.Year, 9, 30);
                else if (date.Month >= 10)
                    return new DateTime(date.Year + 1, 3, 31);
                else
                    return new DateTime(date.Year, 3, 31);

            }
            else if (type == 3)
            {
                if (date.Month >= 4)
                    return new DateTime(date.Year + 1, 3, 31);
                else
                    return new DateTime(date.Year, 3, 31);
            }
            return DateTime.MinValue;
        }
        private string getnullstr(int i,int j)
        {
            if (Dt.Rows[i][j].ToString() == "")
                return "NULL";
            else return Dt.Rows[i][j].ToString();
        }
        private double getamount(int i)
        {
            if (Dt.Rows[i][4].ToString() != "")
                return Convert.ToDouble(Dt.Rows[i][4].ToString());
            else
                return -Convert.ToDouble(Dt.Rows[i][5].ToString());
        }
        private DateTime getdate(int i)
        {
            return converttodate(Dt.Rows[i][0].ToString());
        }
        private double intrest(DateTime amountdate ,double amount, DateTime caldate, double percent, int caldays, int type,string transtype)
        {
            //return 0.00;
            DateTime nextdate = getnextdate(amountdate,type);
            if (nextdate.Subtract(caldate).Days >= 0)
                nextdate = caldate;
            int diff = nextdate.Subtract(amountdate).Days + 1;
            if (transtype == "Bill")
                diff = diff - caldays;
            return (diff * (amount * percent)) / 3000;
        }
        private DateTime getnextdate(DateTime date,int type)
        {
            
            //DateTime nextdate;
            int days;
            if (type == 0)
            {
                days = DateTime.DaysInMonth(date.Year, date.Month);
                return new DateTime(date.Year, date.Month, days);
            }
            else if (type == 1)
            {
                if(date.Month >=4 && date.Month < 7)
                {
                    return new DateTime(date.Year,6,30);
                }
                else if(date.Month >=7 && date.Month < 10)
                {
                    return new DateTime(date.Year,9,30);
                }
                else if(date.Month >=10)
                {
                    return new DateTime(date.Year,12,31);
                }
                else
                {
                    return new DateTime(date.Year,3,31);
                }
            }
            else if (type == 2)
            {
                if (date.Month >= 4 && date.Month < 10)
                    return new DateTime(date.Year, 9, 30);
                else if (date.Month >= 10)
                    return new DateTime(date.Year + 1, 3, 31);
                else
                    return new DateTime(date.Year, 3, 31);

            }
            else if (type == 3)
            {
                if (date.Month >= 4)
                    return new DateTime(date.Year + 1, 3, 31);
                else
                    return new DateTime(date.Year, 3, 31);
            }
            return DateTime.MinValue;
        }
        //private DateTime getnextdate(DateTime date,int type)
        //{
            
        //    //DateTime nextdate;
        //    int days;
        //    if (type == 0)
        //    {
        //        days = DateTime.DaysInMonth(date.Year, date.Month);
        //        return new DateTime(date.Year, date.Month, days);
        //    }
        //    else if (type == 1)
        //    {
        //        if(date.Month >=4 && date.Month < 7)
        //        {
        //            return new DateTime(date.Year,6,30);
        //        }
        //        else if(date.Month >=7 && date.Month < 10)
        //        {
        //            return new DateTime(date.Year,9,30);
        //        }
        //        else if(date.Month >=10)
        //        {
        //            return new DateTime(date.Year,12,31);
        //        }
        //        else
        //        {
        //            return new DateTime(date.Year,3,31);
        //        }
        //    }
        //    else if (type == 2)
        //    {
        //        if (date.Year >= 4 && date.Year < 10)
        //            return new DateTime(date.Year, 9, 30);
        //        else if (date.Month >= 10)
        //            return new DateTime(date.Year + 1, 3, 31);
        //        else
        //            return new DateTime(date.Year, 3, 31);

        //    }
        //    else if (type == 3)
        //    {
        //        if (date.Month >= 4)
        //            return new DateTime(date.Year + 1, 3, 31);
        //        else
        //            return new DateTime(date.Year, 3, 31);
        //    }
        //    return DateTime.MinValue;
        //}
        private DateTime getstartdate(DateTime date,int type)
        {
            if (type == 0)
                return new DateTime(date.Year, date.Month, 1);
            else if (type == 1)
            {
                if (date.Month >= 4 && date.Month < 7)
                {
                    return new DateTime(date.Year, 4, 1);
                }
                else if (date.Month >= 7 && date.Month < 10)
                {
                    return new DateTime(date.Year, 7, 1);
                }
                else if (date.Month >= 10)
                {
                    return new DateTime(date.Year, 10, 1);
                }
                else
                {
                    return new DateTime(date.Year, 1, 1);
                }
            }
            else if (type == 2)
            {
                if (date.Month >= 4 && date.Month < 10)
                    return new DateTime(date.Year, 4, 1);
                else if (date.Month >= 10)
                    return new DateTime(date.Year, 10, 1);
                else
                    return new DateTime(date.Year - 1, 10, 1);
            }
            else
            {
                if (date.Month >= 4)
                    return new DateTime(date.Year, 4, 1);
                else
                    return new DateTime(date.Year-1, 4, 1);
            }
        }
    }
}

//if (!DateTime.Equals(getstartdate(curdate,type),getstartdate(prevdate,type)))
//{

//    //int xxx = DateTime.Compare(getstartdate(getenddate(prevdate, type).AddDays(1),type), getstartdate(curdate,type));
//    //if (DateTime.Equals(getstartdate(caldate,type),getstartdate(curdate,type)))
//    {

//        amount = amount + calintrest;
//        calintrest += intrest(getstartdate(curdate,type), amount, caldate, percent, caldays, type, "Opening balance");

//        DateTime d = getstartdate(curdate, type);

//        int a = getnextdate(curdate, type).Subtract(d).Days + 1;
//        int b = caldate.Subtract(d).Days + 1;
//        if (b < a)
//            a = b;
//        string res;
//        Supporter.set_two_digit_precision(total.ToString(),out res);
//        string date11 =two_length_string(d.Day.ToString()) + "/" +two_length_string(d.Month.ToString()) + "/" + d.Year.ToString();
//        con.exeNonQurey(string.Format("insert into printledger(date,detail,exp,payment,recepit,days,intrest,transtype,detail1) values('{0}','{1}',{2},{3},{4},{5},{6},'Opening balance',NULL)",
//            date11, "Opening Balance", "NULL",res, "NULL",
//            a.ToString(),
//            intrest(getstartdate(curdate, type), total, caldate, percent, caldays, type, "Opening balance")));
//        Supporter.set_two_digit_precision((amount - total).ToString(),out res);
//        /*if(amount - total!=0)
//        con.exeNonQurey(string.Format("insert into printledger(date,detail,exp,payment,recepit,days,intrest,transtype,detail1) values('{0}','{1}',{2},{3},{4},{5},{6},'Opening intrest',NULL)",
//            date11, "Opening intrest", "NULL",res, "NULL",
//            a.ToString(),
//            intrest(getstartdate(curdate, type),amount - total, caldate, percent, caldays, type, "Opening intrest")));
//        */

//        if (DateTime.Compare(d, opendate) < 0)
//        {
//            openint = calintrest + intrest(d, calintrest, caldate, percent, caldays, type, "Closing intrest"); ;
//        }
//    }



//}
//if (DateTime.Equals(getstartdate(curdate, type), getstartdate(caldate, type)))