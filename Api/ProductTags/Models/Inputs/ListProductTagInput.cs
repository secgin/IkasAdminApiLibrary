using IkasAdminApiLibrary.Api.Common.Models.ValueObjects;

namespace IkasAdminApiLibrary.Api.ProductTags.Models.Inputs
{
    public class ListProductTagInput
    {
        public StringFilterInput? Id { get; set; }

        public StringFilterInput? Name { get; set; }
    }
}
