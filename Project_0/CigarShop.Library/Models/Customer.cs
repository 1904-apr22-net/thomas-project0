using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Models
{
    public class Customer
    {
        private int _CustomerId;
        public int customerId
        {
            get => _CustomerId;
            set
            {
                _CustomerId = value;
            }
        }
        private string _FirstName;
        public string firstName
        {
            get => _FirstName;
            set
            {
                _FirstName = value;
            }
        }

        private string _LastName;
        public string lastName
        {
            get => _LastName;
            set
            {
                _LastName = value;
            }
        }


        private string _Address1;
        public string address1
        {
            get => _Address1;
            set
            {
                _Address1 = value;
            }
        }

        private string _Address2;
        public string address2
        {
            get => _Address2;
            set
            {
                _Address2 = value;
            }
        }

        private string _City;
        public string city
        {
            get => _City;
            set
            {
                _City = value;
            }
        }

        private string _State;
        public string state
        {
            get => _State;
            set
            {
                _State = value;
            }
        }

        private string _Zip;
        public string zip
        {
            get => _Zip;
            set
            {
                _Zip = value;
            }
        }

        private string _DefaultStoreCity;
        public string defaultStoreCity
        {
            get => _DefaultStoreCity;
            set
            {
                _DefaultStoreCity= value;
            }
        }

        public int orderId { get; set; }
    }
}
