using PrimeiraAPI.Communication.Request;
using PrimeiraAPI.Communication.Response;
using PrimeiraAPI.Entities;
using PrimeiraAPI.Exceptions.ExceptionBase;
using PrimeiraAPI.Infraestructure;
using PrimeiraAPI.UseCases.SharedValidator;

namespace PrimeiraAPI.UseCases.Genres;

public class RegisterGenreUseCase
{
    public ResponseGenreJson Execute(RequestGenreJson request)
    {
        Validate(request);
        var dbContext = new PrimeiraAPIDbContext();
        var entity = new Genre
        {
            Name = request.Name,
        };

        dbContext.Genres.Add(entity);
        dbContext.SaveChanges();

        return new ResponseGenreJson
        {
            Id = entity.Id,
            Name = request.Name,
        };
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
