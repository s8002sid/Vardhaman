using System;
using System.Collections.Generic;
using System.Text;

namespace Vardhman.db
{
    public class MainInternal
    {
        public Customer customer;
        public MainInternal(Connection con)
        {
            customer = new Customer(con);
        }
    }
}
