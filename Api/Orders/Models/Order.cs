using IkasAdminApiLibrary.Api.Common.Models;

namespace IkasAdminApiLibrary.Api.Orders.Models
{
    public class Order
    {
        public bool? Archived { get; set; }

        public Address? BillingAddress { get; set; }

        public string? CancelReason { get; set; }

        public DateTime? CancelledAt { get; set; }

        public string? CartId { get; set; }

        public string? CartStatus { get; set; }

        public string? CheckoutId { get; set; }

        public string? CouponCode { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CurrencyCode { get; set; }

        public string? CurrencySymbol { get; set; }

        public OrderCustomer? Customer { get; set; }

        public string? CustomerId { get; set; }

        public bool? Deleted { get; set; }

        public DateTime? DueDate { get; set; }

        public bool? Edited { get; set; }

        public string Id { get; set; } = string.Empty;

        public List<OrderInvoice> Invoices { get; set; } = [];

        public int? ItemCount { get; set; }

        public string? MerchantId { get; set; }

        public double? NetTotalFinalPrice { get; set; }

        public string? Note { get; set; }

        public List<OrderLineItem> OrderLineItems { get; set; } = [];

        public string? OrderNumber { get; set; }

        public string? OrderPackageStatus { get; set; }

        public List<OrderPackage> OrderPackages { get; set; } = [];

        public string? OrderPaymentStatus { get; set; }

        public int? OrderSequence { get; set; }

        public List<string> OrderTagIds { get; set; } = [];

        public DateTime? OrderedAt { get; set; }

        public List<OrderPaymentMethod> PaymentMethods { get; set; } = [];

        public Reference? PriceList { get; set; }

        public string? PriceListId { get; set; }

        public Reference? SalesChannel { get; set; }

        public string? SalesChannelId { get; set; }

        public Address? ShippingAddress { get; set; }

        public List<OrderShippingLine> ShippingLines { get; set; } = [];

        public string? ShippingMethod { get; set; }

        public string? SourceId { get; set; }

        public string? Status { get; set; }

        public Reference? StockLocation { get; set; }

        public string? StockLocationId { get; set; }

        public Reference? Storefront { get; set; }

        public string? StorefrontId { get; set; }

        public List<OrderTaxLine> TaxLines { get; set; } = [];

        public double? TotalFinalPrice { get; set; }

        public double? TotalPrice { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public class OrderCustomer
    {
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? FullName { get; set; }

        public string Id { get; set; } = string.Empty;

        public bool? IsGuestCheckout { get; set; }

        public string? LastName { get; set; }

        public bool? NotificationsAccepted { get; set; }

        public string? Phone { get; set; }

        public string? PreferredLanguage { get; set; }
    }

    public class OrderLineItem
    {
        public DateTime? CreatedAt { get; set; }

        public string? CurrencyCode { get; set; }

        public string? CurrencySymbol { get; set; }

        public bool? Deleted { get; set; }

        public double? DiscountPrice { get; set; }

        public bool? Edited { get; set; }

        public double? FinalPrice { get; set; }

        public double? FinalUnitPrice { get; set; }

        public string Id { get; set; } = string.Empty;

        public double? Price { get; set; }

        public double? Quantity { get; set; }

        public string? SourceId { get; set; }

        public string? Status { get; set; }

        public DateTime? StatusUpdatedAt { get; set; }

        public string? StockLocationId { get; set; }

        public double? TaxValue { get; set; }

        public double? UnitPrice { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public class OrderPackage
    {
        public DateTime? CreatedAt { get; set; }

        public bool? Deleted { get; set; }

        public string? ErrorMessage { get; set; }

        public string Id { get; set; } = string.Empty;

        public string? Note { get; set; }

        public List<string> OrderLineItemIds { get; set; } = [];

        public string? OrderPackageFulfillStatus { get; set; }

        public string? OrderPackageNumber { get; set; }

        public string? SourceId { get; set; }

        public string? StockLocationId { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public class OrderPaymentMethod
    {
        public bool? IsAlternativeGateway { get; set; }

        public string? PaymentGatewayCode { get; set; }

        public string? PaymentGatewayId { get; set; }

        public string? PaymentGatewayName { get; set; }

        public double? Price { get; set; }

        public string? Type { get; set; }
    }

    public class OrderShippingLine
    {
        public double? FinalPrice { get; set; }

        public bool? IsRefunded { get; set; }

        public string? PaymentMethod { get; set; }

        public double? Price { get; set; }

        public string? PriceListId { get; set; }

        public string? ShippingSettingsId { get; set; }

        public string? ShippingZoneRateId { get; set; }

        public double? TaxValue { get; set; }

        public string? Title { get; set; }

        public string? TransactionId { get; set; }
    }

    public class OrderInvoice
    {
        public string? AppId { get; set; }

        public string? AppName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool? HasPdf { get; set; }

        public string Id { get; set; } = string.Empty;

        public string? InvoiceData { get; set; }

        public string? InvoiceNumber { get; set; }

        public string? StoreAppId { get; set; }

        public string? Type { get; set; }
    }

    public class OrderTaxLine
    {
        public double? Price { get; set; }

        public double? Rate { get; set; }
    }
}
