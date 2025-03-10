// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;//REFERÊNCIA AO NAMESPACE SYSTEM - PADRÃO DO VISUAL STUDIO
using System.Collections.Generic;
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
            

            //--------------------------------------------------
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
            


            //--------------------------------------------------
            //EXERCÍCIO_03
            double pi = 3.14159;
            Console.WriteLine("Digite o raio do círculo: ");
            double raio_circulo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double area_circulo = pi * (Math.Pow(raio_circulo,2));
            Console.WriteLine($"Área do círculo: {area_circulo.ToString("f4",CultureInfo.InvariantCulture)}");
            


            //--------------------------------------------------
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
            


            //--------------------------------------------------
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
            


            //--------------------------------------------------
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
            


            //--------------------------------------------------
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
            


            //--------------------------------------------------
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
            


            //--------------------------------------------------
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
            


            //--------------------------------------------------
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
            


            //--------------------------------------------------
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
            


            //--------------------------------------------------
            //EXERCÍCIO_12
            double preco = 0;

            Console.WriteLine("Código do item e quantidade: ");
            string[] dados = Console.ReadLine().Split();

            int codigo_item = int.Parse(dados[0], CultureInfo.InvariantCulture);
            int quantidade_item = int.Parse(dados[1], CultureInfo.InvariantCulture);

            if (codigo_item == 1)
            {
                preco = quantidade_item * 4;
            }
            else if (codigo_item == 2)
            {
                preco = quantidade_item * 4.5;
            }
            else if (codigo_item == 3)
            {
                preco = quantidade_item * 5;
            }
            else if (codigo_item == 4)
            {
                preco = quantidade_item * 2;
            }
            else if (codigo_item == 5)
            {
                preco = quantidade_item * 1.5;
            }

            Console.WriteLine($"Total: R$ {preco.ToString("f2", CultureInfo.InvariantCulture)}");
            


            //--------------------------------------------------
            //EXERCÍCIO_13
            Console.WriteLine("Digite um valor numério qualuer: ");
            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            if (valor >= 0 && valor <= 25)
            {
                Console.WriteLine("Intervalo: [0,25]");
            }
            else if (valor > 25 && valor <= 50)
            {
                Console.WriteLine("Intervalo: (25,50]");
            }
            else if (valor > 50 && valor <= 75)
            {
                Console.WriteLine("Intervalo: (50,75]");
            }
            else if (valor > 75 && valor <= 100)
            {
                Console.WriteLine("Intervalo: (75,100]");
            }
            else
            {
                Console.WriteLine("Fora de intervalo");
            }
            


            //--------------------------------------------------
            //EXERCÍCIO_14
            Console.WriteLine("Digite as coordenadas X e Y (com uma casa decimal: )");
            string[] coordenadas = Console.ReadLine().Split();
            double x = double.Parse(coordenadas[0], CultureInfo.InvariantCulture);
            double y = double.Parse(coordenadas[1], CultureInfo.InvariantCulture);

            if (x == 0 && y == 0)
            {
                Console.WriteLine("Origem");
            }
            else if (x > 0)
            {
                if (y > 0)
                {
                    Console.WriteLine("Q1");
                }
                else //y < 0
                {
                    Console.WriteLine("Q4");
                }
            }
            else // x < 0
            {
                if (y > 0)
                {
                    Console.WriteLine("Q2");
                }
                else //y < 0
                {
                    Console.WriteLine("Q3");
                }
            }
            


            //--------------------------------------------------
            //EXERCÍCIO_15
            double imposto = 0;
            double faixa1 = 0;
            double faixa2 = 0;
            double faixa3 = 0;

            Console.WriteLine("Digite o salário: ");
            double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (salario > 0 && salario <= 2000)//
            {
                Console.WriteLine("Isento");
            }
            else if (salario > 2000 && salario <= 3000)//faixa1
            {
                //2500
                faixa1 = (salario - 2000);
                imposto += faixa1 * 0.08;
                Console.WriteLine($"Faixa 1 - {faixa1} - cobrado 8%");
            }

            else if (salario > 3000 && salario <= 4500)//faixa2
            {
                //3500
                faixa2 = (salario - 3000);//500
                imposto += faixa2 * 0.18;

                faixa1 = (salario - faixa2) - 2000;//3500 - 500 = 3000 -> 3000 - 2000 = 1000
                imposto += faixa1 * 0.08;

                Console.WriteLine($"Faixa 1 - {faixa1} - cobrado 8%");
                Console.WriteLine($"Faixa 2 - {faixa2} - cobrado 18%");
            }

            else if (salario > 4500)//faixa3
            {
                //5000
                faixa3 = (salario - 4500); //500
                imposto += faixa3 * 0.28;

                faixa2 = (salario - faixa3) - 3000;//5000 - 500 = 4500 -> 4500 - 3000 = 1500
                imposto += faixa2 * 0.18;

                faixa1 = salario - faixa3 - faixa2 - 2000;//5000 - 500 - 1500 = 3000 -> 3000 - 2000 = 1000
                imposto += faixa1 * 0.08;

                Console.WriteLine($"Faixa 1 - {faixa1} - cobrado 8%");
                Console.WriteLine($"Faixa 2 - {faixa2} - cobrado 18%");
                Console.WriteLine($"Faixa 3 - {faixa3} - cobrado 28%");

            }

            Console.WriteLine($"Imposto de renda: {imposto}");
            


            //--------------------------------------------------
            //EXERCÍCIO_16
            string senha = "2002";
            string tentativa = "";

            while (tentativa != senha)
            {
                Console.Write("Digite a senha: ");
                tentativa = Console.ReadLine();
                if (tentativa != senha)
                {
                    Console.WriteLine("Senha inválida");
                }
            }
            Console.WriteLine("Acesso permitido");
            


            //--------------------------------------------------
            //EXERCÍCIO_17
            int x = 1;
            int y = 1;

            while (x != 0 && y != 0)//ENQUANTO NENHUM COORDENADA FOR NULA
            {
                Console.Write("Digite as coordenadas X e Y (mesma linha, separadas por espaço): ");
                string[] coordenadas = Console.ReadLine().Split();
                x = int.Parse(coordenadas[0]);
                y = int.Parse(coordenadas[1]);

                if (x != 0 && y != 0)
                {
                    if (x > 0)
                    {
                        if (y > 0)
                        {
                            Console.WriteLine("Primeiro");
                        }
                        else //y < 0
                        {
                            Console.WriteLine("Quarto");
                        }
                    }
                    else // x < 0
                    {
                        if (y > 0)
                        {
                            Console.WriteLine("Segundo");
                        }
                        else //y < 0
                        {
                            Console.WriteLine("Terceiro");
                        }
                    }
                }
            }
            


            //--------------------------------------------------
            //EXERCÍCIO_18
            int op = 0;
            int alcool = 0;
            int gasolina = 0;
            int diesel = 0;

            while (op != 4)
            {
                Console.WriteLine("Qual tipo de combustível será abastecido: ");
                Console.WriteLine("1 - Álcool\n" +
                                  "2 - Gasolina\n" +
                                  "3 - Diesel\n" +
                                  "4 - Sair");
                Console.Write("-> ");

                op = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (op == 1)
                {
                    alcool++;
                }
                else if(op == 2)
                {
                    gasolina++;
                }
                else if (op == 3)
                {
                    diesel++;
                }
                else if (op == 4)
                {
                    Console.WriteLine("Muito obrigado!");
                }
                else
                {
                    Console.WriteLine("Código inválido!");
                }

            }

            Console.WriteLine();
            Console.WriteLine("Quantidade de abastecimentos");
            Console.WriteLine($"Álcool: {alcool}\n" +
                              $"Gasolina: {gasolina}\n" +
                              $"Diesel: {diesel}");
            



            //--------------------------------------------------
            //EXERCÍCIO_19
            int x = 0;
            
            while (x < 1 || x > 100)
            {
                Console.Write("Digite um valor x, sendo 1 <= x <= 100 : ");
                x = int.Parse(Console.ReadLine());

                if (x >= 1 && x <= 100)
                {
                    Console.WriteLine($"Ímpares de 1 a {x}: ");
                    int i = 1;
                    for (i = 1; i <= x; i++)
                    {
                        if (i%2 != 0)//SE FOR IMPAR
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
                else//X FORA DO INTERVALO
                {
                    Console.WriteLine("Valor fora do intervalo!");
                    Console.WriteLine();
                }
            }
            



            //--------------------------------------------------
            //EXERCICIO_20
            Console.Write("Quantos números serão lidos: ");
            int quantidade_valores = int.Parse(Console.ReadLine());

            int i = 0;
            int quantidade_in = 0;
            int quantidade_out = 0;

            for (i = 1; i <= quantidade_valores; i++)
            {
                Console.Write($"Valor {i}: ");
                int valor = int.Parse(Console.ReadLine());
                if (valor >= 10 && valor <= 20)
                {
                    quantidade_in++;
                }
                else
                {
                    quantidade_out++;
                }
            }

            Console.WriteLine($"{quantidade_in} in\n{quantidade_out} out");
            



            //--------------------------------------------------
            //EXERCICIO_21
            int peso1 = 2;
            int peso2 = 3;
            int peso3 = 5;
            double media_ponderada1 = 0;
            double media_ponderada2 = 0;
            double media_ponderada3 = 0;

            Console.Write("Quantos casos de teste serão processados: ");
            int quantidade_conjuntos = int.Parse(Console.ReadLine());

            int i = 0;
            for (i = 1; i <= quantidade_conjuntos; i++)//QUANTOS CONJUNTOS FOREM
            {
                double aux_media_ponderada = 0;

                string[] dados = Console.ReadLine().Split();//DIGITAR 3 VALORES E ENTER
                double valor1 = double.Parse(dados[0], CultureInfo.InvariantCulture);
                double valor2 = double.Parse(dados[1], CultureInfo.InvariantCulture);
                double valor3 = double.Parse(dados[2], CultureInfo.InvariantCulture);

                aux_media_ponderada = ((valor1 * peso1) + (valor2 * peso2) + (valor3 * peso3)) / (peso1 + peso2 + peso3);
                
                if (i == 1)
                {
                    media_ponderada1 = aux_media_ponderada;
                }
                else if (i == 2)
                {
                    media_ponderada2 = aux_media_ponderada;
                }
                else if (i == 3)
                {
                    media_ponderada3 = aux_media_ponderada;
                }

            }

            Console.WriteLine($"{media_ponderada1.ToString("f1", CultureInfo.InvariantCulture)}\n" +
                              $"{media_ponderada2.ToString("f1", CultureInfo.InvariantCulture)}\n" +
                              $"{media_ponderada3.ToString("f1", CultureInfo.InvariantCulture)}");
            



            //--------------------------------------------------
            //EXERCICIO_22
            Console.Write("Quantos pares de números serão processados: ");
            int quantidade_pares = int.Parse(Console.ReadLine());

            int i = 0;
            for (i = 1; i <= quantidade_pares; i++)
            {
                string[] par = Console.ReadLine().Split();
                double valor1 = double.Parse(par[0], CultureInfo.InvariantCulture);
                double valor2 = double.Parse(par[1], CultureInfo.InvariantCulture);

                if (valor2 == 0)
                {
                    Console.WriteLine("Divisão impossível");
                }
                else//QUALQUER CASO ONDE O DENOMINADOR NÃO É 0
                {
                    double divisao = valor1 / valor2;
                    Console.WriteLine($"{divisao.ToString("f1",CultureInfo.InvariantCulture)}");
                }

            }
            



            //--------------------------------------------------
            //EXERCICIO_23
            int fatorial = 0;

            Console.Write("Digite o número para cálculo do fatorial: ");
            int numero = int.Parse(Console.ReadLine());

            if (numero == 1 || numero == 0)
            {
                fatorial = 1;
            }
            else
            {
                int i = 0;
                int a = numero;
                for (i = numero - 1; i > 1; i--)//i == 4 - 3 - 2
                {
                    fatorial = a * i; // 20 - 60 - 120
                    Console.WriteLine($"{a} x {i} = {fatorial}");
                    a = fatorial;
                }
            }
            Console.WriteLine(fatorial);
            */



            //--------------------------------------------------
            //EXERCICIO_24










            //RASCUNHO
            /*
            Console.WriteLine("Digite três números inteiros: ");
            string[] numeros = Console.ReadLine().Split();
            int valor1 = int.Parse(numeros[0]);
            int valor2 = int.Parse(numeros[1]);
            int valor3 = int.Parse(numeros[2]);

            Console.WriteLine($"{valor1} - {valor2} - {valor3}");

            int maior = Maior_de_tres(valor1, valor2, valor3);
            Console.WriteLine($"Maior: {maior}");


            //--------------------------------------------------------

            double numero = 0;
            double raiz_numero = 0;

            while (numero >= 0)
            {
                Console.Write("Digite um número inteiro positivo: ");
                numero = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                raiz_numero = Math.Sqrt(numero);

                Console.WriteLine($"Raiz de {numero} : {raiz_numero.ToString("f2", CultureInfo.InvariantCulture)}");
            }

            Console.WriteLine("Número negativo!");

            */



        }



        //FUNÇÕES DO ARQUIVO AQUI

        /*
        static int Maior_de_tres(int n1, int n2, int n3)
        {
            int f_maior = n1;

            if (n2 >= f_maior)
            {
                f_maior = n2;
            }
            if (n3 >= f_maior)
            {
                f_maior = n3;
            }

            return f_maior;
        }
        */

    }
}
