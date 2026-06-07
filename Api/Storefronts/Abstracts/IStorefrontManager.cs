using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Storefronts.Models;
using IkasAdminApiLibrary.Api.Storefronts.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Storefronts.Abstracts
{
    public interface IStorefrontManager
    {
        Task<IResult<List<Storefront>>> List();

        Task<IResult<StorefrontJSScript>> CreateJSScript(CreateStorefrontJSScriptInput input);

        Task<IResult<StorefrontJSScript>> UpdateJSScript(UpdateStorefrontJSScriptInput input);
    }
}
