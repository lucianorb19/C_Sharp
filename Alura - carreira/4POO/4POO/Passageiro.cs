

namespace _4POO;

internal class Passageiro : Pessoa
{
    public int QuantidadeBilhetes { get;}

    public Passageiro(string nome, int idade,int quantidadeBilhetes)
        :base(nome, idade)
    {
        QuantidadeBilhetes = quantidadeBilhetes;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Passageiro: {Nome} - idade: {Idade} - Bilhetes: {QuantidadeBilhetes}");
    }
}
