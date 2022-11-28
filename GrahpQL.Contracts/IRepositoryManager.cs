
namespace GrahpQL.Contracts
{
    public interface IRepositoryManager : IAsyncDisposable
    {
        ISpeakerRepository Speaker { get; }
        ISessionRepository Session { get; }

        Task SaveAsync();

    }
}