using System;
using ProjetoOO_13.Entitites;
using ProjetoOO_13.Services;
using System.Linq; //FUNÇÃO SELECT
using System.Globalization;
using System.Linq;

namespace ProjetoOO_13
{
    class Program
    {
        

        static void Main(string[] args)
        {
            try
            {
                List<Product> lista = new List<Product>();

                Console.Write("Enter full file path: ");// C:\Users\Luciano\Desktop\myfolder\file1.txt
                string path = Console.ReadLine();

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] dados = sr.ReadLine().Split(",");
                        string name = dados[0];
                        double price = double.Parse(dados[1], CultureInfo.InvariantCulture);
                        lista.Add(new Product(name, price));
                    }
                }

                Console.WriteLine();
                //MÉDIA DE PREÇOS DA LISTA
                var media = lista.Select(p => p.Price).DefaultIfEmpty(0).Average();
                Console.WriteLine($"Média de preço da lista: {media.ToString("f2", CultureInfo.InvariantCulture)}");

                //NOME DOS PRODUTOS CUJO PREÇO É ABAIXO DA MÉDIA
                var abaixoMedia = lista.Where(p => p.Price < media).
                    OrderByDescending(p => p.Name).
                    Select(p => p.Name);

                Console.WriteLine();
                Console.WriteLine("Produto com preço abaixo da média: ");
                foreach(String produto in abaixoMedia)
                {
                    Console.WriteLine(produto);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }
            


