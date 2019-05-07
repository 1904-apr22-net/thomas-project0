using CigarShop.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace CigarShop.Tests.Library.Models
{
    public class CigarShopTest
    {
        private readonly Cigar _cigar = new Cigar();

        [Fact]
        public void cName_NonEmptyValue_StoresCorrectly()
        {
            const string randomCigarNameValue = "Liga Privada T 52";
            _cigar.cigarName = randomCigarNameValue;
            Assert.Equal(randomCigarNameValue, _cigar.cigarName);
        }

        [Fact]
        public void cName_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _cigar.cigarName = string.Empty);
        }

        [Fact]
        public void mName_NonEmptyValue_StoresCorrectly()
        {
            const string randomCigarNameValue = "Drew Estates";
            _cigar.manufacturerName = randomCigarNameValue;
            Assert.Equal(randomCigarNameValue, _cigar.manufacturerName);
        }

        [Fact]
        public void mName_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _cigar.manufacturerName = string.Empty);
        }
    }
}
