using AutoMapper;
using BarberShop.Communication.Requests;
using BarberShop.Communication.Responses;
using BarberShop.Domain.Entities;
using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Billings;
using BarberShop.Exception.ExceptionBase;

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

    public async Task<ResponseShortBillingJson> Execute(RequestBillingJson request)
    {

        //request.CreatedAt = DateTime.UtcNow;
        //request.UpdatedAt = DateTime.UtcNow;

        Validate(request);

        var entity = _mapper.Map<Billing>(request);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await _repository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseShortBillingJson>(entity);
    }

    private void Validate(RequestBillingJson request)
    {
        var result = new BillingValidator().Validate(request);
        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(failure => failure.ErrorMessage)
                                             .ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
