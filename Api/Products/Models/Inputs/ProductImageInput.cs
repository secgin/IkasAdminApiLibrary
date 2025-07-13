namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class ProductImageInput
    {
        public string? FileName { get; set; }

        public string? imageId { get; set; }

        public bool IsMain { get; set; }

        public bool IsVideo { get; set; }

        public int Order { get; set; }

        public ProductImageInput(bool isMain, int order)
        {
            FileName = null;
            imageId = null;
            IsMain = isMain;
            IsVideo = false;
            Order = order;
        }
    }
}
