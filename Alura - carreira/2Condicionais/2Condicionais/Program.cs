using System.Globalization;

/*
//----------------------------------------------------------------------------------------
float saldo;

Console.Write("Digite o saldo: ");
saldo = float.Parse(Console.ReadLine());

if(saldo == 0)
{
    Console.WriteLine("Saldo 0");
}else if(saldo > 0)
{
    Console.WriteLine("Saldo positivo.");
}
else
{
    Console.WriteLine("Saldo negativo.");
}

//----------------------------------------------------------------------------------------
int codigoProduto;

Console.Write("Digite o código do produto \n1-Perecível\n2-Não perecível\n --> ");
codigoProduto = int.Parse(Console.ReadLine());
if(codigoProduto != 1 && codigoProduto != 2)
{
    Console.WriteLine("Código inválido!");
}
else
{
    if(codigoProduto == 1)
    {
        Console.WriteLine("Produto perecível!");
    }
    else //2
    {
        Console.WriteLine("Produto não perecível!");
    }
}

//----------------------------------------------------------------------------------------


float nota;
string classificacaoNota;

Console.Write("Informe a nota final do aluno: ");
nota = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

if(nota >= 9)
{
    classificacaoNota = "A";
}
else if(nota >= 7 && nota < 9)
{
    classificacaoNota = "B";
}
else if(nota >= 5 && nota < 7)
{
    classificacaoNota = "C";
}
else// <5
{
    classificacaoNota = "D";
}

Console.WriteLine($"O aluno recebeu a nota {classificacaoNota}");

//----------------------------------------------------------------------------------------
string senha;
int nivelAcesso;

Console.Write("Nivel de acesso: ");
nivelAcesso = int.Parse(Console.ReadLine());
Console.Write("Senha: ");
senha = Console.ReadLine();

if (senha != "42" || nivelAcesso < 5)
{
    Console.WriteLine("Acesso negado!");
    
}
else
{
    Console.WriteLine("Acesso liberado!");
}

//----------------------------------------------------------------------------------------
int idade;
string faixaEtaria = "";

Console.Write("Idade: ");
idade = int.Parse(Console.ReadLine());

if(idade > 60)
{
    faixaEtaria = "Idoso";
}
else if(idade > 18 && idade <= 59)
{
    faixaEtaria = "Adulto";

}
else if(idade > 13 && idade <= 18)
{
    faixaEtaria = "Adolescente";

}
else if (idade > 0 && idade <= 13)
{
    faixaEtaria = "Infantil";

}

Console.WriteLine($"Classificação: {faixaEtaria}");

//----------------------------------------------------------------------------------------
float num1;
float num2;
string opcao;
float resultado=0;

Console.Write("Primeiro número: ");
num1 = float.Parse(Console.ReadLine());
Console.Write("Segundo número: ");
num2 = float.Parse(Console.ReadLine());
Console.Write("Operação (+, -, *, /)\n--> ");
opcao = Console.ReadLine();

switch (opcao)
{
    case "+":
        resultado = num1 + num2;
        break;
    case "-":
        resultado = num1 - num2;
        break;
    case "*":
        resultado = num1 * num2;
        break;
    case "/":
        resultado = num1 / num2;
        break;
}

Console.WriteLine($"Resultado: {resultado}");

//----------------------------------------------------------------------------------------
int momentoDia;
string nome = "";
string mensagem = "";

Console.Write("Qual o seu nome: ");
nome = Console.ReadLine();
Console.Write("Que momento do dia é agora?\n1-Manhã\n2-Tarde\n3-Noite\n--> ");
momentoDia = int.Parse(Console.ReadLine());


switch (momentoDia){
    case 1:
        mensagem = $"Boa manhã, {nome}!";
        break;
    case 2:
        mensagem = $"Boa tarde, {nome}!";
        break;
    case 3:
        mensagem = $"Boa noite, {nome}!";
        break;
    default:
        mensagem = "Bom dia!";
        break;
}

Console.WriteLine(mensagem);

//----------------------------------------------------------------------------------------
string recompensa = "";
string mensagem = "";

Console.Write("Código de recompensa\n--DOBRAR\n--CURAR\n--OURO\n--ESPECIAL\n--> ");
recompensa = Console.ReadLine().ToUpper();

mensagem = recompensa switch
{
    "DOBRAR" => "Ganhar 2x EXP por 1 hora desbloqueado!",
    "CURAR" => "Poção de cura desbloqueada!",
    "OURO" => "1000 moedas desbloqueadas!",
    "ESPECIAL" => "Item lendário desbloqueado!",
    _ => "Código inválido"
};

Console.WriteLine(mensagem);

//----------------------------------------------------------------------------------------
int codigoLivro;

Console.Write("Digite o código do livro: ");
codigoLivro = int.Parse(Console.ReadLine());

switch (codigoLivro/100)
{
    case 1:
        Console.WriteLine("Ficção Científica");
        break;
    case 2:
        Console.WriteLine("Literatura Clássica");
        break;
    case 3:
        Console.WriteLine("Fantasia");
        break;
    case 4:
        Console.WriteLine("Romance");
        break;
    case 5:
        Console.WriteLine("Suspense/Mistério");
        break;
    case 6:
        Console.WriteLine("Não ficção");
        break;
    case 7:
        Console.WriteLine("Biografias/Memórias");
        break;
    case 8:
        Console.WriteLine("Distopia");
        break;
    case 9:
        Console.WriteLine("Infantojuvenil");
        break;
    default:
        Console.WriteLine("Código inexistente");
        break;
}

//----------------------------------------------------------------------------------------

string nome = "";
int opcao;

Console.WriteLine("Sistema de Autenticação\n------------------------------");
Console.Write("Nome de usuarío: ");
nome = Console.ReadLine().ToUpper();

if(nome == "ADMIN")
{
    Console.WriteLine("Usuário admin logado!");
}
else
{
    Console.WriteLine("Usuário não cadastrado!\n" +
                      "[1] - Cadastrar novo usuário\n" +
                      "[2] - Acessar como convidado\n" +
                      "[3] - Sair");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            Console.WriteLine($"Novo usuário {nome} cadastrado com sucesso.");
            break;
        case 2:
            Console.WriteLine($"{nome} logado como convidado.");
            break;
        case 3:
            Console.WriteLine("Logout efetuado.");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}
*/