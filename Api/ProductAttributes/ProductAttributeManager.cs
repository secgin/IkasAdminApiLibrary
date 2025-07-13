using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.ProductAttributes.Abstracts;
using IkasAdminApiLibrary.Api.ProductAttributes.Models;
using IkasAdminApiLibrary.Api.ProductAttributes.Models.Inputs;

namespace IkasAdminApiLibrary.Api.ProductAttributes
{
    internal class ProductAttributeManager : IProductAttributeManager
    {
        private readonly IGraphQLService graphQLService;

        public ProductAttributeManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<List<ProductAttribute>>> List(ListProductAttribute? listProductAttribute = null)
        {
            var query = graphQLService.CreateQuery<ProductAttribute>("listProductAttribute")
                .AddArguments(listProductAttribute ?? new ListProductAttribute())
               .AddField(p => p.Id)
               .AddField(p => p.Name)
               .AddField(p => p.Options, op => op
                   .AddField(p => p.Id)
                   .AddField(p => p.Name))
               .AddField(p => p.Description)
               .AddField(p => p.Type);

            return await graphQLService.QueryAsync<List<ProductAttribute>>(query, "listProductAttribute");
        }

        public async Task<IResult<ProductAttribute>> Save(ProductAttributeInput input)
        {
            var query = graphQLService.CreateQuery<ProductAttribute>("saveProductAttribute")
                .AddArguments(new
                {
                    input
                })
                .AddField(p => p.Id)
                .AddField(p => p.Name)
                .AddField(p => p.Description)
                .AddField(p => p.Type);

            return await graphQLService.MutationQueryAsync<ProductAttribute>(query, "saveProductAttribute");
        }
    }
}
