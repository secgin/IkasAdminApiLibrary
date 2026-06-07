namespace IkasAdminApiLibrary.Api.Orders.Models
{
    public class OrderTag
    {
        public DateTime? CreatedAt { get; set; }

        public bool? Deleted { get; set; }

        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public DateTime? UpdatedAt { get; set; }
    }
}
