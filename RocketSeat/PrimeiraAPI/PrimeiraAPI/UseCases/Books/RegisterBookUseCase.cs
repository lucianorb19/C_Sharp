using PrimeiraAPI.Communication.Request;
using PrimeiraAPI.Communication.Response;
using PrimeiraAPI.Entities;
using PrimeiraAPI.Exceptions.ExceptionBase;
using PrimeiraAPI.Infraestructure;
using PrimeiraAPI.UseCases.SharedValidator;

namespace PrimeiraAPI.UseCases.Books;

public class RegisterBookUseCase
{

    public ResponseBookJson Execute(Guid authorId, Guid genreId, RequestBookJson request)
    {
        var dbContext = new PrimeiraAPIDbContext();
        Validate(dbContext, authorId, genreId, request);

        var entity = new Book
        {
            Title = request.Title,
            Price = request.Price,
            Stock = request.Stock,
            AuthorId = authorId,
            GenreId = genreId,
        };

        dbContext.Books.Add(entity);
        dbContext.SaveChanges();
        return new ResponseBookJson
        {
            Id = entity.Id,
            Title = entity.Title,
            Price = entity.Price,
            Stock = entity.Stock,
            Author = entity.Author.Name,
            Genre = entity.Genre.Name
        };
    }


    private void Validate(PrimeiraAPIDbContext dbContext, Guid authorId, Guid genreId,
                          RequestBookJson request)
    {
        //VALIDAÇÃO SE AUTOR DESSE LIVRO EXISTE NA BASE
        var authorExist = dbContext.Authors.Any(author => author.Id == authorId);
        if (authorExist == false) throw new NotFoundException("Author não existe");

        //VALIDAÇÃO SE O GÊNERO DESSE LIVRO EXISTE NA BASE
        var genreExist = dbContext.Genres.Any(genre => genre.Id == genreId);
        if (genreExist == false) throw new NotFoundException("Gênero não existe");

        //VALIDAÇÃO DE NÃO DUPLICIDADE
        //LIVRO X ASSOCIADO AO AUTOR Y NÃO PODE EXISTIR DUPLICADO
        bool duplicidade = dbContext.Books
                                    .GroupBy(book => new { book.Title, book.Author.Name })
                                    .Any(TituloENomeAutor => TituloENomeAutor.Count() > 1);
        if (duplicidade) throw new ErrorOnValidationException(["Já existe um livro com esse autor cadastrado."]);
        

        //VALIDAÇÃO DOS CAMPOS DO LIVRO
        var validator = new RequestBookValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }

}
