namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class VariantInput(bool isActive, List<ProductPriceInput> prices)
    {
        public List<ProductAttributeValueInput>? Attributes { get; set; }

        public List<string>? BarcodeList { get; set; }

        public List<ProductImageInput>? Images { get; set; }

        public bool IsActive { get; } = isActive;

        public List<ProductPriceInput> Prices { get; } = prices;

        public string? Sku { get; set; }

        public float? Weight { get; set; }

        public List<VariantValueRelationInput>? VariantValueIds { get; set; }

        public string? HsCode { get; set; }
    }
}
