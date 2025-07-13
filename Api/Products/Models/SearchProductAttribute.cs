namespace IkasAdminApiLibrary.Api.Products.Models
{
    public class SearchProductAttribute
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public SearchProductAttribute()
        {
            Id = string.Empty;
            Name = string.Empty;
            Type = string.Empty;
        }
    }
}
