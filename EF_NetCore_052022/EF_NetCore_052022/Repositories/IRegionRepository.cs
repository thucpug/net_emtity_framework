using EF_NetCore_052022.Models.Domain;

namespace EF_NetCore_052022.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
