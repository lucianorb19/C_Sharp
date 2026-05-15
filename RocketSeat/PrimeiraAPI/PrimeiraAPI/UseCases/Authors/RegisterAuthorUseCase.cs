using PrimeiraAPI.Communication.Request;
using PrimeiraAPI.Communication.Response;
using PrimeiraAPI.Entities;
using PrimeiraAPI.Exceptions.ExceptionBase;
using PrimeiraAPI.Infraestructure;
using PrimeiraAPI.UseCases.SharedValidator;

namespace PrimeiraAPI.UseCases.Authors;

public class RegisterAuthorUseCase
{
    public ResponseAuthorJson Execute(RequestAuthorJson request)
    {
        Validate(request);
        var dbContext = new PrimeiraAPIDbContext();
        var entity = new Author
        {
            Name = request.Name,
        };

        dbContext.Authors.Add(entity);
        dbContext.SaveChanges();

        return new ResponseAuthorJson
        {
            Id = entity.Id,
            Name = request.Name,
        };

    }

    private void Validate(RequestAuthorJson request)
    {
        var validator = new RequestAuthorValidator();
        var result = validator.Validate(request);
        if(result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
}
