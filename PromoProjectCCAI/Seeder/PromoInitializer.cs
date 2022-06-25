using Microsoft.EntityFrameworkCore;
using PromoProject;
using PromoProjectCCAI.Models;

namespace PromoProjectCCAI.Seeder
{
    public class PromoInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                PromoDbContext context = serviceScope.ServiceProvider.GetService<PromoDbContext>();

                if (context is not null)
                {
                    context.Database.Migrate();

                    // Stage
                    if (!context.Stores.Any())
                    {
                        context.Stores.AddRange(new List<StoreModel>()
                    {
                        new StoreModel()
                        {
                            StoreID = 111,
                            StoreName = "Toko Jakarta"
                        },
                        new StoreModel()
                        {
                            StoreID = 222,
                            StoreName = "Toko Tangerang"
                        },
                        new StoreModel()
                        {
                            StoreID = 333,
                            StoreName = "Toko Bogor"
                        },
                        new StoreModel()
                        {
                            StoreID = 444,
                            StoreName = "Toko Bandung"
                        }
                    });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
