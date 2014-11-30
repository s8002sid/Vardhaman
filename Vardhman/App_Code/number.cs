using System;
using System.Collections.Generic;
using System.Text;

namespace Vardhman.App_Code
{
    class number
    {
        public static string num2text(Int32 value)
        {
            string op;
            Int32 val = value;
            Int32 carore, lakh, thousand, hundred, tens;
            carore =value / 10000000;
            value %= 10000000;
            lakh = value / 100000;
            value%=100000;
            thousand = value / 1000;
            value%=1000;
            hundred = value / 100;
            value%=100;
            tens = value;
            op = "";
            if (carore != 0)
                op += cal(carore) + " Carore ";
            if (lakh != 0)
                op += cal(lakh) + " Lakh ";
            if (thousand != 0)
                op += cal(thousand) + " Thousand ";
            if (hundred != 0)
                op += cal(hundred) + " Hundred ";
            if (tens != 0)
                op += cal(tens);
            op += " Rupees Only...";
            return op.ToUpper();
        }
        private static string cal(Int32 x)
        {
            if (x < 20)
                return text(x);
            else
                return text(x - x%10) + " " + text(x % 10);
        }
        private static string text(Int32 x)
        {
            switch (x)
            {
                case 0: return ""; break;
                case 1: return "one"; break;
                case 2: return "two"; break;
                case 3: return "three"; break;
                case 4: return "four"; break;
                case 5: return "five"; break;
                case 6: return "six"; break;
                case 7: return "seven"; break;
                case 8: return "eight"; break;
                case 9: return "nine"; break;
                case 10: return "ten"; break;
                case 11: return "eleven"; break;
                case 12: return "twelve"; break;
                case 13: return "thirteen"; break;
                case 14: return "fourteen"; break;
                case 15: return "fifteen"; break;
                case 16: return "sixteen"; break;
                case 17: return "seventeen"; break;
                case 18: return "eighteen"; break;
                case 19: return "nineteen"; break;
                case 20: return "twenty"; break;
                case 30: return "thirty"; break;
                case 40: return "fourty"; break;
                case 50: return "fifty"; break;
                case 60: return "sixty"; break;
                case 70: return "seventy"; break;
                case 80: return "eighty"; break;
                case 90: return "ninety"; break;
            }
            return "";
        }
    }
}
