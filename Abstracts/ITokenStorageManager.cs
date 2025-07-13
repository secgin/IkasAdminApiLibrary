using IkasAdminApiLibrary.Api.Authentication.Models;

namespace IkasAdminApiLibrary.Abstracts
{
    public interface ITokenStorageManager
    {
        public void Save(Token token);

        public Token? Get(string key);
    }
}
