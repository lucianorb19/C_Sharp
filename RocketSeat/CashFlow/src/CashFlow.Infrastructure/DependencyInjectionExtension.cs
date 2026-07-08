using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;
public static class DependencyInjectionExtension
{
    //O this AQUI USADO,FAZ COM QUE NÃO SEJA NECESSÁRIO EXPLICITAR
    //O PARÂMETRO services NA CHAMADA DO MÉTODO
    //JÁ QUE USA O VALOR DELE VINDO DA CLASSE ONDE FOR CHAMADA
    //NESSE CASO É USADO EM PROGRAM
    public static void AddInfrastructure(this IServiceCollection services, 
                                              IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContext(services, configuration);
        services.AddScoped<IPasswordEncripter, Infrastructure.Security.BCrypt>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        //INJEÇÃO DE PEDENDÊNCIA
        //EM QUALQUER LUGAR DO CÓDIGO, AO USAR A PROPRIEDADE [FromServices] OU
        //UM OBJETO IExpensesWriteRepository / IExpensesReadOnlyRepository
        //É INJETADA UMA INSTÂNCIA, QUE INDICADA COMO IExpensesWriteRepository / IExpensesReadOnlyRepository,
        //INSTANCIA UM TIPO ExpensesRepository
        services.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesUpateOnlyRepository, ExpensesRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUnityOfWork, UnityOfWork>();
    }

    //INJEÇÃO DE DEPENDÊNCIA ESPECÍFICA PARA CONEXÃO COM BASE DE DADOS
    //NÃO USA SINGLETON, SCOPED OU TRANSIENT, MAS SIM AddDbContext
    //PARA CONECTAR A CLASSE RESPONSÁVEL PELA BASE DE DADOS
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        //INJEÇÃO PARA DbContextOptions USADO EM CashFlowDbContext - NO CONSTRUTOR
        //LEITURA DA connectionString de appSettings.Development.json
        var connectionString = configuration.GetConnectionString("Connection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 46));
        
        //optionsBuilder.UseMySql(connectionString, serverVersion);
        services.AddDbContext<CashFlowDbContext>(config => 
                                        config.UseMySql(connectionString, serverVersion));
    }


}
