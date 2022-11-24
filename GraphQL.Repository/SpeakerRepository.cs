
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

        public async Task<IEnumerable<Speaker>> GetAllSpeakerAsync(bool AsTraking = false)
        {
            return await FindAll(AsTraking).ToListAsync();
        }

    }
}