namespace PrimeiraAPI.Entities;

public class Book : EntityBase
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    //REFERÊNCIAS A AUTOR E GÊNERO
    public Guid AuthorId { get; set; }
    public Guid GenreId { get; set; }

    //ACESSO A AUTORES PELA INSTÂNCIA DE LIVRO
    public Author Author { get; set; } = default!;
    public Genre Genre { get; set; } = default!;

}
