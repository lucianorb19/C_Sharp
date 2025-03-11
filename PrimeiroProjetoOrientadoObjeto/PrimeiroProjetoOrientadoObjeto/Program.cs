using PrimeiroProjetoOrientadoObjeto;
using System;
using System.Globalization;


namespace PrimerioProjetoOrientadoObjeto
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //ÁREA DE TRIÂNGULO USANDO CLASSE TRIANGULO E FÓRMULAR DE HERON

            Triangulo x, y; //INICIALIZAÇÃO DOS OBJETOS TRIÂNGULO

            x = new Triangulo();
            y = new Triangulo();//INSTANCIAÇÃO DOS OBJETOS TRIANGULO

            Console.WriteLine("Lados primeiro triangulo: ");
            x.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Lados segundo triangulo: ");
            y.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double p = (x.A + x.B + x.C) / 2;
            double area_x = Math.Sqrt(p * (p - x.A) * (p - x.B) * (p - x.C));

            p = (y.A + y.B + y.C) / 2;
            double area_y = Math.Sqrt(p * (p - y.A) * (p - y.B) * (p - y.C));

            Console.WriteLine($"Área do triangulo X: {area_x.ToString("f4", CultureInfo.InvariantCulture)}\n" +
                                  $"Área do triângulo Y: {area_y.ToString("f4", CultureInfo.InvariantCulture)}");

            if (area_x == area_y)
            {
                Console.WriteLine("Áreas iguais!");
            }
            else if (area_x > area_y)
            {
                Console.WriteLine("Maior área: triângulo X");
            }
            else // areay > areax
            {
                Console.WriteLine("Maior área: triângulo Y");
            }

        }
    }
}
