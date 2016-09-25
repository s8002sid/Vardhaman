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
        public ViewBillMaster viewBillMaster;
        public ViewManualBillMaster viewManualBillMaster;
        public MainInternal(Connection con)
        {
            customer = new Customer(con, this);
            itemType = new ItemType(con, this);
            company = new Company(con, this);
            itemDetail = new ItemDetail(con, this);
            viewBillMaster = new ViewBillMaster(con, this);
            viewManualBillMaster = new ViewManualBillMaster(con, this);
        }
    }
}
