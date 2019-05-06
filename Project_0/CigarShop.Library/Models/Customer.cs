using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Models
{
    public class Customer
    {
        private string _FirstName;
        public string firstName { get; set; }

        private string _LastName;
        public string lastName { get; set; }

        private string _Address1;
        public string address1 { get; set; }

        private string _Address2;
        public string address2 { get; set; }

        private string _City;
        public string city { get; set; }

        private string _State;
        public string state { get; set; }

        private string _Zip;
        public string zip { get; set; }

        private string _DefaultStoreCity;
        public string defaultStoreCity { get; set; }
    }
}
