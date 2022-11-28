
namespace GraphQL.Services.Contracts
{
    public interface IServiceManager : IAsyncDisposable
    {
        ISpeakerServices SpeakerServices { get; }
        ISessionServices SessionServices { get; }

    }
}