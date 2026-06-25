using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Repositories.Billings;
public interface IBillingsUpateOnlyRepository
{
    void Update(Billing billing);
    Task<Billing?> GetById(Guid id);
}
