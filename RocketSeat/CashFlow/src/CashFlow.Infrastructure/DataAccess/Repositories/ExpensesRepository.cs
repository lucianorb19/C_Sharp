using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;


//IMPLEMENTA AS FUNÇÕES RESPONSÁVEIS PELAS OPERAÇÕES NA BD
internal class ExpensesRepository : IExpensesReadOnlyRepository, 
                                    IExpensesWriteOnlyRepository, 
                                    IExpensesUpateOnlyRepository
{

    private readonly CashFlowDbContext _dbContext;

    public ExpensesRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Expense expense)
    {
        //var dbContext = new CashFlowDbContext();
        await _dbContext.Expenses.AddAsync(expense);
        //_dbContext.SaveChanges(); FEITO EM UnityOfWork
    }

    public async Task<List<Expense>> GetAll()
    {
        //AsNoTracking() - MELHORA A PERFORMANCE DA CONSULTA
        //AO NÃO UTILIZAR O LOG DE REGISTRO DAS MUDANÇAS NA BD
        //USAR APENAS EM OPERAÇÃO QUE NÃO PODEM MUDAR NADA NA BD
        return await _dbContext.Expenses.AsNoTracking().ToListAsync();
    }

    //DOIS MÉTODOS GetById COM ASSINATURAS SIMILARES,DIFERENTECIADOS POR 
    //IExpensesReadOnlyRepository. E
    //IExpensesUpateOnlyRepository.
    async Task<Expense?> IExpensesReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Expenses.AsNoTracking()
                                        .FirstOrDefaultAsync(expense => expense.Id == id);
    }

    async Task<Expense?> IExpensesUpateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);
        if (result is null) return false;
        _dbContext.Expenses.Remove(result);
        return true;
    }

    public void Update(Expense expense)
    {
        _dbContext.Expenses.Update(expense);
    }

    public async Task<List<Expense>> FilterByMonth(DateOnly date)
    {
        //DIA INICIAL DO MÊS
        //.Date AO FINAL DEFINE O HORÁRIO PARA MEIA NOITE
        var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

        //DIA FINAL DO MÊS
        var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);
        var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth,
                                   hour: 23, minute:59, second:59);

        return await _dbContext.
            Expenses.
            AsNoTracking().
            Where(expense => expense.Date >= startDate && expense.Date <= endDate).
            OrderBy(expense => expense.Date).
            ThenBy(expense => expense.Title).
            ToListAsync();
    }
}
