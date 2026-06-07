using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.Products.Models;

namespace IkasAdminApiLibrary.Api.Customers.Models
{
    public class Customer
    {
        public string? AccountStatus { get; set; }

        public DateTime? AccountStatusUpdatedAt { get; set; }

        public List<Address> Addresses { get; set; } = [];

        public List<CustomerAttributeValue> Attributes { get; set; } = [];

        public DateTime? BirthDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public List<string> CustomerGroupIds { get; set; } = [];

        public List<string> CustomerSegmentIds { get; set; } = [];

        public int? CustomerSequence { get; set; }

        public bool? Deleted { get; set; }

        public string? Email { get; set; }

        public DateTime? EmailVerifiedDate { get; set; }

        public string? FirstName { get; set; }

        public DateTime? FirstOrderDate { get; set; }

        public string? FullName { get; set; }

        public string? Gender { get; set; }

        public string Id { get; set; } = string.Empty;

        public string? Ip { get; set; }

        public bool? IsEmailVerified { get; set; }

        public bool? IsPhoneVerified { get; set; }

        public string? LastName { get; set; }

        public DateTime? LastOrderDate { get; set; }

        public string? LastPriceListId { get; set; }

        public string? LastStorefrontRoutingId { get; set; }

        public string? Note { get; set; }

        public int? OrderCount { get; set; }

        public DateTime? PasswordUpdateDate { get; set; }

        public string? Phone { get; set; }

        public string? PhoneSubscriptionStatus { get; set; }

        public DateTime? PhoneSubscriptionStatusUpdatedAt { get; set; }

        public DateTime? PhoneVerifiedDate { get; set; }

        public string? PreferredLanguage { get; set; }

        public string? PriceListId { get; set; }

        public List<CustomerPriceListRule> PriceListRules { get; set; } = [];

        public string? RegistrationSource { get; set; }

        public string? SmsSubscriptionStatus { get; set; }

        public DateTime? SmsSubscriptionStatusUpdatedAt { get; set; }

        public string? SubscriptionStatus { get; set; }

        public DateTime? SubscriptionStatusUpdatedAt { get; set; }

        public List<string> TagIds { get; set; } = [];

        public double? TotalOrderPrice { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UserAgent { get; set; }
    }

    public class CustomerAttributeValue
    {
        public string? CustomerAttributeId { get; set; }

        public string? CustomerAttributeOptionId { get; set; }

        public string? Value { get; set; }
    }

    public class CustomerPriceListRule
    {
        public double? DiscountRate { get; set; }

        public List<CustomerPriceListRuleFilter> Filters { get; set; } = [];

        public string? PriceListId { get; set; }

        public bool? ShouldMatchAllFilters { get; set; }

        public string? Value { get; set; }

        public string? ValueType { get; set; }
    }

    public class CustomerPriceListRuleFilter
    {
        public string? Type { get; set; }

        public List<string> ValueList { get; set; } = [];
    }
}
