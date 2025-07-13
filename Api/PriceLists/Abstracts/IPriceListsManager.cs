using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.PriceLists.Models;
using IkasAdminApiLibrary.Api.PriceLists.Models.Inputs;

namespace IkasAdminApiLibrary.Api.PriceLists.Abstracts
{
    public interface IPriceListsManager
    {
        public Task<IResult<List<PriceList>>> GetAllAsync(ListPriceList? listPriceList = null);
    }
}
