using Microsoft.EntityFrameworkCore;
using PromoProjectCCAI.Models;

namespace PromoProject
{
    public class PromoDbContext : DbContext
    {
        public PromoDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<PromoModel> Promos { get; set; }
        public DbSet<StoreModel> Stores { get; set; }
        public DbSet<ItemModel> Items { get; set; }
    }
}
