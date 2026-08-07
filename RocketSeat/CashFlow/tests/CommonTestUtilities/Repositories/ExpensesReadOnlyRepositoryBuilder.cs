using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Moq;

namespace CommonTestUtilities.Repositories;
public class ExpensesReadOnlyRepositoryBuilder
{
    private readonly Mock<IExpensesReadOnlyRepository> _repository;

    public ExpensesReadOnlyRepositoryBuilder()
    {
        _repository = new Mock<IExpensesReadOnlyRepository>();
    }

    //CONFIGURAÇÃO DO MOCK
    //return this - PERMITE USAR CHAMADA ENCADEADA
    public ExpensesReadOnlyRepositoryBuilder GetAll(User user, List<Expense> expenses)
    {
        _repository.Setup(respository => respository.GetAll(user)).ReturnsAsync(expenses);
        return this;
    }

    //CONFIGURAÇÃO DO MOCK
    public ExpensesReadOnlyRepositoryBuilder GetById(User user, Expense? expense)
    {
        if (expense is not null) 
            _repository.Setup(repository => repository.GetById(user, expense.Id)).ReturnsAsync(expense);
        return this;
    }

    public IExpensesReadOnlyRepository Build() => _repository.Object;

}
