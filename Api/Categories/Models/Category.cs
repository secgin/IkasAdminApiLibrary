namespace IkasAdminApiLibrary.Api.Categories.Models
{
    public class Category
    {
        public string Id { get; set; }

        public string? ParentId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public Category()
        {
            Id = string.Empty;
            ParentId = null;
            Name = string.Empty;
        }
    }
}
