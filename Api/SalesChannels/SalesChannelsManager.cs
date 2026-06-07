using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.SalesChannels.Abstracts;
using IkasAdminApiLibrary.Api.SalesChannels.Models;
using IkasAdminApiLibrary.Api.SalesChannels.Models.Inputs;

namespace IkasAdminApiLibrary.Api.SalesChannels
{
    internal class SalesChannelsManager : ISalesChannelsManager
    {
        private const string ListSalesChannelQuery = """
            query ListSalesChannel {
              listSalesChannel {
                createdAt
                deleted
                id
                name
                paymentGateways {
                  id
                  order
                }
                priceListId
                stockLocations {
                  id
                  order
                }
                type
                updatedAt
              }
            }
            """;

        private readonly IGraphQLService graphQLService;

        public SalesChannelsManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<SalesChannel>> Get()
        {
            var result = await List();

            if (result.IsFail())
                return Result<SalesChannel>.Fail(result.GetCode(), result.GetMessage());

            var salesChannel = result.Data.FirstOrDefault();
            return salesChannel == null
                ? Result<SalesChannel>.Fail(null, "Sales channel not found")
                : Result<SalesChannel>.Success(salesChannel);
        }

        public async Task<IResult<List<SalesChannel>>> List(ListSalesChannelInput? input = null)
        {
            return await graphQLService.QueryAsync<List<SalesChannel>>(ListSalesChannelQuery, null, "listSalesChannel");
        }
    }
}
