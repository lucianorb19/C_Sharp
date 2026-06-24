using AutoMapper;
using BarberShop.Communication.Requests;
using BarberShop.Communication.Responses;
using BarberShop.Domain.Entities;

namespace BarberShop.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestBillingJson, Billing>();
    }

    private void EntityToResponse()
    {
        CreateMap<Billing, ResponseShortBillingJson>();
        CreateMap<Billing, ResponseShortBillingJson>();
    }
}
