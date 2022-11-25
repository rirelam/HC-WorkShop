
using GrahpQL.Contracts;
using GraphQL.Services.Contracts;

namespace GraphQL.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ISpeakerServices> _speakerServices;
        private readonly Lazy<ISessionServices> _sessionServices;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _speakerServices = new Lazy<ISpeakerServices>(() => new SpeakerServices(repositoryManager));
            _sessionServices = new Lazy<ISessionServices>(() => new SessionServices(repositoryManager));
        }
        public ISpeakerServices SpeakerServices => _speakerServices.Value;
        public ISessionServices SessionServices => _sessionServices.Value;
    }
}