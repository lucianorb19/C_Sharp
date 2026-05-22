using APITarefas.Communication.Responses;

namespace APITarefas.Services.UseCases.Tasks;
public class GetTaskByIdUseCase
{
    public ResponseTaskJson Execute(Guid id)
    {
        return new ResponseTaskJson
        {
            Id = id,
            Name = "teste1",
            Description = "Descrição teste 1",
            Priority = Communication.Enums.Priority.High,
            Status = Communication.Enums.Status.InProgress,
            DueDate = DateTime.Now.ToLongDateString(),
        };
    }
}
