using IkasAdminApiLibrary.Api.Common.Models;

namespace IkasAdminApiLibrary.Api.Merchants.Models
{
    public class MerchantSetting
    {
        public string? AccessPermission { get; set; }

        public DateTime? AccessPermissionToDate { get; set; }

        public Address? Address { get; set; }

        public Address? BillingAddress { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CurrencyCode { get; set; }

        public List<CurrencyFormat> CurrencyFormats { get; set; } = [];

        public string? CurrencySymbol { get; set; }

        public string? DefaultLocale { get; set; }

        public bool? Deleted { get; set; }

        public string Id { get; set; } = string.Empty;

        public string? LogoId { get; set; }

        public string? MerchantName { get; set; }

        public string? Phone { get; set; }

        public bool? RequireMFAForAllStaffs { get; set; }

        public string? Timezone { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public class CurrencyFormat
    {
        public string? CurrencyCode { get; set; }

        public string? DecimalSeparator { get; set; }

        public bool? OmitZeroDecimal { get; set; }

        public string? Symbol { get; set; }

        public string? SymbolPosition { get; set; }

        public string? ThousandSeparator { get; set; }
    }
}
