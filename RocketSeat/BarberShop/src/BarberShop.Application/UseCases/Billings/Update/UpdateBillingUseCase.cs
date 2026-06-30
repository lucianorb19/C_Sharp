using AutoMapper;
using BarberShop.Communication.Requests;
using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Billings;
using BarberShop.Exception;
using BarberShop.Exception.ExceptionBase;

namespace BarberShop.Application.UseCases.Billings.Update;
public class UpdateBillingUseCase : IUpdateBillingUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unityOfWork;
    private readonly IBillingsUpateOnlyRepository _repository;

    public UpdateBillingUseCase(IMapper mapper, IUnitOfWork unityOfWork, 
                                IBillingsUpateOnlyRepository repository)
    {
        _mapper = mapper;
        _unityOfWork = unityOfWork;
        _repository = repository;
    }

    public async Task Execute(Guid id, RequestBillingJson request)
    {
        
        Validate(request);

        var billing = await _repository.GetById(id);
        if (billing is null) throw new NotFoundException(ResourceErrorMessages.BILLING_NOT_FOUND);

        billing.UpdatedAt = DateTime.UtcNow;
        _mapper.Map(request, billing);
        _repository.Update(billing);
        await _unityOfWork.Commit();
    }

    private void Validate(RequestBillingJson request)
    {
        var result = new BillingValidator().Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(failure => failure.ErrorMessage)
                                             .ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
