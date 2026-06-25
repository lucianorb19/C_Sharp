
using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Billings;
using BarberShop.Exception;
using BarberShop.Exception.ExceptionBase;

namespace BarberShop.Application.UseCases.Billings.Delete;
public class DeleteBillingUseCase : IDeleteBillingUseCase
{
    private readonly IBillingsWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBillingUseCase(IBillingsWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id)
    {
        var result = await _repository.Delete(id);
        if (result is false) throw new NotFoundException(ResourceErrorMessages.BILLING_NOT_FOUND);
        await _unitOfWork.Commit();
    }
}
