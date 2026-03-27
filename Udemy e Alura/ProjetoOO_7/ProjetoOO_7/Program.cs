using System;
using System.Globalization;
using System.Collections.Generic;
using ProjetoOO_7.Entities;

namespace ProjetoOO_7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> taxPayers = new List<Person>();

            Console.Write("Enter the number of tax payers: ");
            int numberTaxPayers = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberTaxPayers; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Tax payer #{i+1}");
                Console.Write("Individual or company [i/c]: ");
                string op = Console.ReadLine().ToUpper();

                while(op != "I" && op != "INDIVIDUAL" &&
                      op != "C" && op != "COMPANY")
                {
                    Console.WriteLine("Invalid entry. Try again.");
                    Console.Write("Individual or company [i/c]: ");
                    op = Console.ReadLine().ToUpper();
                }

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(op == "I" || op == "INDIVIDUAL")
                {
                    Console.Write("Health expenses: ");
                    double healthExpenses = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Individual individual = new Individual(name, anualIncome, healthExpenses);
                    taxPayers.Add(individual);
                }
                else//op == "C" || op == "COMPANY"
                {
                    Console.Write("Number of employees: ");
                    int numberEmployees = int.Parse(Console.ReadLine());
                    LegalEntity legalEntity = new LegalEntity(name, anualIncome, numberEmployees);
                    taxPayers.Add(legalEntity);
                }
                
            }
            Console.WriteLine();

            Console.WriteLine("TAXES PAID");
            foreach(Person person in taxPayers)
            {
                Console.WriteLine(person);
            }

            double total = 0;
            foreach (Person person in taxPayers)
            {
                total += person.Tax();
            }
            Console.WriteLine($"TOTAL TAXES: {total}");
           








            /*
            //--------------------------------------------------------------
            //EXERCISE
            List<Product> products = new List<Product>();
            Console.Write("Enter the number os products: ");
            int number_products = int.Parse(Console.ReadLine());

            for(int i = 0; i < number_products; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Product #{i+1} data");
                
                Console.Write("Common, used or imported [c/u/i]: ");
                string op = Console.ReadLine().ToUpper();
                while(op != "C" && op != "COMMON" &&
                      op != "U" && op != "USED" &&
                      op != "I" && op != "IMPORTED")
                {
                    Console.WriteLine("Invalid entry. Try again.");
                    Console.Write("Common, used or imported [c/u/i]: ");
                    op = Console.ReadLine().ToUpper();
                }

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (op == "C" || op == "COMMON")
                {
                    Product product = new Product(name, price);
                    products.Add(product);
                }
                else if(op == "U" || op == "USED")
                {
                    Console.Write("Manufacture date [DD/MM/YYYY]: ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    Product product = new UsedProduct(name, price, manufactureDate);
                    products.Add(product);
                }
                else if(op == "I" || op == "IMPORTED")
                {
                    Console.Write("Custom fee: ");
                    double customFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Product product = new ImportedProduct(name, price, customFee);
                    products.Add(product);
                }
            }
            Console.WriteLine();

            //DATA OUTPUT
            Console.WriteLine("PRICE TAGS");
            foreach(Product product in products)
            {
                Console.WriteLine($"{product.PriceTag()}"); 
            }
            */


            /*
            //--------------------------------------------------------------
            //EXERCISE
            //EMPLOYEES LIST
            List<Employee> employees = new List<Employee>();

            Console.Write("Enter the number of employees: ");
            int number_empolyees = int.Parse(Console.ReadLine());

            for(int i =0; i < number_empolyees; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Employee #{i+1} data:");
                Console.Write("Outsorced? [Y/N]: ");
                string op = Console.ReadLine().ToUpper();
                
                while (op != "Y" && op != "N" && op != "YES" && op != "NO")
                {
                    Console.WriteLine("Invalid entry. Try again");
                    Console.Write("Outsorced? [Y/N]: ");
                    op = Console.ReadLine().ToUpper();
                }
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double value_per_hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                double additional_charge = 0;
                if (op == "YES" || op == "Y")//OutsourcedEmployee
                {
                    Console.Write("Additional charge: ");
                    additional_charge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Employee employee_outsourced = new OutsourcedEmployee(name,hours,value_per_hour,additional_charge);
                    employees.Add(employee_outsourced);
                }
                else//Employee
                {
                    Employee employee = new Employee(name, hours, value_per_hour);
                    employees.Add(employee);
                }

            }
            Console.WriteLine();

            Console.WriteLine("PAYMENTS");
            //DATA OUTPUT
            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
            */




        }
    }
}
