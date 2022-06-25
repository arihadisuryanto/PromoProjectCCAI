using PromoProjectCCAI.Models;

namespace PromoProjectCCAI.Repositories.Stores
{
    public interface IStoreRepository
    {
        public Task<List<StoreModel>> GetStoresAsync();
    }
}
