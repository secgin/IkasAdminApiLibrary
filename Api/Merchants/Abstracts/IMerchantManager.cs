using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Merchants.Models;

namespace IkasAdminApiLibrary.Api.Merchants.Abstracts
{
    public interface IMerchantManager
    {
        Task<IResult<Merchant>> Get();

        Task<IResult<List<MerchantSetting>>> ListSettings();
    }
}
