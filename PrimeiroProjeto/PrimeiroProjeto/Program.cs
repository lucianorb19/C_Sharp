// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;//REFERÊNCIA AO NAMESPACE SYSTEM - PADRÃO DO VISUAL STUDIO
using System.Globalization; //CultureInfo.InvariantCulture


namespace PrimeiroProjeto
{
    internal class Program
    {
        static void Main(string[] args)//ENTRY POINT - ONDE A APLICÃÇÃO COMEÇA A SER EXECUTADA
        {
            /*
            //EXERCÍCIO_1
            string produto1 = "Computador";
            string produto2 = "Mesa de escritório";

            byte idade = 30;
            int codigo = 5290;
            char genero = 'M';

            double preco1 = 2100.0;
            double preco2 = 650.50;
            double medida = 53.234567;

            Console.WriteLine($"{produto1} cujo preço é ${preco1.ToString("f2")}");
            Console.WriteLine($"{produto2}, cujo preço é ${preco2.ToString("f2")}");
            Console.WriteLine($"Registo: {idade} anos de idade, código {codigo} e gênero: {genero}");
            Console.WriteLine($"Medida com oito casas decimais: {medida.ToString("f8")}");
            Console.WriteLine($"Arredondado (três casas decimais): {medida.ToString("f3")}");
            Console.WriteLine($"Separador decimal invariant culture: {medida.ToString("f3", CultureInfo.InvariantCulture)}");
            */
            int a = 5;
            int b = 2;
            double resultado = (double) a / b;
            Console.WriteLine(resultado);
            


        }
    }
}
