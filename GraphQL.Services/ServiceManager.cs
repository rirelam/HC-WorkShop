
using GrahpQL.Contracts;
using GraphQL.Services.Contracts;

namespace GraphQL.Services
{
    public class ServiceManager : IServiceManager, IAsyncDisposable
    {
        private readonly ISpeakerServices _speakerServices;
        private readonly ISessionServices _sessionServices;
        private readonly IAttendeeServices _attendeeServices;
        private readonly ITrackServices _trackServices;

        private readonly IRepositoryManager _repositoryManager;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _speakerServices = new SpeakerServices(_repositoryManager);
            _sessionServices = new SessionServices(_repositoryManager);
            _attendeeServices = new AttendeeServices(_repositoryManager);
            _trackServices = new TrackServices(_repositoryManager);
        }
        public ISpeakerServices SpeakerServices => _speakerServices;
        public ISessionServices SessionServices => _sessionServices;
        public IAttendeeServices AttendeeServices => _attendeeServices;
        public ITrackServices TrackServices => _trackServices;

        public ValueTask DisposeAsync()
        {
            return _repositoryManager.DisposeAsync();
        }
    }
}