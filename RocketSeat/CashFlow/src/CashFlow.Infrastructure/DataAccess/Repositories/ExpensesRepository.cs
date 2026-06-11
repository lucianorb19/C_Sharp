using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Expense>> GetAll()
    {
        //AsNoTracking() - MELHORA A PERFORMANCE DA CONSULTA
        //AO NÃO UTILIZAR O LOG DE REGISTRO DAS MUDANÇAS NA BD
        //USAR APENAS EM OPERAÇÃO QUE NÃO PODEM MUDAR NADA NA BD
        return await _dbContext.Expenses.AsNoTracking().ToListAsync();
    }

    public async Task<Expense?> GetById(long id)
    {
        return await _dbContext.Expenses.AsNoTracking()
                                        .FirstOrDefaultAsync(expense => expense.Id == id);
    }
}
