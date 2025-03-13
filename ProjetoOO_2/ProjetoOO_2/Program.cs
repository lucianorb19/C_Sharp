using System;

namespace ProjetoOO_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Point ponto; //NÃO FUNCIONA
            Point ponto = new Point();

            //ponto = new Point();
            ponto.X = 20;
            ponto.Y = 10;
            Console.WriteLine(ponto);

        }

    }
}
