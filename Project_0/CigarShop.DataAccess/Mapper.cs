using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CigarShop.DataAccess
{
    public static class Mapper
    {
        public static Library.Models.Cigar Map(Entities.Cigar cigar) => new Library.Models.Cigar
        {
            cigarId = cigar.Id,
            cigarName = cigar.Name

        };

        public static Entities.Cigar Map(Library.Models.Cigar cigar) => new Entities.Cigar
        {
            Id = cigar.cigarId,
            Name = cigar.cigarName
        };
        public static IEnumerable<Library.Models.Cigar> Map(IEnumerable<Entities.Cigar> cigars) => cigars.Select(Map);
        public static IEnumerable<Entities.Cigar> Map(IEnumerable<Library.Models.Cigar> cigars) => cigars.Select(Map);
    }
}
