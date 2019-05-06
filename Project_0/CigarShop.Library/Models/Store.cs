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
        public string address1 { get; set; }

        private string _Address2;
        public string address2 { get; set; }

        private string _City;
        public string city { get; set; }

        private string _State;
        public string state { get; set; }

        private string _Zip;
        public string zip { get; set; }

        //public List<Cigars> Cigars { get; set; } = new List<Cigar>
    }
}
