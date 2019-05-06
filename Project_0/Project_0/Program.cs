﻿using System;
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
using Microsoft.Extensions.Logging.Console;
using ILogger = NLog.ILogger;

namespace CigarShop.ConsoleUI
{
       public static class Program
    {
        private static readonly ILogger _interfaceLogger = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            //ICigarShop cigarShop = CreateCigarShop();
            //XmlSerializer serializer = CreateXmlSerializer();

            using (Project0Context dbContext = CreateDbContext())
            {
                UI();
            }
        }

        public static void UI()
        {
            Console.WriteLine("Cigar Shop");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("o: View/Order Cigars");
                Console.WriteLine("e: View/Edit Exiting Order");
                Console.WriteLine("s: Manage Store Locations");
                Console.WriteLine("i: Manage Cigar Invintory");
                Console.WriteLine("c: Manage Customers");
                Console.WriteLine("q: close program");
                Console.WriteLine();
                Console.WriteLine("Please enter one of the specified menu options. ");
                var userInput = Console.ReadLine();

                if (userInput == "o")
                {
                    while (true)
                    {
                        Console.WriteLine("i: Lookup Cigar by Id Number");
                        Console.WriteLine("n: Lookup Cigar by Name");
                        Console.WriteLine("m: Lookup Cigar by Manufacturer Name");
                        Console.WriteLine("b: Go Back");
                        Console.WriteLine();
                        Console.WriteLine("Please enter one of the specified menu options. ");
                        userInput = Console.ReadLine();

                        if (userInput == "i")
                        {
                            Console.WriteLine("Please enter the Id Number");
                            userInput = Console.ReadLine();
                        }
                        else if (userInput == "n")
                        {

                        }
                        else if (userInput =="m")
                        {

                        }
                        else if(userInput == "b")
                        {

                        }
                    }
                }
                else if (userInput == "e")
                {

                }
                else if (userInput == "s")
                {

                }
                else if (userInput == "i")
                {

                }
                else if (userInput == "c")
                {
                    
                }
                else if (userInput =="q")
                {
                    break;
                }
            }

        }
        private static Project0Context CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder
                .UseSqlServer(SecretConfiguration.ConnectionString);
                //.UseLoggerFactory(AppLoggerFactory);

            return new Project0Context(optionsBuilder.Options);
        }
    }
}
