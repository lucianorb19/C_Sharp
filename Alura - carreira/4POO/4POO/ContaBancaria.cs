class ContaBancaria
{

    public string NumeroConta { get;}
    public double Saldo { get; set; }

    public ContaBancaria(string numeroConta, double saldo)
    {
        NumeroConta = numeroConta;
        Saldo = saldo;
    }


    public void Depositar(double valor)
    {
        Saldo += valor;
    }
}