

namespace _4POO;

internal class Interno : Funcionario
{
    public double Salario { get;}

    public Interno(string nome, string cargo, double salario)
        : base(nome, cargo)
    {
        Salario = salario;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Funcionário: {Nome} - Cargo: {Cargo} - Salário: {Salario.ToString("c")}");
    }
}
