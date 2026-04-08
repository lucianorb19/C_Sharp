

namespace _4POO;

internal class ClienteVIP : Pessoa
{
    public string NivelFidelidade { get;}
    public string CodigoVIP { get;}

    public ClienteVIP(string nome, int idade, string nivelFidelidade, string codigoVip)
        : base(nome, idade)
    {
        this.NivelFidelidade = nivelFidelidade;
        this.CodigoVIP = codigoVip;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Bem vindo, cliente VIP: {Nome}\nIdade: {Idade}\n" +
                          $"Nível de Fidelidade: {NivelFidelidade}\nCódigo VIP:{CodigoVIP}\n");
    }
}
