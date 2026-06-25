using BarberShop.Communication.Requests;

namespace BarberShop.Application.UseCases.Billings.Update;
public interface IUpdateBillingUseCase
{
    Task Execute(Guid id, RequestUpdateBillingJson request);
}
