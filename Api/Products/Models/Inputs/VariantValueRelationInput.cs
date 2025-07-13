namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class VariantValueRelationInput
    {
        public string VariantTypeId { get; }

        public string VariantValueId { get; }

        public VariantValueRelationInput(string variantTypeId, string variantValueId)
        {
            VariantTypeId = variantTypeId;
            VariantValueId = variantValueId;
        }
    }
}
