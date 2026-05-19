using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Communication.Response;
using PrimeiraAPI.Exceptions.ExceptionBase;
using PrimeiraAPI.Infraestructure;

namespace PrimeiraAPI.UseCases.Books;

public class GetBookByIdUseCase
{
    public ResponseBookJson Execute(Guid bookId)
    {
        var dbContext = new PrimeiraAPIDbContext();
        var entity = dbContext
            .Books
            .Include(book => book.Author)
            .Include(book => book.Genre)
            .FirstOrDefault(book => book.Id == bookId);
        if (entity is null) throw new NotFoundException("Livro não encontrado.");
        return new ResponseBookJson
        {
            Id = entity.Id,
            Title = entity.Title,
            Price = entity.Price,
            Genre = entity.Genre.Name,
            Stock = entity.Stock,
            Author = entity.Author.Name
        };

    }
}
