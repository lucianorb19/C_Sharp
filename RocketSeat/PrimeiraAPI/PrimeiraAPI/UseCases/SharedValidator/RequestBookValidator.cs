using FluentValidation;
using PrimeiraAPI.Communication.Request;

namespace PrimeiraAPI.UseCases.SharedValidator;

public class RequestBookValidator : AbstractValidator<RequestBookJson>
{
    public RequestBookValidator()
    {
        //NÃO PODE EXISTIR UM REGISTRO DE AUTOR X ASSOCIADO AO LIVRO Y DUPLICADO
        RuleFor(book => book.Title).NotEmpty().WithMessage("O título não pode ser vazio.");
        RuleFor(book => book.Title).Length(2,120)
                                   .WithMessage("O título precisa ter entre 2 e 120 caractéres.");

        RuleFor(book => book.Price).GreaterThanOrEqualTo(0)
                                   .WithMessage("O preço precisa ser maior ou igual a 0");
        RuleFor(book => book.Stock).GreaterThanOrEqualTo(0)
                                   .WithMessage("O estoque precisa ser maior ou igual a 0");

    }
}
