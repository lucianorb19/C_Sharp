using APITarefas.Communication.Responses;
using System.Reflection.Metadata.Ecma335;

namespace APITarefas.Services.UseCases.Tasks;
public class GetAllTasksUseCase
{
    public ResponseAllTasksJson Execute()
    {
        return new ResponseAllTasksJson
        {
            Tasks = [new ResponseShortTaskJson{
                Id = Guid.NewGuid(),
                Name = "teste1",
                DueDate = DateTime.Now.ToLongDateString(),
                Status = APITarefas.Communication.Enums.Status.InProgress,
            },new ResponseShortTaskJson{
                Id = Guid.NewGuid(),
                Name = "teste2",
                DueDate = DateTime.Now.ToLongDateString(),
                Status = APITarefas.Communication.Enums.Status.Completed,
            },new ResponseShortTaskJson{
                Id = Guid.NewGuid(),
                Name = "teste3",
                DueDate = DateTime.Now.ToLongDateString(),
                Status = APITarefas.Communication.Enums.Status.Pending,
            },]
        };
    }
}
