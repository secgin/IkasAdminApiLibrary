namespace IkasAdminApiLibrary.Api.Products.Models.Inputs
{
    public class HTMLMetaDataInput
    {
        public List<string> Canonicals { get; set; } = [];
        public string? Description { get; set; }
        public bool DisableIndex { get; set; }
        public string? PageTitle { get; set; }
        public required string Slug { get; set; }
    }
}
