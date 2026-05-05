
namespace _4POO;

internal class Projeto
{
    public string Nome { get;}
    List<string> tarefas;
    public int QuantidadeTarefas { get { return tarefas.Count; }}

    public Projeto(string nome)
    {
        Nome = nome;
        tarefas = new List<string>();
    }

    public void AdicionarTarefa(string tarefa)
    {
        tarefas.Add(tarefa);
    }

    public void ExibirTarefas()
    {
        Console.WriteLine($"Projeto: {Nome}");
        Console.WriteLine("Tarefas");
        foreach(string tarefa in tarefas)
        {
            Console.WriteLine($"- {tarefa}");
        }
        Console.WriteLine($"Total: {QuantidadeTarefas} taferas");
    }
}
