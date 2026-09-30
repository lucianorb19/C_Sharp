using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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

    public async Task<List<Expense>> GetAll(User user)
    {
        //AsNoTracking() - MELHORA A PERFORMANCE DA CONSULTA
        //AO NÃO UTILIZAR O LOG DE REGISTRO DAS MUDANÇAS NA BD
        //USAR APENAS EM OPERAÇÃO QUE NÃO PODEM MUDAR NADA NA BD
        return await _dbContext.Expenses.AsNoTracking()
                                        .Where(expense => expense.UserId == user.Id)
                                        .ToListAsync();
    }

    //DOIS MÉTODOS GetById COM ASSINATURAS SIMILARES,DIFERENTECIADOS POR 
    //IExpensesReadOnlyRepository. E
    //IExpensesUpateOnlyRepository.
    async Task<Expense?> IExpensesReadOnlyRepository.GetById(User user,long id)
    {
        return await GetFullExpense()
            .AsNoTracking()
            .FirstOrDefaultAsync(expense => expense.Id == id && expense.UserId == user.Id);
    }

    async Task<Expense?> IExpensesUpateOnlyRepository.GetById(User user,long id)
    {
        return await GetFullExpense()
            .FirstOrDefaultAsync(expense => expense.Id == id && expense.UserId == user.Id);
    }

    public async Task Delete(long id)
    {
        //var result = await _dbContext.Expenses.FirstAsync(expense => expense.Id == id);
        var result = await _dbContext.Expenses.FindAsync(id);
        _dbContext.Expenses.Remove(result!);
    }

    public void Update(Expense expense)
    {
        _dbContext.Expenses.Update(expense);
    }

    public async Task<List<Expense>> FilterByMonth(User user,DateOnly date)
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
            Where(expense => expense.UserId == user.Id && 
                  expense.Date >= startDate && expense.Date <= endDate).
            OrderBy(expense => expense.Date).
            ThenBy(expense => expense.Title).
            ToListAsync();
    }


    //FUNÇÕES AUXILIARES
    private IIncludableQueryable<Expense, ICollection<Tag>> GetFullExpense()
    {
        return _dbContext.Expenses
            .Include(expense => expense.Tags);
    }
}
