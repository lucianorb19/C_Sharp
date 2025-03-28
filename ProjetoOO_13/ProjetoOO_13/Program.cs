using System;
using ProjetoOO_13.Entitites;
using ProjetoOO_13.Services;
using System.Linq; //FUNÇÃO SELECT

namespace ProjetoOO_13
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> produtos = new List<Product>();

            produtos.Add(new Product("tv", 900));
            produtos.Add(new Product("mouse",50));
            produtos.Add(new Product("tablet",350));
            produtos.Add(new Product("hd",80.9));

            //A NOVA LISTA RESULTADO RECEBE PARA CADA ITEM DE produtos, O RESULTADO DA FUNÇÃO
            //NameUpper APLICADA A ELES. - UMA LISTA DE STRINGS
            List<string> resultado = produtos.Select(NameUpper).ToList();


            //TAMBÉM FUNCIONA ASSIM
            //Func<Product, string> func = NameUpper;
            //List<string> resultado = produtos.Select(func).ToList();


            //TAMBÉM FUNCIONA ASSIM - FUNÇÃO LAMBDA - NÃO É PRECISO O MÉTODO ESTÁTICO
            //Func<Product, string> func = p => p.Name.ToUpper();
            //List<string> resultado = produtos.Select(func).ToList();


            //TAMBÉM FUNCIONA ASSIM - FUNÇÃO LAMBDA - NÃO É PRECISO O MÉTODO ESTÁTICO
            //List<string> resultado = produtos.Select(p => p.Name.ToUpper()).ToList();



            foreach (Product produto in produtos)
            {
                Console.WriteLine(produto);
            }
            Console.WriteLine();

            foreach (string nome in resultado)
            {
                Console.WriteLine(nome);
            }


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

        //MÉTODO USADO NO FUNC - ACEITA TIPO GENÉRICO E TEM RETORNO STRING
        static string NameUpper(Product p)
        {
            return p.Name.ToUpper();
        }

    }
}
