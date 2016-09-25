using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Vardhman.db
{
    public class ItemDetail : ATable
    {
        protected override void populate_col_list()
        {
            col_list = new e_columns[] {e_columns.e_id,
                                        e_columns.e_item_name,
                                        e_columns.e_company,
                                        e_columns.e_price,
                                        e_columns.e_note,
                                        e_columns.e_date,
                                        e_columns.e_inddate,
                                        e_columns.e_type_name,
                                        e_columns.e_shortcut,
                                        e_columns.e_Metercount};
        }
        protected override string get_table_name()
        {
            return "item_detail";
        }
        public ItemDetail(Connection con, MainInternal t_internalData)
            : base(con, t_internalData)
        {

        }

        public e_error add(DataTable dt)
        {

            return e_error.e_success;
        }

        public override e_error add(e_columns[] columns, string[] values)
        {
            return e_error.e_success;
        }/*ItemDetail::add*/

        public override e_error update(e_columns[] columns, string[] values)
        {
            return e_error.e_success;
        }/*ItemDetail::update*/
        protected override void populate()
        {
            if (table != null)
                return;
            con.connent();
            string select_query = "select * from " + table_name;
            table = con.getTable(select_query);
            con.disconnect();
        }/*ItemDetail::populate*/
        public double getPrice(string company, string type_name, string item_name)
        {
            DataTable dt = get(new e_columns[] { e_columns.e_price },
                                                e_db_operation.e_getAll,
                                                string.Format("{0} = '{1}' and {2} like('{3}') and ({4} like ('{5}') or {6} like ('{5}'))",
                                                column_to_str(e_columns.e_item_name),
                                                item_name,
                                                column_to_str(e_columns.e_company),
                                                company + "%",
                                                column_to_str(e_columns.e_type_name),
                                                type_name + "%",
                                                column_to_str(e_columns.e_shortcut)));
            /*select min(price) from item_detail where [Item Name] = @name and company like(@company + '%') and ([Type name] like(@group +'%') or shortcut like(@group + '%'))*/
            if (dt.Rows.Count == 0)
                return -1;
            double min = Convert.ToDouble(dt.Rows[0][0].ToString());
            double tmp;
            foreach (DataRow dr in dt.Rows)
            {
                tmp = Convert.ToDouble(dr[0].ToString());
                if (min > tmp)
                    min = tmp;
            }
            return min;
        }
    }/*public class ItemDetail : ATable*/
}
