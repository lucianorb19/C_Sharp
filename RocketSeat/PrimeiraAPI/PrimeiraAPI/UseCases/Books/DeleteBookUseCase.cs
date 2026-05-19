using PrimeiraAPI.Exceptions.ExceptionBase;
using PrimeiraAPI.Infraestructure;

namespace PrimeiraAPI.UseCases.Books;

public class DeleteBookUseCase
{
    public void Execute(Guid id)
    {
        var dbContext = new PrimeiraAPIDbContext();
        var entity = dbContext.Books.FirstOrDefault(book => book.Id == id);
        if (entity is null) throw new NotFoundException("Livro não encontrado.");
        dbContext.Books.Remove(entity);
        dbContext.SaveChanges();
    }
}
