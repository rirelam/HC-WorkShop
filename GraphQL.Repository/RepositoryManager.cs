
using GrahpQL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Repository
{
    public class RepositoryManager : IRepositoryManager, IAsyncDisposable
    {
        private readonly ApplicationDbContext _repositoryContext;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly ISessionRepository _sessionRepository;

        public RepositoryManager(IDbContextFactory<ApplicationDbContext> repositoryContext)
        {
            _repositoryContext = repositoryContext.CreateDbContext();
            _speakerRepository = new SpeakerRepository(_repositoryContext);
            _sessionRepository =  new SessionRepository(_repositoryContext);
        }

        public ISpeakerRepository Speaker => _speakerRepository;
        public ISessionRepository Session => _sessionRepository;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

        public ValueTask DisposeAsync()
        {
            // GC.SuppressFinalize(this);

            return _repositoryContext.DisposeAsync();
        }
    }
}