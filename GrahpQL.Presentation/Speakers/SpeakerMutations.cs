using GraphQL.Entities;
using GraphQL.Services.Contracts;
using GraphQL.Shared.DTO;

namespace GrahpQL.Presentation.Speakers
{
    [ExtendObjectType("Mutation")]
    public class SpeakerMutations
    {
        public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input,
            [Service] IServiceManager service)
        {
            var speaker = new AddSpeakerInputDto
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            await service.SpeakerServices.AddSpeaker(speaker);

            // TODO: cambiar para uso de automapper
            return new AddSpeakerPayload(new Speaker { Name = input.Name, Bio = input.Bio, WebSite = input.WebSite });
        }

    }
}