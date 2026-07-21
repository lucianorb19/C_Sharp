using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Tokens;
using Moq;

namespace CommonTestUtilities.Token;
public class JwtTokenGeneratorBuilder
{
    public static IAccessTokenGenerator Build()
    {
        var mock = new Mock<IAccessTokenGenerator>();

        //CONFIGURAR MOCK PARA RETORNAR A STRING "tokenAQUI" E RECEBER COMO PARÂMETRO
        //QUALQUER OBJETO DO TIPO User (PQ A FUNÇAO IAcessTokenGenerator.Generate TEM
        //RETORNO DO TIPO User)
        mock.Setup(acessTokenGenerator => acessTokenGenerator.Generate(It.IsAny<User>()))
                                                             .Returns("tokenAQUI");
        return mock.Object;
    }
}
