namespace IkasAdminApiLibrary.Api.StockLocations.Models.Inputs
{
    public class ProductStockLocationInput
    {
        public string? Id { get; set; }

        public string ProductId { get; }

        public string VariantId { get; }

        public string StockLocationId { get; }

        public float StockCount { get; }

        public ProductStockLocationInput(string productId, string variantId, string stockLocationId, float stockCount)
        {
            ProductId = productId;
            VariantId = variantId;
            StockLocationId = stockLocationId;
            StockCount = stockCount;
        }
    }
}
