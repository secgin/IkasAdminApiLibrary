namespace IkasAdminApiLibrary.Api.Orders.Models
{
    public class OrderTransaction
    {
        public double? Amount { get; set; }

        public string? AuthCode { get; set; }

        public string? CheckoutId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CurrencyCode { get; set; }

        public string? CurrencySymbol { get; set; }

        public string? CustomerId { get; set; }

        public bool? Deleted { get; set; }

        public OrderTransactionError? Error { get; set; }

        public string? GatewayReferenceId { get; set; }

        public string Id { get; set; } = string.Empty;

        public List<OrderTransactionLineItem> LineItems { get; set; } = [];

        public string? OrderId { get; set; }

        public string? PaymentGatewayCode { get; set; }

        public string? PaymentGatewayId { get; set; }

        public string? PaymentGatewayName { get; set; }

        public string? PaymentMethod { get; set; }

        public OrderPaymentMethodDetail? PaymentMethodDetail { get; set; }

        public DateTime? ProcessedAt { get; set; }

        public string? RefundReason { get; set; }

        public string? Status { get; set; }

        public string? Type { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public class OrderTransactionError
    {
        public string? Code { get; set; }

        public string? DeclineCode { get; set; }

        public string? Message { get; set; }
    }

    public class OrderTransactionLineItem
    {
        public double? FinalPrice { get; set; }

        public string Id { get; set; } = string.Empty;

        public double? Price { get; set; }

        public double? Quantity { get; set; }

        public double? TaxValue { get; set; }

        public OrderTransactionVariant? Variant { get; set; }
    }

    public class OrderTransactionVariant
    {
        public string Id { get; set; } = string.Empty;

        public string? MainImageId { get; set; }

        public string? Name { get; set; }

        public string? ProductId { get; set; }

        public string? Sku { get; set; }

        public string? Slug { get; set; }

        public string? Type { get; set; }
    }

    public class OrderPaymentMethodDetail
    {
        public string? BankName { get; set; }

        public string? BinNumber { get; set; }

        public string? CardAssociation { get; set; }

        public string? CardFamily { get; set; }

        public string? CardType { get; set; }

        public OrderInstallment? Installment { get; set; }

        public string? LastFourDigits { get; set; }

        public string? PaymentMethodName { get; set; }

        public bool? ThreeDSecure { get; set; }
    }

    public class OrderInstallment
    {
        public int? InstallmentCount { get; set; }

        public double? InstallmentPrice { get; set; }

        public double? OriginalRate { get; set; }

        public double? Rate { get; set; }

        public double? TotalPrice { get; set; }
    }
}
