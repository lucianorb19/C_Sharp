using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Repositories.Billings;
public interface IBillingsReadOnlyRepository
{
    Task<List<Billing>> GetAll();
}
