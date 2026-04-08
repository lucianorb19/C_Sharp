namespace _4POO.Alura;

class Filme2
{

    public string Titulo { get; set; }
    public int Duracao { get; set; }
    public List<Artista> Elenco { get; set; } = new List<Artista>();


    public Filme2(string titulo, int duracao)
    {
        Titulo = titulo;
        Duracao = duracao;
    }

    public void AdicionarArtista(Artista artistaAAdicionar)
    {
        bool artistaJaElecado = false;
        foreach(Artista ator in Elenco)
        {
            if(ator.Nome == artistaAAdicionar.Nome)
            {
                Console.WriteLine($"Artista {artistaAAdicionar.Nome} já elencado na obra {Titulo} : /\n");
                artistaJaElecado = true;
                break;
            }
        }

        if (!artistaJaElecado)
        {
            Elenco.Add(artistaAAdicionar);
            Console.WriteLine($"Ator {artistaAAdicionar.Nome} elencado em {Titulo}!\n");
            artistaAAdicionar.Filmes.Add(new(Titulo, Duracao));
        }
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Título: {Titulo}\nDuração: {Duracao} minutos");
        Console.WriteLine("Elenco:");
        foreach(Artista ator in Elenco)
        {
            Console.WriteLine($"- {ator.Nome}");
        }
        Console.WriteLine();
    }

}