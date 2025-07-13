namespace IkasAdminApiLibrary.Api.ProductAttributes.Models
{
    public class ProductAttributeOption
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ProductAttributeOption()
        {
            Id = string.Empty;
            Name = string.Empty;
        }
    }
}
