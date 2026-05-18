using System.Net;

namespace PrimeiraAPI.Exceptions.ExceptionBase;
public class NotFoundException : PrimeiraAPIException
{

    public NotFoundException(string errorMessage) : base(errorMessage) { }

    public override List<string> GetErrors() => [Message];

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;

}
