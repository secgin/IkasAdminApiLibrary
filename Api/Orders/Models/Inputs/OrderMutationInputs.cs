namespace IkasAdminApiLibrary.Api.Orders.Models.Inputs
{
    public class ListOrderTransactionsInput
    {
        public string OrderId { get; set; } = string.Empty;
    }

    public class FulfillOrderInput
    {
        public string OrderId { get; set; } = string.Empty;

        public bool? MarkAsReadyForShipment { get; set; }

        public List<FulfillOrderLineInput>? Lines { get; set; }

        public bool? SendNotificationToCustomer { get; set; }

        public string? SourcePackageId { get; set; }

        public TrackingInfoInput? TrackingInfoDetail { get; set; }
    }

    public class FulfillOrderLineInput
    {
        public string OrderLineItemId { get; set; } = string.Empty;

        public double Quantity { get; set; }
    }

    public class UpdateOrderPackageStatusInput
    {
        public string? ErrorMessage { get; set; }

        public string OrderId { get; set; } = string.Empty;

        public string? PackageId { get; set; }

        public string? SourceId { get; set; }

        public string Status { get; set; } = string.Empty;

        public TrackingInfoInput? TrackingInfo { get; set; }
    }

    public class TrackingInfoInput
    {
        public string? Barcode { get; set; }

        public string? CargoCompany { get; set; }

        public string? CargoCompanyId { get; set; }

        public bool? IsSendNotification { get; set; }

        public string? ShippingLabelImageBase64 { get; set; }

        public string? TrackingLink { get; set; }

        public string? TrackingNumber { get; set; }
    }

    public class CreateOrderTagInput
    {
        public string Name { get; set; } = string.Empty;
    }

    public class AddOrderTagInput
    {
        public string Name { get; set; } = string.Empty;

        public string OrderId { get; set; } = string.Empty;
    }

    public class AddOrderInvoiceInput
    {
        public string? AppId { get; set; }

        public string? Base64 { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? InvoiceData { get; set; }

        public string? InvoiceNumber { get; set; }

        public string OrderId { get; set; } = string.Empty;

        public bool? SendNotificationToCustomer { get; set; }

        public string? Type { get; set; }
    }

    public class CancelFulfillmentInput
    {
        public string OrderId { get; set; } = string.Empty;

        public string OrderPackageId { get; set; } = string.Empty;
    }
}
