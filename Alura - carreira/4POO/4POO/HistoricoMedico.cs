
namespace _4POO;

internal class HistoricoMedico
{
    public string CodigoProntuario { get; set; }

    public HistoricoMedico(string codigoProntuario)
    {
        CodigoProntuario = codigoProntuario;
    }

    public void ExibirCodigo()
    {
        Console.WriteLine($"Código do prontuário: {CodigoProntuario}");
    }
}
