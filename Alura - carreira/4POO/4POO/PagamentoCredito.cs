
using System.Runtime.CompilerServices;

namespace _4POO;

internal class PagamentoCredito : Pessoa2, IPagamento
{
    public PagamentoCredito(string nome, string email) :base(nome, email){ }

    public void ProcessarPagamento()
    {
        Console.WriteLine($"Processando pagamento com cartão de crédito para {Nome} - {Email}");
    }
}
