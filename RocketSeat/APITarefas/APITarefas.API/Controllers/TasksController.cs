using APITarefas.Communication.Requests;
using APITarefas.Communication.Responses;
using APITarefas.Services.UseCases.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APITarefas.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    //CREAT
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterTaskJson),StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Register([FromBody] RequestTaskJson request)
    {
        var useCase = new RegisterTaskUseCase();
        var response = useCase.Execute(request);
        return Created(string.Empty,response);
    }

    //READ
    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTasksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTasksUseCase();
        var response = useCase.Execute();
        if (response.Tasks.Any())
        {
            return Ok(response);
        }
        return NoContent();
    }


    //READBYID
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute]Guid id)
    {
        var useCase = new GetTaskByIdUseCase();
        var response = useCase.Execute(id);
        //if (response is null) return NotFound();
        return Ok(response);
    }


    //UPDATE
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] Guid id, [FromBody]RequestTaskJson request)
    {
        new UpdateTaskUseCase().Execute(id, request);
        return NoContent();
    }


    //DELETE
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        new DeleteTaskUseCase().Execute(id);
        return NoContent();
    }
}
