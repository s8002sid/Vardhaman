using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Vardhman.App_Code
{
    public class dataset_fill : Connection
    {
    
        public void fill()
        {
            connent();
            dataset_billing ds = new dataset_billing();
            SqlDataAdapter da;
            SqlCommand cmd = new SqlCommand("select * from temp_bill_detail", conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds , "Billdetail");
            string x = ds.Tables["Billdetail"].Rows[0][0].ToString();
        }
    }
}
