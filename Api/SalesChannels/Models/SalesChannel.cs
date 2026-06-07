namespace IkasAdminApiLibrary.Api.SalesChannels.Models
{
    public class SalesChannel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool? Deleted { get; set; }

        public List<SalesChannelRelation> PaymentGateways { get; set; }

        public string? PriceListId { get; set; }

        public List<SalesChannelRelation> StockLocations { get; set; }

        public SalesChannelTypeEnum? Type { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public SalesChannel()
        {
            Id = string.Empty;
            Name = string.Empty;
            PaymentGateways = [];
            StockLocations = [];
        }
    }

    public class SalesChannelRelation
    {
        public string Id { get; set; } = string.Empty;

        public int? Order { get; set; }
    }
}
