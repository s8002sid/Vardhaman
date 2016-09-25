using System;
using System.Collections.Generic;
using System.Text;

namespace Vardhman.db
{
    public class Company : ATable
    {
        protected override void populate_col_list()
        {
            col_list = new e_columns[] {e_columns.e_id,
                                        e_columns.e_name,
                                        e_columns.e_note,
                                        e_columns.e_address,
                                        e_columns.e_pincode,
                                        e_columns.e_phno_1,
                                        e_columns.e_phno_2,
                                        e_columns.e_city};
        }
        protected override string get_table_name()
        {
            return "company";
        }
        public Company(Connection con, MainInternal t_internalData)
            : base(con, t_internalData)
        {

        }

        public override e_error add(e_columns[] columns, string[] values)
        {
            return e_error.e_success;
        }/*Company::add*/
        public override e_error update(e_columns[] columns, string[] values)
        {
            return e_error.e_success;
        }/*Company::update*/
        protected override void populate()
        {
            if (table != null)
                return;
            con.connent();
            string select_query = "select * from " + table_name;
            table = con.getTable(select_query);
            con.disconnect();
        }/*Company::populate*/
    }
}
