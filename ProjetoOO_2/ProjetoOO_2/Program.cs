using System;
using System.Globalization;
using System.Net.Http.Headers;
using System.Collections.Generic; //LISTA
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
            



            //---------------------------------------------------
            //EXERCÍCIO_40

            Console.Write("How many employees will be registred:/" +
                          "Quantos funcionários serão registrados: ");
            int n = int.Parse(Console.ReadLine());

            List<Funcionario> lista_funcionarios = new List<Funcionario>();

            //GETTING DATA FOR EMPLOYESS
            //RECEBENDO DADOS PARA FUNCIONÁRIOS
            for (int i =0; i < n; i++)
            {
                Console.WriteLine($"Employee #{i+1}");
                Funcionario funcionario = new Funcionario();
                //REGISTRING INFORMATION
                //REGISTRANDO INFORMAÇÕES
                funcionario = Funcionario.RegisterEmployee(lista_funcionarios);
                //ADDED AT LIST END
                //ADICIONADO AO FINAL DA LISTA
                lista_funcionarios.Add(funcionario);
                Console.WriteLine();
            }

            //SHOWING EMPLOYEES REGISTRED
            //MOSTRANDO FUNCIONÁRIOS REGISTRADOS
            Funcionario.ShowEmployees(lista_funcionarios);

            //SALARY RASE / AUMENTO SALARIAL
            Funcionario.SalaryRase(lista_funcionarios);

            Funcionario.ShowEmployees(lista_funcionarios);
            


            //---------------------------------------------------
            //EXERCÍCIO_41
            Console.Write("Ordem da matriz: ");
            int n = int.Parse(Console.ReadLine());

            int[,] matriz = new int[n, n];


            //DATA IN - ENTRADA DE DADOS
            for (int i = 0; i < n; i++)//LINE - LINHA
            {
                Console.Write($"Linha {i + 1}: ");
                string[] values = Console.ReadLine().Split(" "); //VALUES FOR THE LINE - VALORES PARA A LINHA

                for (int j = 0; j < n; j++)//COLUMN - COLUNA
                {
                    matriz[i, j] = int.Parse(values[j]);
                }
            }
            Console.WriteLine();

            //MAIN DIAGONAL - LINE == COLUMN
            //DIAGONAL PRINCIPAL - LINHA == COLUNA
            Console.WriteLine("Main Diagonal / Diagonal principal");
            for (int i = 0; i < (matriz.GetLength(0)); i++)
            {
                Console.Write($"{matriz[i, i]} ");
            }
            Console.WriteLine();


            //NEGATIVE VALUES
            //VALORES NEGATIVOS
            Console.WriteLine("Negative values - Valores negativos");
            for (int i = 0; i < (matriz.GetLength(0)); i++)
            {
                for (int j = 0; j < (matriz.GetLength(1)); j++)
                {
                    if ((matriz[i,j]) < 0)
                    {
                        Console.Write($"{matriz[i, j]} ");
                    }
                }
            }
            



            //---------------------------------------------------
            //EXERCÍCIO_42
            Console.Write("How many lines:/ Quantas linhas: ");
            int n_lines = int.Parse(Console.ReadLine());
            Console.Write("How many columns:/ Quantas colunas: ");
            int n_columns = int.Parse(Console.ReadLine());

            int[,] matriz = new int[n_lines,n_columns];

            //DATA IN / ENTRADA DE DADOS
            for(int i = 0; i < n_lines; i++)
            {
                for (int j = 0; j < n_columns; j++)
                {
                    Console.Write($"[{i}, {j}]: ");
                    matriz[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();

            //DATA OUT / DADOS NA TELA
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.Write("Number for processing:/Número para processar: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (x == matriz[i, j])//IF X IN MATRIX / CASO ENCONTRE O X NA MATRIZ
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Number/Número: {x}\nPosition/Posição: [{i},{j}]");
                        if(j > 0)//IF NOT IN FIRST COLUMN / CASO NÃO ESTEJA NA PRIMEIRA COLUNA
                        {
                            Console.WriteLine($"Left / Esquerda: {matriz[i, j - 1]}");
                        }
                        if(j < (matriz.GetLength(1)-1))//IF NOT IN LAST COLUMN / SE NÃO ESTIVER NA ÚLTIMA COLUNA
                        {
                            Console.WriteLine($"Right / Direita: {matriz[i, j + 1]}");
                        }
                        if (i > 0)//IF NOT IN FIRST LINE / CASO NÃO ESTEJA NA PRIMEIRA LINHA
                        {
                            Console.WriteLine($"Up / Acima: {matriz[i-1,j]}");
                        }
                        if (i < (matriz.GetLength(0)-1))//IF NOT IN LAST LINE / CASO NÃO ESTEJA NA ÚLTIMA LINHA
                        {
                            Console.WriteLine($"Down / Abaixo: {matriz[i + 1, j]}");
                        }
                    }
                }
                Console.WriteLine();
            }
            */



            //---------------------------------------------------
            //EXERCÍCIO_43
            DateTime d1 = DateTime.UtcNow;
            Console.WriteLine(d1);














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
