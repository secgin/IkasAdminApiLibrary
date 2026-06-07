using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Storefronts.Abstracts;
using IkasAdminApiLibrary.Api.Storefronts.Models;
using IkasAdminApiLibrary.Api.Storefronts.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Storefronts
{
    internal class StorefrontManager : IStorefrontManager
    {
        private const string ListStorefrontQuery = """
            query ListStorefront {
              listStorefront {
                createdAt
                deleted
                id
                name
                routings {
                  countryCodes
                  createdAt
                  currencyCode
                  currencySymbol
                  deleted
                  domain
                  dynamicCurrencySettings {
                    roundingFormat
                    targetCurrencyCode
                    targetCurrencySymbol
                  }
                  id
                  locale
                  path
                  priceListId
                  updatedAt
                }
                salesChannelId
                updatedAt
              }
            }
            """;

        private const string CreateStorefrontJSScriptMutation = """
            mutation CreateStorefrontJSScript($input: CreateStorefrontJSScriptInput!) {
              createStorefrontJSScript(input: $input) {
                authorizedAppId
                contentType
                createdAt
                deleted
                fileName
                id
                isActive
                isHighPriority
                name
                order
                scriptContent
                storeAppId
                storefrontId
                updatedAt
              }
            }
            """;

        private const string UpdateStorefrontJSScriptMutation = """
            mutation UpdateStorefrontJSScript($input: UpdateStorefrontJSScriptInput!) {
              updateStorefrontJSScript(input: $input) {
                authorizedAppId
                contentType
                createdAt
                deleted
                fileName
                id
                isActive
                isHighPriority
                name
                order
                scriptContent
                storeAppId
                storefrontId
                updatedAt
              }
            }
            """;

        private readonly IGraphQLService graphQLService;

        public StorefrontManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<List<Storefront>>> List()
        {
            return await graphQLService.QueryAsync<List<Storefront>>(ListStorefrontQuery, null, "listStorefront");
        }

        public async Task<IResult<StorefrontJSScript>> CreateJSScript(CreateStorefrontJSScriptInput input)
        {
            return await graphQLService.MutationQueryAsync<StorefrontJSScript>(
                CreateStorefrontJSScriptMutation,
                new { input },
                "createStorefrontJSScript");
        }

        public async Task<IResult<StorefrontJSScript>> UpdateJSScript(UpdateStorefrontJSScriptInput input)
        {
            return await graphQLService.MutationQueryAsync<StorefrontJSScript>(
                UpdateStorefrontJSScriptMutation,
                new { input },
                "updateStorefrontJSScript");
        }
    }
}
