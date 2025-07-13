namespace IkasAdminApiLibrary.Abstracts
{
    public interface IConfig
    {
        public string GetServiceAddress();

        public string GetTokenServiceAddress();

        public string GetProductImageServiceAddress();

        public string GetClientId();

        public string GetClientSecret();

        public string GetStoreName();
    }
}
