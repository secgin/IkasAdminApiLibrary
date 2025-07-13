namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class ProductStockLocation
    {
        public string? Id { get; set; }

        public string ProductId { get; set; }

        public float StockCount { get; set; }

        public string StockLocationId { get; set; }

        public string VariantId { get; set; }

        public ProductStockLocation()
        {
            Id = null;
            ProductId = string.Empty;
            StockCount = 0;
            StockLocationId = string.Empty;
            VariantId = string.Empty;
        }

        public ProductStockLocation(string productId, float stockCount, string stockLocationId, string variantId) : base()
        {
            ProductId = productId;
            StockCount = stockCount;
            StockLocationId = stockLocationId;
            VariantId = variantId;
        }
    }
}
