using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Webhooks.Models;
using IkasAdminApiLibrary.Api.Webhooks.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Webhooks.Abstracts
{
    public interface IWebhookManager
    {
        Task<IResult<List<Webhook>>> ListAsync();

        Task<IResult<List<Webhook>>> SaveAsync(WebhookInput input);

        Task<IResult<bool>> DeleteAsync(List<string> scopes);
    }
}
