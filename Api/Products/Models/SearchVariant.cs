namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class SearchVariant
    {
        public string Id { get; set; } = string.Empty;

        public string Sku { get; set; } = string.Empty;

        public List<SearchVariationValueRelation>? VariantValues { get; set; }
    }
}
