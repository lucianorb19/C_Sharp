using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Billings;
using BarberShop.Infrastructure.DataAccess;
using BarberShop.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.Infrastructure;
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
    }


    public static void AddRepositories(IServiceCollection services)
    {
        //INJEÇÃO DE PEDENDÊNCIA
        //EM QUALQUER LUGAR DO CÓDIGO, AO USAR A PROPRIEDADE [FromServices] OU
        //UM OBJETO IExpensesWriteRepository / IExpensesReadOnlyRepository
        //É INJETADA UMA INSTÂNCIA, QUE INDICADA COMO IExpensesWriteRepository / IExpensesReadOnlyRepository,
        //INSTANCIA UM TIPO ExpensesRepository
        services.AddScoped<IBillingsWriteOnlyRepository, BillingRepository>();
        services.AddScoped<IBillingsReadOnlyRepository, BillingRepository>();
        services.AddScoped<IBillingsUpateOnlyRepository, BillingRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        //INJEÇÃO PARA DbContextOptions USADO EM BarberShopDbContext - NO CONSTRUTOR
        //LEITURA DA connectionString de appSettings.Development.json
        var connectionString = configuration.GetConnectionString("Connection");
        var serverVersion = new MySqlServerVersion(new Version(8,0,46));

        //optionsBuilder.UseMySql(connectionString, serverVersion);
        services.AddDbContext<BarberShopDbContext>(config =>
                                        config.UseMySql(connectionString, serverVersion));
    }
}
