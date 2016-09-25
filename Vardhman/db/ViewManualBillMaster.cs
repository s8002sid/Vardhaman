using System;
using System.Collections.Generic;
using System.Text;

namespace Vardhman.db
{
    public class ViewManualBillMaster : ATable
    {
        protected override void populate_col_list()
        {
            col_list = new e_columns[] {e_columns.e_id,
                                        e_columns.e_billno,
                                        e_columns.e_name,
                                        e_columns.e_city,
                                        e_columns.e_date,
                                        e_columns.e_total,
                                        e_columns.e_expenseper,
                                        e_columns.e_expenses,
                                        e_columns.e_transport,
                                        e_columns.e_transportcharge,
                                        e_columns.e_transportnumber,
                                        e_columns.e_grandtotal,
                                        e_columns.e_through,
                                        e_columns.e_paymenttype,
                                        e_columns.e_note,
                                        e_columns.e_rgtotal,
                                        e_columns.e_iscd,
                                        e_columns.e_vatper,
                                        e_columns.e_vat};
        }
        protected override string get_table_name()
        {
            return "view_manual_bill_master";
        }
        public ViewManualBillMaster(Connection con, MainInternal t_internalData)
            : base(con, t_internalData)
        {

        }

        public override e_error add(e_columns[] columns, string[] values)
        {
            return e_error.e_success;
        }/*ViewManualBillMaster::add end*/
        public override e_error update(e_columns[] columns, string[] values)
        {
            return e_error.e_success;
        }/*ViewManualBillMaster::update end*/
        protected override void populate()
        {
            if (table != null)
                return;
            con.connent();
            string select_query = "select * from " + table_name;
            table = con.getTable(select_query);
            con.disconnect();
        }/*ViewManualBillMaster::populate end*/
    }/*ViewManualBillMaster end*/
}
