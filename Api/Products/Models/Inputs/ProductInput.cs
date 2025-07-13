using IkasAdminApiLibrary.Api.Products.Models;

namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class ProductInput
    {
        public string? Id { get; set; }

        public List<ProductAttributeValueInput>? Attributes { get; set; }

        public string Name { get; }

        public string? Description { get; set; }

        public ProductTypeEnum Type { get; set; }

        public List<string> SalesChannelIds { get; set; }

        public List<string>? CategoryIds { get; set; }

        public string? BrandId { get; set; }

        public string? VendorId { get; set; }

        public List<ProductVariantTypeInput>? ProductVariantTypes { get; set; }

        public List<VariantInput> Variants { get; set; }

        public ProductInput(string name, ProductTypeEnum productType, List<VariantInput> variants, List<string> salesChannelIds)
        {
            Name = name;
            Type = productType;
            Variants = variants;
            SalesChannelIds = salesChannelIds;
        }
    }
}
