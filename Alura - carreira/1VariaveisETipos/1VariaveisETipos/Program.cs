using System.Globalization;
using System.Security.Cryptography.X509Certificates;

//--------------------------------------------------------------------------------------------
/*
int anoNascimento = 1997;
int anoAtual = DateTime.Today.Year;
int idade = anoAtual-anoNascimento;

Console.WriteLine($"Ano nascimento: {anoNascimento}\nAno atual: {anoAtual}\nIdade:{idade}");

//--------------------------------------------------------------------------------------------
float valorRecebido;
string opcao;
bool doacaoAnonima;
string tipoConta;


Console.Write("Valor recebido: R$");
valorRecebido = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
Console.Write("Doação anônima? [S/N]: ");
opcao =  Console.ReadLine().ToUpper();
if(opcao == "S")
{
    doacaoAnonima=true;
}
else
{
    doacaoAnonima = false;
}

Console.Write("Tipo de conta [Corrente / Poupança]: ");
opcao = Console.ReadLine().ToUpper();
if (opcao == "CORRENTE")
{
    tipoConta = "C";
}
else if(opcao == "POUPANÇA")
{
    tipoConta = "P";
}
else
{
    tipoConta = "Indefinido";
}

    Console.WriteLine($"\nValor recebido: R${valorRecebido}\nDoação anônima: {doacaoAnonima}\nTipo de conta: {tipoConta}");

//--------------------------------------------------------------------------------------------
double distanciaEmMilhas;
double distanciaEmQuilometros;
double medidaConversao = 1.60934;

Console.Write("Distância em milhas: ");
distanciaEmMilhas = double.Parse(Console.ReadLine());
distanciaEmQuilometros = (distanciaEmMilhas * medidaConversao);

Console.WriteLine($"{distanciaEmMilhas} milhas equivalem a {distanciaEmQuilometros}km");

//--------------------------------------------------------------------------------------------
int valorMinutos;
int horas;
int minutos;

Console.Write("Tempo decorrido em minutos: ");
valorMinutos = int.Parse(Console.ReadLine());

horas = (valorMinutos/60);
minutos = (valorMinutos%60);

Console.WriteLine($"Em horas\nHoras: {horas}\n+{minutos} minutos");

//--------------------------------------------------------------------------------------------
float largura;
float comprimento;
float areaRetangulo;

Console.Write("Largura [m]: ");
largura = float.Parse(Console.ReadLine());
Console.Write("Comprimento [m]: ");
comprimento = float.Parse(Console.ReadLine());
areaRetangulo = largura * comprimento;

Console.WriteLine($"A área do terreno é: {areaRetangulo} metros quadrados");

//--------------------------------------------------------------------------------------------
float nota1 = 7.2f;
float nota2 = 8.3f;
float nota3 = 9.1f;
double mediaAritmeticaNotas = (nota1+ nota2 + nota3)/3;
Console.WriteLine($"A média das notas é: {mediaAritmeticaNotas}");

//--------------------------------------------------------------------------------------------
decimal pesoContainers;
int quantidadeVeiculosNecessarios;

Console.Write("Peso dos containers em toneladas: ");
pesoContainers = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
quantidadeVeiculosNecessarios = (int)pesoContainers;

Console.WriteLine($"Veículos necessário: {quantidadeVeiculosNecessarios}");

//--------------------------------------------------------------------------------------------
byte vidasIniciais;
byte vidasFinais;
string opcao;

Console.Write("Número inicial de vidas: ");
vidasIniciais = byte.Parse(Console.ReadLine());
vidasFinais = vidasIniciais;

while (vidasFinais > 0)
{
    Console.Write("Perder vida [S/N]? ");
    opcao = Console.ReadLine().ToUpper();
    if(opcao == "S" || opcao == "SIM")
    {
        vidasFinais--;
    }

    Console.WriteLine($"Vidas: {vidasFinais}");
}

Console.WriteLine("Fim");
//--------------------------------------------------------------------------------------------
decimal salarioInicial;
decimal percentualAumento;
decimal valorAumento;
decimal salarioIncrementado;

Console.Write("Salário atual: R$ ");
salarioInicial = decimal.Parse(Console.ReadLine());
Console.Write("Percentual de aumento [%]: ");
percentualAumento = decimal.Parse(Console.ReadLine());
valorAumento = salarioInicial * (percentualAumento / 100);
salarioIncrementado = salarioInicial + valorAumento;

Console.WriteLine($"Salário inicial: R${salarioInicial.ToString("f2")}\n" +
                  $"Percentual de aumento: {percentualAumento}% => R${valorAumento.ToString("f2")}\n" +
                  $"Salário incrementado: R${salarioIncrementado.ToString("f2")}");
*/
//--------------------------------------------------------------------------------------------
double pi = 3.14159;
double raioCirculo;
double areaCirculo;
double circunferenciaCirculo;


Console.Write("Raio da circunferência: ");
raioCirculo = double.Parse(Console.ReadLine());
areaCirculo = pi * raioCirculo * raioCirculo;
circunferenciaCirculo = 2 * pi * raioCirculo;

Console.WriteLine($"Raio: {raioCirculo}\nÁrea: {areaCirculo}\nCircunferência: {circunferenciaCirculo}");


