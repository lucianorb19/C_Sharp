using System;
using System.Globalization;
using ProjetoOO_11.Entities;

namespace ProjetoOO_11
{
    class Program
    {
        static void Main(string[] args)
        {





            /*
            //------------------------------------------------------------------------
            //EXERCISE
            List<Product> lista = new List<Product>();

            Console.Write("How many products: ");
            int n = int.Parse(Console.ReadLine());

            for(int i=0; i < n; i++)
            {
                string[] dados = Console.ReadLine().Split(",");
                string name = dados[0];//NOME PRODUTO
                double price = double.Parse(dados[1], CultureInfo.InvariantCulture);//PREÇO PRODUTO
                Product produto = new Product(name, price);
                lista.Add(produto);
            }

            CalculationService calculationService = new CalculationService();

            Product max = calculationService.Max(lista);

            Console.WriteLine($"Max: {max}");
            */



            /*
            //------------------------------------------------------------------------
            //EXERCISE 
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
            */



        }
    }
}
