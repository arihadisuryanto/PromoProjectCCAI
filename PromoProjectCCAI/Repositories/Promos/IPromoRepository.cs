using PromoProjectCCAI.Models;

namespace PromoProjectCCAI.Repositories.Promos
{
    public interface IPromoRepository
    {
        Task<List<PromoModel>> GetPromosAsync();
        Task AddAsync(PromoModel promoModel);
        Task BulkInsertItemAsync(List<ItemModel> itemModels);
    }
}
