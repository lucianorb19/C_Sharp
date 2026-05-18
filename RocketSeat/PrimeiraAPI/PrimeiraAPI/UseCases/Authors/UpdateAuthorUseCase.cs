using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Communication.Request;
using PrimeiraAPI.Exceptions.ExceptionBase;
using PrimeiraAPI.Infraestructure;
using PrimeiraAPI.UseCases.SharedValidator;

namespace PrimeiraAPI.UseCases.Authors;

public class UpdateAuthorUseCase
{
    public void Execute(Guid id, RequestAuthorJson request)
    {
        Validate(request);
        var dbContext = new PrimeiraAPIDbContext();
        var entity = dbContext.Authors.FirstOrDefault(author => author.Id == id);
        if (entity is null)
        {
            throw new NotFoundException("Author não encontrado.");
        }

        entity.Name = request.Name;
        dbContext.Authors.Update(entity);
        dbContext.SaveChanges();
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
