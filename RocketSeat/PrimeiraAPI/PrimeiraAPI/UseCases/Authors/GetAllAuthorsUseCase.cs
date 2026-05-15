using PrimeiraAPI.Communication.Response;
using PrimeiraAPI.Infraestructure;

namespace PrimeiraAPI.UseCases.Authors;

public class GetAllAuthorsUseCase
{

    public ResponseAllAuthorsJson Execute()
    {
        var dbContext = new PrimeiraAPIDbContext();
        var authors = dbContext.Authors.ToList();
        return new ResponseAllAuthorsJson
        {
            Authors = authors.Select(author => new ResponseAuthorJson
            {
                Id = author.Id,
                Name = author.Name,
            }).ToList(),
        };

    }
}
