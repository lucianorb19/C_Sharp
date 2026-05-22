using APITarefas.Communication.Requests;
using APITarefas.Communication.Responses;

namespace APITarefas.Services.UseCases.Tasks;
public class RegisterTaskUseCase
{
    public ResponseBase Execute(RequestTaskJson request)
    {
        request.Name = request.Name.Trim();

        if (request.DueDate < DateTime.Now || request.Name.Length > 100 || 
            string.IsNullOrEmpty(request.Name))
        {
            throw new ArgumentException("Erros de validação: campos DueDate / Nome tarefa");
        }

        return new ResponseRegisterTaskJson
        {
            //ID GUID GERADO AUTOMATICAMENTE
            Name = request.Name,
            Description = request.Description,
            Priority = request.Priority,
            Status = request.Status,
            DueDate = request.DueDate.ToLongDateString(),
        };
    }
}
