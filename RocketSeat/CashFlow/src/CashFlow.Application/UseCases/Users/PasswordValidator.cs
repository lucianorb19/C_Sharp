using CashFlow.Exception;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace CashFlow.Application.UseCases.Users;
public class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_MESSAGE_KEY = "ErrorMessage";

    public override string Name => "PasswordValidator";


    //SOBRESCRITA NECESSÁRIA PARA QUE A MENSAGEM DE ERRO USADA EM .AppendArgument
    //SEJA CORRETAMENTE REPASSADA PARA RegisterUserValidator
    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        //{ErrorMessage}
        return $"{{{ERROR_MESSAGE_KEY}}}";
    }


    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            context.MessageFormatter
                   .AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (password.Length < 8)
        {
            context.MessageFormatter
                   .AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        //SE SENHA SEM MAIÚSCULAS
        if(Regex.IsMatch(password, @"[A-Z]+") == false)
        {
            context.MessageFormatter
                   .AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        //SE SENHA SEM MINÚSCULAS
        if (Regex.IsMatch(password, @"[a-z]+") == false)
        {
            context.MessageFormatter
                   .AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        //SE SENHA SEM NÚMEROS
        if (Regex.IsMatch(password, @"[0-9]+") == false)
        {
            context.MessageFormatter
                   .AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        //SE SENHA SEM CARACTERES ESPECIAIS
        if (Regex.IsMatch(password, @"[\!\#\$\%\&\*\(\)\.\,\{\}\[\]\=\+\-]+") == false)
        {
            context.MessageFormatter
                   .AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }


        return true;
    }
}
