using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.ProductBrands.Models;
using IkasAdminApiLibrary.Api.Vendors.Models;

namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ProductTypeEnum? Type { get; set; }

        public string? Description { get; set; }

        public string? ShortDescription { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? Deleted { get; set; }

        public ProductBaseUnit? BaseUnit { get; set; }

        public ProductBrand? Brand { get; set; }

        public List<Reference> Categories { get; set; }

        public List<string>? DynamicPriceListIds { get; set; }

        public string? GoogleTaxonomyId { get; set; }

        public int? MaxQuantityPerCart { get; set; }

        public ProductMetaData? MetaData { get; set; }

        public string? ProductOptionSetId { get; set; }

        public string? ProductVolumeDiscountId { get; set; }

        public List<ProductVariantType>? ProductVariantTypes { get; set; }

        public List<Variant> Variants { get; set; }

        public float? Weight { get; set; }

        public List<ProductAttributeValue>? Attributes { get; set; }

        public List<string> SalesChannelIds { get; set; }

        public List<ProductSalesChannel> SalesChannels { get; set; }

        public List<Reference> Tags { get; set; }

        public double? TotalStock { get; set; }

        public List<ProductTranslation> Translations { get; set; }

        public Vendor? Vendor { get; set; }

        public Product()
        {
            Id = string.Empty;
            Name = string.Empty;
            Categories = [];
            Variants = [];
            SalesChannelIds = [];
            SalesChannels = [];
            Tags = [];
            Translations = [];
        }

        public bool IsSimpleProduct()
        {
            return Variants.Count == 1 && Variants[0].VariantValueIds?.Count == 0;
        }
    }

    public class ProductBaseUnit
    {
        public double? BaseAmount { get; set; }

        public string? Type { get; set; }

        public string? UnitId { get; set; }
    }

    public class ProductMetaData
    {
        public string Id { get; set; } = string.Empty;

        public string? Slug { get; set; }
    }

    public class ProductSalesChannel
    {
        public string Id { get; set; } = string.Empty;

        public int? MaxQuantityPerCart { get; set; }

        public int? MinQuantityPerCart { get; set; }

        public string? ProductVolumeDiscountId { get; set; }

        public string? QuantitySettings { get; set; }

        public string? Status { get; set; }
    }

    public class ProductTranslation
    {
        public string? Description { get; set; }

        public string? Locale { get; set; }

        public string? Name { get; set; }
    }
}
