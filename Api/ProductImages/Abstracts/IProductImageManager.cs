using IkasAdminApiLibrary.Api.ProductImages.Models.Inputs;

namespace IkasAdminApiLibrary.Api.ProductImages.Abstracts
{
    public interface IProductImageManager
    {
        public Task<bool> UploadImage(UploadProductImageInput uploadProductImageInput);
    }
}
