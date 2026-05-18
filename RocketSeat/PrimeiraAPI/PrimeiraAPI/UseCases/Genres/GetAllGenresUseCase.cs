using PrimeiraAPI.Communication.Response;
using PrimeiraAPI.Infraestructure;

namespace PrimeiraAPI.UseCases.Genres;

public class GetAllGenresUseCase
{
    public ResponseAllGenresJson Execute()
    {
        var dbContext = new PrimeiraAPIDbContext();
        var genres = dbContext.Genres.ToList();
        return new ResponseAllGenresJson
        {
            Genres = genres.Select(genre => new ResponseGenreJson
            {
                Id = genre.Id,
                Name = genre.Name,
            }).ToList(),
        };

    }
}
