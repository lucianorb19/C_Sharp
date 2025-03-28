using System;
using ProjetoOO_13.Entitites;
using ProjetoOO_13.Services;
using System.Linq; //FUNÇÃO SELECT

namespace ProjetoOO_13
{
    class Program
    {
        //MÉTODO ESTÁTICO GENÉRICO PARA IMPRIMIR RESULTADOS
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach(T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
            Console.WriteLine();

        }
        static void Main(string[] args)
        {
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

            var r1 = products.Where(p => p.Price < 900 && p.Category.Tier == 1);
            Print("PRODUTOS TIER 1 E PREÇO < 900",r1);
            //LÊ-SE
            //Where(p => p.Price) -OBJETOS P ONDE O PREÇO P.... 

            var r2 = products.Where(p => p.Category.Name == "Tools")
                             .Select(p => p.Name);
            Print("PRODUTOS CATEGOARIA TOOLS", r2);
            //LÊ-SE
            //.Select(p=>p.Name) - SELECIONANDO P E TRANSFORMANDO EM p.NAME

            var r3 = products.Where(p => p.Name[0] == 'C')
                             .Select(p => new { p.Name,p.Price, CategoryName = p.Category.Name });
            Print("PRODUTOS QUE COMEÇAM COM A LETRA C, MOSTRAR NOME, PREÇO E CATEGORIA",r3);
            //new { p.Name,p.Price, CategoryName = p.Category.Name }
            //OBJETO ANÔNIMO QUE OBTEM AS INFORMAÇÕES DO PRODUTO (NOME, PREÇO E NOME DA CATEGORIA)

            //CategoryName = p.Category.Name - É ASSIM PQ OS CAMPOS TEM O MESMO NOME, ENTÃO CRIA-SE UM APELIDO
            //PARA UM DELE

            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("PRODUTOS DE CATEGORIA TIER 1, ORDENADOS POR: PREÇO -> NOME", r4);

            //LÊ-SE
            //OrderBy(p => p.Price) - ORDENADOS OBJETOS P CONSIDERANDO O p.Price
            //ThenBy(p => p.Name) - E DEPOIS, CASO HAJA "EMPATE", ORDENAR OBJETOS P CONSIDERANDO p.Name

            var r5 = r4.Skip(2).Take(4);
            Print("PRODUTOS DE CATEGORIA TIER 1, ORDENADOS POR: PREÇO -> NOME\n" +
                  "PULA OS DOIS PRIMEIROS - MOSTRA OS 4 PRÓXIMOS", r5);

            var r6 = products.First();
            //var r6 = products.FirstOrDefault();
            
            Console.WriteLine($"PRIMEIRO ELEMENTO DA LISTA: {r6}");
            //CASO SEJA UMA LISTA VAZIA, GERA ERRO.
            //MELHOR USAR .FirstOrDefault() - QUE NÃO MOSTRA NADA CASO NÃO HAJA ELEMENTOS

            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine($"PRODUTO COM ID 3 - USANDO SingleOrDefault PARA GARANTIR UM ÚNICO ELEMENTO\n" +
                              $"{r8}");
            //GERA EXCEÇÃO CASO O RESULTADO SEJA MAIS QUE UM ITEM
            //SÓ ACEITA UM OU NENHUM ELEMENTO













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
    }
}
