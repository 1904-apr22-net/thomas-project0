using CigarShop.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Interfaces
{

    public interface ICigarShop
    {

        IEnumerable<Cigar> GetCigars(string search = null);

        void AddCigar(Cigar cigar);
    }
}
