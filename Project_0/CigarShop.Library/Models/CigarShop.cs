using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CigarShop.Library.Models
{
    public class Cigar
    {
        private string _cName; //name of cigar
        private string _mName; //name of manufacturer

        public string cName
        {
            get => _cName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Cigar name must not be empty", nameof(value));
                }
                _cName = value;
            }
        }
        public string mName
        {
            get => _mName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Manufacturer name must not be empty", nameof(value));
                }
                _mName = value;
            }
        }
    }
}
