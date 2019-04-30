using CigarShop.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CigarShop.Library.Interfaces
{
    /// <summary>
    /// A repo managing data access for cigar objects and their notes
    /// </summary>
    public interface ICigarShop
    {
        /// <summary>
        /// get all cigars with deffered execution.
        /// </summary>
        /// <param name="search"></param>
        /// <returns>The collection of cigars</returns>
        IEnumerable<Cigar> GetCigars(string search = null);
        
        /// <summary>
        /// Add a cigar, including the manufacturer, notes, and price
        /// </summary>
        /// <param name="cigar"></param>
        void AddCigar(Cigar cigar);
    }
}
