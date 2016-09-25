
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Vardhman.db
{
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
        public Customer(Connection con, MainInternal t_internalData)
            : base(con, t_internalData)
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
        }/*Customer::add_internal*/

        private void update_internal(Dictionary<e_columns, string> key_val)
        {
            DataRow[] row = table.Select(string.Format("id={0}", key_val[e_columns.e_id]));
            key_val.Remove(e_columns.e_id);
            foreach (KeyValuePair<e_columns, string> item in key_val)
            {
                row[0][col_mapping[item.Key]] = item.Value;
            }
        }/*Customer::update_internal*/

        public override e_error add(e_columns[] columns, string[] values)
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
        }/*Customer::add*/
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
        }/*Customer::update*/
        protected override void populate()
        {
            if (table != null)
                return;
            con.connent();
            string select_query = "select *, dbo.inddatevar(date) as inddate from " + table_name;
            table = con.getTable(select_query);
            con.disconnect();
        }/*Customer::populate*/
    }/*public class Customer : ATable*/
}
