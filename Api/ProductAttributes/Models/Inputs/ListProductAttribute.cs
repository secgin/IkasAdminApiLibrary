using IkasAdminApiLibrary.Api.Common.Models.ValueObjects;

namespace IkasAdminApiLibrary.Api.ProductAttributes.Models.Inputs
{
    public class ListProductAttribute
    {
        public StringFilterInput? Id { get; set; }

        public StringFilterInput? Name { get; set; }
    }
}
