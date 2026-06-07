namespace IkasAdminApiLibrary.Api.Storefronts.Models
{
    public class Storefront
    {
        public DateTime? CreatedAt { get; set; }

        public bool? Deleted { get; set; }

        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public List<StorefrontRouting> Routings { get; set; } = [];

        public string? SalesChannelId { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public class StorefrontRouting
    {
        public List<string> CountryCodes { get; set; } = [];

        public DateTime? CreatedAt { get; set; }

        public string? CurrencyCode { get; set; }

        public string? CurrencySymbol { get; set; }

        public bool? Deleted { get; set; }

        public string? Domain { get; set; }

        public DynamicCurrencySettings? DynamicCurrencySettings { get; set; }

        public string Id { get; set; } = string.Empty;

        public string? Locale { get; set; }

        public string? Path { get; set; }

        public string? PriceListId { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public class DynamicCurrencySettings
    {
        public string? RoundingFormat { get; set; }

        public string? TargetCurrencyCode { get; set; }

        public string? TargetCurrencySymbol { get; set; }
    }
}
