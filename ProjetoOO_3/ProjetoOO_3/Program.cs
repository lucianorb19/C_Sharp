using System;
using System.Globalization;
using ProjetoOO_3.Entities;
using ProjetoOO_3.Entities.Enums;

namespace ProjetoOO_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DATA ENTRY - WORKER AND DEPARTMENT
            Console.Write("Enter department's name: ");
            string name_department = Console.ReadLine();
            Console.WriteLine("Worker Data");
            Console.Write("Name: ");
            string name_worker = Console.ReadLine();
            //WORKER'S LEVEL
            bool continuar=true;
            string levelString="";
            while (continuar)
            {
                Console.Write("Level [Junior/MidLevel/Senior]\n--> ");
                levelString = Console.ReadLine();
                if(levelString == "Junior" || levelString == "MidLevel" || levelString == "Senior")
                {
                    continuar = false;
                }
                else
                {
                    Console.WriteLine("Ivalid Level. Try again!");
                }
            }
            //CONVERSÃO STRING PARA ENUM WorkLevel
            WorkerLevel level = Enum.Parse<WorkerLevel>(levelString);
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //OBJECTS
            Department department = new Department(name_department);
            Worker worker = new Worker(name_worker, level, baseSalary, department);

            //DATA ENTRY - CONTRACTS
            Console.Write("How many contracts to this woker: ");
            int numero_contratos = int.Parse(Console.ReadLine());

            for(int i = 0; i < numero_contratos; i++)
            {
                Console.WriteLine($"Enter #{i+1} contract data");
                Console.Write("Date [DD/MM/YYYY]: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                //CREATING OBJECT HOURCONTRACT
                HourContract contract = new HourContract(date, valuePerHour,hours);

                //INSERTING CONTRACT INTO WORKERS LIST OF CONTRACTS
                worker.AddContract(contract);
                Console.WriteLine();
            }

            //DATA ENTRY - MONTH AND YEAR FOR PROCESSING
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income [MM/YYYY]: ");
            string monthAndYear = Console.ReadLine(); // 03/2025 (VERIFICATION ?)
            int month = int.Parse(monthAndYear.Substring(0, 2)); // 03
            int year = int.Parse(monthAndYear.Substring(3)); //2025 

            //DATA OUTPUT
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year,month).ToString("f2",CultureInfo.InvariantCulture)}");














        }
    }
}
