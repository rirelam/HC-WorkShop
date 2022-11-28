
using GrahpQL.Presentation.Shared;
using GraphQL.Entities;

namespace GrahpQL.Presentation.Speakers
{  // TODO: Cambiar el Speaker por un Dto
    public class AddSpeakerPayload : SpeakerPayloadBase
    {
        public AddSpeakerPayload(Speaker speaker)
                    : base(speaker)
        {
        }

        public AddSpeakerPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}