using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Vardhman.db
{
    public class Password : ATable
    {
        protected override void populate_col_list()
        {
            col_list = new e_columns[] {e_columns.e_passwd};
        }
        protected override string get_table_name()
        {
            return "password_";
        }
        public Password(Connection con, MainInternal t_internalData)
            : base(con, t_internalData)
        {

        }

        public override e_error add(e_columns[] columns, string[] values)
        {
            return e_error.e_success;
        }/*Password::add end*/
        public override e_error update(e_columns[] columns, string[] values)
        {
            return e_error.e_success;
        }/*Password::update end*/
        protected override void populate()
        {
            if (table != null)
                return;
            con.connent();
            string select_query = "select * from " + table_name;
            table = con.getTable(select_query);
            con.disconnect();
        }/*Password::populate end*/
        public string getPassword()
        {
             DataTable dt = get(new e_columns[] { e_columns.e_passwd }, e_db_operation.e_getUnique);
             if (dt.Rows.Count == 0)
                 return "";
             return dt.Rows[0][0].ToString();
        }
    }/*Password end*/
}
