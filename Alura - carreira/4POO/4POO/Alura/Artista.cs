namespace _4POO.Alura;


class Artista
{
   
    public string Nome { get; set; }
    public int Idade { get; set; }
    public List<Filme2> Filmes { get; set; } = new List<Filme2>();

    public Artista(string nome, int idade)
    {
        Nome = nome.ToUpper();
        Idade = idade;
    }

    public void ExibirFilmografia()
    {
        Console.WriteLine($"Filmografia {Nome}: ");
        foreach(Filme2 filme in Filmes)
        {
            Console.WriteLine($"- {filme.Titulo}");
        }
    }

}