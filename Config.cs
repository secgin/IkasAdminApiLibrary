using IkasAdminApiLibrary.Abstracts;

namespace IkasAdminApiLibrary
{
    public class Config(string clientId, string clientSecret, string storeName) : IConfig
    {
        public string GetClientId() => clientId;

        public string GetClientSecret() => clientSecret;

        public string GetStoreName() => storeName;

        public string GetServiceAddress() => "https://api.myikas.com/api/v1/admin/graphql";

        public string GetTokenServiceAddress() => "https://" + storeName + ".myikas.com/api/admin/oauth/token";

        public string GetProductImageServiceAddress() => "https://api.myikas.com/api/v1/admin/product/upload/image";
    }
}
