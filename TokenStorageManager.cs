using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Authentication.Models;

namespace IkasAdminApiLibrary
{
    internal class TokenStorageManager : ITokenStorageManager
    {
        private readonly string _tokenFile;


        public TokenStorageManager()
        {
            _tokenFile = AppContext.BaseDirectory + "\\token.json";
        }

        public Token? Get(string key)
        {
            return GetAllTokens().FirstOrDefault(t => t.Key == key);
        }

        public void Save(Token token)
        {
            var tokens = GetAllTokens();
            var existingToken = tokens.FirstOrDefault(t => t.Key == token.Key);
            if (existingToken != null)
            {
                existingToken.AccessToken = token.AccessToken;
                existingToken.TokenType = token.TokenType;
                existingToken.ExpiresIn = token.ExpiresIn;
            }
            else
                tokens.Add(token);

            string json = System.Text.Json.JsonSerializer.Serialize(tokens);
            File.WriteAllText(_tokenFile, json);
        }

        private List<Token> GetAllTokens()
        {
            if (File.Exists(_tokenFile))
            {
               try
                {
                    string json = File.ReadAllText(_tokenFile);
                    return System.Text.Json.JsonSerializer.Deserialize<List<Token>>(json) ?? new List<Token>();
                }
                catch (Exception)
                {
                    return [];
                }
            }
            return [];
        }
    }
}
