using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommonTestUtilities.Cryptography;
public class PasswordEncripterBuilder
{

    public static IPasswordEncripter Build()
    {

        //CONFIGURAR MOCK PARA RETORNAR A STRING "aA1!aaaaa" (SENHA VÁLIDA) E RECEBER COMO PARÂMETRO
        //QUALQUER STRING (PQ A FUNÇAO IPasswordEncripter.Encrypt TEM RETORNO DO TIPO string)
        var mock = new Mock<IPasswordEncripter>();
        mock.Setup(passwordEncripter => passwordEncripter.Encrypt(It.IsAny<string>()))
                                                         .Returns("aA1!aaaaa");//SENHA VALIDA

        return mock.Object;
    }

    
}
