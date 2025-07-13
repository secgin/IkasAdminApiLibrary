using IkasAdminApiLibrary.Api.Common.Models.ValueObjects;

namespace IkasAdminApiLibrary.Api.ProductBrands.Models.Inputs
{
    public class ListProductBrandInput
    {
        public StringFilterInput? Id { get; set; }

        public StringFilterInput? Name { get; set; }

        public StringFilterInput? Search { get; }

        public DateFilterInput? UpdatedAt { get; set; }
    }
}
