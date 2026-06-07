using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.PriceLists.Abstracts;
using IkasAdminApiLibrary.Api.PriceLists.Models;
using IkasAdminApiLibrary.Api.PriceLists.Models.Inputs;

namespace IkasAdminApiLibrary.Api.PriceLists
{
    internal class PriceListsManager : IPriceListsManager
    {
        private const string ListPriceListQuery = """
            query ListPriceList {
              listPriceList {
                addProductsAutomatically
                createdAt
                currency
                currencyCode
                currencySymbol
                deleted
                id
                name
                ruleList {
                  basePriceListId
                  currencyRateSettings {
                    amount
                    type
                  }
                  currencySettings {
                    roundingFormat
                  }
                  rules {
                    amount
                    amountType
                    operationType
                  }
                }
                type
                updatedAt
              }
            }
            """;

        private readonly IGraphQLService graphQLService;

        public PriceListsManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<List<PriceList>>> GetAllAsync(ListPriceList? listPriceList = null)
        {
            return await graphQLService.QueryAsync<List<PriceList>>(ListPriceListQuery, null, "listPriceList");
        }
    }
}
