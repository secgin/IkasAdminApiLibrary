using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Authentication.Abstracts;
using IkasAdminApiLibrary.Api.ProductImages.Abstracts;
using IkasAdminApiLibrary.Api.ProductImages.Models.Inputs;
using IkasAdminApiLibrary.Library.HttpRequest;
using IkasAdminApiLibrary.Library.HttpRequest.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace IkasAdminApiLibrary.Api.ProductImages
{
    internal class ProductImageManager : IProductImageManager
    {
        private readonly IConfig _config;

        private readonly IHttpRequest _httpRequest;

        private readonly IAuthenticationManager _authenticationManager;

        public ProductImageManager(IConfig config, IHttpRequest httpRequest, IAuthenticationManager authenticationManager)
        {
            _config = config;
            _httpRequest = httpRequest;
            _authenticationManager = authenticationManager;
        }

        public async Task<bool> UploadImage(UploadProductImageInput uploadProductImageInput)
        {
            var payload = new
            {
                productImage = new
                {
                    variantIds = uploadProductImageInput.VariantIds,
                    order = uploadProductImageInput.Order,
                    isMain = uploadProductImageInput.IsMain,
                    url = uploadProductImageInput.Url
                }
            };

            List<IHttpHeader> headers = [];
            if (_authenticationManager.Token != null)
                headers.Add(new HttpHeader(
                "Authorization",
                _authenticationManager.Token.TokenType + " " + _authenticationManager.Token.AccessToken));

            var data = JsonConvert.SerializeObject(payload);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            var serviceAddress = _config.GetProductImageServiceAddress();

            var httpResult = await _httpRequest.PostAsync(serviceAddress, headers, content);
            var response = httpResult.GetContent()?.ToString();
            return response == "OK";
        }
    }
}
