using PrimeiroProjetoOrientadoObjeto;
using System;
using System.Globalization;


namespace PrimerioProjetoOrientadoObjeto
{

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //------------------------------------------------------------- 
            //EXERCÍCIO_26
            //ÁREA DE TRIÂNGULO USANDO CLASSE TRIANGULO E FÓRMULAR DE HERON
            Triangulo x, y; //INICIALIZAÇÃO DOS OBJETOS TRIÂNGULO

            x = new Triangulo();
            y = new Triangulo();//INSTANCIAÇÃO DOS OBJETOS TRIANGULO

            Console.WriteLine("Lados primeiro triangulo: ");
            x.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Lados segundo triangulo: ");
            y.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double area_x = x.Area_Triangulo();
            double area_y = y.Area_Triangulo();

            Console.WriteLine($"Área do triangulo X: {area_x.ToString("f4", CultureInfo.InvariantCulture)}\n" +
                              $"Área do triângulo Y: {area_y.ToString("f4", CultureInfo.InvariantCulture)}");

            if (area_x == area_y)
            {
                Console.WriteLine("Áreas iguais!");
            }
            else if (area_x > area_y)
            {
                Console.WriteLine("Maior área: triângulo X");
            }
            else // areay > areax
            {
                Console.WriteLine("Maior área: triângulo Y");
            }
            



            //------------------------------------------------------------- 
            //EXERCÍCIO_27
            Pessoa pessoa1, pessoa2;
            pessoa1 = new Pessoa();
            pessoa2 = new Pessoa();

            Console.WriteLine("Dados da primeira pessoa:");
            Console.Write("Nome: ");
            pessoa1.Nome = Console.ReadLine();
            Console.Write("Idade: ");
            pessoa1.Idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Dados da segunda pessoa:");
            Console.Write("Nome: ");
            pessoa2.Nome = Console.ReadLine();
            Console.Write("Idade: ");
            pessoa2.Idade = int.Parse(Console.ReadLine());

            if (pessoa1.Idade == pessoa2.Idade)
            {
                Console.WriteLine("Idades iguais!");
            }
            else if (pessoa1.Idade > pessoa2.Idade)
            {
                Console.WriteLine($"Pessoa mais velha: {pessoa1.Nome}");
            }
            else//pessoa2.Idade > pessoa1.Idade
            {
                Console.WriteLine($"Pessoa mais velha: {pessoa2.Nome}");
            }
            



            //------------------------------------------------------------- 
            //EXERCÍCIO_28
            Funcionario funcionario1, funcionario2;
            funcionario1 = new Funcionario();
            funcionario2 = new Funcionario();

            Console.WriteLine("Dados do primeiro funcionário:");
            Console.Write("Nome: ");
            funcionario1.Nome = Console.ReadLine();
            Console.Write("Salário: ");
            funcionario1.Salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Dados do segundo funcionário:");
            Console.Write("Nome: ");
            funcionario2.Nome = Console.ReadLine();
            Console.Write("Salário: ");
            funcionario2.Salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double salario_medio = (funcionario1.Salario+funcionario2.Salario)/2;
            Console.WriteLine($"Salário médio: {salario_medio.ToString("f2",CultureInfo.InvariantCulture)}");
            */



            //------------------------------------------------------------- 
            //EXERCÍCIO_28

            Produto produto1 = new Produto();

            Console.WriteLine("Digite os dados do produto: ");
            Console.Write("Nome: ");
            produto1.Nome = Console.ReadLine();
            Console.Write("Preço: ");
            produto1.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade em estoque: ");
            produto1.Quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine($"Dados do produto: {produto1}");












        }
    }
}
