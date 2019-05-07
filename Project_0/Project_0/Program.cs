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
using Microsoft.Extensions.Logging.Console;
using ILogger = NLog.ILogger;

namespace CigarShop.ConsoleUI
{
       public static class Program
    {
        private static readonly ILogger _interfaceLogger = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            XmlSerializer serializer = Dependencies.CreateXmlSerializer();

            using ( ICigarShop cigarShopRepo = Dependencies.CreateCigarShopRepo())//Project0Context dbContext = CreateDbContext())
            {
                ExecuteUI(cigarShopRepo, serializer);
            }
        }

        public static void ExecuteUI(ICigarShop cigarShopRepo, XmlSerializer serializer)
        {
            Console.WriteLine("Winston Churchill's Cigars");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("o: Order Cigars");
                Console.WriteLine("e: View Exiting Order");
                Console.WriteLine("c: Customer Lookup");
                Console.WriteLine("s: Store Lookup");
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
                        Console.WriteLine("d: Lookup Cigar by Manufacturer's Id number");
                        Console.WriteLine("m: Lookup Cigar by Manufacturer's Name");
                        Console.WriteLine("b: Go Back");
                        Console.WriteLine();
                        Console.WriteLine("Please enter one of the specified menu options. ");
                        userInput = Console.ReadLine();

                        if (userInput == "i")
                        {
                            Console.WriteLine("Please enter the Cigar's Id Number");
                            userInput = Console.ReadLine();
                        }
                        else if (userInput == "n")
                        {
                            Console.WriteLine("Please enter the Cigar's Name");
                            userInput = Console.ReadLine();
                        }
                        else if (userInput == "d")
                        {
                            Console.WriteLine("Please enter the Manufactuer's Id Number");
                            userInput = Console.ReadLine();
                        }
                        else if (userInput =="m")
                        {
                            Console.WriteLine("Please enter the Manufactuer's Name");
                            userInput = Console.ReadLine();
                        }
                        else if(userInput == "b")
                        {
                            Console.WriteLine();
                            break;
                        }
                    }
                }
                else if (userInput == "e")
                {
                    Console.WriteLine("o: Lookup Order by Order Id");
                    Console.WriteLine("s: Lookup Order by Store Id");
                    Console.WriteLine("c: Lookup Order by Customer Last Name");
                    Console.WriteLine("b: Go Back");
                    Console.WriteLine();
                    Console.WriteLine("Please enter one of the specified menu options. ");
                    userInput = Console.ReadLine();

                    while (true)
                    {
                        if (userInput == "o")
                        {
                            Console.WriteLine("Please enter the Order Id Number. ");
                            userInput = Console.ReadLine();
                        }
                        else if (userInput == "s")
                        {
                            Console.WriteLine("Please enter the Store's Id Number. ");
                            userInput = Console.ReadLine();
                        }
                        else if (userInput == "c")
                        {
                            Console.WriteLine("Please enter the Customer's Last Name. ");
                            userInput = Console.ReadLine();
                        }
                        else if (userInput == "b")
                        {
                            break;
                        }
                    }
                }
                else if (userInput == "s")
                {
                    Console.WriteLine("v: View Store Locations");
                    Console.WriteLine("a: Add a New Store");
                    Console.WriteLine("r: Remove a Store");
                    Console.WriteLine("b: Go Back");
                    Console.WriteLine();
                    Console.WriteLine("Please enter one of the specified menu options. ");
                    userInput = Console.ReadLine();

                    while (true)
                    {
                        if (userInput == "v")
                        {
                            Console.WriteLine("i: Lookup store by Store Id");
                            Console.WriteLine("l: Lookup store by Location");
                            Console.WriteLine("b: Go Back");
                            Console.WriteLine();
                            Console.WriteLine("Please enter one of the specified menu options. ");
                            userInput = Console.ReadLine();

                            while (true)
                            {
                                if (userInput == "i")
                                {
                                    Console.WriteLine("Please enter the store's Id Number");
                                    userInput =Console.ReadLine();
                                }
                                else if (userInput =="l")
                                {

                                }
                                else if (userInput == "b")
                                {
                                    break;
                                }
                            }
                        }
                        if (userInput == "a")
                        {

                        }
                        if (userInput == "r")
                        {

                        }
                        if (userInput == "b")
                        {
                            break;
                        }
                    }
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


            return new Project0Context(optionsBuilder.Options);
        }
    }
}
