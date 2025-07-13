namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class SearchProduct
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public List<SearchVariant> Variants { get; set; }

        public List<SearchProductAttributeValue> Attributes { get; set; }

        public SearchProduct()
        {
            Id = string.Empty;
            Name = string.Empty;
            Type = string.Empty;
            Variants = [];
            Attributes = [];
        }

        public bool IsSimpleProduct()
        {
            return Variants.Count == 1 && Variants[0].VariantValues?.Count == 0;
        }
    }
}
