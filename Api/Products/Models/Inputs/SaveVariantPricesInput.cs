namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class SaveVariantPricesInput
    {
        public string? PriceListId { get; set; }

        public List<VariantPriceInput> VariantPriceInputs { get; set; }

        public SaveVariantPricesInput(List<VariantPriceInput> variantPricesInputs, string? priceListId = null)
        {
            PriceListId = priceListId;
            VariantPriceInputs = variantPricesInputs;
        }
    }
}
