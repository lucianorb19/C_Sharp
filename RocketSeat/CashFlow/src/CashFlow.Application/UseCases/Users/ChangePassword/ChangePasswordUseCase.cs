using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.Users.ChangePassword;
public class ChangePasswordUseCase : IChangePasswordUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IUserUpdateOnlyRepository _repository;
    private readonly IUnityOfWork _unitOfWork;
    private readonly IPasswordEncripter _passWordEncripter;

    public ChangePasswordUseCase(ILoggedUser loggedUser, 
                                 IUserUpdateOnlyRepository repository, 
                                 IUnityOfWork unitOfWork, 
                                 IPasswordEncripter passWordEncripter)
    {
        _loggedUser = loggedUser;
        _repository = repository;
        _unitOfWork = unitOfWork;
        _passWordEncripter = passWordEncripter;
    }

    public async Task Execute(RequestChangePasswordJson request)
    {
        var loggedUser = await _loggedUser.Get();
        Validate(request, loggedUser);

        var user = await _repository.GetById(loggedUser.Id);
        user.Password = _passWordEncripter.Encrypt(request.NewPassword);

        _repository.Update(user);
        await _unitOfWork.Commit();
    }


    //VALIDATOR
    private void Validate(RequestChangePasswordJson request, Domain.Entities.User loggedUser)
    {
        var validator = new ChangePasswordValidator();
        var result = validator.Validate(request);

        //SENHA INFORMADA COMO ATUAL É A SENHA REGISTRADA NO BANCO?
        var passwordMatch = _passWordEncripter.Verify(request.Password, loggedUser.Password);

        //SE NÃO, ERRO
        if(passwordMatch == false)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.PASSWORD_DIFFERENT_CURRENT_PASSWORD));
        }

        //SE NÃO PASSAR NA VALIDAÇÃO
        if(result.IsValid == false)
        {
            var errors = result.Errors.Select(erro => erro.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
}
