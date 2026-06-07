using IkasAdminApiLibrary.Api.Common.Models;

namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class SaveVariantStocksInputV2
    {
        public List<VariantStockInput> StockInputs { get; set; } = [];
    }

    public class VariantStockInput
    {
        public bool? Deleted { get; set; }

        public string ProductId { get; set; } = string.Empty;

        public double StockCount { get; set; }

        public string StockLocationId { get; set; } = string.Empty;

        public string VariantId { get; set; } = string.Empty;
    }

    public class SaveVariantStocksErrorData
    {
        public string ProductId { get; set; } = string.Empty;

        public string VariantId { get; set; } = string.Empty;
    }

    public class SaveVariantStocksResult : BulkOperationResult<SaveVariantStocksErrorData>
    {
    }
}
