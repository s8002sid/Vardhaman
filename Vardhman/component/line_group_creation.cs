using System;
using System.Collections.Generic;
using System.Text;

namespace Vardhman
{
    class line_group_creation
    {
        public void check(string city)
        {
            city = city.ToLower();
            Connection con = new Connection();
            con.connent();
            System.Data.DataTable dt = con.getTable("select distinct([group]) from line");
            int flag = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string x = dt.Rows[i][0].ToString().ToLower().Replace("line", "");
                if (x == "")
                    continue;
                if (city.Contains(x))
                {
                    con.exeNonQurey(string.Format("exec insert_line_group '{0}','{1}'", city.ToUpper(), dt.Rows[i][0].ToString().ToUpper()));
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                con.exeNonQurey(string.Format("exec insert_line_group '{0}','{1}'", city.ToUpper(), city.ToUpper()));
            }
        }
        public void check4allgroup()
        {
            Connection con = new Connection();
            con.connent();
            System.Data.DataTable dt = con.getTable("select distinct(city) from customer");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                check(dt.Rows[i][0].ToString().ToLower());
            }
        }
    }
}
