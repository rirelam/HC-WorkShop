
using GrahpQL.Contracts;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Repository
{
    public class SpeakerRepository : RepositoryBase<Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(ApplicationDbContext repositoryContext)
         : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<Speaker>> GetAllSpeakerAsync(bool AsTraking = false)
        {
            return await FindAll(AsTraking).ToListAsync();
         }

    }
}