using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.Products.Models;
using IkasAdminApiLibrary.Api.Products.Models.Inputs;
using IkasAdminApiLibrary.Api.Products.Models.Response;

namespace IkasAdminApiLibrary.Api.Products.Abstracts
{
    public interface IProductManager
    {
        public Task<IResult<Product>> Save(ProductInput productInput);

        public Task<IResult<bool>> SaveVariantPrices(SaveVariantPricesInput saveVariantPricesInput);

        public Task<IResult<Pagination<Product>>> List(ListProductInput? input = null);

        public Task<IResult<Product>> Create(CreateProductInput input);

        public Task<IResult<Product>> Update(UpdateProductInput input);

        public Task<IResult<Product>> AddVariant(AddVariantToProductInput input);

        public Task<IResult<UpdateVariantPricesResult>> UpdateVariantPrices(UpdateVariantPricesInput input);

        public Task<IResult<SaveVariantStocksResult>> SaveVariantStocks(SaveVariantStocksInputV2 input);

        public Task<IResult<UpdateSalesChannelStatusResult>> UpdateSalesChannelStatus(UpdateSalesChannelStatusInput input);

        public Task<IResult<ProductSearchResponse>> Search(SearchProductInput searchInput);
    }
}
