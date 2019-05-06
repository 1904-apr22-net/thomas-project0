using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Models
{
    public class Store
    {
        private int _StoreId;
        public int storeId
        {
            get => _StoreId;
            set
            {
                _StoreId = value;
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
                _Address2= value;
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

        public List<Cigar> cigarInvintory { get; set; } = new List<Cigar>();

     
    }
}
