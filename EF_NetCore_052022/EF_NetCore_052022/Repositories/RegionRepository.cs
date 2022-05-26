using EF_NetCore_052022.Data;
using EF_NetCore_052022.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EF_NetCore_052022.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly WalkDbContext walkDbContext;
        public RegionRepository(WalkDbContext walkDbContext)
        {
            this.walkDbContext = walkDbContext;
        }
        public IEnumerable<Region> GetAll()
        {
            Thread.Sleep(5000);
            return walkDbContext.Regions.ToList();
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            Thread.Sleep(5000);
            return await walkDbContext.Regions.ToListAsync();
        }
    }
}
