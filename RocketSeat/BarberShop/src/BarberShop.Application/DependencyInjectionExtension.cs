using BarberShop.Application.AutoMapper;
using BarberShop.Application.UseCases.Billings.Delete;
using BarberShop.Application.UseCases.Billings.GetAll;
using BarberShop.Application.UseCases.Billings.GetById;
using BarberShop.Application.UseCases.Billings.Register;
using BarberShop.Application.UseCases.Billings.Update;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterBillingUseCase, RegisterBillingUseCase>();
        services.AddScoped<IGetAllBillingsUseCase, GetAllBillingsUseCase>();
        services.AddScoped<IGetBillingByIdUseCase, GetBillingByIdUseCase>();
        services.AddScoped<IDeleteBillingUseCase, DeleteBillingUseCase>();
        services.AddScoped<IUpdateBillingUseCase, UpdateBillingUseCase>();
    }


}
