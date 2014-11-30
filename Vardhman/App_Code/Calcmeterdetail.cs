using System;
using System.Collections.Generic;
using System.Text;

namespace Vardhman
{
    class Calcmeterdetail
    {
        public string meter, qty;
        Connection con = new Connection();

        private int strchk(string str , string meter_dg , string quantity)
        {
            if (str.Trim() == "")
            {
                meter = meter_dg;
                qty = quantity;
                return 0;
            }
            string[] y = str.Split(Convert.ToChar(","));
            for (int i = 0; i < y.Length; i++)
            {
                string intchk = y[i];
                string[] intochk = y[i].Split(Convert.ToChar("*"));
                if (intochk.Length == 1)
                {
                    try
                    {
                        double data = Convert.ToDouble(intochk[0]);
                    }
                    catch
                    {
                        meter = meter_dg;
                        qty = quantity;
                        return 0;
                    }
                }
                else if (intochk.Length == 2)
                {
                    try
                    {
                        double data1 = Convert.ToDouble(intochk[0]);
                        double data2 = Convert.ToDouble(intochk[1]);
                    }
                    catch
                    {
                        meter = meter_dg;
                        qty = quantity;
                        return 0;
                    }
                }
            }
            return 1;
        }
        public void calc(string str , string company , string group , string item , string quantity , string meter_dg)
        {
            string quantity1 = quantity;
            double m, q , q1 = 0;
            string[] y = str.Split(Convert.ToChar(","));
            if (strchk(str , meter_dg , quantity) == 0)
                return;
            m = 0; q = 0;
            string status = getItemStatus(company, group, item);
            if(status.Trim() == "YES")
            {
                for (int i = 0; i < y.Length; i++)
                {
                   if (y[i].Contains("*"))
                    {
                        string[] z = y[i].Split(Convert.ToChar("*"));
                        m += Convert.ToDouble(z[0]) * Convert.ToInt32(z[1]);
                        q +=Convert.ToInt32(z[1]);
                    }
                    else
                    {
                        q++;
                        m += Convert.ToDouble(y[i]);
                    }
                }

            }
            else if(status.Trim() == "NO")
            {
                for (int i = 0; i < y.Length; i++)
                {
                   if (y[i].Contains("*"))
                    {
                        string[] z = y[i].Split(Convert.ToChar("*"));
                        q +=Convert.ToInt32(z[0]) *Convert.ToInt32(z[1]);
                    }
                    else
                    {
                        q += Convert.ToInt32(y[i]);
                        q1++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < y.Length; i++)
                {
                    if (y[i].Contains("*"))
                    {
                        string[] z = y[i].Split(Convert.ToChar("*"));
                        m +=Convert.ToDouble(z[0]) *Convert.ToInt32(z[1]);
                        q +=Convert.ToInt32(z[1]);
                    }
                    else
                    {
                        q++;
                        m += Convert.ToDouble(y[i]);
                    }
                }
            }
            if (m == 0)
            {
                meter = "";
                qty = q.ToString();
            }
            else
            {
                qty = q.ToString();
                meter = m.ToString();
            }
            if (q1 == 0)
                q1 = q;
            chk_meter_qty(quantity1, meter_dg , q1.ToString());

        }
        private void chk_meter_qty(string quantity_dg ,string meter_dg , string q1)
        {
            double m, q, m_dg, q_dg;
            if (quantity_dg == "" || qty == "")
                return;
            if(meter == "")
                m = Convert.ToDouble(qty);
            else
            m = Convert.ToDouble(meter);
            q = Convert.ToDouble(qty);
            q_dg = Convert.ToDouble(quantity_dg);
            if (meter_dg == "" && (quantity_dg == qty || quantity_dg == meter))
            {
                meter = "";
                qty = m.ToString();
            }
            else if (q1 == quantity_dg)
            {
                qty = q1;
                meter = m.ToString();
            }
            else if (meter == "")
                qty = m.ToString();
            else
                qty = q1;
        }
        private string getItemStatus(string company, string group, string item)
        {
            con.connent();
            string x = con.exesclr(string.Format("exec getMeterCount '{0}' , '{1}' , '{2}'",company , group , item));
            con.disconnect();
            return x;
        }
    }
}
