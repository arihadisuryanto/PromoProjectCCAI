using AutoMapper;
using PromoProjectCCAI.Dtos;
using PromoProjectCCAI.Models;
using PromoProjectCCAI.Repositories.Promos;
using System.Text;
using System.Web;

namespace PromoProjectCCAI.Services.Promos
{
    public class PromoService : IPromoService
    {
        private readonly IPromoRepository _repoPromo;
        private readonly IMapper _mapper;

        public PromoService(IPromoRepository repoPromo, IMapper mapper)
        {
            _repoPromo = repoPromo;
            _mapper = mapper;
        }
        public async Task<List<PromoDto>> GetPromosAsync()
        {
            // get list data from repository:
            List<PromoModel> listPromo = await _repoPromo.GetPromosAsync();

            // convert list of model object to list of dto object, then return the result:
            return _mapper.Map<List<PromoModel>, List<PromoDto>>(listPromo);
        }

        public async Task<int> GetCountPromosAsync()
        {
            List<PromoDto> listPromos = await GetPromosAsync();

            // convert list of model object to list of dto object, then return the result:
            return listPromos.Count;
        }

        public List<string> GenerateItem(IFormFile item)
        {
            List<string> items = new List<string>();
            using (var reader = new StreamReader(item.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    items.Add(reader.ReadLine());
                }
                items.RemoveAt(0);
            }

            return items;
        }

        public async Task AddWithItem(PromoDto promo, List<string> items)
        {
            //insert data promo
            await AddAsync(promo);

            List<ItemModel> itemModels = new List<ItemModel>();
            foreach (var item in items)
            {
                var itemModel = new ItemModel
                {
                    PromoID = promo.PromoID,
                    ItemName = item
                };
                itemModels.Add(itemModel);
            }

            //insert data item
            await BulkAddItemAsync(itemModels);

            //generate file
            GenerateFile(promo, items);
        }
        private async Task AddAsync(PromoDto promoDto)
        {
            // convert from dto object to model object:
            PromoModel promo = _mapper.Map<PromoDto, PromoModel>(promoDto);

            // add to promo:
            await _repoPromo.AddAsync(promo);
        }

        private async Task BulkAddItemAsync(List<ItemModel> itemModels)
        {
            // add items:
            await _repoPromo.BulkInsertItemAsync(itemModels);
        }

        private void GenerateFile(PromoDto promo, List<string> items)
        {
            var print = new StringBuilder();
            print.AppendLine($"FHEAD|{promo.PromoDescription}|||;");
            foreach (string i in items)
            {
                print.AppendLine($"FITEM|{i}|{promo.PromoType.Substring(0, 1)}|{promo.Value}|;");
            }
            foreach (StoreDto s in promo.Stores.Where(s => s.IsChecked == true))
            {
                print.AppendLine($"FSTORE|{s.StoreID}|{Convert.ToDateTime(promo.StartDate).ToString("yyyyMMdd")}|{Convert.ToDateTime(promo.EndDate).ToString("yyyyMMdd")}|;");
            }
            print.AppendLine("FTAIL||||");

            //save file on specific folder
            var fileByte = Encoding.UTF8.GetBytes(print.ToString());
            File.WriteAllBytes("../PromoProjectCCAI/Content/Download/" + promo.PromoID + ".txt", fileByte);
        }
    }
}
