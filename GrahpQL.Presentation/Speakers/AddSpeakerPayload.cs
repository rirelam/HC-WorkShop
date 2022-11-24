using GraphQL.Shared.DTO;

namespace GrahpQL.Presentation.Speakers
{
    public class AddSpeakerPayload
    {
        public AddSpeakerPayload(AddSpeakerOutputDto speaker)
        {
            Speaker = speaker;
        }

        public AddSpeakerOutputDto Speaker { get; init; }
    }
}