namespace PrimeiraAPI.Entities;

public class Genre : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public List<Book> Livros { get; set; } = [];
}
