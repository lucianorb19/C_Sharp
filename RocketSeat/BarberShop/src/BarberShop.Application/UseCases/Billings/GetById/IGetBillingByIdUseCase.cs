using BarberShop.Communication.Responses;

namespace BarberShop.Application.UseCases.Billings.GetById;
public interface IGetBillingByIdUseCase
{
    Task<ResponseBillingJson> Execute(Guid id);
}
