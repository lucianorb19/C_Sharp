using BarberShop.Communication.Requests;
using BarberShop.Communication.Responses;

namespace BarberShop.Application.UseCases.Billings.Register;
public interface IRegisterBillingUseCase
{
    Task<ResponseShortBillingJson> Execute(RequestBillingJson request);
}
