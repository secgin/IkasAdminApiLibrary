using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.StockLocations.Models;
using IkasAdminApiLibrary.Api.StockLocations.Models.Inputs;

namespace IkasAdminApiLibrary.Api.StockLocations.Abstracts
{
    public interface IStockLocationManager
    {
        public Task<IResult<List<StokLocation>>> ListStockLocations(ListStockLocationInput? input = null);

        public Task<IResult<Pagination<ProductStockLocation>>> ListProductStockLocations(ListProductStockLocationInput? input = null);

        public Task<IResult<bool>> SaveProductStockLocations(SaveStockLocationsInput input);
    }
}
