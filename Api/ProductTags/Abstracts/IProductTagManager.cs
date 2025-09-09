using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.ProductTags.Models;
using IkasAdminApiLibrary.Api.ProductTags.Models.Inputs;


namespace IkasAdminApiLibrary.Api.ProductTags.Abstracts
{
    public interface IProductTagManager
    {
        Task<IResult<IList<ProductTag>>> ListAsync(ListProductTagInput? input = null);

        Task<IResult<ProductTag>> SaveAsync(ProductTagInput productTagInput);
    }
}
