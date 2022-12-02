
using GrahpQL.Presentation.Shared;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GrahpQL.Presentation.Tracks
{
    [ExtendObjectType("Mutation")]
    public class TrackMutations
    {
        public async Task<AddTrackPayload> AddTrackAsync(
            AddTrackInput input,
            IServiceManager service,
            CancellationToken cancellationToken)
        {
            var track = new Track { Name = input.Name };
            await service.TrackServices.AddAsync(track);

            return new AddTrackPayload(track);
        }

        public async Task<RenameTrackPayload> RenameTrackAsync(
                    RenameTrackInput input,
                    IServiceManager service,
                    CancellationToken cancellationToken)
        {
            Track? track = await service.TrackServices.FindAsync(input.Id, cancellationToken);

            if (track == null){
                return new RenameTrackPayload(new UserError("Track not found.", "TRACK_NOT_FOUND"));
            }

            track.Name = input.Name;

            await service.TrackServices.UpdateTrackAsync(track);

            return new RenameTrackPayload(track);
        }
    }
}