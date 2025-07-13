namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class SearchProductAttributeValue
    {
        public required SearchProductAttribute ProductAttribute { get; set; }

        public required string Value { get; set; }
    }
}
