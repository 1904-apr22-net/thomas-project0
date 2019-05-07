using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;
using CigarShop.Library.Interfaces;
using CigarShop.Library.Models;
using CigarShop.DataAccess.Entities;
using CigarShop.DataAccess.CigarShopRepository;

namespace CigarShop.ConsoleUI
{
    public static class Dependencies
    { 
        public static ICigarShop CreateCigarRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);

            var dbContext = new Project0Context(optionsBuilder.Options);

            return new CigarShopRepository(dbContext);
        }

        public static XmlSerializer CreateXmlSerializer() =>
    new XmlSerializer(typeof(List<Library.Models.Cigar>));
    }
}
