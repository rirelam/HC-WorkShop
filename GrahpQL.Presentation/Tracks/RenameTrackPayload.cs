
using GrahpQL.Presentation.Shared;
using GraphQL.Entities;

namespace GrahpQL.Presentation.Tracks
{
    public class RenameTrackPayload : TrackPayloadBase
    {
        public RenameTrackPayload(Track track) : base(track)
        {
        }

        public RenameTrackPayload(UserError error)
            : base(new[] { error })
        {
        }
    }
}