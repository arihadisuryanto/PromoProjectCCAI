using AutoMapper;
using PromoProjectCCAI.Dtos;
using PromoProjectCCAI.Models;
using PromoProjectCCAI.Repositories.Stores;

namespace PromoProjectCCAI.Services.Stores
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _repoStore;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository repoStore, IMapper mapper)
        {
            _repoStore = repoStore;
            _mapper = mapper;
        }
        public async Task<List<StoreDto>> GetStoresAsync()
        {
            // get list data from repository:
            List<StoreModel> listStore = await _repoStore.GetStoresAsync();

            // convert list of model object to list of dto object, then return the result:
            return _mapper.Map<List<StoreModel>, List<StoreDto>>(listStore);
        }
    }
}
