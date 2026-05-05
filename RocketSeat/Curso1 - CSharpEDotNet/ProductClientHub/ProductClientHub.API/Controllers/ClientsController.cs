using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        //A RESPOSTA PRODUZIDA PELO MÉTODO PODE SER DO TIPO ResponseClientJson COM CÓDIGO HTTP 201
        //COLOCANDO ESSA LINHA, APARECE ISSO NA DOCUMENTAÇÃO SWEAGGER
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]

        //A RESPOSTA DO TIPO ResponseErrorMessageJson COM CÓDIGO HTTP 400
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            try
            {
                var useCase = new RegisterClientUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }
            //SE FOR EXCEÇÃO DE ARGUMENTO, RETORNO EXCEÇÃO BadRequest
            catch(ProductClientHubException ex)
            {
                var errors = ex.GetErrors();
                //BadRequest TEM COMO RETORNO CÓDIGO HTTP 400
                return BadRequest(new ResponseErrorMessagesJson(errors));
            }
            //SE NÃO SEI QUAL O ERRO, JOGO NUM CATH GENÉRICO COM CÓDIGO 500
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new ResponseErrorMessagesJson("ERRO DESCONHECIDO"));
            }
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        //[HttpGet("by-id")]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

    }
}
