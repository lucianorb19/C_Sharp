

namespace _4POO;

internal class Pergaminho : ItemDigital
{
    internal string conteudoTextual;

    public Pergaminho(string titulo, string conteudo)
        : base(titulo)
    {
        this.conteudoTextual = conteudo;
    }

    public void MostrarDetalhes()
    {
        Console.WriteLine($"Detalhes do pergaminho\nTítulo: {titulo}\nDescrição: {conteudoTextual}\n");
    }
}
