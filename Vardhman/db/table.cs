using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
namespace Vardhman.db
{
    
    public enum e_columns
    {
        e_name,
        e_note,
        e_address,
        e_city,
        e_pincode,
        e_phno_1,
        e_phno_2,
        e_openbalance,
        e_date,
        e_type,
        e_accountnumber,
        e_accounttype,
        e_debcredit,
        e_id,
        e_select,
        e_inddate
    }
    public enum e_error
    {
        e_success,
        e_duplicate_error,
        e_invalid_col_error,
        e_unknown_error
    }
    class ColMapping
    {
        private static Dictionary<e_columns, string> col_mapping = null;
        private static void populate()
        {
            if (col_mapping != null)
                return;
            col_mapping = new Dictionary<e_columns,string>();
            col_mapping.Add(e_columns.e_accountnumber, "accountnumber");
            col_mapping.Add(e_columns.e_accounttype, "accounttype");
            col_mapping.Add(e_columns.e_address, "address");
            col_mapping.Add(e_columns.e_city, "city");
            col_mapping.Add(e_columns.e_date, "date");
            col_mapping.Add(e_columns.e_debcredit, "debcredit");
            col_mapping.Add(e_columns.e_id, "id");
            col_mapping.Add(e_columns.e_name, "name");
            col_mapping.Add(e_columns.e_note, "note");
            col_mapping.Add(e_columns.e_openbalance, "openbalance");
            col_mapping.Add(e_columns.e_phno_1, "phno_1");
            col_mapping.Add(e_columns.e_phno_2, "phno_2");
            col_mapping.Add(e_columns.e_pincode, "pincode");
            col_mapping.Add(e_columns.e_type, "type");
            col_mapping.Add(e_columns.e_select, "select");
            col_mapping.Add(e_columns.e_inddate, "inddate");
        }
        public static Dictionary<e_columns, string> getColMapping()
        {
            populate();
            return col_mapping;
        }
    }
    public enum e_db_operation
    {
        e_getUnique,
        e_getAll
    }
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
        abstract protected void populate();
        protected bool col_valid(e_columns[] cols)
        {
            foreach (e_columns col in cols)
            {
                if(!col_mapping.ContainsKey(col))
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
            if(!col_valid(cols))
                return new DataTable();            
            populate();            
            DataView view = new DataView(table);            
            bool distinct = oper == e_db_operation.e_getUnique? true : false;
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
            if(!col_mapping.ContainsKey(col))
                return "";
            return col_mapping[col];
        }
        abstract public e_error add(e_columns[] columns, string[] values);
        abstract public e_error update(e_columns[] columns, string[] values);
        abstract protected void populate_col_list();
        abstract protected string get_table_name();
    }
    public class Customer : ATable
    {
        protected override void populate_col_list()
        {
            col_list = new e_columns[] {e_columns.e_accountnumber,
                                        e_columns.e_accounttype,
                                        e_columns.e_address,
                                        e_columns.e_city,
                                        e_columns.e_date,
                                        e_columns.e_debcredit,
                                        e_columns.e_id,
                                        e_columns.e_name,
                                        e_columns.e_note,
                                        e_columns.e_openbalance,
                                        e_columns.e_phno_1,
                                        e_columns.e_phno_2,
                                        e_columns.e_pincode,
                                        e_columns.e_type,
                                        e_columns.e_select,
                                        e_columns.e_inddate};
        }
        protected override string get_table_name()
        {
            return "customer";
        }
        public Customer(Connection con) : base(con)
        {
            
        }
        private void add_internal(Dictionary<e_columns, string> key_val)
        {
            DataRow row = table.NewRow();
            foreach (KeyValuePair<e_columns, string> item in key_val)
            {
                row[col_mapping[item.Key]] = item.Value; 
            }
            table.Rows.Add(row);
        }

        private void update_internal(Dictionary<e_columns, string> key_val)
        {
            DataRow[] row = table.Select(string.Format("id={0}", key_val[e_columns.e_id]));
            key_val.Remove(e_columns.e_id);
            foreach (KeyValuePair<e_columns, string> item in key_val)
            {
                row[0][col_mapping[item.Key]] = item.Value;
            }
        }

        public override e_error add(e_columns[] columns, string[] values)
        {
            if (!col_valid(columns))
                return e_error.e_invalid_col_error;

            if (columns.Length != values.Length || columns.Length < 13)
                return e_error.e_invalid_col_error;

            Dictionary<e_columns, string> key_val = new Dictionary<e_columns,string>();
            for (int i = 0; i < columns.Length; i++)
            {
                key_val.Add(columns[i], values[i]);
            }
            
            con.connent();
            con.exeNonQurey(string.Format("exec add_customer '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}'",
                                            key_val[e_columns.e_name],
                                            key_val[e_columns.e_note],
                                            key_val[e_columns.e_address],
                                            key_val[e_columns.e_city],
                                            key_val[e_columns.e_pincode],
                                            key_val[e_columns.e_phno_1],
                                            key_val[e_columns.e_phno_2],
                                            key_val[e_columns.e_openbalance],
                                            key_val[e_columns.e_date],
                                            key_val[e_columns.e_type],
                                            key_val[e_columns.e_accountnumber],
                                            key_val[e_columns.e_accounttype],
                                            key_val[e_columns.e_select]));
            string id = con.exesclr(string.Format("select max(id) from {0} where name='{1}' and city='{2}'", table_name, 
                                                                                                                key_val[e_columns.e_name], 
                                                                                                                key_val[e_columns.e_city]));
            key_val.Add(e_columns.e_id, id);
            con.disconnect();
            key_val.Remove(e_columns.e_select);
            add_internal(key_val);
            return e_error.e_success;
        }
        public override e_error update(e_columns[] columns, string[] values)
        {
            if (!col_valid(columns))
                return e_error.e_invalid_col_error;

            if (columns.Length != values.Length || columns.Length < 13)
                return e_error.e_invalid_col_error;

            Dictionary<e_columns, string> key_val = new Dictionary<e_columns, string>();
            for (int i = 0; i < columns.Length; i++)
            {
                key_val.Add(columns[i], values[i]);
            }

            con.connent();
            con.exeNonQurey(string.Format("exec update_customer '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', {12}",
                                            key_val[e_columns.e_name],
                                            key_val[e_columns.e_note],
                                            key_val[e_columns.e_address],
                                            key_val[e_columns.e_city],
                                            key_val[e_columns.e_pincode],
                                            key_val[e_columns.e_phno_1],
                                            key_val[e_columns.e_phno_2],
                                            key_val[e_columns.e_openbalance],
                                            key_val[e_columns.e_date],
                                            key_val[e_columns.e_type],
                                            key_val[e_columns.e_accountnumber],
                                            key_val[e_columns.e_accounttype],
                                            key_val[e_columns.e_id]));
            con.disconnect();
            update_internal(key_val);
            return e_error.e_success;
        }
        protected override void populate()
        {
            if(table != null)
                return;
            con.connent();
            string select_query = "select *, dbo.inddatevar(date) as inddate from " + table_name;
            table = con.getTable(select_query);
            con.disconnect();
        }
    }
}
