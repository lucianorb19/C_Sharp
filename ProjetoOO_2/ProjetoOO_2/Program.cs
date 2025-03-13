using System;

namespace ProjetoOO_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //Point ponto; //NÃO FUNCIONA
            Point ponto = new Point();

            //ponto = new Point();
            ponto.X = 20;
            ponto.Y = 10;
            Console.WriteLine(ponto);
            */







            //RASCUNHO
            //------------------------------------------

            /*
            Point ponto1 = new Point();
            Point ponto2 = new Point();
            ponto1.X = 5;
            ponto1.Y = 5;
            ponto2.X = 10;
            ponto2.Y = 10;
            Console.WriteLine($"ponto 1: {ponto1}\n" +
                              $"ponto 2: {ponto2}");
            //AMBOS APONTAM PARA O MESMO LUGAR DE PONTO1
            ponto2 = ponto1;
            Console.WriteLine($"ponto 1: {ponto1}\n" +
                              $"ponto 2: {ponto2}");
            
            
            //---------------------------------------------------------
            int p = 0;
            for (p=0; p < 10; p++)
            {
                int x = p;
                Console.WriteLine(x);
            }
            //Console.WriteLine(x);//VARIÁVEL NÃO EXISTE FORA DO ESCOPO DO FOR
            


            //---------------------------------------------------------
            //double x = null;
            //Nullable<double> x1 = null;
            double? x = null;
            double? y = 10;

            Console.WriteLine(x.GetValueOrDefault());
            Console.WriteLine(y.GetValueOrDefault());
            Console.WriteLine();
            Console.WriteLine(x.HasValue);
            Console.WriteLine(y.HasValue);
            Console.WriteLine();
            if (x.HasValue)
            {
                Console.WriteLine(x.Value); ;
            }
            else
            {
                Console.WriteLine($"Variável é null");
            }
            Console.WriteLine();
            if (y.HasValue)
            {
                Console.WriteLine(y.Value); ;
            }
            else
            {
                Console.WriteLine($"Variável é null");
            }
            */

            //---------------------------------------------------------
            double? x = null;
            double y = x ?? 0;

            Console.WriteLine(y);
















        }

    }
}
