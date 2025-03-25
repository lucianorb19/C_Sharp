using System;
using System.Globalization;
using ProjetoOO_10.Entities;
using ProjetoOO_10.Services;

namespace ProjetoOO_10
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter contract data");
                Console.Write("Number: ");
                int numberContract = int.Parse(Console.ReadLine());
                Console.Write("Date (DD/MM/YYYY/): ");
                DateTime dateContract = DateTime.Parse(Console.ReadLine());
                Console.Write("Contract Value: ");
                double valueContract = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Number of installments: ");
                int numberInstallments = int.Parse(Console.ReadLine());

                //IFeeCalculation feeCalculationService = new FeeCalculation(dateContract,valueContratc,numberInstallments);
                Contract contract = new Contract(numberContract, dateContract, valueContract, numberInstallments, new FeeCalculation());
                Console.WriteLine(contract);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }

        }
    }
}