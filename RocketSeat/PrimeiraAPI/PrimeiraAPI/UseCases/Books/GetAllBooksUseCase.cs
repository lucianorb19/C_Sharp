using PrimeiraAPI.Communication.Response;
using PrimeiraAPI.Infraestructure;

namespace PrimeiraAPI.UseCases.Books;

public class GetAllBooksUseCase
{
    public ResponseAllBooksJson Execute()
    {
        var dbContext = new PrimeiraAPIDbContext();
        var books = dbContext.Books.ToList();

        return new ResponseAllBooksJson
        {
            Books = books.Select(book => new ResponseBookJson
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                Stock = book.Stock,
                Author = buscaAuthor(book.AuthorId),
                Genre = buscaGenre(book.GenreId)
            }).ToList()
        };
    }

    private string buscaAuthor(Guid authorId)
    {
        //VALIDAÇÃO SE AUTOR DESSE LIVRO EXISTE NA BASE
        var dbContext = new PrimeiraAPIDbContext();
        var authorExist = dbContext.Authors.Any(author => author.Id == authorId);
        if (authorExist == false) return string.Empty;
        var author = dbContext.Authors.FirstOrDefault(author => author.Id == authorId);
        return author.Name;
    }

    private string buscaGenre(Guid genreId)
    {
        //VALIDAÇÃO SE GÊNERO DESSE LIVRO EXISTE NA BASE
        var dbContext = new PrimeiraAPIDbContext();
        var genreExist = dbContext.Genres.Any(genre => genre.Id == genreId);
        if (genreExist == false) return string.Empty;
        var genre = dbContext.Genres.FirstOrDefault(genre => genre.Id == genreId);
        return genre.Name;
    }
}
