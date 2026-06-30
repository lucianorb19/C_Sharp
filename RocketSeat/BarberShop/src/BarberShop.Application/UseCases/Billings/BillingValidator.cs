using BarberShop.Communication.Requests;
using BarberShop.Exception;
using FluentValidation;

namespace BarberShop.Application.UseCases.Billings;
public class BillingValidator : AbstractValidator<RequestBillingJson>
{
    public BillingValidator()
    {
        RuleFor(billing => billing.Date).NotEmpty()
                                        .WithMessage(ResourceErrorMessages.DATE_REQUIRED);
        
        RuleFor(billing => billing.BarberName).NotEmpty()
                                              .Length(2,80)
                                              .WithMessage(ResourceErrorMessages.BARBER_REQUIRED);
        
        RuleFor(billing => billing.ClientName).NotEmpty()
                                              .Length(2, 120)
                                              .WithMessage(ResourceErrorMessages.CLIENT_REQUIRED);
        
        RuleFor(billing => billing.ServiceName).NotEmpty()
                                          .Length(2, 120)
                                          .WithMessage(ResourceErrorMessages.SERVICE_NAME_REQUIRED);
        
        RuleFor(billing => billing.Amount).NotNull()
                                          .WithMessage(ResourceErrorMessages.AMOUNT_REQUIRED);
        
        RuleFor(billing => billing.Amount).Equal(0)
                                          .When(billing => billing.Status == Communication.Enums.Status.Canceled)
                                          .WithMessage(ResourceErrorMessages.AMOUNT_ZERO_WHEN_CANCELED);

        RuleFor(billing => billing.Amount).GreaterThan(0)
                                          .When(billing => billing.Status == Communication.Enums.Status.Paid)
                                          .WithMessage(ResourceErrorMessages.AMOUNT_GREATER_THAN_ZERO);

        RuleFor(billing => billing.PaymentMethod).NotNull()
                                                 .IsInEnum()
                                                 .WithMessage(ResourceErrorMessages.INVALID_PAYMENT_METHOD);
        
        RuleFor(billing => billing.Status).NotNull()
                                          .IsInEnum()
                                          .WithMessage(ResourceErrorMessages.INVALID_STATUS);

        RuleFor(billing => billing.Notes).Length(0, 500)
                                         .WithMessage(ResourceErrorMessages.NOTE_LENGTH_LESS_THAN_OR_EQUAL_TO_500);

    }
}
