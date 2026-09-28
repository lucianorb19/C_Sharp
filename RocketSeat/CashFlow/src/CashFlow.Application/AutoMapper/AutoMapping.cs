using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        
        //MAPEIA TODOS OS CAMPOS, EXCETO PASSWORD
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(destino => destino.Password, config => config.Ignore());

        //NO MAPEAMENTO DAS TAGS DA REQUEST PARA A ENTIDADE Expense, TIRA AS TAGS DUPLICADAS
        CreateMap<RequestExpenseJson, Expense>()
            .ForMember(destino => destino.Tags, config => config.MapFrom(source => source.Tags.Distinct()));


        //MAPEAMENTO DE ENUM TAG PARA CLASSE Tag
        //VALOR DO ENUM ATRIBUÍDO PARA O CAMPO TagValue DO OBJETO Tag
        CreateMap<Communication.Enums.Tag, Tag>()
            .ForMember(destino => destino.ValueTag, config => config.MapFrom(source => source));
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisteredExpenseJson>();
        CreateMap<Expense, ResponseShortExpenseJson>();
        CreateMap<Expense, ResponseExpenseJson>();
        CreateMap<User, ResponseUserProfileJson>();

    }
}
