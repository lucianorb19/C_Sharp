using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Repositories.Billings;
public interface IBillingsReadOnlyRepository
{
    Task<List<Billing>> GetAll();
    Task<Billing?> GetById(Guid id);
    Task<List<Billing>> FilterByMonth(DateOnly date);
}
