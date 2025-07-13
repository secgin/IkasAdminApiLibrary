namespace IkasAdminApiLibrary.Api.Vendors.Models.Inputs
{
    public class VendorInput
    {
        public string Name { get; set; }

        public VendorInput(string name)
        {
            Name = name;
        }
    }
}
