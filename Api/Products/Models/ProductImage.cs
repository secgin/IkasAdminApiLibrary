namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class ProductImage
    {
        public string? FileName { get; set; }

        public string? ImageId { get; set; }

        public bool IsMain { get; set; }

        public bool IsVideo { get; set; }

        public float Order { get; set; }

        public ProductImage()
        {
            FileName = null;
            ImageId = null;
            IsMain = false;
            IsVideo = false;
            Order = 0;
        }
    }
}
