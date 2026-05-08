using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Clients.SharedValidator
{
    public class RequestClientValidator : AbstractValidator<RequestClientJson>
    {
        public RequestClientValidator()
        {
            RuleFor(cliente => cliente.Name).NotEmpty().WithMessage("O nome não pode ser vazio.");
            RuleFor(cliente => cliente.Email).EmailAddress().WithMessage("O e-mail não é válido.");
        }
    }
}
