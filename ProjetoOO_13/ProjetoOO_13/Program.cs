using System;
using ProjetoOO_13.Entitites;
using ProjetoOO_13.Services;

namespace ProjetoOO_13
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> produtos = new List<Product>();

            produtos.Add(new Product("TV", 900));
            produtos.Add(new Product("MOUSE",50));
            produtos.Add(new Product("TABLET",350));
            produtos.Add(new Product("HD",80.9));

            //USO DO DELEGATE ACTION PELA FUNÇÃO ForEach - NATIVO DE LISTAS
            //QUE RECEBE O MÉTODO UpdatePrice COMO PARÂMETRO
            //UpdatePrice É UM MÉTODO ESTÁTICO VOID QUE ACEITA UM TIPO GENÉRICO
            //OU SEJA, PODE SER USADO COM DELEGATE ACTION
            //UpdatePrice AUMENTA EM 10% TODOS VALORES
            produtos.ForEach(UpdatePrice);

            //TAMBÉM FUNCIONA ASSIM - OBJETO TIPO ACTION
            //Action<Product> action = UpdatePrice;
            //produtos.ForEach(action);

            //TAMBÉM FUNCIONA ASSIM - FUNÇÃO LAMBDA
            //Action<Product> action = p => { p.Price += p.Price * 0.1; };


            foreach (Product produto in produtos)
            {
                Console.WriteLine(produto);
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

        //MÉTODO USADO NO ACTION - ACEITA TIPO GENÉRICO E NÃO TEM RETORNO
        static void UpdatePrice(Product produto)
        {
            produto.Price += produto.Price * 0.1;//AUMENTO 10%
        }



    }
}
