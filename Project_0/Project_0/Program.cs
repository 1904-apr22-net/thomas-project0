using System;
using CigarShop.DataAccess.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using CigarShop.Library.Interfaces;
using NLog;
using CigarShop.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging.Console;


namespace CigarShop.ConsoleUI
{
       public static class Program
    {
       // private static readonly ILogger _interfaceLogger = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            //ICigarShop cigarShop = CreateCigarShop();
            //  XmlSerializer serializer = CreateXmlSerializer();

            using (CigarShopDbContext dbContext = CreateDbContext())
            {

            }
        }
        private static CigarShopDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CigarShopDbContext>();
            optionsBuilder
                .UseSqlServer(SecretConfiguration.ConnectionString);
                //.UseLoggerFactory(AppLoggerFactory);

            return new CigarShopDbContext(optionsBuilder.Options);
        }
    }
}
