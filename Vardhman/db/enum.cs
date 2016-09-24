using System;
using System.Collections.Generic;
using System.Text;

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
        e_inddate,
        e_typename,
        e_shortcut,
        e_Metercount,
        e_to_typename
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
            col_mapping = new Dictionary<e_columns, string>();
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
            col_mapping.Add(e_columns.e_typename, "typename");
            col_mapping.Add(e_columns.e_shortcut, "shortcut");
            col_mapping.Add(e_columns.e_Metercount, "Metercount");
            col_mapping.Add(e_columns.e_to_typename, "typename");
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
}
