
using GrahpQL.Contracts;
using GraphQL.Services.Contracts;

namespace GraphQL.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ISpeakerServices> _speakerServices;
        private readonly Lazy<ISessionServices> _sessionServices;

        private readonly IRepositoryManager _repositoryManager;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _speakerServices = new Lazy<ISpeakerServices>(() => new SpeakerServices(repositoryManager));
            _sessionServices = new Lazy<ISessionServices>(() => new SessionServices(repositoryManager));
            _repositoryManager = repositoryManager;
        }
        public ISpeakerServices SpeakerServices => _speakerServices.Value;
        public ISessionServices SessionServices => _sessionServices.Value;

        public async ValueTask DisposeAsync()
        {
            if (_repositoryManager == null)
            {
                return;
            }

            await _repositoryManager.DisposeAsync();
            GC.SuppressFinalize(this);
        }

    }
}