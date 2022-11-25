
using GrahpQL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _repositoryContext;
        private readonly Lazy<ISpeakerRepository> _speakerRepository;
        private readonly Lazy<ISessionRepository> _sessionRepository;

        public RepositoryManager(IDbContextFactory<ApplicationDbContext> repositoryContext)
        {
            _repositoryContext = repositoryContext.CreateDbContext();
            _speakerRepository = new Lazy<ISpeakerRepository>(() => new SpeakerRepository(_repositoryContext));
            _sessionRepository = new Lazy<ISessionRepository>(() => new SessionRepository(_repositoryContext));
        }

        public ISpeakerRepository Speaker => _speakerRepository.Value;
        public ISessionRepository Session => _sessionRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}