            /*
            //-------------------------------------------------------
            //EXERCÍCIO
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Product1> products = new List<Product1>() {
                new Product1() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
                new Product1() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
                new Product1() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
                new Product1() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
                new Product1() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
                new Product1() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
                new Product1() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
                new Product1() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
                new Product1() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new Product1() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
                new Product1() { Id = 11, Name = "Level", Price = 70.0, Category = c1 }
            };

            //LINQ
            //var r1 = products.Where(p => p.Price < 900 && p.Category.Tier == 1);
            //Print("PRODUTOS TIER 1 E PREÇO < 900",r1);
            //LÊ-SE
            //Where(p => p.Price) -OBJETOS P ONDE O PREÇO P.... 

            //LINQ-SQL
            var r1 =
                from p in products
                where p.Category.Tier == 1 && p.Price < 900
                select p;
            Print("PRODUTOS TIER 1 E PREÇO < 900", r1);
            //----------------------------------------------------------------------

            //LINQ
            //var r2 = products.Where(p => p.Category.Name == "Tools")
                             //.Select(p => p.Name);
            //Print("PRODUTOS CATEGOARIA TOOLS", r2);
            //LÊ-SE
            //.Select(p=>p.Name) - SELECIONANDO P E TRANSFORMANDO EM p.NAME

            //LINQ-SQL
            var r2 =
                from p in products
                where p.Category.Name == "Tools"
                select p.Name;
            Print("PRODUTOS CATEGOARIA TOOLS", r2);
            //----------------------------------------------------------------------

            //LINQ
            //var r3 = products.Where(p => p.Name[0] == 'C')
            //.Select(p => new { p.Name,p.Price, CategoryName = p.Category.Name });
            //Print("PRODUTOS QUE COMEÇAM COM A LETRA C, MOSTRAR NOME, PREÇO E CATEGORIA",r3);
            //new { p.Name,p.Price, CategoryName = p.Category.Name }
            //OBJETO ANÔNIMO QUE OBTEM AS INFORMAÇÕES DO PRODUTO (NOME, PREÇO E NOME DA CATEGORIA)

            //CategoryName = p.Category.Name - É ASSIM PQ OS CAMPOS TEM O MESMO NOME, ENTÃO CRIA-SE UM APELIDO
            //PARA UM DELE

            //LINQ-SQL
            var r3 =
                from p in products
                where p.Name[0] == 'C'
                select new { p.Name, p.Price, CategoryName = p.Category.Name };
            Print("PRODUTOS QUE COMEÇAM COM A LETRA C, MOSTRAR NOME, PREÇO E CATEGORIA", r3);
            //----------------------------------------------------------------------

            //LINQ
            //var r4 = products.Where(p => p.Category.Tier == 1)
            //.OrderBy(p => p.Price)
            //.ThenBy(p => p.Name);
            //Print("PRODUTOS DE CATEGORIA TIER 1, ORDENADOS POR: PREÇO -> NOME", r4);

            //LÊ-SE
            //OrderBy(p => p.Price) - ORDENADOS OBJETOS P CONSIDERANDO O p.Price
            //ThenBy(p => p.Name) - E DEPOIS, CASO HAJA "EMPATE", ORDENAR OBJETOS P CONSIDERANDO p.Name

            //LINQ-SQL
            var r4 =
                from p in products
                where p.Category.Tier == 1
                orderby p.Name  //APLICA ESSA ORDENAÇÃO POR ÚLTIMO
                orderby p.Price //ORDENA PRIMEIRO POR ESSE
                select p;
            Print("PRODUTOS DE CATEGORIA TIER 1, ORDENADOS POR: PREÇO -> NOME", r4);
            //----------------------------------------------------------------------


            //EXPRESSÕES SKIP, TAKE, FIRST, SINGLE E DEMAIS
            //APLICAR O LINQ SQL - COLOCAR ENTRE () E APLICAR A FUNÇÃO NORMALMENTE


            //LINQ
            //var r5 = r4.Skip(2).Take(4);
            //Print("PRODUTOS DE CATEGORIA TIER 1, ORDENADOS POR: PREÇO -> NOME\n" +
            //      "PULA OS DOIS PRIMEIROS - MOSTRA OS 4 PRÓXIMOS", r5);

            //LINQ-SQL
            var r5 = (from p in r4 select p).Skip(2).Take(4);
            Print("PRODUTOS DE CATEGORIA TIER 1, ORDENADOS POR: PREÇO -> NOME\n" +
                  "PULA OS DOIS PRIMEIROS - MOSTRA OS 4 PRÓXIMOS", r5);
            //----------------------------------------------------------------------

            //LINQ
            var r6 = products.First();
            //var r6 = products.FirstOrDefault();
            
            Console.WriteLine($"PRIMEIRO ELEMENTO DA LISTA: {r6}\n");
            //CASO SEJA UMA LISTA VAZIA, GERA ERRO.
            //MELHOR USAR .FirstOrDefault() - QUE NÃO MOSTRA NADA CASO NÃO HAJA ELEMENTOS
            //----------------------------------------------------------------------

            //LINQ
            var r8 = products.Where(p => p.Id == 3)
                             .SingleOrDefault();
            Console.WriteLine($"PRODUTO COM ID 3 - USANDO SingleOrDefault PARA GARANTIR UM ÚNICO ELEMENTO\n" +
                              $"{r8}\n");
            //GERA EXCEÇÃO CASO O RESULTADO SEJA MAIS QUE UM ITEM
            //SÓ ACEITA UM OU NENHUM ELEMENTO
            //----------------------------------------------------------------------

            //LINQ
            var r10 = products.Max(p => p.Price);
            Console.WriteLine($"MAIOR PREÇO: {r10}\n");
            //MAX PARA NUMÉRICO - MAIOR VALOR
            //MAX PARA STRING - MAIS DISTANTE NA ORDEM ALFABÉTICA
            //----------------------------------------------------------------------

            //LINQ
            var r11 = products.Min(p => p.Price);
            Console.WriteLine($"MENOR PREÇO: {r11}\n");
            //MAX PARA NUMÉRICO - MAIOR VALOR
            //MAX PARA STRING - MAIS DISTANTE NA ORDEM ALFABÉTICA
            //----------------------------------------------------------------------

            //LINQ
            var r12 = products.Where(p => p.Category.Id == 1)
                              .Sum(p => p.Price);
            Console.WriteLine($"SOMA DE TODOS VALORES DE PRODUTOS DA CATEGORIA 1: {r12}\n");

            //var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            //Console.WriteLine($"MÉDIA DE TODOS VALORES DE PRODUTOS DA CATEGORIA 1: {r13}\n");

            //MÉDIA GERA EXEÇÃO CASO SEJA MÉDIA DE UM CONJUNTO VAZIO. PARA REMEDIAR ISSO, USA-SE O CAMPO QUE
            //SERIA CALCULADA A MÉDIA PARA FORMAR UMA LISTA DE DOUBLEs (USANDO SELECT) JUNTO COM A FUNÇÃO
            //DefaultIfEmpty(0.0) E SOBRE TODA ESSA EXPRESSÃO, APLICA-SE O Average
            //----------------------------------------------------------------------

            //LINQ
            var r13 = products.Where(p => p.Category.Id == 1)
                              .Select(p => p.Price)
                              .DefaultIfEmpty(0)//ATÉ AQUI, É GERADA UMA LISTA COM OS VALORES - SE FOR VAZIA, 0
                              .Average();//MÉDIA DE 0 É 0
            Console.WriteLine($"MÉDIA DE TODOS VALORES DE PRODUTOS DA CATEGORIA 1: {r13}\n");
            //----------------------------------------------------------------------

            //LINQ
            //AGGREGATE - FUNÇÃO PERSONALIZÁVEL PARA PROCESSAR DADOS
            var r14 = products.Where(p => p.Category.Id == 1)//PRODUTOS DE CATEGORIA 1
                              .Select(p => p.Price) //SELECIONO O PREÇO DELES
                              .Aggregate(0.0, (x, y) => x + y); //AGREGO OS PREÇOS FAZENDO A SOMA
                              //0.0 - RETORNA 0 CASO SEJA AGGREGATE DE UM CONJUNTO VAZIO
                              //(x, y) => x + y - FUNÇÃO ANÔNIMA - RETORNA A SOMA DOS PREÇOS
            Console.WriteLine($"SOMA DE TODOS OS PREÇOS DOS PRODUTOS DE CATEGORIA 1 (COM AGGREGATE): {r14}\n");
            //----------------------------------------------------------------------

            //LINQ
            //GROUPBY - AGRUPA OS DADOS EM GRUPOS CONSIDERANDO UM CRITÉRIO/CAMPO
            //PRODUTOS AGRUPADOS POR CATEGORIA
            //var r15 = products.GroupBy(p => p.Category);

            //LINQ-SQL PARA GROUPBY
            var r15 = from p in products
                      group p by p.Category;


            //FOR EACH ESPECIAL PARA RESULTADOS DE GROUP BY
            foreach (IGrouping<Category, Product1> grupo in r15)
            {
                Console.WriteLine($"Categoria: {grupo.Key.Name}");
                foreach(Product1 p in grupo)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }
            */



