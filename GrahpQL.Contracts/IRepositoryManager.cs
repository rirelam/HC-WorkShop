
namespace GrahpQL.Contracts
{
    public interface IRepositoryManager : IAsyncDisposable
    {
        ISpeakerRepository Speaker { get; }
        ISessionRepository Session { get; }
        IAttendeeRepository Attendee { get; }
        ITrackRepository Track { get; }

        Task SaveAsync();

    }
}