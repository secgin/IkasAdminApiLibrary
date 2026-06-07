using Newtonsoft.Json;

namespace IkasAdminApiLibrary.Api.Common.Models
{
    public class Address
    {
        public string Id { get; set; } = string.Empty;

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        [JsonProperty("address")]
        public string? AddressText { get; set; }

        public GeoLocation? City { get; set; }

        public string? Company { get; set; }

        public GeoLocation? Country { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool? Deleted { get; set; }

        public GeoLocation? District { get; set; }

        public string? FirstName { get; set; }

        public string? IdentityNumber { get; set; }

        public bool? IsDefault { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

        public string? PostalCode { get; set; }

        public Reference? Region { get; set; }

        public GeoLocation? State { get; set; }

        public string? TaxNumber { get; set; }

        public string? TaxOffice { get; set; }

        public string? Title { get; set; }

        public string? Type { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? Vkn { get; set; }
    }
}
