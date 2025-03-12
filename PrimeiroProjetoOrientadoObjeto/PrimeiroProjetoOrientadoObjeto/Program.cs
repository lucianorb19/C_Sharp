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
            



            //------------------------------------------------------------- 
            //EXERCÍCIO_29

            Produto produto1 = new Produto();

            Console.WriteLine("Digite os dados do produto: ");
            Console.Write("Nome: ");
            produto1.Nome = Console.ReadLine();
            Console.Write("Preço: ");
            produto1.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade em estoque: ");
            produto1.Quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine($"Dados do produto: {produto1}");
            Console.WriteLine();

            Console.Write("Quantidade desse produto a ser adicionada: ");
            int quantidade = int.Parse(Console.ReadLine());
            produto1.AdicionarProdutos(quantidade);
            Console.WriteLine();

            Console.WriteLine($"Dados atualizados: {produto1}");
            Console.WriteLine();

            Console.Write("Quantidade desse produto a ser removida: ");
            quantidade = int.Parse(Console.ReadLine());
            produto1.RemoverProdutos(quantidade);

            Console.WriteLine($"Dados atualizados: {produto1}");
            Console.WriteLine();
            


            //------------------------------------------------------------- 
            //EXERCÍCIO_30
            Retangulo retangulo1 = new Retangulo();

            Console.WriteLine("Digite a largura e a altura do retângulo: ");
            Console.Write("Largura: ");
            retangulo1.Largura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Altura: ");
            retangulo1.Altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double area_retangulo = retangulo1.Area();
            double perimetro_retangulo = retangulo1.Perimetro();
            double diagonal_retangulo = retangulo1.Diagonal();

            Console.WriteLine($"Área: {area_retangulo.ToString("f2", CultureInfo.InvariantCulture)}\n" +
                              $"Perímetro: {perimetro_retangulo.ToString("f2", CultureInfo.InvariantCulture)}\n" +
                              $"Diagonal: {diagonal_retangulo.ToString("f2", CultureInfo.InvariantCulture)}");
            



            //------------------------------------------------------------- 
            //EXERCÍCIO_31
            Funcionario1 funcionario = new Funcionario1();


            Console.WriteLine("Digite os dados do funcionário: ");
            Console.Write("Nome: ");
            funcionario.Nome = Console.ReadLine();
            Console.Write("Salário Bruto: ");
            funcionario.Salario_Bruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Imposto: ");
            funcionario.Imposto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine($"Funcionário: {funcionario}");
            Console.WriteLine();

            Console.Write("Digite a porcentagem para aumentar o salário bruto: ");
            double porcentagem = double.Parse(Console.ReadLine());
            funcionario.AumentarSalario(porcentagem);
            Console.WriteLine();

            Console.WriteLine($"Dados atualizados: {funcionario}");
            



            //------------------------------------------------------------- 
            //EXERCÍCIO_32
            Aluno aluno = new Aluno();

            Console.Write("Nome do aluno: ");
            aluno.Nome = Console.ReadLine();
            Console.WriteLine("Digite as três notas do aluno [ENTER a cada nota]");
            Console.Write("1º Trimestre [máximo 30]--> ");
            aluno.Nota1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("2º Trimestre [máximo 35]--> ");
            aluno.Nota2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("3º Trimestre [máximo 35]--> ");
            aluno.Nota3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            aluno.StatusAluno();
            



            //------------------------------------------------------------- 
            //EXERCÍCIO_33
            //POO USANDO MEMBROS ESTÁTICOS
            Console.Write("Qual a cotação do dólar: ");
            double p_cotacao_dolar = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantos dólares você vai comprar? ");
            double p_dolares_a_comprar = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double resultado = ConversorMoeda.ConversorDolar(p_cotacao_dolar, p_dolares_a_comprar);

            Console.WriteLine($"Valor a ser pago em reais: {resultado.ToString("f2",CultureInfo.InvariantCulture)}");
            


            //------------------------------------------------------------- 
            //EXERCÍCIO_34

            Console.WriteLine("Digite os dados do produto: ");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            //Console.Write("Quantidade em estoque: ");
            //int quantidade = int.Parse(Console.ReadLine());

            //USO DE CONSTRUTOR PERSONALIZADO
            Produto1 produto1 = new Produto1(nome, preco);
            //USO CONSTRUTOR PADRÃO
            Produto1 produto2 = new Produto1();

            Console.WriteLine($"Dados do produto: {produto1}");
            Console.WriteLine();

            Console.Write("Quantidade desse produto a ser adicionada: ");
            int quantidade_adicionar = int.Parse(Console.ReadLine());
            produto1.AdicionarProdutos(quantidade_adicionar);
            Console.WriteLine();

            Console.WriteLine($"Dados atualizados: {produto1}");
            Console.WriteLine();

            Console.Write("Quantidade desse produto a ser removida: ");
            int quantidade_remover = int.Parse(Console.ReadLine());
            produto1.RemoverProdutos(quantidade_remover);

            Console.WriteLine($"Dados atualizados: {produto1}");
            Console.WriteLine();
            



            //------------------------------------------------------------- 
            //EXERCÍCIO_35
            Produto1 produto1 = new Produto1()
            {
                Nome = "TV",
                Preco = 1500,
                Quantidade = 10
            };

            Console.WriteLine($"Dados atualizados: {produto1}");
            Console.WriteLine();
            */










        }
    }
}
