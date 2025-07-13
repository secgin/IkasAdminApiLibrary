using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Common.Models.ValueObjects;
using IkasAdminApiLibrary.Api.ProductBrands.Abstracts;
using IkasAdminApiLibrary.Api.ProductBrands.Models;
using IkasAdminApiLibrary.Api.ProductBrands.Models.Inputs;

namespace IkasAdminApiLibrary.Api.ProductBrands
{
    internal class ProductBrandManager : IProductBrandManager
    {
        private readonly IGraphQLService graphQLService;

        public ProductBrandManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<ProductBrand?>> GetByName(string name)
        {
            var result = await List(new ListProductBrandInput
            {
                Name = StringFilterInput.Equal(name)
            });
            if (result.IsFail())
                return Result<ProductBrand?>.Fail(result.GetCode(), result.GetMessage());

            return Result<ProductBrand?>.Success(result.Data?.FirstOrDefault() ?? null, result.GetCode(), result.GetMessage());
        }

        public async Task<IResult<List<ProductBrand>>> List(ListProductBrandInput? input = null)
        {
            var query = graphQLService.CreateQuery<ProductBrand>("listProductBrand")
                .AddArguments(input ?? new ListProductBrandInput())
               .AddField(p => p.Id)
               .AddField(p => p.Name)
               .AddField(p => p.CreatedAt);

            return await graphQLService.QueryAsync<List<ProductBrand>>(query, "listProductBrand");
        }

        public async Task<IResult<ProductBrand>> Save(ProductBrandInput productBrandInput)
        {
            var query = graphQLService.CreateQuery<ProductBrand>("saveProductBrand")
                .AddArguments(new
                {
                    input = productBrandInput
                })
                .AddField(p => p.Id)
                .AddField(p => p.Name)
                .AddField(p => p.CreatedAt);

            return await graphQLService.MutationQueryAsync<ProductBrand>(query, "saveProductBrand");
        }

        public async Task<IResult<ProductBrand>> SaveByName(string name)
        {
            return await Save(new ProductBrandInput(name, []));
        }
    }
}
