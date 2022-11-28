using GrahpQL.Presentation.Shared;
using GraphQL.Entities;

namespace GrahpQL.Presentation.Speakers
{
    public class SpeakerPayloadBase : Payload
    {   // TODO: Cambiar el Speaker por un Dto
        protected SpeakerPayloadBase(Speaker speaker)
        {
            Speaker = speaker;
        }

        protected SpeakerPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Speaker? Speaker { get; }
    }
}