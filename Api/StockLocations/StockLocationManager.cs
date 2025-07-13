using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.StockLocations.Abstracts;
using IkasAdminApiLibrary.Api.StockLocations.Models;
using IkasAdminApiLibrary.Api.StockLocations.Models.Inputs;

namespace IkasAdminApiLibrary.Api.StockLocations
{
    internal class StockLocationManager : IStockLocationManager
    {
        private readonly IGraphQLService graphQLService;

        public StockLocationManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<Pagination<ProductStockLocation>>> ListProductStockLocations(ListProductStockLocationInput? input = null)
        {
            var query = graphQLService.CreateQuery<Pagination<ProductStockLocation>>("listProductStockLocation")
               .AddArguments(input ?? new ListProductStockLocationInput())
               .AddField(p => p.Count)
               .AddField(p => p.Data, d => d
                   .AddField(p => p.Id)
                   .AddField(p => p.ProductId)
                   .AddField(p => p.StockLocationId)
                   .AddField(p => p.StockCount)
                   .AddField(p => p.VariantId)
               )
              .AddField(p => p.Limit)
              .AddField(p => p.Page);

            return await graphQLService.QueryAsync<Pagination<ProductStockLocation>>(query, "listProductStockLocation");
        }

        public async Task<IResult<List<StokLocation>>> ListStockLocations(ListStockLocationInput? input = null)
        {
            var query = graphQLService.CreateQuery<StokLocation>("listStockLocation")
                .AddArguments(input ?? new ListStockLocationInput())
                .AddField(p => p.Id)
                .AddField(p => p.Name)
                .AddField(p => p.Type);

            return await graphQLService.QueryAsync<List<StokLocation>>(query, "listStockLocation");
        }

        public async Task<IResult<bool>> SaveProductStockLocations(SaveStockLocationsInput input)
        {
            var query = graphQLService.CreateQuery<bool>("saveProductStockLocations")
                .AddArguments(new
                {
                    input
                });

            return await graphQLService.MutationQueryAsync<bool>(query, "saveProductStockLocations");
        }
    }
}
