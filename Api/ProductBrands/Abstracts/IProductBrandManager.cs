using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.ProductBrands.Models;
using IkasAdminApiLibrary.Api.ProductBrands.Models.Inputs;

namespace IkasAdminApiLibrary.Api.ProductBrands.Abstracts
{
    public interface IProductBrandManager
    {
        Task<IResult<ProductBrand>> Save(ProductBrandInput productBrandInput);

        Task<IResult<ProductBrand>> SaveByName(string name);

        Task<IResult<List<ProductBrand>>> List(ListProductBrandInput? input = null);

        Task<IResult<ProductBrand?>> GetByName(string name);

        Task<IResult<bool>> Delete(DeleteProductBrandList input);
    }
}
