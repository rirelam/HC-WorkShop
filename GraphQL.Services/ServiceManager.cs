
using GrahpQL.Contracts;
using GraphQL.Services.Contracts;

namespace GraphQL.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ISpeakerServices> _speakerServices;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _speakerServices = new Lazy<ISpeakerServices>(() => new SpeakerServices(repositoryManager));
        }
        public ISpeakerServices SpeakerServices => _speakerServices.Value;
    }
}