            /*
            //-------------------------------------------------------
            //EXERCÍCIO
            List<Product> lista = new List<Product>();

            lista.Add(new Product("TV", 900));
            lista.Add(new Product("Notebook", 1200));
            lista.Add(new Product("Tablet", 450));

            //lista.Sort(CompareProducts);
            
            //Sort NÃO FUNCIONARIA SEM A PASSAGEM DO MÉTODO COMO PARÂMETRO
            //PQ OS OBJETOS Product NÃO SABEM COMO PODEM SE COMPARAR, JÁ QUE
            //A CLASSE Product NÃO IMPLEMENTA A INTERFACE IComparable
            //A UTILIZAÇÃO DO MÉTODO COMO PARÂMETRO É UMA REFERÊNCIA PARA A FUNÇÃO
            //COM TYPESAFETY - A FUNÇÃO É DO TIPO DELEGATE
            //O MÉTODO ESTÁTICO É USADO COMO PARÂMETRO, ASSIM O SORT USA A LÓGICA
            //DELE PARA ORDERNAR
            //CompareProducts FICA NO MESMO ARQUIVO, FORA DA MAIN
            


            //ASSIM TAMBÉM FUNCIONARIA
            //Comparison<Product> comp = CompareProducts;
            //lista.Sort(comp);


            //ASSIM TAMBÉM FUNCIONARIA - FUNÇÃO LAMBDA - NÃO PRECISA CONSTRUIR A FUNÇÃO ESTÁTICA FORA DO MAIN
            //Comparison<Product> comp = (p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
            //lista.Sort(comp);

            //ASSIM TAMBÉM FUNCIONARIA - PASSANDO A FUNÇÃO LAMBDA DIRETO NO SORT
            //lista.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));
            
            //CADA VEZ MENOS LINHAS E MENOS COMPREENSÍVEL



            foreach (Product produto in lista)
            {
                Console.WriteLine(produto);
            }
            */

        }



        /*
        //MÉTODO ESTÁTICO GENÉRICO PARA IMPRIMIR RESULTADOS
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        */


    }
}
