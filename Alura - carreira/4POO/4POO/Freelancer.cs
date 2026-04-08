

namespace _4POO;

internal class Freelancer : Funcionario
{
    public double ValorProjeto { get;}

    public Freelancer(string nome, string cargo,double valorProjeto)
        :base(nome, cargo)
    {
        ValorProjeto = valorProjeto;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Freelancer: {Nome} - Cargo: {Cargo} - Valor projeto atual: {ValorProjeto.ToString("c")}");
    }
}
