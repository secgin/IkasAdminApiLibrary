using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.ProductAttributes.Models;
using IkasAdminApiLibrary.Api.ProductAttributes.Models.Inputs;

namespace IkasAdminApiLibrary.Api.ProductAttributes.Abstracts
{
    public interface IProductAttributeManager
    {
        public Task<IResult<List<ProductAttribute>>> List(ListProductAttribute? listProductAttribute = null);

        public Task<IResult<ProductAttribute>> Save(ProductAttributeInput input);
    }
}
