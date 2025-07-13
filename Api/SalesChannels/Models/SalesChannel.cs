namespace IkasAdminApiLibrary.Api.SalesChannels.Models
{
    public class SalesChannel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public SalesChannelTypeEnum Type { get; set; }

        public SalesChannel()
        {
            Id = string.Empty;
            Name = string.Empty;
        }
    }
}
