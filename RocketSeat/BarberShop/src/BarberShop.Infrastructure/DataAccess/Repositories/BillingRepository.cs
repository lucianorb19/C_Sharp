using BarberShop.Domain.Entities;
using BarberShop.Domain.Repositories.Billings;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infrastructure.DataAccess.Repositories;
internal class BillingRepository : IBillingsWriteOnlyRepository,
                                   IBillingsReadOnlyRepository,
                                   IBillingsUpateOnlyRepository
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


    //DOIS MÉTODOS GetById COM ASSINATURAS SIMILARES,DIFERENTECIADOS POR 
    //IBillingsReadOnlyRepository. E
    //IBillingsUpateOnlyRepository.
    async Task<Billing?> IBillingsReadOnlyRepository.GetById(Guid id)
    {
        return await _dbContext.Billings.AsNoTracking()
                                        .FirstOrDefaultAsync(billing => billing.Id == id);
    }

    async Task<Billing?> IBillingsUpateOnlyRepository.GetById(Guid id)
    {
        return await _dbContext.Billings.FirstOrDefaultAsync(billing => billing.Id == id);
    }


    public void Update(Billing billing)
    {
        _dbContext.Billings.Update(billing);
    }

    public async Task<List<Billing>> FilterByMonth(DateOnly date)
    {
        //DIA INICIAL DO MÊS
        var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

        //DIA FINAL DO MÊS
        var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);
        var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth,
                                   hour: 23, minute: 59, second: 59);

        return await _dbContext
            .Billings
            .AsNoTracking()
            .Where(billing => billing.Date >= startDate && billing.Date <= endDate)
            .OrderBy(billing => billing.Date)
            .ThenBy(billing => billing.Amount)
            .ToListAsync();
    }

    public async Task<List<Billing>> FilterByWeek()
    {
        var today = DateTime.Today;

        var weekStart = today.AddDays(-(int)today.DayOfWeek + (today.DayOfWeek == DayOfWeek.Sunday ? -6 : 1));
        var weekEnd = weekStart.AddDays(7);

        return await _dbContext
            .Billings
            .AsNoTracking()
            .Where(billing => billing.Date >= weekStart && billing.Date <= weekEnd)
            .OrderBy(billing => billing.Date)
            .ThenBy(billing => billing.Amount)
            .ToListAsync();

        /*
         var inicioSemana = hoje.AddDays(-(int)hoje.DayOfWeek + (hoje.DayOfWeek == DayOfWeek.Sunday ? -6 : 1));

// Domingo da semana atual
var fimSemana = inicioSemana.AddDays(7);

var resultado = dados.Where(x =>
    x.DataFaturamento >= inicioSemana &&
    x.DataFaturamento < fimSemana);
         */
    }
}
