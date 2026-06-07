namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class Variant
    {
        public string Id { get; set; }

        public List<ProductAttributeValue>? Attributes { get; set; }

        public List<string>? BarcodeList { get; set; }

        //bundleSettings
        //fileId

        public VariantBundleSettings? BundleSettings { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool? Deleted { get; set; }

        public string? HsCode { get; set; }

        public List<ProductImage>? Images { get; set; }

        public bool? IsActive { get; set; }

        public List<ProductPrice> Prices { get; set; }

        public bool? SellIfOutOfStock { get; set; }

        public string Sku { get; set; }

        public List<ProductStockLocation>? Stocks { get; set; }

        //unit

        public VariantUnit? Unit { get; set; }

        public List<VariantValueRelation>? VariantValueIds { get; set; }

        public List<VariantValueRelation>? VariantValues { get; set; }

        public DateTime? UpdatedAt { get; set; }

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

    public class VariantBundleSettings
    {
        public int? MaxBundleQuantity { get; set; }

        public int? MinBundleQuantity { get; set; }

        public List<VariantBundleProduct> Products { get; set; } = [];
    }

    public class VariantBundleProduct
    {
        public bool? AddToBundleBasePrice { get; set; }

        public double? DiscountRatio { get; set; }

        public List<string>? FilteredVariantIds { get; set; }

        public string Id { get; set; } = string.Empty;

        public int? MaxQuantity { get; set; }

        public int? MinQuantity { get; set; }

        public int? Order { get; set; }

        public string? ProductId { get; set; }

        public int? Quantity { get; set; }
    }

    public class VariantUnit
    {
        public double? Amount { get; set; }

        public string? Type { get; set; }
    }
}
