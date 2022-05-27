using EF_NetCore_052022.Models.Domain;

namespace EF_NetCore_052022.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid guid);
        Task<Region> AddSync(Region region);
        Task<Region> DeleteAsync(Guid guid);
        Task<Region> UpdateAsync(Guid guid,Region region);
    }
}
