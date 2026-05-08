using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Delete;
using ProductClientHub.API.UseCases.Clients.GetAll;
using ProductClientHub.API.UseCases.Clients.GetById;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.Update;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        //A RESPOSTA PRODUZIDA PELO MÉTODO PODE SER DO TIPO ResponseClientJson COM CÓDIGO HTTP 201
        //COLOCANDO ESSE ATRIBUTO, É MOSTRADO ISSO NA DOCUMENTAÇÃO SWAGGER
        [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]

        //A RESPOSTA DO TIPO ResponseErrorMessageJson COM CÓDIGO HTTP 400
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            var useCase = new RegisterClientUseCase();
            var response = useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        //OPERAÇÃO DE ATUALIZAÇÃO EFETUADA, NÃO DAMOS NENHUMA INFORMAÇÃO NO RETORNO
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //DADOS DA REQUEST NÃO VALIDADOS
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        //ID PASSADO COMO PARÂMETRO NÃO ENCONTRADO
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] Guid id,
                                    [FromBody] RequestClientJson request)
        {
            var useCase = new UpdateClientUseCase();
            useCase.Execute(id, request);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]//CONSULTA COM RESULTADO VAZIO
        public IActionResult GetAll()
        {
            var useCase = new GetAllClientsUseCase();
            var response = useCase.Execute();

            if(response.Clients.Count == 0) return NoContent();
            return Ok(response);
        }

        //[HttpGet("by-id")]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var useCase = new GetClientByIdUseCase();
            var response = useCase.Execute(id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteClientUseCase();
            useCase.Execute(id);
            return NoContent();
        }

    }
}
