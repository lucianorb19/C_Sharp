using System.Net;

namespace ProductClientHub.Exceptions.ExceptionBase
{
    public class NotFoundException : ProductClientHubException
    {
        public NotFoundException(string errorMessage) : base(errorMessage){}

        //MÉTODO RETORNA O ATRIBUTO Message QUE VEM DA CLASSE MÃE
        public override List<string> GetErrors() => [Message];

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
