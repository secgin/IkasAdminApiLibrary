using IkasAdminApiLibrary.Api.Common.Models.ValueObjects;

namespace IkasAdminApiLibrary.Api.VariantTypes.Models.Inputs
{
    public class ListVariantTypeInput
    {
        public StringFilterInput? Id { get; set; }

        public StringFilterInput? Name { get; set; }
    }
}
