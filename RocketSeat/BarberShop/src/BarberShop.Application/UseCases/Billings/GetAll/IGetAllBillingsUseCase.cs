using BarberShop.Communication.Responses;

namespace BarberShop.Application.UseCases.Billings.GetAll;
public interface IGetAllBillingsUseCase
{
    Task<ResponseBillingsJson> Execute();
}
