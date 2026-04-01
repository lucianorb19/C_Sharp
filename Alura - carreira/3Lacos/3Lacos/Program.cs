/*
//----------------------------------------------------------------------------------
double total=0;
double valorItem = 0;

do
{
    Console.Write("Digite o valor da venda (ou 0 para sair)\n--> ");
    valorItem = double.Parse(Console.ReadLine());
    total += valorItem;
}while(valorItem!=0);

Console.WriteLine($"Total de vendas do dia: {total}");

//----------------------------------------------------------------------------------
int opcaoAdicionar = 1;
int opcaoContinuar = 1;
int quantidadeAdicionar = 0;
int quantidadeEstoque=0;

while (opcaoContinuar == 1)
{
    Console.Write("Deseja adicionar um produto ao estoque [1 - SIM   2- NÃO]?\n--> ");
    opcaoAdicionar = int.Parse(Console.ReadLine());
    if(opcaoAdicionar == 1)
    {
        Console.Write("Quantidade: ");
        quantidadeAdicionar = int.Parse(Console.ReadLine());
        quantidadeEstoque+=quantidadeAdicionar;
        Console.WriteLine($"Estoque atual: {quantidadeEstoque}");
    }
    Console.Write("Continuar [1 - SIM   2- NÃO]?\n--> ");
    opcaoContinuar = int.Parse(Console.ReadLine());
}

Console.WriteLine("Obrigado por usar nosso sitema de estoque!");

//----------------------------------------------------------------------------------
int numeroSecreto = 2;
int numeroTentativa = 0;

while(numeroSecreto != numeroTentativa)
{
    Console.Write("Tente adivinhar o número entre 1 e 10: ");
    numeroTentativa = int.Parse(Console.ReadLine());
    if(numeroTentativa != numeroSecreto)
    {
        Console.WriteLine("Errou! tente novamente.");
    }
    else
    {
        Console.WriteLine("Parabéns, você acertou!");
    }
}

//----------------------------------------------------------------------------------
string[] nomesAlunos = ["LUCIANO","JEIDSON","CRISTIANO","MARIA","JEICILAINE"];
string nomeProcurado = "";
bool encontrado = false;

Console.Write("Digite o nome do aluno procurado: ");
nomeProcurado = Console.ReadLine().ToUpper();

for(int i = 0; i < nomesAlunos.Length; i++)
{
    if (nomesAlunos[i] == nomeProcurado)
    {
        Console.WriteLine($"Aluno encontrado na posião {i}");
        encontrado = true;
        break;
    }
}

if (encontrado == false)
{
    Console.WriteLine($"Aluno {nomeProcurado} não está presente na lista");
}

//----------------------------------------------------------------------------------
int senhaGerada = 0;
int senhaAtual = 0;
int opcao;

do
{
    Console.Write("1 - Gerar nova senha\n2 - Chamar próxima senha\n3- Sair\n--> ");
    opcao = int.Parse(Console.ReadLine());
    switch (opcao)
    {
        case 1:
            senhaGerada++;
            Console.WriteLine($"Senha gerada: {senhaGerada.ToString("D3")}\n");
            break;
        case 2:
            senhaAtual++;
            Console.WriteLine($"Senha chamada: {senhaAtual.ToString("D3")}\n");
            break;
        case 3:
            Console.WriteLine("Saindo do sistema.\n");
            break;
        default:
            Console.WriteLine("Opção inválida!\n");
            break;
    }
} while (opcao != 3);

//----------------------------------------------------------------------------------
int opcao;
double temperaturaCelsius;
double temperaturaFahrenheit;

do
{
    Console.Write("\n1 - Celsius para Fahrenheit\n2 - Fahrenheit para Celsius\n3 - Sair\n--> ");
    opcao = int.Parse(Console.ReadLine());
    switch (opcao)
    {
        case 1:
            Console.Write("Temperatura em Celsius: ");
            temperaturaCelsius = double.Parse(Console.ReadLine());
            temperaturaFahrenheit = (temperaturaCelsius * 9) / 5 + 32;
            Console.Write($"{temperaturaCelsius}°C equivalem a {temperaturaFahrenheit}°F\n");

            break;
        case 2:
            Console.Write("Temperatura em Fahrenheit: ");
            temperaturaFahrenheit = double.Parse(Console.ReadLine());
            temperaturaCelsius = ((temperaturaFahrenheit-32)*5)/9;
            Console.Write($"{temperaturaFahrenheit}°F equivalem a {temperaturaCelsius}°C\n");
            break;
        case 3:
            Console.WriteLine("Saindo do sistema.\n");
            break;
        default:
            Console.WriteLine("Operação inválida!\n");
            break;
    }
} while (opcao != 3);
//----------------------------------------------------------------------------------
for(int i = 0; i <= 20; i++)
{
    if (i % 3 == 0)
    {
        continue;
    }
    Console.WriteLine(i);
}
//----------------------------------------------------------------------------------
for(int i = 1; i <= 10; i++)
{
    Console.WriteLine($"7x{i} = {7*i}");
}

//----------------------------------------------------------------------------------
List<int> notas = new List<int> { 4, 7, 5, 9, 6 };
string statusAluno;

for (int i = 0; i < notas.Count; i++)
{
    statusAluno = notas[i] >= 6 ? "Aprovado" : "Reprovado";
    Console.WriteLine($"Aluno {i+1}, nota {notas[i]}, {statusAluno}");
}
//----------------------------------------------------------------------------------
List<double> notas = new List<double>
        {
    8.5,
    6.2,
    9.1,
    5.8,
    7.4
        };
double media=0;
double somaTotal=0;
string avisoAluno;

foreach(double nota in notas)
{
    somaTotal += nota;
}
media = somaTotal / notas.Count;
//Console.WriteLine(media);

foreach(double nota in notas)
{
    avisoAluno = nota >= media ? "indo muito bem!" : "abaixo da média!";
    Console.WriteLine($"Aluno com nota {nota} está {avisoAluno}");
}

//----------------------------------------------------------------------------------
int numero;
int contadorImpares=0;

for(int i = 0; i < 10; i++)
{
    Console.Write("Digite um número: ");
    numero = int.Parse(Console.ReadLine());
    if (numero % 2 != 0) contadorImpares++;
}
Console.WriteLine($"Você digitou {contadorImpares} números ímpares.");
*/