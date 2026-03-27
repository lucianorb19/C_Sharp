using ProjetoOO_8.Entities;
using ProjetoOO_8.Exceptions;
using System;
using System.Globalization;

namespace ProjetoOO_8
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //EXERCISE
            //-------------------------------------------------------------------
            try
            {
                Console.WriteLine("Enter data account");
                Console.Write("Number: ");
                int account_number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial Balance: ");
                double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw limit: ");
                double withDrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account account = new Account(account_number, holder, balance, withDrawLimit);
                Console.WriteLine();

                Console.Write("Enter ammount for withdraw: ");
                double ammount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                account.WithDraw(ammount);
                Console.WriteLine($"New Balance: {account.Balance.ToString("f2",CultureInfo.InvariantCulture)}");
            }
            catch (DomainException e)//BUSINESS DOMAIN
            {
                Console.WriteLine($"{e.Message}");
            }
            catch (FormatException e)//VARIABLE TYPE 
            {
                Console.WriteLine($"Erro! {e.Message}");
            }
            catch(Exception e)//GENERIC
            {
                Console.WriteLine($"{e.Message}");
            }
            */






            /*
            Console.WriteLine("Check In: [DD/MM/YYYY]");
            DateTime checkIn = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Check Out: [DD/MM/YYYY]");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());
            TimeSpan duration = checkOut.Subtract(checkIn);
            int result = (int)duration.TotalDays;
            Console.WriteLine(result);
            */

        }
    }
}
