using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Communication.Request;
using PrimeiraAPI.Communication.Response;
using PrimeiraAPI.UseCases.Genres;

namespace PrimeiraAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ResponseGenreJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status500InternalServerError)]
    public IActionResult Register([FromBody] RequestGenreJson request)
    {
        var useCase = new RegisterGenreUseCase();
        var response = useCase.Execute(request);
        return Created(string.Empty, response);
    }


    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllGenresJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]//CONSULTA COM RESULTADO VAZIO
    public IActionResult GetAll()
    {
        var useCase = new GetAllGenresUseCase();
        var response = useCase.Execute();

        if (response.Genres.Count == 0) return NoContent();
        return Ok(response);
    }


    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseGenreJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var usecase = new GetGenreByIdUseCase();
        var response = usecase.Execute(id);
        return Ok(response);
    }


    //PUT
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid id,
                                [FromBody] RequestGenreJson request)
    {
        var useCase = new UpdateGenreUseCase();
        useCase.Execute(id, request);
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var useCase = new DeleteGenreUseCase();
        useCase.Execute(id);
        return NoContent();
    }

}
