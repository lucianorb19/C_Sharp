using PrimeiraAPI.Exceptions.ExceptionBase;
using PrimeiraAPI.Infraestructure;

namespace PrimeiraAPI.UseCases.Authors;

public class DeleteAuthorUseCase
{
    public void Execute(Guid id)
    {
        var dbContext = new PrimeiraAPIDbContext();
        var entity = dbContext.Authors.FirstOrDefault(author => author.Id == id);
        if (entity is null) throw new NotFoundException("Author não encontrado.");
        dbContext.Authors.Remove(entity);
        dbContext.SaveChanges();
    }
}
