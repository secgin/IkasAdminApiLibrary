using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.SalesChannels.Abstracts;
using IkasAdminApiLibrary.Api.SalesChannels.Models;
using IkasAdminApiLibrary.Api.SalesChannels.Models.Inputs;

namespace IkasAdminApiLibrary.Api.SalesChannels
{
    internal class SalesChannelsManager : ISalesChannelsManager
    {
        private readonly IGraphQLService graphQLService;

        public SalesChannelsManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<SalesChannel>> Get()
        {
            var query = graphQLService.CreateQuery<SalesChannel>("getSalesChannel")
                .AddField(p => p.Id)
                .AddField(p => p.Name)
                .AddField(p => p.Type);

            return await graphQLService.QueryAsync<SalesChannel>(query, "getSalesChannel");
        }

        public async Task<IResult<List<SalesChannel>>> List(ListSalesChannelInput? input = null)
        {
            var query = graphQLService.CreateQuery<SalesChannel>("listSalesChannel")
                .AddField(p => p.Id)
                .AddField(p => p.Name)
                .AddField(p => p.Type);

            return await graphQLService.QueryAsync<List<SalesChannel>>(query, "listSalesChannel");
        }
    }
}
