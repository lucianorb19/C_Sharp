using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Update;
public class UpdateExpenseUseCase : IUpdateExpenseUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IExpensesUpateOnlyRepository _repository;

    public UpdateExpenseUseCase(IMapper mapper, IUnityOfWork unityOfWork, 
                                IExpensesUpateOnlyRepository repository)
    {
        _mapper = mapper;
        _unityOfWork = unityOfWork;
        _repository = repository;
    }

    public async Task Execute(long id, RequestExpenseJson request)
    {
        Validate(request);
        
        var expense = await _repository.GetById(id);
        if(expense is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        //ATRIBUI DE request PARA expense
        _mapper.Map(request, expense);

        //ATRIBUI DE request PARA UMA NOVA INSTÂNCIA DE Expense
        //_mapper.Map<Expense>(request);

        _repository.Update(expense);
        await _unityOfWork.Commit();
    }


    private void Validate(RequestExpenseJson request)
    {
        var result = new ExpenseValidator().Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(failure => failure.ErrorMessage)
                                             .ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
