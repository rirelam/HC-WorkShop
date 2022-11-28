
using GrahpQL.Contracts;
using GraphQL.Services.Contracts;

namespace GraphQL.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly ISpeakerServices _speakerServices;
        private readonly ISessionServices _sessionServices;

        private readonly IRepositoryManager _repositoryManager;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _speakerServices = new SpeakerServices(repositoryManager);
            _sessionServices = new SessionServices(repositoryManager);
            _repositoryManager = repositoryManager;
        }
        public ISpeakerServices SpeakerServices => _speakerServices;
        public ISessionServices SessionServices => _sessionServices;


    }
}