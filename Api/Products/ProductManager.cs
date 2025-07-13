using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.Products.Abstracts;
using IkasAdminApiLibrary.Api.Products.Models;
using IkasAdminApiLibrary.Api.Products.Models.Inputs;
using IkasAdminApiLibrary.Api.Products.Models.Response;

namespace IkasAdminApiLibrary.Api.Products
{
    internal class ProductManager : IProductManager
    {
        private readonly IGraphQLService graphQLService;

        public ProductManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<Pagination<Product>>> List(ListProductInput? input = null)
        {
            var query = graphQLService.CreateQuery<Pagination<Product>>("listProduct")
                .AddArguments(input ?? new ListProductInput())
                .AddField(p => p.Count)
                .AddField(p => p.Data, d => d
                    .AddField(p => p.Id)
                    .AddField(p => p.Name)
                    .AddField(p => p.Type)
                    .AddField(p => p.CreatedAt)
                    .AddField(p => p.ProductVariantTypes!, v => v
                        .AddField(p => p.Order)
                        .AddField(p => p.VariantTypeId)
                        .AddField(p => p.VariantValueIds))
                    .AddField(p => p.Variants, v => v
                        .AddField(p => p.Id)
                        .AddField(p => p.Sku)
                        .AddField(p => p.BarcodeList)
                        .AddField(p => p.Prices, v => v
                            .AddField(v => v.SellPrice)
                            .AddField(v => v.BuyPrice)
                            .AddField(v => v.DiscountPrice)
                            .AddField(v => v.Currency)
                            .AddField(v => v.CurrencyCode)
                            .AddField(v => v.CurrencySymbol)
                            .AddField(v => v.PriceListId))
                        .AddField(p => p.Images!, v => v
                            .AddField(v => v.FileName)
                            .AddField(v => v.ImageId)
                            .AddField(v => v.Order)
                            .AddField(v => v.IsMain))
                        .AddField(p => p.VariantValueIds!, v => v
                            .AddField(p => p.VariantTypeId)
                            .AddField(p => p.VariantValueId))
                        .AddField(p => p.Stocks!, v => v
                            .AddField(p => p.Id)
                            .AddField(p => p.ProductId)
                            .AddField(p => p.VariantId)
                            .AddField(p => p.StockLocationId)
                            .AddField(p => p.StockCount))
                        .AddField(p => p.Weight)
                        .AddField(p => p.Attributes!, av => av
                            .AddField(p => p.ProductAttributeId)
                            .AddField(p => p.ProductAttributeOptionId)
                            .AddField(p => p.Value))
                        .AddField(p => p.IsActive)
                        .AddField(p => p.SellIfOutOfStock)
                        .AddField(p => p.HsCode))                        
                    .AddField(p => p.Attributes!, av => av
                        .AddField(p => p.ProductAttributeId)
                        .AddField(p => p.ProductAttributeOptionId)
                        .AddField(p => p.Value))
                    .AddField(p => p.Weight)
                    .AddField(p => p.SalesChannelIds)
        )
       .AddField(p => p.Limit)
       .AddField(p => p.Page)
       .AddField(p => p.HasNext);

            return await graphQLService.QueryAsync<Pagination<Product>>(query, "listProduct");
        }

        public async Task<IResult<Product>> Save(ProductInput productInput)
        {
            var query = graphQLService.CreateQuery<Product>("saveProduct")
                .AddArguments(new
                {
                    input = productInput
                })
                .AddField(p => p.Id)
                    .AddField(p => p.Name)
                    .AddField(p => p.Type)
                    .AddField(p => p.CreatedAt)
                    .AddField(p => p.ProductVariantTypes!, v => v
                        .AddField(p => p.Order)
                        .AddField(p => p.VariantTypeId)
                        .AddField(p => p.VariantValueIds))
                    .AddField(p => p.Variants, v => v
                        .AddField(p => p.Id)
                        .AddField(p => p.Sku)
                        .AddField(p => p.BarcodeList)
                        .AddField(p => p.Prices, v => v
                            .AddField(v => v.SellPrice)
                            .AddField(v => v.BuyPrice)
                            .AddField(v => v.DiscountPrice)
                            .AddField(v => v.Currency)
                            .AddField(v => v.CurrencyCode)
                            .AddField(v => v.CurrencySymbol)
                            .AddField(v => v.PriceListId))
                        .AddField(p => p.Images!, v => v
                            .AddField(v => v.FileName)
                            .AddField(v => v.ImageId)
                            .AddField(v => v.Order)
                            .AddField(v => v.IsMain))
                        .AddField(p => p.VariantValueIds!, v => v
                            .AddField(p => p.VariantTypeId)
                            .AddField(p => p.VariantValueId))
                        .AddField(p => p.Stocks!, v => v
                            .AddField(p => p.Id)
                            .AddField(p => p.ProductId)
                            .AddField(p => p.VariantId)
                            .AddField(p => p.StockLocationId)
                            .AddField(p => p.StockCount))
                        .AddField(p => p.Weight)
                        .AddField(p => p.Attributes!, av => av
                            .AddField(p => p.ProductAttributeId)
                            .AddField(p => p.ProductAttributeOptionId)
                            .AddField(p => p.Value))
                        .AddField(p => p.HsCode))
                    .AddField(p => p.Attributes!, av => av
                        .AddField(p => p.ProductAttributeId)
                        .AddField(p => p.ProductAttributeOptionId)
                        .AddField(p => p.Value))
                    .AddField(p => p.Weight)
                    .AddField(p => p.SalesChannelIds);

            return await graphQLService.MutationQueryAsync<Product>(query, "saveProduct");
        }

        public async Task<IResult<bool>> SaveVariantPrices(SaveVariantPricesInput saveVariantPricesInput)
        {
            var query = graphQLService.CreateQuery<bool>("saveVariantPrices")
                .AddArguments(new
                {
                    input = saveVariantPricesInput
                });

            return await graphQLService.MutationQueryAsync<bool>(query, "saveVariantPrices");
        }

        public async Task<IResult<ProductSearchResponse>> Search(SearchProductInput searchInput)
        {
            var query = graphQLService.CreateQuery<ProductSearchResponse>("searchProducts")
                .AddArguments(new
                {
                    input = searchInput
                })
                .AddField(p => p.Count)
                .AddField(p => p.Results, d => d
                    .AddField(p => p.Id)
                    .AddField(p => p.Name)
                    .AddField(p => p.Type)
                    .AddField(vp => vp.Variants, v => v
                        .AddField(p => p.Id)
                        .AddField(p => p.Sku)
                        .AddField(sv => sv.VariantValues!, v => v
                            .AddField(p => p.VariantTypeId)
                            .AddField(p => p.VariantValueId)
                        )
                    )
                        /*.AddField<SearchProductAttributeValue>(av => av.Attributes, av => av
                            .AddField<SearchProductAttribute>(pa => pa.ProductAttribute, pa => pa
                                .AddField(p => p.Id)
                                .AddField(p => p.Name)
                                .AddField(p => p.Type)
                            )
                            .AddField(p => p.Value)
                        )*/
                        )
                       .AddField(p => p.Limit)
                       .AddField(p => p.Page)
                       .AddField(p => p.TotalCount);

            return await graphQLService.QueryAsync<ProductSearchResponse>(query, "searchProducts");
        }
    }
}
