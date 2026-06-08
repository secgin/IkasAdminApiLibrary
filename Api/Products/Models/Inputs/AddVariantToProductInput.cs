namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class AddVariantToProductInput
    {
        public string ProductId { get; set; } = string.Empty;

        public CreateProductVariantInput Variant { get; set; } = new();
    }

    public class CreateProductVariantInput
    {
        public List<ProductAttributeValueInput>? Attributes { get; set; }

        public List<string>? BarcodeList { get; set; }

        public string? HsCode { get; set; }

        public List<CreateProductImageInput> Images { get; set; } = [];

        public bool IsActive { get; set; } = true;

        public List<ProductPriceInput> Prices { get; set; } = [];

        public bool? SellIfOutOfStock { get; set; }

        public string? Sku { get; set; }

        public ProductVariantUnitInput? Unit { get; set; }

        public List<CreateVariantValueInput> VariantValues { get; set; } = [];

        public double? Weight { get; set; }
    }

    public class CreateProductImageInput
    {
        public string? Base64 { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsMain { get; set; }

        public int Order { get; set; }
    }

    public class ProductVariantUnitInput
    {
        public double? Amount { get; set; }

        public string? Type { get; set; }
    }

    public class CreateVariantValueInput
    {
        public string? SelectionType { get; set; }

        public string? VariantTypeName { get; set; } = string.Empty;

        public string? VariantValueName { get; set; } = string.Empty;
    }
}
