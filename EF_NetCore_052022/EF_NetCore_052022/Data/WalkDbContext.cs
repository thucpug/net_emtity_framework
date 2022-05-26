using EF_NetCore_052022.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EF_NetCore_052022.Data
{
    public class WalkDbContext : DbContext
    {
        public WalkDbContext(DbContextOptions<WalkDbContext> options) : base(options)
        {
        }
        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }  

    }
}
