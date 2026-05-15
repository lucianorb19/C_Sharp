namespace PrimeiraAPI.Entities;

public class Author : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public List<Book> Livros { get; set; } = [];
}
