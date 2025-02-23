using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories
{
    public interface IItemsRepository
    {
        Task CreateAsync(Items entity);
        Task<IReadOnlyCollection<Items>> GetAllAsync();
        Task<Items> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsyn(Items entity);
    }
}