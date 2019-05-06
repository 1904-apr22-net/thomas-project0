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
        private string _BodyCharacteristic; //will either be light, medium, or full. 

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
        public string bodyCharacteristic
        {
            get => _BodyCharacteristic;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("What is the body characteristic of the cigar? ", nameof(value));
                }
                _BodyCharacteristic = value;
            }
        }
        public int cID { get; set; }
        public int mID { get; set; }
    }
}
