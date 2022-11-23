
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         :base(options)
         {}

        public DbSet<Speaker> Speakers { get; set; }
    }
}