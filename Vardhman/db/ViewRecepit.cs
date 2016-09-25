using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Vardhman.db
{
    public class ViewRecepit : ATable
    {
        protected override void populate_col_list()
        {
            col_list = new e_columns[] {e_columns.e_id,
                                        e_columns.e_recepitno,
                                        e_columns.e_date,
                                        e_columns.e_name,
                                        e_columns.e_city,
                                        e_columns.e_amount,
                                        e_columns.e_cd,
                                        e_columns.e_total,
                                        e_columns.e_manualrecepit,
                                        e_columns.e_bank,
                                        e_columns.e_bank_city,
                                        e_columns.e_checknumber,
                                        e_columns.e_billno,
                                        e_columns.e_through,
                                        e_columns.e_note,
                                        e_columns.e_inddate};
        }
        protected override string get_table_name()
        {
            return "view_recepit";
        }
        public ViewRecepit(Connection con, MainInternal t_internalData)
            : base(con, t_internalData)
        {

        }

        public override e_error add(e_columns[] columns, string[] values)
        {
            return e_error.e_success;
        }/*ViewRecepit::add end*/
        public override e_error update(e_columns[] columns, string[] values)
        {
            return e_error.e_success;
        }/*ViewRecepit::update end*/
        protected override void populate()
        {
            if (table != null)
                return;
            con.connent();
            string select_query = "select *, dbo.inddatevar(date) as inddate from " + table_name;
            table = con.getTable(select_query);
            con.disconnect();
        }/*ViewRecepit::populate end*/
        public void delete(string recepitno)
        {
            if (table == null)
                return;
            DataRow[] dr = table.Select(string.Format("{0}={1}", column_to_str(e_columns.e_recepitno), recepitno));
            if (dr.Length == 0)
                return;
            else
            {
                foreach (DataRow t_dr in dr)
                    t_dr.Delete();
            }
        }
    }/*ViewRecepit end*/
}
