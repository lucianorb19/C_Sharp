
namespace _4POO;

internal class Curso
{
    public string Nome { get; }
    public int VagasTotais { get; }
    private List<Estudante2> matriculas;
    public int VagasDisponiveis { get { return VagasTotais - matriculas.Count; } }   

    public Curso(string nome, int vagasTotais)
    {
        Nome = nome;
        VagasTotais = vagasTotais;
        matriculas = new List<Estudante2>();
    }

    public bool Matricular(Estudante2 estudante)
    {
        if (matriculas.Count < VagasTotais)
        {
            matriculas.Add(estudante);
            Console.WriteLine($"Estudante {estudante.Nome} matriculado com sucesso.");
            return true;
        }
        else
        {
            Console.WriteLine($"Erro. Não há vagas disponíveis para este curso.");
            return false;
        }
    }

    public void ListarMatriculados()
    {
        Console.WriteLine($"Estudante matriculados em {Nome}");
        foreach(Estudante2 estudante in matriculas)
        {
            Console.WriteLine($"- {estudante.Nome}");
        }
        Console.WriteLine($"Vagas dispóníveis: {VagasDisponiveis}");
    }
}
