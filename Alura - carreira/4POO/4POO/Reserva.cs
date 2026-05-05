
namespace _4POO;

internal class Reserva
{
    private int diarias;
    public Hospede Hospede { get;}
    public Quarto Quarto { get;}
    public double ValorTotal { get { return diarias * Quarto.ValorDiaria; } }

    public Reserva(Hospede hospede, Quarto quarto, int diarias)
    {
        Hospede = hospede;
        Quarto = quarto;
        this.diarias = diarias;
    }

    public void ExibirRerva()
    {
        Console.WriteLine($"Reserva para {Hospede.Nome}\nQuarto: {Quarto.Numero}\nValor total: {ValorTotal.ToString("c")}");
    }
}
