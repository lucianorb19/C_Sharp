using FluentValidation;
using PrimeiraAPI.Communication.Request;

namespace PrimeiraAPI.UseCases.SharedValidator;

public class RequestAuthorValidator : AbstractValidator<RequestAuthorJson>
{
    public RequestAuthorValidator()
    {
        RuleFor(author => author.Name).NotEmpty().WithMessage("O nome não pode ser vazio.");
    }
}
