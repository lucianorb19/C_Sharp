using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses;
public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        //TITULO
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty) throw new ArgumentException("O título precisa ser preenchido.");

        //VALOR
        if (request.Amount <= 0) throw new ArgumentException("O valor da despesa precisa ser maior que zero.");

        //DATA
        var comparacaoDatas = DateTime.Compare(request.Date,DateTime.UtcNow);
        if (comparacaoDatas > 0) throw new ArgumentException("Data da despesa não pode ser futura.");

        //TIPO DE PAGAMENTO
        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
        if (paymentTypeIsValid == false) throw new ArgumentException("Tipo de despesa não é válido.");
    }

    
}
