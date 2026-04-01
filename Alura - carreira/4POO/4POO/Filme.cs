class Filme
{
    public string Titulo { get;}
    public int ClassificacaoEtaria { get;}

    public Filme(string titulo, int classificacaoEtaria )
    {
        Titulo = titulo;
        ClassificacaoEtaria = classificacaoEtaria;
    }

    public bool PodeAssistir(int idadeUsuario)
    {
        return idadeUsuario >= ClassificacaoEtaria ? true : false;
    }

    public void ExibirResultado(int idadeUsuario)
    {
        if (PodeAssistir(idadeUsuario))
        {
            Console.WriteLine($"Usuário com {idadeUsuario} anos pode assistir ao filme {Titulo}.");
        }
        else
        {
            Console.WriteLine($"Usuário com {idadeUsuario} anos não pode assistir ao filme {Titulo}.");
        }
    }
}