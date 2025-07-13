namespace IkasAdminApiLibrary.Api.PriceLists.Models
{
    public class PriceListRuleList
    {
        public string? BasePriceListId { get; set; }

        public PriceListCurrencyRateSettings? CurrencyRateSettings { get; set; }

        public required PriceListCurrencySettings CurrencySettings { get; set; }

        public required List<PriceListRules> Rules { get; set; }
    }
}
