namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class ProductAttributeValue
    {
        public List<string> ImageIds { get; set; }

        public string ProductAttributeId { get; set; }

        public string ProductAttributeOptionId { get; set; }

        public string Value { get; set; }

        public ProductAttributeValue()
        {
            ImageIds = [];
            ProductAttributeId = string.Empty;
            ProductAttributeOptionId = string.Empty;
            Value = string.Empty;
        }
    }
}
