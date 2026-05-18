using PrimeiraAPI.Communication.Request;
using PrimeiraAPI.Exceptions.ExceptionBase;
using PrimeiraAPI.Infraestructure;
using PrimeiraAPI.UseCases.SharedValidator;

namespace PrimeiraAPI.UseCases.Genres;

public class UpdateGenreUseCase
{

    public void Execute(Guid id, RequestGenreJson request)
    {
        Validate(request);
        var dbContext = new PrimeiraAPIDbContext();
        var entity = dbContext.Genres.FirstOrDefault(genre => genre.Id == id);
        if (entity is null)
        {
            throw new NotFoundException("Author não encontrado.");
        }

        entity.Name = request.Name;
        dbContext.Genres.Update(entity);
        dbContext.SaveChanges();
    }


    private void Validate(RequestGenreJson request)
    {
        var validator = new RequestGenreValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
}
