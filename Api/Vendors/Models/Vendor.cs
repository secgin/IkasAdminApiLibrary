namespace IkasAdminApiLibrary.Api.Vendors.Models
{
    public class Vendor
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Vendor()
        {
            Id = string.Empty;
            Name = string.Empty;
        }
    }
}
