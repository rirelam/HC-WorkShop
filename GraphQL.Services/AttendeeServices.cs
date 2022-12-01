using GrahpQL.Contracts;
using GraphQL.Entities;
using GraphQL.Services.Contracts;

namespace GraphQL.Services
{
    public class AttendeeServices : IAttendeeServices
    {
        private readonly IRepositoryManager _repository;

        public AttendeeServices(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Attendee>> GetAttendeebyIdsAsync(IReadOnlyList<int> keys)
        {
            return await _repository.Attendee.GetAttendeebyIdsAsync(keys);
        }
    }
}