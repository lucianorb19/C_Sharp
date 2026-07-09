using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Login.DoLogin;
public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _acessTokenGenerator;

    public DoLoginUseCase(IUserReadOnlyRepository repository, 
                          IPasswordEncripter passwordEncripter,
                          IAccessTokenGenerator acessTokenGenerator)
    {
        _repository = repository;
        _passwordEncripter = passwordEncripter;
        _acessTokenGenerator = acessTokenGenerator;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.GetUserByEmail(request.Email);
        if(user is null)//USUÁRIO NÃO CADASTRADO, JÁ QUE SEU E-MAIL NÃO EXISTE NA BD
        {
            throw new InvalidLoginException();
        }

        //MÉTODO BCRYPT PODE GERAR DIFERENTES HASHs DE SENHA PARA A MESMA SENHA
        //NESSE CASO, PARA SABER SE A SENHA PASSADA NO LOGIN CORRESPONDE AO HASH
        //ARMAZENADO NA BASE DE DADOS, USA-SE A FUNÇÃO Verify DO BCRYPT, QUE
        //INFORMA QUE, DADA UMA SENHA X E HASH Y, É POSSÍVEL QUE ESSE HASH Y TENHA SIDO
        //GERADO A PARTIR DAQUELA SENHA X, O QUE É SUFICIENTE PARA NOSSO PROCESSO DE 
        //AUTENTICAÇÃO
        var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);
        if(passwordMatch == false)//USUÁRIO REGISTRADO, MAS SENHA INVÁLIDA
        {
            throw new InvalidLoginException();
        }

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Token = _acessTokenGenerator.Generate(user)
        };
    }
}
