using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionBase;

namespace ProductClientHub.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //JÁ FAZ A VALIDAÇÃO ATRIBUINDO POR MEIO DE CASTING O VALOR DE 
            //context.Exception PARA ProductClientHubException productClientHubException
            if (context.Exception is ProductClientHubException productClientHubException)
            {
                //PARA CADA EXCEÇÃO, É NECESSÁRIO DEFINIR O StatusCode e Result
                context.HttpContext.Response.StatusCode = (int)productClientHubException.GetHttpStatusCode();
                context.Result = new ObjectResult(new ResponseErrorMessagesJson(productClientHubException.GetErrors()));
            }
            else
            {
                TrowUnknowError(context);
            }
            

        }


        private void TrowUnknowError(ExceptionContext context)
        {
            //PARA CADA EXCEÇÃO, É NECESSÁRIO DEFINIR O StatusCode e Result
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessagesJson("ERRO DESCONHECIDO"));
        }


    }



}
