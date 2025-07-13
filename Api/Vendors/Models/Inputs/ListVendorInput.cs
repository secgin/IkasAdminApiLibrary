using IkasAdminApiLibrary.Api.Common.Models.ValueObjects;

namespace IkasAdminApiLibrary.Api.Vendors.Models.Inputs
{
    public class ListVendorInput
    {
        public StringFilterInput? Id { get; set; }

        public StringFilterInput? Name { get; set; }
    }
}
