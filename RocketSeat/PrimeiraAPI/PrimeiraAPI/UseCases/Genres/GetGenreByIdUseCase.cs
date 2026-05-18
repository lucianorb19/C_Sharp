using PrimeiraAPI.Communication.Response;
using PrimeiraAPI.Exceptions.ExceptionBase;
using PrimeiraAPI.Infraestructure;

namespace PrimeiraAPI.UseCases.Genres;

public class GetGenreByIdUseCase
{
    public ResponseGenreJson Execute(Guid id)
    {
        var dbContext = new PrimeiraAPIDbContext();
        var entity = dbContext.Genres.FirstOrDefault(genre => genre.Id == id);
        if (entity is null) throw new NotFoundException("Gênero não encontrado.");
        return new ResponseGenreJson
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
