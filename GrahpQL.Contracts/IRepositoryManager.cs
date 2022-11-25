
namespace GrahpQL.Contracts
{
    public interface IRepositoryManager
    {
        ISpeakerRepository Speaker { get; }
        ISessionRepository Session { get; }

        Task SaveAsync();

    }
}