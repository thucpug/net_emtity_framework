using EF_NetCore_052022.Models.Domain;

namespace EF_NetCore_052022.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> GetAsync(Guid guid);
        Task<IEnumerable<Walk>> GetAllAsync();
        Task<Walk> AddAsync(Walk walk);
        Task<Walk> UpdateAsync(Guid guid, Walk walk);
        Task<Walk> DeleteAsync(Guid guid);

    }
}
