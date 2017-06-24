using System;
using System.Collections.Generic;
using System.Text;

namespace Vardhman
{
    class VatGst
    {
        static DateTime VatEndDate = new DateTime(2016, 3, 31);
        static DateTime VatStartDate = new DateTime(2013, 12, 5);
        static DateTime GSTStartDate = new DateTime(2017, 7, 1);
        static DateTime GSTEndDate = new DateTime(5000, 3, 31);
        public static string CurrentTaxStr(DateTime date)
        {
            string taxstr;
            if (date >= VatStartDate && date <= VatEndDate)
            {
                taxstr = "VAT";
            }
            else if (date >= GSTStartDate && date <= GSTEndDate)
            {
                taxstr = "GST";
            }
            else
            {
                taxstr = "VAT";
            }
            return taxstr;
        }
        public static bool IsGstEnabled(DateTime date)
        {
            if (date >= GSTStartDate && date <= GSTEndDate)
            {
                return true;
            }
            return false;
        }
        public static bool IsVatEnabled(DateTime date)
        {
            if (date >= VatStartDate && date <= VatEndDate)
            {
                return true;
            }
            return false;
        }
    }
}
