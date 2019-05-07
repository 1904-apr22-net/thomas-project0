using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Models
{
    public class Store
    {
        private int _StoreId;
        public int storeId { get; set; }

        private string _Address1;
        public string address1
        {
            get => _Address1;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Address 1 must not be empty", nameof(value));
                }
                _Address1 = value;
            }
        }

        private string _Address2;
        public string address2 { get; set; }

        private string _City;
        public string city
        {
            get => _City;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("City must not be empty", nameof(value));
                }
                _City = value;
            }
        }

        private string _State;
        public string state
        {
            get => _State;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("State must not be empty", nameof(value));
                }
                _State = value;
            }
        }

        private string _Zip;
        public string zip
        {
            get => _Zip;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Zip code name must not be empty", nameof(value));
                }
                _Zip = value;
            }
        }

        public List<Cigar> cigarInvintory { get; set; } = new List<Cigar>();

     
    }
}
