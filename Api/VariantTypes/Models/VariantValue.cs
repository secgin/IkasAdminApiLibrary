namespace IkasAdminApiLibrary.Api.VariantTypes.Models
{
    public class VariantValue
    {
        public string Id { get; set; }

        public string? ColorCode { get; set; }

        public string Name { get; set; }

        public string? ThumbnailImageId { get; set; }

        public VariantValue()
        {
            Id = string.Empty;
            Name = string.Empty;
        }
    }
}
