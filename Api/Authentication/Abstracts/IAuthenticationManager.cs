using IkasAdminApiLibrary.Api.Authentication.Models;

namespace IkasAdminApiLibrary.Api.Authentication.Abstracts
{
    public interface IAuthenticationManager
    {
        public Token? Token { get; }

        public Task<Token?> GetAccessToken();
    }
}
