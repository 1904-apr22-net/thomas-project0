using System;
using CigarShop.DataAccess.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using CigarShop.Library.Interfaces;
using NLog;
using CigarShop.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using ILogger = NLog.ILogger;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Data;

namespace CigarShop.ConsoleUI
{
       public static class Program
    {
        private static readonly ILogger _interfaceLogger = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            
            // XmlSerializer serializer = Dependencies.CreateXmlSerializer();
            // ICigarShop cigarShopRepository = Dependencies.CreateCigarShopRepository();
            using (Project0Context dbContext = CreateDbContext())//ICigarShop cigarShopRepo = Dependencies.CreateCigarShopRepo())//
            {
                ExecuteUI();// cigarShopRepository);
            }
        }

        public static void ExecuteUI() //ICigarShop cigarShopRepo)
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
                        Console.WriteLine("n: Lookup Cigar by Name");
                        Console.WriteLine("m: Lookup Cigar by Manufacturer's Name");
                        Console.WriteLine("c: Lookup Cigar by Body Characteristic");
                        Console.WriteLine("b: Go Back");
                        Console.WriteLine();
                        Console.WriteLine("Please enter one of the specified menu options. ");
                        userInput = Console.ReadLine();


                        if (userInput == "n")
                        {
                            Console.WriteLine("Please enter the Cigar's Name");
                            userInput = Console.ReadLine();
                            var commString = $"SELECT Cigar.Id, Cigar.Name, CigarBodyChar.Body, Manufacturer.Name FROM Cigar.Cigar INNER Join Cigar.CigarBodyChar on Cigar.Cigar.BodyId = CigarBodyChar.Id INNER Join Cigar.Manufacturer on Cigar.Cigar.ManufacturerId = Manufacturer.Id WHERE Cigar.Name = '{ userInput}';";
                            var connectionString = SecretConfiguration.ConnectionString;
                            var dataSet = new DataSet();
                            using (var connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                using (var command = new SqlCommand(commString, connection))
                                using (var adapter = new SqlDataAdapter(command))
                                {
                                    adapter.Fill(dataSet);
                                }

                                connection.Close();
                            }
                            foreach(DataTable table in dataSet.Tables)
                            {
                                foreach(DataRow row in table.Rows)
                                {
                                    foreach (DataColumn column in table.Columns)
                                    {
                                        Console.WriteLine("    "+column.ColumnName+ "   "+row[column]);
                                    }
                                }
                            }
                            Console.WriteLine();
 
                        }

                        else if (userInput =="m")
                        {
                            Console.WriteLine("Please enter the Manufactuer's Name");
                            userInput = Console.ReadLine();
                            var commString = $"SELECT Cigar.Id, Cigar.Name, CigarBodyChar.Body, Manufacturer.Name FROM Cigar.Cigar INNER Join Cigar.CigarBodyChar on Cigar.Cigar.BodyId = CigarBodyChar.Id INNER Join Cigar.Manufacturer on Cigar.Cigar.ManufacturerId = Manufacturer.Id WHERE Manufacturer.Name = '{ userInput}';";
                            var connectionString = SecretConfiguration.ConnectionString;
                            var dataSet = new DataSet();
                            using (var connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                using (var command = new SqlCommand(commString, connection))
                                using (var adapter = new SqlDataAdapter(command))
                                {
                                    adapter.Fill(dataSet);
                                }

                                connection.Close();
                            }
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    foreach (DataColumn column in table.Columns)
                                    {
                                        Console.WriteLine("    " + column.ColumnName + "   " + row[column]);
                                    }
                                    Console.WriteLine();
                                }
                                
                            }
                            Console.WriteLine();

                        }
                        else if(userInput =="c")
                        {
                            Console.WriteLine("Please enter the body characteristic");
                            userInput = Console.ReadLine();
                            var commString = $"SELECT Cigar.Id, Cigar.Name, CigarBodyChar.Body, Manufacturer.Name FROM Cigar.Cigar INNER Join Cigar.CigarBodyChar on Cigar.Cigar.BodyId = CigarBodyChar.Id INNER Join Cigar.Manufacturer on Cigar.Cigar.ManufacturerId = Manufacturer.Id WHERE CigarBodyChar.Body = '{ userInput}';";
                            var connectionString = SecretConfiguration.ConnectionString;
                            var dataSet = new DataSet();
                            using (var connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                using (var command = new SqlCommand(commString, connection))
                                using (var adapter = new SqlDataAdapter(command))
                                {
                                    adapter.Fill(dataSet);
                                }

                                connection.Close();
                            }
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    foreach (DataColumn column in table.Columns)
                                    {
                                        Console.WriteLine("    " + column.ColumnName + "   " + row[column]);
                                    }
                                    Console.WriteLine();
                                }

                            }
                            Console.WriteLine();
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
                            userInput = Console.ReadLine();
                            var commString = $"SELECT * FROM Cigar.Store WHERE Store.Id = { userInput};";
                            var connectionString = SecretConfiguration.ConnectionString;
                            var dataSet = new DataSet();
                            using (var connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                using (var command = new SqlCommand(commString, connection))
                                using (var adapter = new SqlDataAdapter(command))
                                {
                                    adapter.Fill(dataSet);
                                }

                                connection.Close();
                            }
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    foreach (DataColumn column in table.Columns)
                                    {
                                        Console.WriteLine("    " + column.ColumnName + "   " + row[column]);
                                    }
                                }
                            }
                            Console.WriteLine();

                        }
                        if (userInput == "l")
                        {
                            Console.WriteLine("Please enter the City");
                            userInput = Console.ReadLine();
                            Console.WriteLine("Please enter the State");
                            string userInput2 = Console.ReadLine();
                            var commString = $"SELECT * FROM Cigar.Store WHERE Store.City = '{ userInput}' AND Store.State = '{userInput2}';";
                            var connectionString = SecretConfiguration.ConnectionString;
                            var dataSet = new DataSet();
                            using (var connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                using (var command = new SqlCommand(commString, connection))
                                using (var adapter = new SqlDataAdapter(command))
                                {
                                    adapter.Fill(dataSet);
                                }

                                connection.Close();
                            }
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    foreach (DataColumn column in table.Columns)
                                    {
                                        Console.WriteLine("    " + column.ColumnName + "   " + row[column]);
                                    }
                                }
                            }
                            Console.WriteLine();
                        }
                        if (userInput == "b")
                        {
                            break;
                        }
                    }
                }

                else if (userInput == "c")
                {
                    Console.WriteLine("Please enter the Customer's Last Name");
                    userInput = Console.ReadLine();
                    Console.WriteLine("Please enter the Customer's First Name");
                    String userInput2 = Console.ReadLine();
                    var commString = $"SELECT * FROM Cigar.Customer WHERE FirstName = '{ userInput2}' AND LastName = '{userInput}';";
                    var connectionString = SecretConfiguration.ConnectionString;
                    var dataSet = new DataSet();
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (var command = new SqlCommand(commString, connection))
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataSet);
                        }

                        connection.Close();
                    }
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            foreach (DataColumn column in table.Columns)
                            {
                                Console.WriteLine("    " + column.ColumnName + "   " + row[column]);
                            }
                            Console.WriteLine();
                        }

                    }
                    Console.WriteLine();
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
