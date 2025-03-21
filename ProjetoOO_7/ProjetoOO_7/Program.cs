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





        }
    }
}
