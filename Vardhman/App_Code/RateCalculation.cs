using System;
using System.Collections.Generic;
using System.Text;

namespace Vardhman
{
    class RateCalculation
    {
        private static double strDoubleChk(string x)
        {
            double tag;
            try
            {
                tag = Convert.ToDouble(x);
                string start, mid, end;
                if (x.StartsWith("5") && x.EndsWith("5"))
                {
                    mid = x.Substring(1, x.Length - 2);
                    return Convert.ToDouble(mid);
                }
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }
        public static double rateCalc(string x)
        {
            double rate = strDoubleChk(x);
            if (rate == 0)
            {
                return 0;
            }
            if (x.Length > 6)
            {
                return rate / 100 - 100;
            }
            else
            {
                return rate - 100;
            }
        }
        public static double rateCalc(string[] x)
        {
            double y = 0;
            for (int i = 0; i < x.Length; i++)
            {
                y = rateCalc(x[i]);
                if (y != 0)
                    break;
            }
            return y;
        }
    }
}
