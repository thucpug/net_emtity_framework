using EF_NetCore_052022.Data;
using EF_NetCore_052022.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EF_NetCore_052022.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly WalkDbContext context;

        public WalkRepository(WalkDbContext context)
        {
            this.context = context;
        }
        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await context.Walks.AddAsync(walk);
            await context.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid guid)
        {
            var walk = await context.Walks.FirstOrDefaultAsync(x => x.Id == guid);
            if (walk == null)
            {
                return null;
            }
            context.Walks.Remove(walk);
            await context.SaveChangesAsync();
            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await context.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid guid)
        {
            return await context.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == guid);
        }

        public async Task<Walk> UpdateAsync(Guid guid, Walk walk)
        {
            var walkEntity = await context.Walks.FirstOrDefaultAsync(x => x.Id == guid);
            if (walkEntity == null)
            {
                return null;
            }
            walkEntity.Name = walk.Name;
            walkEntity.Length = walk.Length;
            walkEntity.RegionId = walk.RegionId;
            walkEntity.WalkDifficultyId = walk.WalkDifficultyId;
            await context.SaveChangesAsync();
            return walkEntity;
        }
    }
}
