using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PromoProjectCCAI.Dtos;
using PromoProjectCCAI.Services.Promos;
using PromoProjectCCAI.Services.Stores;

namespace PromoProjectCCAI.Controllers
{
    public class PromoController : Controller
    {
        private readonly IStoreService _serviceStore;
        private readonly IPromoService _servicePromo;

        public PromoController(IStoreService serviceStore, IPromoService servicePromo)
        {
            _serviceStore = serviceStore;
            _servicePromo = servicePromo;
        }

        public async Task<IActionResult> Create()
        {
            List<StoreDto> stores = await _serviceStore.GetStoresAsync();
            var promos = new PromoDto
            {
                ValueTypeList = new SelectList(new string[] { "Percentage", "Amount" }),
                PromoTypeList = new SelectList(new string[] { "Completed Discount", "Simple Discount", }),
                Stores = stores
            };
            return View(promos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PromoDto promoDto)
        {
            try
            {
                int countPromo = await _servicePromo.GetCountPromosAsync();
                promoDto.PromoID = "P" + DateTime.UtcNow.ToString("yyyyMMdd") + countPromo + 1.ToString().PadLeft(4, '0');

                //concatenate StoreID
                promoDto.StoreID = string.Join(",",
                    promoDto.Stores.Where(s => s.IsChecked == true).Select(s => s.StoreID).ToList());

                List<string> items = _servicePromo.GenerateItem(promoDto.Item);

                //save and generate file
                await _servicePromo.AddWithItem(promoDto, items);

                return View(promoDto);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
