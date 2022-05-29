using EF_NetCore_052022.Data;
using EF_NetCore_052022.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EF_NetCore_052022.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly WalkDbContext context;

        public WalkDifficultyRepository(WalkDbContext context)
        {
            this.context = context;
        }
        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await context.WalkDifficulties.AddAsync(walkDifficulty);
            await context.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid guid)
        {
            var walkDifficulty = await context.WalkDifficulties.FirstOrDefaultAsync(x => x.Id == guid);
            if (walkDifficulty == null)
            {
                return null;
            }
            context.WalkDifficulties.Remove(walkDifficulty);
            await context.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await context.WalkDifficulties.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid guid)
        {
            return await context.WalkDifficulties.FirstOrDefaultAsync(x => x.Id == guid);
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid guid, WalkDifficulty walkDifficulty)
        {
            var walkDefficultyEntity = await context.WalkDifficulties.FirstOrDefaultAsync(x => x.Id == guid);
            if (walkDefficultyEntity == null) return null;
            walkDefficultyEntity.Code = walkDifficulty.Code;
            await context.SaveChangesAsync();
            return walkDefficultyEntity;
        }
    }
}
