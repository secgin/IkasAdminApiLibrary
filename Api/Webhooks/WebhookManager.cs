using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Webhooks.Abstracts;
using IkasAdminApiLibrary.Api.Webhooks.Models;
using IkasAdminApiLibrary.Api.Webhooks.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Webhooks
{
    internal class WebhookManager : IWebhookManager
    {
        private const string ListWebhookQuery = """
            query ListWebhook {
              listWebhook {
                createdAt
                deleted
                endpoint
                id
                scope
                updatedAt
              }
            }
            """;

        private const string SaveWebhooksMutation = """
            mutation SaveWebhooks($input: WebhookInput!) {
              saveWebhooks(input: $input) {
                createdAt
                deleted
                endpoint
                id
                scope
                updatedAt
              }
            }
            """;

        private readonly IGraphQLService graphQLService;

        public WebhookManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<List<Webhook>>> ListAsync()
        {
            return await graphQLService.QueryAsync<List<Webhook>>(ListWebhookQuery, null, "listWebhook");
        }

        public async Task<IResult<List<Webhook>>> SaveAsync(WebhookInput input)
        {
            return await graphQLService.MutationQueryAsync<List<Webhook>>(
                SaveWebhooksMutation,
                new { input },
                "saveWebhooks");
        }

        public async Task<IResult<bool>> DeleteAsync(List<string> scopes)
        {
            var query = graphQLService.CreateQuery<bool>("deleteWebhook")
               .AddArguments(new
               {
                   scopes
               });

            return await graphQLService.MutationQueryAsync<bool>(query, "deleteWebhook");
        }
    }
}
