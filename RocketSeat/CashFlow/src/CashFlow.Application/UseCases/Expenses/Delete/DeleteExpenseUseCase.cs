using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Delete;
public class DeleteExpenseUseCase : IDeleteExpenseUseCase
{
    private readonly IExpensesReadOnlyRepository _readRespository;
    private readonly IExpensesWriteOnlyRepository _writeRespository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly ILoggedUser _loggedUser;

    public DeleteExpenseUseCase(IExpensesWriteOnlyRepository writeRespository,
                                IUnityOfWork unityOfWork, ILoggedUser loggedUser,
                                IExpensesReadOnlyRepository readRepository)
    {
        _writeRespository = writeRespository;
        _unityOfWork = unityOfWork;
        _loggedUser = loggedUser;
        _readRespository = readRepository;
    }

    public async Task Execute(long id)
    {
        var loggedUser = await _loggedUser.Get();
        var expense = await _readRespository.GetById(loggedUser, id);
        if(expense is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        await _writeRespository.Delete(id);
        await _unityOfWork.Commit();
    }
}
