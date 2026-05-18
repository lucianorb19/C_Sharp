using PrimeiraAPI.Communication.Response;
using PrimeiraAPI.Exceptions.ExceptionBase;
using PrimeiraAPI.Infraestructure;

namespace PrimeiraAPI.UseCases.Authors;

public class GetAuthorByIdUseCase
{
    public ResponseAuthorJson Execute(Guid id)
    {
        var dbContext = new PrimeiraAPIDbContext();
        var entity = dbContext.Authors.FirstOrDefault(author => author.Id == id);
        if(entity is null) throw new NotFoundException("Author não encontrado.");
        return new ResponseAuthorJson
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
