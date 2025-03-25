using ProjetoOO_11;
using System;

namespace ProjetoOO_10
{
    class Program
    {
        static void Main(string[] args)
        {

            //NO PROGRAMA PRINCIPAL, DEFINIR QUAL TIPO SERÁ USADO NO LUGAR NO GENERIC T
            PrintService<string> printService = new PrintService<string>();

            Console.Write("How many values: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                string x = Console.ReadLine();
                printService.AddValue(x);
            }

            Console.WriteLine(printService);

            string a = printService.First();
            Console.WriteLine($"First: {a}");




        }
    }
}
