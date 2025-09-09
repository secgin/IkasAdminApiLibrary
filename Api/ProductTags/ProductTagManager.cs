using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.ProductTags.Abstracts;
using IkasAdminApiLibrary.Api.ProductTags.Models;
using IkasAdminApiLibrary.Api.ProductTags.Models.Inputs;

namespace IkasAdminApiLibrary.Api.ProductTags
{
    internal class ProductTagManager : IProductTagManager
    {
        private readonly IGraphQLService graphQLService;

        public ProductTagManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<IList<ProductTag>>> ListAsync(ListProductTagInput? input = null)
        {
            var query = graphQLService.CreateQuery<ProductTag>("listProductTag")
                .AddArguments(input ?? new ListProductTagInput())
               .AddField(p => p.Id)
               .AddField(p => p.Name);

            return await graphQLService.QueryAsync<IList<ProductTag>>(query, "listProductTag");
        }

        public async Task<IResult<ProductTag>> SaveAsync(ProductTagInput productTagInput)
        {
            var query = graphQLService.CreateQuery<ProductTag>("saveProductTag")
                .AddArguments(new
                {
                    input = productTagInput
                })
                .AddField(p => p.Id)
                .AddField(p => p.Name);

            return await graphQLService.MutationQueryAsync<ProductTag>(query, "saveProductTag");
        }
    }
}
