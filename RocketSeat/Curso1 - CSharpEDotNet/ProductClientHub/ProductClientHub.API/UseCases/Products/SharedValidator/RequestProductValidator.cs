using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Products.SharedValidator
{
    public class RequestProductValidator : AbstractValidator<RequestProductJson>
    {
        public RequestProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Nome do produto não pode ser vazio");
            RuleFor(product => product.Brand).NotEmpty().WithMessage("Nome da marca não pode ser vazia");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Valor do produto precisa ser maior que 0");
        }
    }
}
