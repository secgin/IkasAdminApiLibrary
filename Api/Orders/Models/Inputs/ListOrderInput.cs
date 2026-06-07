using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.Common.Models.ValueObjects;

namespace IkasAdminApiLibrary.Api.Orders.Models.Inputs
{
    public class ListOrderInput
    {
        public StringFilterInput? BranchId { get; set; }

        public StringFilterInput? BranchSessionId { get; set; }

        public DateFilterInput? ClosedAt { get; set; }

        public StringFilterInput? CustomerEmail { get; set; }

        public StringFilterInput? CustomerId { get; set; }

        public StringFilterInput? Id { get; set; }

        public StringFilterInput? InvoicesStoreAppId { get; set; }

        public StringFilterInput? OrderNumber { get; set; }

        public EnumFilterInput? OrderPackageStatus { get; set; }

        public EnumFilterInput? OrderPaymentStatus { get; set; }

        public StringFilterInput? OrderTagIds { get; set; }

        public DateFilterInput? OrderedAt { get; set; }

        public PaginationInput Pagination { get; set; } = new(20, 1);

        public EnumFilterInput? PaymentMethodType { get; set; }

        public StringFilterInput? SalesChannelId { get; set; }

        public string? Search { get; set; }

        public EnumFilterInput? ShippingMethod { get; set; }

        public string? Sort { get; set; }

        public EnumFilterInput? Status { get; set; }

        public StringFilterInput? StockLocationId { get; set; }

        public StringFilterInput? TerminalId { get; set; }

        public DateFilterInput? UpdatedAt { get; set; }
    }
}
