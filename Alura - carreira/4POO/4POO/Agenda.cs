
namespace _4POO;

internal class Agenda
{
    public string Proprietario { get;}
    private readonly List<Contato> contatos;
    public int QuantidadeContatos { get {return contatos.Count;} }

    public Agenda(string proprietario)
    {
        Proprietario = proprietario;
        contatos = new List<Contato>();
    }

    public bool AdicionarContato(Contato contato)
    {
        if(contatos.Any( c => c.Nome == contato.Nome))
        {
            Console.WriteLine("Contato com esse nome já está na agenda.");
            return false;
        }
        contatos.Add(contato);
        return true;
    }

    public void ListarContatos()
    {
        Console.WriteLine($"Agenda de {Proprietario}\nContatos");
        foreach(Contato contato in contatos)
        {
            Console.WriteLine($"- {contato.Nome} | {contato.Telefone}");
        }
        Console.WriteLine($"Total de contatos: {QuantidadeContatos}");
    }
}
