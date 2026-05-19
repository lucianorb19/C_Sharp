using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Communication.Request;
using PrimeiraAPI.Communication.Response;
using PrimeiraAPI.UseCases.Authors;
using PrimeiraAPI.UseCases.Books;

namespace PrimeiraAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    [HttpPost]
    [Route("{authorId}/{genreId}")]
    [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status500InternalServerError)]
    public IActionResult Register([FromRoute] Guid authorId,
                                  [FromRoute] Guid genreId,
                                  [FromBody] RequestBookJson request)
    {
        var useCase = new RegisterBookUseCase();
        var response = useCase.Execute(authorId,genreId,request);
        return Created(string.Empty, response);
    }

    //READALL
    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllBooksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllBooksUseCase();
        var response = useCase.Execute();

        if (response.Books.Count == 0) return NoContent();
        return Ok(response);
    }

    //READBYID
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetBookByIdUseCase();
        var response = useCase.Execute(id);
        return Ok(response);
    }

    //PUT
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid id,
                                [FromBody] RequestBookJson request)
    {
        var useCase = new UpdateBookUseCase();
        useCase.Execute(id, request);
        return NoContent();
    }


    //DELETE
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var useCase = new DeleteBookUseCase();
        useCase.Execute(id);
        return NoContent();
    }


}
