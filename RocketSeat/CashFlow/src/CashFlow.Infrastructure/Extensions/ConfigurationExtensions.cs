using Microsoft.Extensions.Configuration;

namespace CashFlow.Infrastructure.Extensions;
public static class ConfigurationExtensions
{
    //FUNÇÃO QUE LÊ O VALOR DA VARIÁVEL "InMemoryTest"
    //QUE É true CASO SEJA AMBIENTE DE TEST
    //OU DEFAULT (false) CASO NÃO ENCONTRE
    //OU SEJA
    //RETORNA TRUE CASO O AMBIENTE DE TESTE ESTEJA SENDO EXECUTADO
    public static bool IsTestEnviroment(this IConfiguration configuration)
    {
        return configuration.GetValue<bool>("InMemoryTest");//LIDO DE CashFlow.API.appsettings.Test.json
    }
}
