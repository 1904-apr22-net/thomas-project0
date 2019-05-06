using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Models
{
    class Order
    {
        private int _OrderId;
        public int orderId
        {
            get => _OrderId;
            set
            {
                    _OrderId = value;
            }
        }

        public int storeId { get; set; }

        public int customerId { get; set; }

        public double orderTotal { get; set; }

        public DateTime orderPlaced { get; set; }
    }
}
