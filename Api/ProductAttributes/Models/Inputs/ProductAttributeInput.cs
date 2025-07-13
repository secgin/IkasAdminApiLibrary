using IkasAdminApiLibrary.Api.ProductAttributes.Models;

namespace IkasAdminApiLibrary.Api.ProductAttributes.Models.Inputs
{
    public class ProductAttributeInput
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public ProductAttributeTypeEnum Type { get; set; }

        public ProductAttributeInput(string name, ProductAttributeTypeEnum type)
        {
            Id = string.Empty;
            Name = name;
            Description = null;
            Type = type;
        }
    }
}
