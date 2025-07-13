using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Authentication.Abstracts;
using IkasAdminApiLibrary.Api.Authentication.Models;
using IkasAdminApiLibrary.Library.HttpRequest.Interfaces;
using Newtonsoft.Json;

namespace IkasAdminApiLibrary.Api.Authentication
{
    internal class AuthenticationManager(
        IConfig config, 
        ITokenStorageManager tokenStorageManager, 
        IHttpRequest httpRequest) : IAuthenticationManager
    {
        private readonly IConfig _config = config;

        private readonly ITokenStorageManager _tokenStorageManager = tokenStorageManager;

        private readonly IHttpRequest _httpRequest = httpRequest;

        public Token? Token => _tokenStorageManager.Get(_config.GetStoreName());

        public async Task<Token?> GetAccessToken()
        {
            var parameters = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", _config.GetClientId() },
                { "client_secret", _config.GetClientSecret() }
            };
            var content = new FormUrlEncodedContent(parameters);

            var httpResult = await _httpRequest.PostAsync(_config.GetTokenServiceAddress(), null, content);

            var result = JsonConvert.DeserializeObject<dynamic>(httpResult.GetContent() ?? "");

            if (result != null)
            {
                var token = new Token
                {
                    Key = _config.GetStoreName(),
                    AccessToken = result.access_token,
                    TokenType = result.token_type,
                    ExpiresIn = result.expires_in
                };
                _tokenStorageManager.Save(token);
                return token;
            }

            return null;
        }
    }
}
