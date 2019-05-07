using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CigarShop.Library.Models
{
    public class Cigar
    {
        private int _CigarId; //id of cigar
        private string _CigarName; //name of cigar
        private string _ManufacturerName; //name of manufacturer
        private string _BodyCharacteristic; //will either be light, medium, or full. 

        public int cigarId   { get; set; }
        public string cigarName
        {
            get => _CigarName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Cigar name must not be empty", nameof(value));
                }
                _CigarName = value;
            }
        }
        public string manufacturerName
        {
            get => _ManufacturerName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Manufacturer name must not be empty", nameof(value));
                }
                _ManufacturerName = value;
            }
        }
        public string bodyCharacteristic
        {
            get => _BodyCharacteristic;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Body Characteristic must not be empty", nameof(value));
                }
                _BodyCharacteristic = value;
            }
        }
    }
}
