namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class VariantValueRelation
    {
        public string VariantTypeId { get; set; }

        public string VariantValueId { get; set; }

        public VariantValueRelation()
        {
            VariantTypeId = string.Empty;
            VariantValueId = string.Empty;
        }

        public VariantValueRelation(string variantTypeId, string variantValueId)
        {
            VariantTypeId = variantTypeId;
            VariantValueId = variantValueId;
        }
    }
}
