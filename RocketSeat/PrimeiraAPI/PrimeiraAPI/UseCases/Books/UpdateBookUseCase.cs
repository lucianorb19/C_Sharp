using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Communication.Request;
using PrimeiraAPI.Exceptions.ExceptionBase;
using PrimeiraAPI.Infraestructure;
using PrimeiraAPI.UseCases.SharedValidator;

namespace PrimeiraAPI.UseCases.Books;

public class UpdateBookUseCase
{
    public void Execute(Guid bookId, RequestBookJson request)
    {
        Validate(request);
        var dbContext = new PrimeiraAPIDbContext();
        var entity = dbContext.Books.FirstOrDefault(book => book.Id == bookId);
        if (entity is null)
        {
            throw new NotFoundException("Livro não encontrado.");
        }
        entity.Title = request.Title;
        entity.Price = request.Price;
        entity.Stock = request.Stock;
        dbContext.Books.Update(entity);
        dbContext.SaveChanges();
    }

    private void Validate(RequestBookJson request)
    {
        var validator = new RequestBookValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }


}
