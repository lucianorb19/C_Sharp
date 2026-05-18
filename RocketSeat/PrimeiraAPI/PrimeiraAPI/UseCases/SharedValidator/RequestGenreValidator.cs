using FluentValidation;
using PrimeiraAPI.Communication.Request;

namespace PrimeiraAPI.UseCases.SharedValidator;

public class RequestGenreValidator : AbstractValidator<RequestGenreJson>
{
    public RequestGenreValidator()
    {
        RuleFor(genre => genre.Name).NotEmpty().WithMessage("O nome não pode ser vazio.");
    }
}
