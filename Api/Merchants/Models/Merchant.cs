using IkasAdminApiLibrary.Api.Common.Models;

namespace IkasAdminApiLibrary.Api.Merchants.Models
{
    public class Merchant
    {
        public Address? Address { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string Id { get; set; } = string.Empty;

        public string? LastName { get; set; }

        public string? MerchantName { get; set; }

        public int? MerchantSequence { get; set; }

        public string? PhoneNumber { get; set; }

        public string? StoreName { get; set; }
    }
}
