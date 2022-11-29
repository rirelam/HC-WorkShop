
using GrahpQL.Contracts;
using GraphQL.Services.Contracts;

namespace GraphQL.Services
{
    public class ServiceManager : IServiceManager, IAsyncDisposable
    {
        private readonly ISpeakerServices _speakerServices;
        private readonly ISessionServices _sessionServices;

        private readonly IRepositoryManager _repositoryManager;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _speakerServices = new SpeakerServices(_repositoryManager);
            _sessionServices = new SessionServices(_repositoryManager);
        }
        public ISpeakerServices SpeakerServices => _speakerServices;
        public ISessionServices SessionServices => _sessionServices;

        public ValueTask DisposeAsync()
        {
            // GC.SuppressFinalize(this);
            return _repositoryManager.DisposeAsync();
        }
    }
}