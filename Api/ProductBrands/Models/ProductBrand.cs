namespace IkasAdminApiLibrary.Api.ProductBrands.Models
{
    public class ProductBrand
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public ProductBrand()
        {
            Id = string.Empty;
            Name = string.Empty;
        }
    }
}
