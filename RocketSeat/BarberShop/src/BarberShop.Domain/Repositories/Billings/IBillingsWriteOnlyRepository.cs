using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Repositories.Billings;
public interface IBillingsWriteOnlyRepository
{
    Task Add(Billing billing);
    Task<bool> Delete(Guid id);
}
