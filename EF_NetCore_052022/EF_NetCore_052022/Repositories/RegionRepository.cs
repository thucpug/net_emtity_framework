using AutoMapper;
using EF_NetCore_052022.Data;
using EF_NetCore_052022.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EF_NetCore_052022.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly WalkDbContext walkDbContext;
        private readonly IMapper mapper;

        public RegionRepository(WalkDbContext walkDbContext, IMapper mapper)
        {
            this.walkDbContext = walkDbContext;
            this.mapper = mapper;
        }

        public IEnumerable<Region> GetAll()
        {
            return walkDbContext.Regions.ToList();
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await walkDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid guid)
        {
            return await walkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == guid);

        }
        public async Task<Region> AddSync(Region region)
        {
            region.Id = Guid.NewGuid();
            await walkDbContext.Regions.AddAsync(region);
            await walkDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid guid)
        {
            var region = await walkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == guid);
            if (region == null)
            {
                return null;

            }
            walkDbContext.Regions.Remove(region);
            await walkDbContext.SaveChangesAsync();
            return region;
        }


        public async Task<Region> UpdateAsync(Guid guid, Region region)
        {
            var regionEntity = await walkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == guid);
            if (regionEntity == null)
            {
                return null;

            }
            regionEntity.Name = region.Name;
            regionEntity.Area = region.Area;
            regionEntity.Code = region.Code;
            regionEntity.Lat = region.Lat;
            regionEntity.Long = region.Long;
            regionEntity.Population = region.Population;
            //walkDbContext.Regions.Update(regionEntity);
            await walkDbContext.SaveChangesAsync();
            return regionEntity;
        }
    }
}
