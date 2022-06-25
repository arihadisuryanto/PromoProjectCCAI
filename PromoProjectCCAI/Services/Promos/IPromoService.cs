using PromoProjectCCAI.Dtos;

namespace PromoProjectCCAI.Services.Promos
{
    public interface IPromoService
    {
        Task<List<PromoDto>> GetPromosAsync();
        Task<int> GetCountPromosAsync();
        List<string> GenerateItem(IFormFile item);
        Task AddWithItem(PromoDto promo, List<string> items);
    }
}
