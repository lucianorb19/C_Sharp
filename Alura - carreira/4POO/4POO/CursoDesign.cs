
namespace _4POO
{
    internal class CursoDesign : ICurso
    {
        public Instrutor Instrutor { get;}
        public string Titulo { get;}

        public CursoDesign(Instrutor instrutor, string titulo)
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
            Console.WriteLine($"Validando conteúdo do curso de design: {Titulo}");
        }
    }
}
