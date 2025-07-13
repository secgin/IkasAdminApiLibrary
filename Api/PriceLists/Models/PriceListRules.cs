namespace IkasAdminApiLibrary.Api.PriceLists.Models
{
    public class PriceListRules
    {
        public double Amount { get; set; }

        public PriceListRulesAmountTypeEnum AmountType { get; set; }

        public PriceListRulesOperationTypeEnum OperationType { get; set; }
    }
}
