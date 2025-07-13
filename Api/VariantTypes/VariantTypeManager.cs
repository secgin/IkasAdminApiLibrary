using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.VariantTypes.Abstracts;
using IkasAdminApiLibrary.Api.VariantTypes.Models;
using IkasAdminApiLibrary.Api.VariantTypes.Models.Inputs;

namespace IkasAdminApiLibrary.Api.VariantTypes
{
    internal class VariantTypeManager : IVariantTypeManager
    {
        private readonly IGraphQLService graphQLService;

        public VariantTypeManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<List<VariantType>>> List(ListVariantTypeInput? input = null)
        {
            var query = graphQLService.CreateQuery<VariantType>("listVariantType")
                .AddArguments(input ?? new ListVariantTypeInput())
                .AddField(p => p.Id)
                .AddField(p => p.Name)
                .AddField(p => p.SelectionType)
                .AddField(p => p.Values, v => v
                    .AddField(p => p.Id)
                    .AddField(p => p.ColorCode)
                    .AddField(p => p.Name)
                    .AddField(p => p.ThumbnailImageId));

            return await graphQLService.QueryAsync<List<VariantType>>(query, "listVariantType");
        }

        public async Task<IResult<VariantType>> Save(VariantTypeInput variantTypeInput)
        {
            var query = graphQLService.CreateQuery<VariantType>("saveVariantType")
                .AddArguments(new
                {
                    input = variantTypeInput
                })
                .AddField(p => p.Id)
                .AddField(p => p.Name)
                .AddField(p => p.SelectionType)
                .AddField(p => p.Values, v => v
                    .AddField(p => p.Id)
                    .AddField(p => p.ColorCode)
                    .AddField(p => p.Name)
                    .AddField(p => p.ThumbnailImageId));

            return await graphQLService.MutationQueryAsync<VariantType>(query, "saveVariantType");
        }
    }
}
