using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionsBase;


namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public RegisterExpenseUseCase(IExpensesRepository repository,
                                  IUnityOfWork unityOfWork,
                                  IMapper mapper)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisteredExpenseJson> Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        /*
        var entity = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType,
        };
        */
        var entity = _mapper.Map<Expense>(request);

        await _repository.Add(entity);//USO DE INJEÇÃO DE DEPENDÊNCIA
        await _unityOfWork.Commit();//USO DE INJEÇÃO DE DEPENDÊNCIA

        //return new ResponseRegisteredExpenseJson();
        return _mapper.Map<ResponseRegisteredExpenseJson>(entity);
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var result = new RegisterExpenseValidator().Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(failure => failure.ErrorMessage)
                                             .ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }

    
}
