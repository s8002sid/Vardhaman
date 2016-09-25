using System;
using System.Collections.Generic;
using System.Text;

namespace Vardhman.db
{
    public class MainInternal
    {
        public Customer customer;
        public ItemType itemType;
        public Company company;
        public ItemDetail itemDetail;
        public MainInternal(Connection con)
        {
            customer = new Customer(con, this);
            itemType = new ItemType(con, this);
            company = new Company(con, this);
            itemDetail = new ItemDetail(con, this);
        }
    }
}
