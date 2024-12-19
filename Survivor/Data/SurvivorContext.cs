using Microsoft.EntityFrameworkCore;
using Survivor.Models;

namespace Survivor.Data
{
    public class SurvivorContext : DbContext
    {
        public SurvivorContext(DbContextOptions<SurvivorContext> options) : base(options)
        {

        }

        public DbSet<Competitors> Competitors { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
