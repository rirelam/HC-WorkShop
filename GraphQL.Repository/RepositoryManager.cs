
using GrahpQL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _repositoryContext;
        private readonly Lazy<ISpeakerRepository> _speakerRepository;

        public RepositoryManager(IDbContextFactory<ApplicationDbContext> repositoryContext)
        {
            _repositoryContext = repositoryContext.CreateDbContext();
            _speakerRepository = new Lazy<ISpeakerRepository>(() => new SpeakerRepository(repositoryContext));
        }

        public ISpeakerRepository Speaker => _speakerRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}