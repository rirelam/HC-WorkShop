
using GrahpQL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _repositoryContext;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IAttendeeRepository _attendeeRepository;
        private readonly ITrackRepository _trackRepository;

        public RepositoryManager(IDbContextFactory<ApplicationDbContext> repositoryContext)
        {
            _repositoryContext = repositoryContext.CreateDbContext();
            _speakerRepository = new SpeakerRepository(_repositoryContext);
            _sessionRepository = new SessionRepository(_repositoryContext);
            _attendeeRepository = new AttendeeRepository(_repositoryContext);
            _trackRepository = new TrackRepository(_repositoryContext);
        }

        public ISpeakerRepository Speaker => _speakerRepository;
        public ISessionRepository Session => _sessionRepository;
        public IAttendeeRepository Attendee => _attendeeRepository;
        public ITrackRepository Track => _trackRepository;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

        public ValueTask DisposeAsync()
        {

            return _repositoryContext.DisposeAsync();
        }
    }
}