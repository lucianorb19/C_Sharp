using BarberShop.Domain.Entities;
using BarberShop.Domain.Repositories.Billings;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infrastructure.DataAccess.Repositories;
internal class BillingRepository : IBillingsWriteOnlyRepository,
                                   IBillingsReadOnlyRepository
{

    private readonly BarberShopDbContext _dbContext;

    public BillingRepository(BarberShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Billing billing)
    {
        await _dbContext.Billings.AddAsync(billing);
    }

    public async Task<bool> Delete(Guid id)
    {
        var result = await _dbContext.Billings.FirstOrDefaultAsync(billing => billing.Id == id);
        if (result is null) return false;
        _dbContext.Billings.Remove(result);
        return true;
    }

    public async Task<List<Billing>> GetAll()
    {
        return await _dbContext.Billings.AsNoTracking().ToListAsync();
    }

    public async Task<Billing?> GetById(Guid id)
    {
        return await _dbContext.Billings.AsNoTracking()
                                        .FirstOrDefaultAsync(billing => billing.Id == id);
    }
}
