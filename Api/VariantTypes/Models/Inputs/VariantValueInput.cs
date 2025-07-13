namespace IkasAdminApiLibrary.Api.VariantTypes.Models.Inputs
{
    public class VariantValueInput
    {
        public string? Id { get; set; }

        public string Name { get; set; }

        public VariantValueInput(string name)
        {
            Name = name;
        }

        public VariantValueInput(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
