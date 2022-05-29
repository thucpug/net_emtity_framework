using EF_NetCore_052022.Models.Domain;

namespace EF_NetCore_052022.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();
        Task<WalkDifficulty> GetAsync(Guid guid);
        Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty);
        Task<WalkDifficulty> UpdateAsync(Guid guid, WalkDifficulty walkDifficulty);
        Task<WalkDifficulty> DeleteAsync(Guid guid);
    }
}
