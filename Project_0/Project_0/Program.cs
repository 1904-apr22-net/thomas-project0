using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using CigarShop.Library.Interfaces;
using NLog;
using CigarShop.Library.Models;

namespace CigarShop.ConsoleUI
{
       public static class Program
    {
        private static readonly ILogger _interfaceLogger = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            ICigarShop cigarShop = CreateCigarShop();
            XmlSerializer serializer = CreateXmlSerializer();
        }
    }
}
