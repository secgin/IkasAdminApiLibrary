namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class ProductVariantTypeInput
    {
        public float Order { get; set; }

        public string VariantTypeId { get; set; }

        public List<string> VariantValueIds { get; set; }

        public ProductVariantTypeInput(float order, string variantTypeId)
        {
            Order = order;
            VariantTypeId = variantTypeId;
            VariantValueIds = [];
        }
    }
}
