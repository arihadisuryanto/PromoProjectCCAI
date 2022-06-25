using PromoProjectCCAI.Dtos;

namespace PromoProjectCCAI.Services.Stores
{
    public interface IStoreService
    {
        Task<List<StoreDto>> GetStoresAsync();
    }
}
