/*
//----------------------------------------------------------------
Console.Write("Qual seu nome?\n-> ");
string nome = Console.ReadLine();
Console.WriteLine($"Olá, {nome}! Seja bem-vindo!");

//----------------------------------------------------------------
Console.Write("Qual seu nome?\n-> ");
string nome = Console.ReadLine();
Console.Write("Qual seu sobrenome?\n-> ");
string sobrenome = Console.ReadLine();
Console.WriteLine($"Nome completo: {nome} {sobrenome}");

//----------------------------------------------------------------
Console.Write("Primeiro número\n--> ");
double primeiroNumero = double.Parse(Console.ReadLine());
Console.Write("Primeiro número\n--> ");
double segundoNumero = double.Parse(Console.ReadLine());

Console.Write($"Soma: {primeiroNumero+segundoNumero}\n" +
                  $"Subtração: {primeiroNumero - segundoNumero}\n" +
                  $"Multiplicação: {primeiroNumero * segundoNumero}\n");
if(segundoNumero == 0)
{
    Console.WriteLine($"Divisão: Impossível realizar divisão por 0.");
}
else
{
    Console.WriteLine($"Divisão: {primeiroNumero / segundoNumero}");
}
Console.WriteLine($"Media: {(primeiroNumero+segundoNumero)/2}");

//----------------------------------------------------------------
Console.Write("Digite uma palavra ou frase qualquer:\n--> ");
string fraseOuPalavra = Console.ReadLine().Trim();
string frasePalavraSemEspacos = fraseOuPalavra.Replace(" ", "");
int tamanho = frasePalavraSemEspacos.Length;
Console.WriteLine($"\nQuantidade de caractéres na frase/palavra (desconsiderando espaços vazios):" +
                  $" {tamanho}");

//----------------------------------------------------------------
bool placaValida=false;

Console.Write("Digite a placa de um veículo:\n--> ");
string placa = Console.ReadLine().ToUpper();

if (placa.Length == 7)//7 DÍGITOS NA PLACA
{
    for(int i = 0; i < 3; i++)
    {
        char letraAtual = placa[i];
        if ((letraAtual >= 'A' && letraAtual <= 'Z'))//3 PRIMEIROS LETRAS
        {
            placaValida = true;
        }
        else
        {
            placaValida = false;
            break;
        }
    }

    for(int i = 3; i< placa.Length; i++)
    {
        char digitoAtual = placa[i];
        if (char.IsDigit(digitoAtual))//4 ÚLTIMOS NÚMEROS
        {
            placaValida = true;
        }
        else
        {
            placaValida = false;
            break;
        }
    }
}
else placaValida = false;

Console.WriteLine($"Placa válida: {placaValida}");

//----------------------------------------------------------------
TimeZoneInfo fusoBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
DateTime agora = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, fusoBrasilia);

Console.WriteLine($"{agora.ToLongDateString()} --- {agora.ToLongTimeString()}");
Console.WriteLine($"{agora.ToShortDateString()}");
Console.WriteLine($"{agora.ToShortTimeString()}");
Console.WriteLine($"{agora.ToLongDateString()}");
*/

