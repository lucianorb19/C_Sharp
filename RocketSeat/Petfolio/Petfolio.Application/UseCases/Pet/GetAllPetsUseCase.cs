using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet;
public class GetAllPetsUseCase
{
    public ResponseAllPetsJson Execute()
    {
        return new ResponseAllPetsJson
        {
            Pets = new List<ResponseShortPetJson>
            {
                new ResponseShortPetJson
                {
                    Id = 1,
                    Name = "NomeTeste1",
                    Type = Communication.Enums.PetType.Dog,
                },
                new ResponseShortPetJson
                {
                    Id=2,
                    Name = "NomeTeste2",
                    Type = Communication.Enums.PetType.Cat,
                },
            }
        };
    }
}
