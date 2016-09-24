using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Vardhman.db
{
    public abstract class ATable
    {
        protected Dictionary<e_columns, string> col_mapping;
        protected e_columns[] col_list;
        protected string table_name;
        protected Connection con;
        protected DataTable table;
        public ATable(Connection con)
        {
            this.con = con;
            col_mapping = null;
            col_list = null;
            col_mapping = new Dictionary<e_columns, string>();
            table_name = null;
            populate_col_list();
            populate_col_mapping();
            table_name = get_table_name();
        }
        protected void populate_col_mapping()
        {
            if (col_list == null)
                return;
            Dictionary<e_columns, string> orig_mapping = ColMapping.getColMapping();
            foreach (e_columns col in col_list)
            {
                col_mapping.Add(col, orig_mapping[col]);
            }
        }
        protected bool col_valid(e_columns[] cols)
        {
            foreach (e_columns col in cols)
            {
                if (!col_mapping.ContainsKey(col))
                {
                    return false;
                }
            }
            return true;
        }
        protected string[] col_arr_to_str_arr(e_columns[] cols)
        {
            string[] str = new string[cols.Length];
            for (int i = 0; i < cols.Length; i++)
            {
                str[i] = col_mapping[cols[i]];
            }
            return str;
        }
        public DataTable get(e_columns[] cols, e_db_operation oper)
        {
            if (!col_valid(cols))
                return new DataTable();
            populate();
            DataView view = new DataView(table);
            bool distinct = oper == e_db_operation.e_getUnique ? true : false;
            string[] str = col_arr_to_str_arr(cols);
            DataTable newTable = view.ToTable(distinct, str);
            return newTable;
        }
        public DataTable get(e_columns[] cols, e_db_operation oper, string where)
        {
            if (!col_valid(cols))
                return new DataTable();
            populate();
            DataView view = new DataView(table);
            view.RowFilter = where;
            bool distinct = oper == e_db_operation.e_getUnique ? true : false;
            string[] str = col_arr_to_str_arr(cols);
            DataTable newTable = view.ToTable(distinct, str);
            return newTable;
        }
        public string column_to_str(e_columns col)
        {
            if (!col_mapping.ContainsKey(col))
                return "";
            return col_mapping[col];
        }
        abstract protected void populate();
        abstract public e_error add(e_columns[] columns, string[] values);
        abstract public e_error update(e_columns[] columns, string[] values);
        abstract protected void populate_col_list();
        abstract protected string get_table_name();
    }/*ATable*/
}
