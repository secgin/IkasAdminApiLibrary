namespace IkasAdminApiLibrary.Api.PriceLists.Models
{
    public class PriceList
    {
        public string Id { get; set; }

        public bool? AddProductsAutomatically { get; set; }

        public string Currency { get; set; }

        public string? CurrencyCode { get; set; }

        public string? CurrencySymbol { get; set; }

        public string Name { get; set; }

        public List<PriceListRuleList> RuleList { get; set; }

        public PriceListTypeEnum Type { get; set; }

        public PriceList()
        {
            Id = string.Empty;
            Currency = string.Empty;
            Name = string.Empty;
            RuleList = [];
        }
    }
}
