
namespace GraphQL.Services.Contracts
{
    public interface IServiceManager 
    {
        ISpeakerServices SpeakerServices { get; }
        ISessionServices SessionServices { get; }

    }
}