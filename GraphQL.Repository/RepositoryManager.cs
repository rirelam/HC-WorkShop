
using GrahpQL.Contracts;

namespace GraphQL.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _repositoryContext;
        private readonly Lazy<ISpeakerRepository> _speakerRepository;

        public RepositoryManager(ApplicationDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _speakerRepository = new Lazy<ISpeakerRepository>(() => new SpeakerRepository(repositoryContext));
        }

        public ISpeakerRepository Speaker => _speakerRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}