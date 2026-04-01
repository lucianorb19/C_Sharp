class Retangulo
{

    public double Altura { get;}
    public double Largura { get;}

    public Retangulo(double altura, double largura)
    {
        Altura = altura;
        Largura = largura;
    }

    public double CalculaArea()
    {
        return Altura * Largura;
    }
}