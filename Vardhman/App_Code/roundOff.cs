using System;
namespace Vardhman
{
    class roundOff
    {
        public static string round(string text)
        {
            double value;
            try
            {
                value = Convert.ToDouble(text);
                return round(value);
            }
            catch { }
            return "";            
        }
        public static string round(double value)
        {
            double integer, point, actualpoint;
                string total;
                integer = Math.Floor(value);
                point = value - integer;
                if (point < 0.5)
                    actualpoint = 0.0;
                else
                    actualpoint = 1.0;
                total = Convert.ToString(integer + actualpoint);
                switch (actualpoint.ToString().Length)
                {
                    case 1: total += ".00"; break;
                    case 3: total += "0"; break;
                }
                return total;
        }
        public static string withpoint(string amt)
        {
            string abc;
            Supporter.set_two_digit_precision(amt, out abc);
            return abc;
            //if (amt == "")
            //    return "0.00";
            //if (amt.Contains("."))
            //{
            //    string[] y = amt.Split(Convert.ToChar( "."));
            //    if (y[1].Length == 0)
            //        return amt + "00";
            //    else if (y[1].Length == 1)
            //        return amt + "0";
            //    else if (y[1].Length == 2)
            //        return amt;
            //    else return y[0] + "." + y[1].Substring(0, 2);
            //}
            //else
            //{
            //    return amt + ".00";
            //}
        }
        public static string check_zero(string value)
        {
            double x , y , z;
            try
            {
                x = Convert.ToDouble(value);
                y = Math.Floor(x);
                z = x - y;
            }
            catch
            {
                return "";
            }
            switch (z.ToString().Length)
            {
                case 1: return value + ".00"; break;
                case 3: return value + "0"; break;
                case 4: return value;
            }
            return "";
        }
    }
}
