namespace IkasAdminApiLibrary.Api.ProductTags.Models.Inputs
{
    public class ProductTagInput
    {
        public string Name { get; }

        public ProductTagInput(string name)
        {
            Name = name;
        }
    }
}
