
namespace _4POO;

internal class Avaliacao
{
    public string Aluno { get; set; }
    public double Nota { get; private set; }

    public Avaliacao(string aluno)
    {
        Aluno = aluno;
    }

    public void AtribuirNota(double nota)
    {
        if(nota >= 0 && nota <= 10)
        {
            Nota = nota;
            Console.WriteLine($"Aluno: {Aluno}\nNota atribuída: {Nota}");
        }
        else
        {
            Console.WriteLine("Erro: nota deve estar entre 0 e 10");
        }
    }
}
