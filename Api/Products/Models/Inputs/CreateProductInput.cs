namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class CreateProductInput
    {
        public string Name { get; set; } = string.Empty;

        public List<CreateProductVariantInput> Variants { get; set; } = [];

        public ProductBaseUnitInput? BaseUnit { get; set; }

        public ProductRelationInput? Brand { get; set; }

        public List<ProductCategoryRelationInput> Categories { get; set; } = [];

        public string? Description { get; set; }

        public List<string>? DynamicPriceListIds { get; set; }

        public string? GoogleTaxonomyId { get; set; }

        public bool? GroupVariantsByVariantTypeName { get; set; }

        public HTMLMetaDataInput? MetaData { get; set; }

        public string? ProductOptionSetId { get; set; }

        public List<ProductSalesChannelInput> SalesChannels { get; set; } = [];

        public string? ShortDescription { get; set; }

        public List<ProductRelationInput> Tags { get; set; } = [];

        public List<ProductTranslationInput> Translations { get; set; } = [];

        public ProductTypeEnum Type { get; set; } = ProductTypeEnum.PHYSICAL;

        public ProductRelationInput? Vendor { get; set; }

        public double? Weight { get; set; }
    }

    public class UpdateProductInput
    {
        public string Id { get; set; } = string.Empty;

        public string? Name { get; set; }

        public ProductBaseUnitInput? BaseUnit { get; set; }

        public ProductRelationInput? Brand { get; set; }

        public List<ProductCategoryRelationInput>? Categories { get; set; }

        public string? Description { get; set; }

        public List<string>? DynamicPriceListIds { get; set; }

        public string? GoogleTaxonomyId { get; set; }

        public HTMLMetaDataInput? MetaData { get; set; }

        public string? ProductOptionSetId { get; set; }

        public List<ProductSalesChannelInput>? SalesChannels { get; set; }

        public string? ShortDescription { get; set; }

        public List<ProductRelationInput>? Tags { get; set; }

        public List<ProductTranslationInput>? Translations { get; set; }

        public ProductTypeEnum? Type { get; set; }

        public ProductRelationInput? Vendor { get; set; }

        public double? Weight { get; set; }
    }

    public class AddVariantToProductInput
    {
        public string ProductId { get; set; } = string.Empty;

        public CreateProductVariantInput Variant { get; set; } = new();
    }

    public class ProductBaseUnitInput
    {
        public double? BaseAmount { get; set; }

        public string? Type { get; set; }

        public string? UnitId { get; set; }
    }

    public class ProductRelationInput
    {
        public string? Description { get; set; }

        public string? Id { get; set; }

        public string? Name { get; set; }
    }

    public class ProductCategoryRelationInput : ProductRelationInput
    {
        public string? Path { get; set; }
    }

    public class ProductSalesChannelInput
    {
        public string? Id { get; set; }

        public int? MaxQuantityPerCart { get; set; }

        public int? MinQuantityPerCart { get; set; }

        public string? ProductVolumeDiscountId { get; set; }

        public string? QuantitySettings { get; set; }

        public string? Status { get; set; }
    }

    public class ProductTranslationInput
    {
        public string? Description { get; set; }

        public string? Locale { get; set; }

        public string? Name { get; set; }
    }
}
