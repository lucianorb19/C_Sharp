
namespace _4POO;

internal class CursoProgramacao : ICurso
{
    public Instrutor Instrutor { get;}
    public string Titulo { get;}

    public CursoProgramacao(Instrutor instrutor, string titulo)
    {
        Instrutor = instrutor;
        Titulo = titulo;
    }

    public void PublicarCurso()
    {
        Console.WriteLine($"Curso publicado com sucesso: {Titulo} - " +
                          $"Instrutora: {Instrutor.Nome} ({Instrutor.Especialidade})\n");
    }

    public void ValidarConteudo()
    {
        Console.WriteLine($"Validando conteúdo do curso de programação: {Titulo}");
    }
}
