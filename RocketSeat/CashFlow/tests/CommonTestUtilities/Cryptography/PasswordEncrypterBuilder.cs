using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommonTestUtilities.Cryptography;
public class PasswordEncrypterBuilder
{

    private readonly Mock<IPasswordEncripter> _mock;

    public PasswordEncrypterBuilder()
    {
        _mock = new Mock<IPasswordEncripter>();
        
        //CONFIGURAR MOCK PARA RETORNAR A STRING "aA1!aaaaa" (SENHA VÁLIDA) E RECEBER COMO PARÂMETRO
        //QUALQUER STRING
        var mock = new Mock<IPasswordEncripter>();
        _mock.Setup(passwordEncripter => passwordEncripter.Encrypt(It.IsAny<string>()))
                                                         .Returns("aA1!aaaaa");//SENHA VALIDA
    }

    //FUNÇÃO QUE, SE PASSADO O PARÂMETRO password, CONFIGURA MOCK PARA DEVOLVER true
    //CASO A SENHA PASSADA NO PARÂMETRO SEJA A MESMA
    //PASSADA EM IPasswordEncripter.Verify, DEFININDO TAMBÉM QUE O SEGUNDO PARÂMETRO, QUE SERIA
    //O HASH DA SENHA, POSSA SER QUALQUER STRING, ISSO PQ, PARA ESTE TESTE, O HASH JÁ FOI GERADO
    //COM MOCK
    public PasswordEncrypterBuilder Verify(string? password)
    {
        if(string.IsNullOrWhiteSpace(password) == false)
        {
            _mock.Setup(passwordEncrypter => passwordEncrypter.Verify(password, It.IsAny<string>()))
             .Returns(true);
        }

        return this;
    }


    public IPasswordEncripter Build()
    {
        return _mock.Object;
    }

    
}
