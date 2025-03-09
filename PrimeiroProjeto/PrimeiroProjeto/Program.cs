// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;//REFERÊNCIA AO NAMESPACE SYSTEM - PADRÃO DO VISUAL STUDIO
using System.Data;
using System.Globalization;
using System.Numerics; //CultureInfo.InvariantCulture


namespace PrimeiroProjeto
{
    internal class Program
    {
        static void Main(string[] args)//ENTRY POINT - ONDE A APLICÃÇÃO COMEÇA A SER EXECUTADA
        {
            /*
            //EXERCÍCIO_1
            string produto1 = "Computador";
            string produto2 = "Mesa de escritório";

            byte idade = 30;
            int codigo = 5290;
            char genero = 'M';

            double preco1 = 2100.0;
            double preco2 = 650.50;
            double medida = 53.234567;

            Console.WriteLine($"{produto1} cujo preço é ${preco1.ToString("f2")}");
            Console.WriteLine($"{produto2}, cujo preço é ${preco2.ToString("f2")}");
            Console.WriteLine($"Registo: {idade} anos de idade, código {codigo} e gênero: {genero}");
            Console.WriteLine($"Medida com oito casas decimais: {medida.ToString("f8")}");
            Console.WriteLine($"Arredondado (três casas decimais): {medida.ToString("f3")}");
            Console.WriteLine($"Separador decimal invariant culture: {medida.ToString("f3", CultureInfo.InvariantCulture)}");
            


            //EXERCÍCIO_2
            Console.WriteLine("Digite seu nome completo: ");
            string nome = Console.ReadLine();
            
            Console.WriteLine("Quantos quartos tem na sua casa? ");
            int numero_quartos = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o preço de um produto: ");
            double preco_produto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            Console.WriteLine("Digite seu último nome, idade e altura (mesma linha): ");
            string[] dados = Console.ReadLine().Split(' ');
            string ultimo_nome = dados[0];
            int idade1 = int.Parse(dados[1]);
            double altura = double.Parse(dados[2], CultureInfo.InvariantCulture);


            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Quantidade de quartos: {numero_quartos}");
            Console.WriteLine($"Preço do produto: {preco_produto.ToString("f2",CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Último nome: {ultimo_nome}");
            Console.WriteLine($"Idade: {idade1}");
            Console.WriteLine($"Altura: {altura.ToString("f2", CultureInfo.InvariantCulture)}");
            


            //EXERCÍCIO_03
            double pi = 3.14159;
            Console.WriteLine("Digite o raio do círculo: ");
            double raio_circulo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double area_circulo = pi * (Math.Pow(raio_circulo,2));
            Console.WriteLine($"Área do círculo: {area_circulo.ToString("f4",CultureInfo.InvariantCulture)}");
            


            //EXERCÍCIO_04
            Console.WriteLine("Primeiro número inteiro: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Segundo número inteiro: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Terceiro número inteiro: ");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Quarto número inteiro: ");
            int d = int.Parse(Console.ReadLine());

            int produto1 = a * b;
            int produto2 = c * d;
            int diferenca_produtos = produto1 - produto2;

            Console.WriteLine($"{a} * {b} - {c} * {d} = {diferenca_produtos}");
            


            //EXERCÍCIO_05
            Console.WriteLine("Número do funcionário: ");
            int numero_funcionario = int.Parse(Console.ReadLine());
            Console.WriteLine("Quantidade de horas trabalhadas: ");
            int horas_trabalhadas = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor da hora de trabalho: ");
            float valor_hora = float.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            double salario = horas_trabalhadas * valor_hora;

            Console.WriteLine($"Number: {numero_funcionario}");
            Console.WriteLine($"Salary: U$ {salario.ToString("f2",CultureInfo.InvariantCulture)}");
            


            //EXERCÍCIO_06
            Console.WriteLine("Peça 1: ");
            string[] peca1 = Console.ReadLine().Split(' ');
            Console.WriteLine("Peça 2: ");
            string[] peca2 = Console.ReadLine().Split(' ');

            int quantidade_peca_1 = int.Parse(peca1[1]);
            float valor_peca_1 = float.Parse(peca1[2], CultureInfo.InvariantCulture);
            double preco_peca_1 = quantidade_peca_1 * valor_peca_1;

            int quantidade_peca_2 = int.Parse(peca2[1]);
            float valor_peca_2 = float.Parse(peca2[2], CultureInfo.InvariantCulture);
            double preco_peca_2 = quantidade_peca_2 * valor_peca_2;

            double total = preco_peca_1 + preco_peca_2;

            Console.WriteLine($"Total a pagar: {total.ToString("F2",CultureInfo.InvariantCulture)}");
            


            //EXERCÍCIO_07
            double pi = 3.14159;

            Console.WriteLine("Valores: ");
            string[] valores = Console.ReadLine().Split();

            double valor1 = double.Parse(valores[0], CultureInfo.InvariantCulture);
            double valor2 = double.Parse(valores[1], CultureInfo.InvariantCulture);
            double valor3 = double.Parse(valores[2], CultureInfo.InvariantCulture);

            double area_triangulo = (valor1 * valor3) / 2;
            double area_circulo = pi * (Math.Pow(valor3,2));
            double area_trapezio = ((valor1 + valor2) * valor3) / 2;
            double area_quadrado = Math.Pow(valor2, 2);
            double area_retangulo = valor1 * valor2;

            Console.WriteLine($"Triângulo: {area_triangulo.ToString("f3", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Círculo: {area_circulo.ToString("f3", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Trapézio: {area_trapezio.ToString("f3", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Quadrado: {area_quadrado.ToString("f3", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Retângulo: {area_retangulo.ToString("f3", CultureInfo.InvariantCulture)}");
            

            //EXERCÍCIO_08
            Console.WriteLine("Digite um número inteiro: ");
            int numero = int.Parse(Console.ReadLine());
            if(numero < 0)
            {
                Console.WriteLine("Negativo");
            }
            else
            {
                Console.WriteLine("Não negativo");
            }
            

            //EXERCÍCIO_09
            Console.WriteLine("Digite um número inteiro: ");
            int numero = int.Parse(Console.ReadLine());
            if(numero%2 == 0)
            {
                Console.WriteLine("Par");
            }
            else
            {
                Console.WriteLine("Ímpar");
            }
            


            //EXERCÍCIO_10
            Console.WriteLine("Digite o primeiro número inteiro: ");
            int valor1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo número inteiro: ");
            int valor2 = int.Parse(Console.ReadLine());

            if (valor1 > valor2 || valor1==valor2)
            {
                if (valor1 % valor2 == 0)
                {
                    Console.WriteLine("São múltiplos");
                }
                else//valor 1%valor 2 != 0
                {
                    Console.WriteLine("Não são múltiplos");
                }
            }
            else //valor 2 > valor1
            {
                if (valor2 % valor1 == 0)
                {
                    Console.WriteLine("São múltiplos");
                }
                else//valor 2%valor 1 != 0
                {
                    Console.WriteLine("Não são múltiplos");
                }
            }
            

            //EXERCÍCIO_11
            int duracao = 0;

            Console.WriteLine("Digite a hora de ínicio do jogo [24h]: ");
            int hora_inicio = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a hora de término do jogo [24h]: ");
            int hora_fim = int.Parse(Console.ReadLine());

            if (hora_inicio < hora_fim) //JOGO NO MESMO DIA
            {
                duracao = hora_fim - hora_inicio;
            }
            else if (hora_inicio == hora_fim)//JOGO DUROU 24H
            {
                duracao = 24;
            }
            else//JOGO COMEÇA EM UM DIA E TERMINA NO OUTRO
            {
                int aux1 = 24 - hora_inicio;
                duracao = aux1 + hora_fim;
            }

            Console.WriteLine($"O jogo durou {duracao} horas!");
            */








        }
    }
}
