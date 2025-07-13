namespace IkasAdminApiLibrary.Api.Categories.Models.Inputs
{
    public class CategoryInput
    {
        public string Name { get; set; }

        public string? ParentId { get; set; }

        public CategoryInput(string name, string? parentId = null)
        {
            Name = name;
            ParentId = parentId;
        }
    }
}
