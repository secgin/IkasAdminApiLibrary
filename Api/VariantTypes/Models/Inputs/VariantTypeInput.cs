using IkasAdminApiLibrary.Api.VariantTypes.Models;

namespace IkasAdminApiLibrary.Api.VariantTypes.Models.Inputs
{
    public class VariantTypeInput
    {
        public string? Id { get; set; }

        public string Name { get; set; }

        public VariantSelectionTypeEnum SelectionType { get; set; }

        public List<VariantValueInput> Values { get; set; }

        public VariantTypeInput(string name, VariantSelectionTypeEnum selectionType, List<VariantValueInput> values)
        {
            Name = name;
            SelectionType = selectionType;
            Values = values;
        }
    }
}
