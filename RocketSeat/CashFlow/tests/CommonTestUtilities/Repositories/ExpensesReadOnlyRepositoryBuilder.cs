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

    public IExpensesReadOnlyRepository Build() => _repository.Object;

}
