using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.ProductBrands.Models;
using IkasAdminApiLibrary.Api.ProductBrands.Models.Inputs;

namespace IkasAdminApiLibrary.Api.ProductBrands.Abstracts
{
    public interface IProductBrandManager
    {
        public Task<IResult<ProductBrand>> Save(ProductBrandInput productBrandInput);

        public Task<IResult<ProductBrand>> SaveByName(string name);

        public Task<IResult<List<ProductBrand>>> List(ListProductBrandInput? input = null);

        public Task<IResult<ProductBrand?>> GetByName(string name);
    }
}
