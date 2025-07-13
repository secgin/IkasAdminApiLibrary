using IkasAdminApiLibrary.Api.Categories.Models.Inputs;
using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.Common.Models.ValueObjects;

namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class ListProductInput
    {
        public StringFilterInput? Id { get; set; }

        public StringFilterInput? Name { get; set; }

        public StringFilterInput? Sku { get; set; }

        public StringFilterInput? BarcodeList { get; set; }

        public ProductAttributeFilterInput? AttributeId { get; set; }

        public StringFilterInput? VendorId { get; set; }

        public StringFilterInput? BrandId { get; set; }

        public CategoryPathFilterInput? CategoryIds { get; set; }

        public PaginationInput? Pagination { get; set; }
    }
}
