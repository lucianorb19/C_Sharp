using BarberShop.Communication.Requests;
using BarberShop.Communication.Responses;

namespace BarberShop.Application.UseCases.Billings.Register;
public interface IRegisterBillingUseCase
{
    Task<ResponseRegisteredBillingJson> Execute(RequestBillingJson request);
}
