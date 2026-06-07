using IkasAdminApiLibrary.Api.Common.Models;

namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class UpdateVariantPricesInput
    {
        public string? PriceListId { get; set; }

        public List<VariantPriceUpdateInput> VariantPriceInputs { get; set; } = [];
    }

    public class VariantPriceUpdateInput
    {
        public bool? Deleted { get; set; }

        public VariantPriceValueInput Price { get; set; } = new();

        public string ProductId { get; set; } = string.Empty;

        public string VariantId { get; set; } = string.Empty;
    }

    public class VariantPriceValueInput
    {
        public double? BuyPrice { get; set; }

        public double? DiscountPrice { get; set; }

        public double SellPrice { get; set; }
    }

    public class UpdateVariantPricesErrorData
    {
        public string ProductId { get; set; } = string.Empty;

        public VariantPriceValueInput? Price { get; set; }

        public string VariantId { get; set; } = string.Empty;
    }

    public class UpdateVariantPricesResult : BulkOperationResult<UpdateVariantPricesErrorData>
    {
    }
}
