
namespace _4POO;

internal class Quarto
{
    public int Numero { get;}

    private double valorDiaria;
    public double ValorDiaria
    {
        get { return valorDiaria; }
        set {
            if (value > 0) valorDiaria = value;
            else Console.WriteLine("Erro. Valor da diária deve ser maior do que zero");
        }
    }

    public Quarto(int numero)
    {
        Numero = numero;
    }
}
