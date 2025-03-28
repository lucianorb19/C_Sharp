﻿using System;
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
            try
            {
                //HASHSETS QUE REPRESENTAM CADA TURMA
                HashSet<int> A = new HashSet<int>();
                HashSet<int> B = new HashSet<int>();
                HashSet<int> C = new HashSet<int>();

                //INPUT - CLASS A
                Console.Write("How many strudents for course A? ");
                int aNumber = int.Parse(Console.ReadLine());
                for (int i = 0; i < aNumber; i++)
                {
                    Console.Write("->> ");
                    int aluno_id = int.Parse(Console.ReadLine());
                    A.Add(aluno_id);
                }
                //INPUT - CLASS B
                Console.Write("How many strudents for course B? ");
                int bNumber = int.Parse(Console.ReadLine());
                for (int i = 0; i < bNumber; i++)
                {
                    Console.Write("->> ");
                    int aluno_id = int.Parse(Console.ReadLine());
                    B.Add(aluno_id);
                }

                //INPUT - CLASS C
                Console.Write("How many strudents for course C? ");
                int cNumber = int.Parse(Console.ReadLine());
                for (int i = 0; i < cNumber; i++)
                {
                    Console.Write("->> ");
                    int aluno_id = int.Parse(Console.ReadLine());
                    C.Add(aluno_id);
                }

                //UNION BETWEEN CLASSES A, B AND C
                //UNION - ONLY DIFFERENT NUMBERS
                HashSet<int> alunosAlex = new HashSet<int>(A);
                alunosAlex.UnionWith(B);
                alunosAlex.UnionWith(C);

                Console.WriteLine($"Total students: {alunosAlex.Count}");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }
            

            //MÉTODO ESTÁTICO QUE PRINTA A COLEÇÃO
            static void PrintCollection<T>(IEnumerable<T> collection)
            {
                foreach (T item in collection)
                {
                    Console.WriteLine($"{item}");
                }
                Console.WriteLine();
            }
            */



            /*
            //------------------------------------------------------------------------
            //EXERCISE
            SortedSet<int> a = new SortedSet<int>() {0, 4, 2, 5, 8, 6, 10 };
            SortedSet<int> b = new SortedSet<int>() {5, 6, 7, 8, 9, 10};

            //ALGUMAS OPERAÇÕES

            //COLEÇÃO INICIADA COM TODOS ELEMENTOS DA OUTRA
            SortedSet<int> c = new SortedSet<int>(a);
            //UNINDO DOIS CONJUNTOS - FINAL SÓ COM ELEMENTOS DIFERENTES - NÃO ACEITA REPETIÇÃO
            c.UnionWith(b);

            //COLEÇÃO INICIADA COM TODOS ELEMENTOS DA OUTRA
            SortedSet<int> d = new SortedSet<int>(a);
            //INTERSEÇÃO - SOMENTE ELEMENTOS EM COMUM
            d.IntersectWith(b);

            //COLEÇÃO INICIADA COM TODOS ELEMENTOS DA OUTRA
            SortedSet<int> e = new SortedSet<int>(a);
            //DIFERENÇA - TIRA DE A O QUE TIVER EM COMUM COM B
            e.ExceptWith(b);


            PrintCollection(a);
            PrintCollection(b);
            PrintCollection(c);
            PrintCollection(d);
            PrintCollection(e);

            //MÉTODO ESTÁTICO PARA PERCORRER A COLEÇÃO

            //IEnumerable - INTERFACE PARA GetEnumerate
            //GetEnumerate - PERCORRER COLEÇÕES
            //TODOS TIPOS NATIVOS SUPORTAM IEnumerate
            static void PrintCollection<T>(IEnumerable<T> collection)
            {
                foreach(T item in collection)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            */



            /*
            //------------------------------------------------------------------------
            //EXERCISE
            string a = "Luciano";
            string b = "Luciano";
            string c = "Dudu";

            Console.WriteLine(a.Equals(b)); 
            Console.WriteLine(a.Equals(c));

            Console.WriteLine(a.GetHashCode()); 
            Console.WriteLine(b.GetHashCode()); 
            Console.WriteLine(c.GetHashCode());
            Console.WriteLine();

            Client client1 = new Client("Luciano", "luciano@gmail");
            Client client2 = new Client("Maria", "maria@gmail");
            Client client3 = new Client("Carlos", "luciano@gmail");

            Console.WriteLine(client1.Equals(client2));
            Console.WriteLine(client1.Equals(client3));

            Console.WriteLine(client1.GetHashCode());
            Console.WriteLine(client2.GetHashCode());
            Console.WriteLine(client3.GetHashCode());
            */



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
