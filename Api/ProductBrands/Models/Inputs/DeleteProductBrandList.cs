namespace IkasAdminApiLibrary.Api.ProductBrands.Models.Inputs
{
    public class DeleteProductBrandList
    {
        public IEnumerable<string> IdList { get; }

        public DeleteProductBrandList(IEnumerable<string> idList)
        {
            IdList = idList;
        }
    }
}
