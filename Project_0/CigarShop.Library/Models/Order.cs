﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Models
{
    public class Order
    {
        private int _OrderId;
        public int orderId { get; set; }

        public int storeId { get; set; }

        public int customerId { get; set; }

        public double orderTotal { get; set; }

        public DateTime orderPlaced { get; set; }
    }
}
