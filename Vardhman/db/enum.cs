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
        e_to_typename,
        e_item_name,
        e_company,
        e_price,
        e_type_name,
        e_billno,
        e_total,
        e_expenseper,
        e_expenses,
        e_transport,
        e_transportcharge,
        e_transportnumber,
        e_grandtotal,
        e_through,
        e_paymenttype,
        e_rgtotal,
        e_iscd,
        e_vatper,
        e_vat,
        e_recepitno,
        e_amount,
        e_cd,
        e_manualrecepit,
        e_bank,
        e_bank_city,
        e_checknumber,
        e_bank_name,
        e_checkno,
        e_bounce_charge,
        e_passwd
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
            col_mapping.Add(e_columns.e_item_name, "[Item Name]");
            col_mapping.Add(e_columns.e_company, "Company");
            col_mapping.Add(e_columns.e_price, "price");
            col_mapping.Add(e_columns.e_type_name, "[Type Name]");
            col_mapping.Add(e_columns.e_billno, "billno");
            col_mapping.Add(e_columns.e_total, "total");
            col_mapping.Add(e_columns.e_expenseper, "expenseper");
            col_mapping.Add(e_columns.e_expenses, "expenses");
            col_mapping.Add(e_columns.e_transport, "transport");
            col_mapping.Add(e_columns.e_transportcharge, "transportcharge");
            col_mapping.Add(e_columns.e_transportnumber, "transportnumber");
            col_mapping.Add(e_columns.e_grandtotal, "grandtotal");
            col_mapping.Add(e_columns.e_through, "through");
            col_mapping.Add(e_columns.e_paymenttype, "paymenttype");
            col_mapping.Add(e_columns.e_rgtotal, "rgtotal");
            col_mapping.Add(e_columns.e_iscd, "iscd");
            col_mapping.Add(e_columns.e_vatper, "vatper");
            col_mapping.Add(e_columns.e_vat, "vat");
            col_mapping.Add(e_columns.e_recepitno, "recepitno");
            col_mapping.Add(e_columns.e_amount, "amount");
            col_mapping.Add(e_columns.e_cd, "cd");
            col_mapping.Add(e_columns.e_manualrecepit, "manualrecepit");
            col_mapping.Add(e_columns.e_bank, "bank");
            col_mapping.Add(e_columns.e_bank_city, "bank_city");
            col_mapping.Add(e_columns.e_checknumber, "checknumber");
            col_mapping.Add(e_columns.e_bank_name, "bank_name");
            col_mapping.Add(e_columns.e_checkno, "checkno");
            col_mapping.Add(e_columns.e_bounce_charge, "bounce_charge");
            col_mapping.Add(e_columns.e_passwd, "passwd");
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
