using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet;
public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = 1,
            Name = "NomeTeste1",
            BirthDay = new DateTime(year: 2025, month:01, day:10),
            Type = Communication.Enums.PetType.Dog,
        };
    }
}
