using Microsoft.EntityFrameworkCore;
using PromoProject;
using PromoProjectCCAI.Models;

namespace PromoProjectCCAI.Repositories.Stores
{
    public class StoreRepository : IStoreRepository
    {
        private readonly PromoDbContext _context;

        public StoreRepository(PromoDbContext context)
        {
            _context = context;
        }

        public async Task<List<StoreModel>> GetStoresAsync()
        {
            try
            {
                return await _context.Stores.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
