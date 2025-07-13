namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class ProductVariantType
    {
        public float Order { get; set; }

        public string VariantTypeId { get; set; }

        public List<string> VariantValueIds { get; set; }

        public ProductVariantType()
        {
            Order = 0;
            VariantTypeId = string.Empty;
            VariantValueIds = [];
        }

        public ProductVariantType(float order, string variantTypeId)
        {
            Order = order;
            VariantTypeId = variantTypeId;
            VariantValueIds = [];
        }
    }
}
