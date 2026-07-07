using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.Users.Register;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncrypter;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;

    public RegisterUserUseCase(IMapper mapper, IPasswordEncripter passwordEncrypter, 
                               IUserReadOnlyRepository userReadOnlyRepository)
    {
        _mapper = mapper;
        _passwordEncrypter = passwordEncrypter;
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        await Validate(request);

        var user = _mapper.Map<User>(request);//MAPEAMENTO IGNORANDO PASSWORD
        user.Password = _passwordEncrypter.Encrypt(request.Password);


        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            //TOKEN....
        };

    }


    private async Task Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);
        var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty,
                                                    ResourceErrorMessages.EMAIL_ALREADY_EXISTS));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(failure => failure.ErrorMessage)
                                             .ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
