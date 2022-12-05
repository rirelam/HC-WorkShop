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

        public async Task Add(Attendee attendee)
        {
            _repository.Attendee.Add(attendee);
            await _repository.SaveAsync();
        }

        public async Task<Attendee?> GetAttendeeByIdAsync(int attendeeId, CancellationToken cancellationToken)
        {
            return await _repository.Attendee.GetAttendeeByIdAsync(attendeeId, cancellationToken);
        }

        public async Task<IEnumerable<Attendee>> GetAttendeebyIdsAsync(IReadOnlyList<int> keys)
        {
            return await _repository.Attendee.GetAttendeebyIdsAsync(keys);
        }

        public IQueryable<Attendee> GetAttendees()
        {
            return _repository.Attendee.GetAttendees();
        }

        public async Task<ICollection<int>> GetAttendeeSessionsAsync(int attendeeId, CancellationToken cancellationToken)
        {
            return await _repository.Attendee.GetAttendeeSessionsAsync(attendeeId, cancellationToken);
        }

        public async Task UpdateAttendee(Attendee attendee, CancellationToken cancellationToken)
        {
            _repository.Attendee.UpdateAttendee(attendee);
            await _repository.SaveAsync();
        }
    }
}