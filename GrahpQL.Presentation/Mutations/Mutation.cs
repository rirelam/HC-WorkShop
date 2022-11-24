
using GrahpQL.Presentation.Speakers;
using GraphQL.Services.Contracts;
using GraphQL.Shared.DTO;

namespace GrahpQL.Presentation.Mutations
{
    public class Mutation
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


            return new AddSpeakerPayload(new AddSpeakerOutputDto { Name = input.Name, Bio = input.Bio, Website = input.WebSite });
        }

    }
}