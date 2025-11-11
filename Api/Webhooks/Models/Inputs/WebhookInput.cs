namespace IkasAdminApiLibrary.Api.Webhooks.Models.Inputs
{
    public class WebhookInput
    {
        public string Endpoint { get; }

        public List<string> SalesChannelIds { get; }

        public List<string> Scopes { get; }

        public WebhookInput(string endpoint, List<string> salesChannelIds, List<string> scopes)
        {
            Endpoint = endpoint;
            SalesChannelIds = salesChannelIds;
            Scopes = scopes;
        }
    }
}
