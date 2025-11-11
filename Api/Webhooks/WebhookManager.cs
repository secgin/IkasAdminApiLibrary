using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Webhooks.Abstracts;
using IkasAdminApiLibrary.Api.Webhooks.Models;
using IkasAdminApiLibrary.Api.Webhooks.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Webhooks
{
    internal class WebhookManager : IWebhookManager
    {
        private readonly IGraphQLService graphQLService;

        public WebhookManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<List<Webhook>>> ListAsync()
        {
            var query = graphQLService.CreateQuery<Webhook>("listWebhook")
              .AddField(p => p.Id)
              .AddField(p => p.Endpoint)
              .AddField(p => p.Scope);

            return await graphQLService.QueryAsync<List<Webhook>>(query, "listWebhook");
        }

        public async Task<IResult<List<Webhook>>> SaveAsync(WebhookInput input)
        {
            var query = graphQLService.CreateQuery<Webhook>("saveWebhook")
               .AddArguments(new
               {
                   input
               })
               .AddField(p => p.Id)
               .AddField(p => p.Endpoint)
               .AddField(p => p.Scope);

            return await graphQLService.MutationQueryAsync<List<Webhook>>(query, "saveWebhook");
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
