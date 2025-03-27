using System;
using ProjetoOO_13.Entitites;
using ProjetoOO_13.Services;

namespace ProjetoOO_13
{
    //DECLARAÇÃO DO DELEGATE NOME issoEhUmDelegate
    delegate void issoEhUmDelegate(double n1, double n2);

    class Program
    {
        static void Main(string[] args)
        {

            double a = 10;
            double b = 5;
            
            //VARIÁVEL operation AGORA É UMA REFERÊNCIA PARA OS MÉTODOS ShowSum e ShowMax
            issoEhUmDelegate operation = CalculationService.ShowSum;
            operation += CalculationService.ShowMax;

            operation.Invoke(a, b);
            



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

        //MÉTODO ESTÁTICO QUE É USADO NO DELEGATE PARA A FUNÇÃO Sort
        static int CompareProducts(Product p1, Product p2)
        {
            return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
        }
    }
}
