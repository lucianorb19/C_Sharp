
using System.Net;

namespace BarberShop.Exception.ExceptionBase;
public class NotFoundException : BarberShopException
{

    public NotFoundException(string message) : base(message) {}

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        //ATRIBUTO Message VINDO DE Exception -> SystemException -> BarberShopException
        return [Message];
    }
}
