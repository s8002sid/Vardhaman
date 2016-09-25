using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Vardhman.db
{
    public class ItemType : ATable
    {
        protected override void populate_col_list()
        {
            col_list = new e_columns[] {e_columns.e_id,
                                        e_columns.e_typename,
                                        e_columns.e_shortcut,
                                        e_columns.e_Metercount,
                                        e_columns.e_to_typename};
        }
        protected override string get_table_name()
        {
            return "itemtype";
        }
        public ItemType(Connection con, MainInternal t_internalData)
            : base(con, t_internalData)
        {

        }

        public override e_error add(e_columns[] columns, string[] values)
        {
            return e_error.e_success;
        }/*ItemType::add*/
        private void merge_internal(Dictionary<e_columns, string> key_val)
        {
            if (key_val[e_columns.e_typename] == key_val[e_columns.e_to_typename])
                return;
            DataRow[] row = table.Select(string.Format("typename='{0}'", key_val[e_columns.e_typename]));
            row[0].Delete();
        }/*ItemType::merge_internal*/
        public override e_error update(e_columns[] columns, string[] values)
        {
            return e_error.e_success;
        }/*ItemType::update*/
        public e_error merge(e_columns[] columns, string[] values)
        {
            if (!col_valid(columns))
                return e_error.e_invalid_col_error;

            if (columns.Length != values.Length || columns.Length < 2)
                return e_error.e_invalid_col_error;

            Dictionary<e_columns, string> key_val = new Dictionary<e_columns, string>();
            for (int i = 0; i < columns.Length; i++)
            {
                key_val.Add(columns[i], values[i]);
            }
            if (key_val[e_columns.e_typename] == key_val[e_columns.e_to_typename])
                return e_error.e_success;
            con.connent();
            con.exeNonQurey(string.Format("exec PROC_ITEM_TYPE_MERGE '{0}','{1}'",
                                            key_val[e_columns.e_typename],
                                            key_val[e_columns.e_to_typename]));
            con.disconnect();
            merge_internal(key_val);
            return e_error.e_success;
        }/*ItemType::merge*/
        protected override void populate()
        {
            if (table != null)
                return;
            con.connent();
            string select_query = "select * from " + table_name;
            table = con.getTable(select_query);
            con.disconnect();
        }/*ItemType::populate*/
    }/*public class ItemType : ATable*/
}
