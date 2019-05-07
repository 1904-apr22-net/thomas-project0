using CigarShop.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Interfaces
{

    public interface ICigarShop : IDisposable
    {

        IEnumerable<Cigar> GetCigars(string search = null);

        // void AddCigar(Cigar cigar); //on second thought, i dont know if i need/want the application to be able to add cigars

        Cigar GetCigarById(int cigarId);

        Cigar GetCigarByManufacturerId(int manufacturerId);

        void Save();
    }
}
