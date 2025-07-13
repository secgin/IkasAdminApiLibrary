namespace IkasAdminApiLibrary.Api.ProductImages.Models.Inputs
{
    public class UploadProductImageInput
    {
        public List<string> VariantIds { get; set; }

        public int? Order { get; set; }

        public bool IsMain { get; set; }

        public string Url { get; set; }

        public UploadProductImageInput(List<string> variantIds, int? order, bool isMain, string url)
        {
            VariantIds = variantIds;
            Order = order;
            IsMain = isMain;
            Url = url;
        }
    }
}
