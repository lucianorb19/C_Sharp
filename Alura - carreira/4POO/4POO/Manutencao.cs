
namespace _4POO;

internal class Manutencao : IServico
{
    public Funcionario3 Funcionario { get;}
    public string TituloServico { get; }

    public Manutencao(string tituloServico, Funcionario3 funcionario)
    {
        TituloServico = tituloServico;
        Funcionario = funcionario;
    }

    public void ExecutarServico()
    {
        Console.WriteLine($"Executando serviço de manutenção: {TituloServico}\n" +
                          $"Responsável: {Funcionario.Nome} - {Funcionario.Departamento}\n");
    }
}
