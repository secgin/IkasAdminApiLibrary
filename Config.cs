using IkasAdminApiLibrary.Abstracts;

namespace IkasAdminApiLibrary
{
    public class Config(
        string clientId,
        string clientSecret,
        string storeName,
        string? tokenStoragePath = null,
        TokenProtectionScope tokenProtectionScope = TokenProtectionScope.CurrentUser) : IConfig
    {
        public string GetClientId() => clientId;

        public string GetClientSecret() => clientSecret;

        public string GetStoreName() => storeName;

        public string GetServiceAddress() => "https://api.myikas.com/api/v2/admin/graphql";

        public string GetTokenServiceAddress() => "https://api.myikas.com/api/admin/oauth/token";

        public string GetProductImageServiceAddress() => "https://api.myikas.com/api/v2/admin/upload/image";

        public string? GetTokenStoragePath() => tokenStoragePath;

        public TokenProtectionScope GetTokenProtectionScope() => tokenProtectionScope;
    }
}
