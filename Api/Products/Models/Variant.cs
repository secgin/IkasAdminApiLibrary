namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class Variant
    {
        public string Id { get; set; }

        public List<ProductAttributeValue>? Attributes { get; set; }

        public List<string>? BarcodeList { get; set; }

        //bundleSettings
        //fileId

        public string? HsCode { get; set; }

        public List<ProductImage>? Images { get; set; }

        public bool IsActive { get; set; }

        public List<ProductPrice> Prices { get; set; }

        public bool? SellIfOutOfStock { get; set; }

        public string Sku { get; set; }

        public List<ProductStockLocation>? Stocks { get; set; }

        //unit

        public List<VariantValueRelation>? VariantValueIds { get; set; }

        public float? Weight { get; set; }

        public Variant()
        {
            Id = string.Empty;
            IsActive = false;
            Prices = [];
            Sku = string.Empty;
            Weight = 0;
        }
    }
}
