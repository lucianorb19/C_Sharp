using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Communication.Request;
using PrimeiraAPI.Communication.Response;
using PrimeiraAPI.UseCases.Authors;

namespace PrimeiraAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    //POST
    [HttpPost]
    [ProducesResponseType(typeof(ResponseAuthorJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status500InternalServerError)]
    public IActionResult Register([FromBody] RequestAuthorJson request)
    {
        var useCase = new RegisterAuthorUseCase();
        var response = useCase.Execute(request);
        return Created(string.Empty, response);
    }


    //READALL
    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllAuthorsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]//CONSULTA COM RESULTADO VAZIO
    public IActionResult GetAll()
    {
        var useCase = new GetAllAuthorsUseCase();
        var response = useCase.Execute();

        if (response.Authors.Count == 0) return NoContent();
        return Ok(response);
    }



    //READBYID
    //PUT
    //DELETE
}
