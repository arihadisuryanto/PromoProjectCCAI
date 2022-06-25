using Microsoft.EntityFrameworkCore;
using PromoProject;
using PromoProjectCCAI.Models;

namespace PromoProjectCCAI.Repositories.Promos
{
    public class PromoRepository : IPromoRepository
    {
        private readonly PromoDbContext _context;

        public PromoRepository(PromoDbContext context)
        {
            _context = context;
        }

        public async Task<List<PromoModel>> GetPromosAsync()
        {
            try
            {
                return await _context.Promos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddAsync(PromoModel promoModel)
        {
            try
            {
                await _context.Promos.AddAsync(promoModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task BulkInsertItemAsync(List<ItemModel> itemModels)
        {
            _context.Items.AddRange(itemModels);
            await _context.SaveChangesAsync();
        }
    }
}
