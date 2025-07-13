namespace IkasAdminApiLibrary.Api.ProductAttributes.Models
{
    public class ProductAttribute
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<ProductAttributeOption>? Options { get; set; }

        public string? Description { get; set; }

        public ProductAttributeTypeEnum Type { get; set; }

        public ProductAttribute()
        {
            Id = string.Empty;
            Name = string.Empty;
        }
    }
}
