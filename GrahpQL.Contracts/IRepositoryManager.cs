
namespace GrahpQL.Contracts
{
    public interface IRepositoryManager
    {
        ISpeakerRepository Speaker { get; }

        Task SaveAsync();

    }
}