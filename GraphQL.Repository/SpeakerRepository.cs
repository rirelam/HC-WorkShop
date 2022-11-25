
using System.Reflection.Metadata.Ecma335;
using GrahpQL.Contracts;
using GraphQL.Entities;
using GraphQL.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Repository
{
    public class SpeakerRepository : RepositoryBase<Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(ApplicationDbContext repositoryContext)
         : base(repositoryContext)
        {

        }

        public void AddSpeaker(AddSpeakerInputDto speakerDto)
        {
            var speaker = new Speaker
            {
                Name = speakerDto.Name,
                Bio = speakerDto.Bio,
                WebSite = speakerDto.WebSite
            };
            Create(speaker);
        }

        public async Task<IEnumerable<Speaker>> GetAllSpeakersAsync(bool AsTraking = false)
        {
            return await FindAll(AsTraking).ToListAsync();
        }

        public async Task<ICollection<int>> GetSessionsIdsAsync(int speakerId, CancellationToken cancellationToken)
        {
            return await RepositoryContext.Speakers
                    .Where(s => s.Id == speakerId)
                    .Include(s => s.SessionSpeakers)
                    .SelectMany(s => s.SessionSpeakers.Select(t => t.SessionId))
                    .ToArrayAsync(cancellationToken);

        }           

        public async Task<IReadOnlyDictionary<int, Speaker>> GetSpeakersDictionaryAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            return await RepositoryContext.Speakers
                        .Where(sp => keys.Contains(sp.Id))
                        .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
        
    }
}