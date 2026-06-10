using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories;


//IMPLEMENTA AS FUNÇÕES RESPONSÁVEIS PELAS OPERAÇÕES NA BD
internal class ExpensesRepository : IExpensesRepository
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
}
