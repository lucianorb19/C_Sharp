
namespace _4POO;

internal class Veiculo
{
    private double velocidadeAtual;
    
    public string Placa { get; set; }
    public double VelocidadeAtual {get{return velocidadeAtual;}}

    public Veiculo(string placa)
    {
        Placa = placa;
    }

    public void AtualizarVelocidade(double novaVelocidade)
    {
        this.velocidadeAtual = novaVelocidade;
    }


}
