using System;
using System.Globalization;
using System.Net.Http.Headers;
namespace ProjetoOO_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //---------------------------------------------------
            //EXERCÍCIO_36
            double soma_notas = 0, media_notas = 0;

            Console.Write("Número de notas a processar: ");
            int n = int.Parse(Console.ReadLine());
            double[] vetor1 = new double[n];

            for (int i = 0; i < n; i++)
            {
                vetor1[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                soma_notas += vetor1[i];
            }
            Console.WriteLine();
            Console.WriteLine("Vetor resultante:");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{vetor1[i]} - ");
            }
            Console.WriteLine();

            media_notas = soma_notas / n;
            Console.WriteLine($"Média de notas: {media_notas}");
            



            //---------------------------------------------------
            //EXERCÍCIO_37
            double media_preco = 0;

            Console.Write("Quantos produtos serão cadastrados: ");
            int numero_produtos = int.Parse(Console.ReadLine());

            Product[] vetor_produtos = new Product[numero_produtos];

            for(int i =0; i < numero_produtos; i++)
            {
                Console.WriteLine($"Produto {i+1}");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Preço: ");
                double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                //CADA POSIÇÃO DO VETOR RECEBE UM OBJETO PRODUCT
                vetor_produtos[i] = new Product();
                vetor_produtos[i].Nome = nome;
                vetor_produtos[i].Preco = preco;
                media_preco += preco;

                Console.WriteLine(vetor_produtos[i].ToString());
            }
            media_preco = media_preco / numero_produtos;
            Console.WriteLine();
            
            Console.WriteLine("MOSTRANDO VETOR");
            for(int i=0;i < numero_produtos; i++)
            {
                Console.WriteLine($"{vetor_produtos[i].ToString()}");
            }
            Console.WriteLine();
            Console.WriteLine($"Média de preços: {media_preco}");
            


            //---------------------------------------------------
            //EXERCÍCIO_38
            Console.Write("How many rooms will be rented: ");
            int number_of_rents = int.Parse(Console.ReadLine());

            //TEN ROOMS AVAILABLE
            Room[] vector_rooms = new Room[10];

            for (int i = 0; i < number_of_rents; i++)
            {
                //SHOWING BUSY ROOMS BEFORE RESERVING
                Room.ShowBusyRooms(vector_rooms);

                //RESERVING ROOM
                Console.WriteLine($"Rent #{i + 1}: ");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("E-mail: ");
                string email = Console.ReadLine();
                Console.Write("Room Number: ");
                int room_number = int.Parse(Console.ReadLine());
                Room.ReserveRoom(name, email, room_number,vector_rooms);
            }
            Console.WriteLine();

            //SHOWING DETAILS ABOUT EACH ROOM TAKEN
            Room.ShowBusyRoomsDetails(vector_rooms);
            */



            //---------------------------------------------------
            //EXERCÍCIO_39

            //string[] vetor = new string[] { "Luciano", "Ana", "Goiaba" };
            Point[] vetor_coordenadas = new Point[2];



            for (int i = 0; i < vetor_coordenadas.Length; i++)
            {
               
                Console.WriteLine($"Ponto {i+1}");
                Console.Write("X: ");
                double x = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Y: ");
                double y = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                
                vetor_coordenadas[i] = new Point(x,y);
                Console.WriteLine(vetor_coordenadas[i]);
                Console.WriteLine();
            }

            foreach(Point obj in vetor_coordenadas)
            {
                Console.WriteLine(obj);
            }







            //RASCUNHO
            //------------------------------------------

            /*
            //Point ponto; //NÃO FUNCIONA
            Point ponto = new Point();

            //ponto = new Point();
            ponto.X = 20;
            ponto.Y = 10;
            Console.WriteLine(ponto);
           

            //------------------------------------------
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
            

            //---------------------------------------------------------
            double? x = null;
            double y = x ?? 0;

            Console.WriteLine(y);
            */















        }

    }
}
