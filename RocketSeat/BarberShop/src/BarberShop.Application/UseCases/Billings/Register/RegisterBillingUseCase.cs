using AutoMapper;
using BarberShop.Communication.Requests;
using BarberShop.Communication.Responses;
using BarberShop.Domain.Entities;
using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Billings;
using System.Runtime.CompilerServices;

namespace BarberShop.Application.UseCases.Billings.Register;
public class RegisterBillingUseCase : IRegisterBillingUseCase
{
    private readonly IBillingsWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public RegisterBillingUseCase(IBillingsWriteOnlyRepository repository, 
                                  IUnitOfWork unityOfWork, 
                                  IMapper mapper)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisteredBillingJson> Execute(RequestBillingJson request)
    {
        //Validate(request)

        var entity = _mapper.Map<Billing>(request);
        await _repository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisteredBillingJson>(entity);
    }

    private void Validate(RequestBillingJson request)
    {
        //VALIDAR AQUI COM VALIDATOR
    }
}
