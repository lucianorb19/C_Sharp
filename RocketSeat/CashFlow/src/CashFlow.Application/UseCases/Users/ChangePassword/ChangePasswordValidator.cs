using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users.ChangePassword;
public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
{

    //VALIDATOR PARA A TROCA DE SENHA UTILIZA, NO CAMPO NewPassword, O VALIDATOR JÁ CRIADO EM
    //PassWordValidator
    public ChangePasswordValidator()
    {
        RuleFor(request => request.NewPassword)
            .SetValidator(new PasswordValidator<RequestChangePasswordJson>());
    }
}
