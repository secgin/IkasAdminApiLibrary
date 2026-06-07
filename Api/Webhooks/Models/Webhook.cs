namespace IkasAdminApiLibrary.Api.Webhooks.Models
{
    public class Webhook
    {
        public string Id { get; set; } = string.Empty;

        public string Endpoint { get; set; } = string.Empty;

        public string Scope { get; set; } = string.Empty;

        public DateTime? CreatedAt { get; set; }

        public bool? Deleted { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
