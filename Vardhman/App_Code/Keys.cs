using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Vardhman
{
    class Key_check
    {
        public static Boolean isNumeric(Keys k)
        {
            if ((((int)k >= 48 && (int)k <= 56) || k == Keys.Enter || k == Keys.Back || k == Keys.OemPeriod))
                return true;
            else
                return false;
        }
        public static Boolean hasDot(string value)
        {
            if (value.Contains("."))
                return true;
            else
                return false;
        }
    }
}
