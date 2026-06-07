namespace IkasAdminApiLibrary.Api.Storefronts.Models
{
    public class StorefrontJSScript
    {
        public string? AuthorizedAppId { get; set; }

        public string? ContentType { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool? Deleted { get; set; }

        public string? FileName { get; set; }

        public string Id { get; set; } = string.Empty;

        public bool? IsActive { get; set; }

        public bool? IsHighPriority { get; set; }

        public string Name { get; set; } = string.Empty;

        public int? Order { get; set; }

        public string? ScriptContent { get; set; }

        public string? StoreAppId { get; set; }

        public string? StorefrontId { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
