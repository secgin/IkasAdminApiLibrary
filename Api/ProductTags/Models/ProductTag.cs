namespace IkasAdminApiLibrary.Api.ProductTags.Models
{
    public class ProductTag
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ProductTag()
        {
            Id = string.Empty;
            Name = string.Empty;
        }
    }
}
