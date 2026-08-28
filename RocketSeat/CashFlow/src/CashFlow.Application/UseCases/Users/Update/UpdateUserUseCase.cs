using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using FluentValidation.Results;
using Microsoft.Extensions.Options;

namespace CashFlow.Application.UseCases.Users.Update;
public class UpdateUserUseCase : IUpdateUserUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IUserUpdateOnlyRepository _repositoryUserUpdateOnly;
    private readonly IUserReadOnlyRepository _repositoryUserReadOnly;
    private readonly IUnityOfWork _unitOfWork;

    public UpdateUserUseCase()
    {
        
    }

    public UpdateUserUseCase(ILoggedUser loggedUser, 
                             IUserUpdateOnlyRepository repositoryUserUpdateOnly, 
                             IUserReadOnlyRepository repositoryUserReadOnly, 
                             IUnityOfWork unitOfWork)
    {
        _loggedUser = loggedUser;
        _repositoryUserUpdateOnly = repositoryUserUpdateOnly;
        _repositoryUserReadOnly = repositoryUserReadOnly;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(RequestUpdateUserJson request)
    {
        var loggedUser = await _loggedUser.Get();
        await Validate(request, loggedUser.Email);

        var user = await _repositoryUserUpdateOnly.GetById(loggedUser.Id);

        user.Name = request.Name;
        user.Email = request.Email;

        _repositoryUserUpdateOnly.Update(user);
        await _unitOfWork.Commit();
    }

    private async Task Validate(RequestUpdateUserJson request, string currentEmail)
    {
        var validator = new UpdateUserValidator();

        var result = validator.Validate(request);
        //SE EMAIL LOGADO DIFERENTE DO EMAIL DA REQUEST - OK (É NECESSÁRIO)
        if (currentEmail.Equals(request.Email) == false){
            var userExist = await _repositoryUserReadOnly.ExistActiveUserWithEmail(request.Email);
            if (userExist) result.Errors //SE EMAIL DA REQUEST JÁ ESTIVER CADASTRADO - IMPEDIMENTO
                                 .Add(new ValidationFailure(string.Empty,
                                                            ResourceErrorMessages.EMAIL_ALREADY_EXISTS));
        }

        if(result.IsValid == false)//REQUEST NÃO APROVADA PELO VALIDATOR
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }

}
