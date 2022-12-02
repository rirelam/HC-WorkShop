
using GrahpQL.Presentation.Shared;
using GraphQL.Entities;

namespace GrahpQL.Presentation.Tracks
{
public class TrackPayloadBase : Payload
    {
        public TrackPayloadBase(Track track)
        {
            Track = track;
        }

        public TrackPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Track? Track { get; }
    }
}