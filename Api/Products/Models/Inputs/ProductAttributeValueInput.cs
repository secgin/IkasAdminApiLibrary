namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class ProductAttributeValueInput
    {
        public List<string> ImageIds { get; set; }

        public string ProductAttributeId { get; set; }

        public string? ProductAttributeOptionId { get; set; }

        public string Value { get; set; }

        public ProductAttributeValueInput(string productAttributeId, string value)
        {
            ImageIds = [];
            ProductAttributeId = productAttributeId;
            ProductAttributeOptionId = null;
            Value = value;
        }
    }
}
