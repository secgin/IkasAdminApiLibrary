namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ProductTypeEnum Type { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public List<ProductVariantType>? ProductVariantTypes { get; set; }

        public List<Variant> Variants { get; set; }

        public float? Weight { get; set; }

        public List<ProductAttributeValue>? Attributes { get; set; }

        public List<string> SalesChannelIds { get; set; }

        public Product()
        {
            Id = string.Empty;
            Name = string.Empty;
            Variants = [];
            SalesChannelIds = [];
        }

        public bool IsSimpleProduct()
        {
            return Variants.Count == 1 && Variants[0].VariantValueIds?.Count == 0;
        }
    }
}
