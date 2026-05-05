
namespace _4POO;

internal class ContaBancaria2
{
    public string Titular { get;}
    private double saldo;
    public double Saldo { get { return saldo; } }

    public ContaBancaria2(string titular, double saldoInicial)
    {
        Titular = titular;
        this.saldo = saldoInicial;
    }

    public void Sacar(double valor)
    {
        if (SegurancaConta.ValidarSaque(valor))
        {
            saldo -= valor;
            Console.WriteLine($"Saque realizado com sucesso!\nSaldo atual:{Saldo.ToString("c")}");
        }
        else
        {
            Console.WriteLine("Saldo negado pela política de segurança (saque maior que R$ 1.000,00)");
        }
    }
}
