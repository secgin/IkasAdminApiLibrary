using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Authentication.Models;
using System.Security.Cryptography;

namespace IkasAdminApiLibrary
{
    internal class TokenStorageManager : ITokenStorageManager
    {
        private readonly string _tokenFile;
        private readonly DataProtectionScope _protectionScope;

        public TokenStorageManager(IConfig config)
        {
            _tokenFile = ResolveTokenFilePath(config);
            _protectionScope = MapProtectionScope(config.GetTokenProtectionScope());
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
                existingToken.RefreshToken = token.RefreshToken;
            }
            else
                tokens.Add(token);

            string json = System.Text.Json.JsonSerializer.Serialize(tokens);
            var data = System.Text.Encoding.UTF8.GetBytes(json);
#pragma warning disable CA1416 // Validate platform compatibility
            var protectedData = ProtectedData.Protect(data, null, _protectionScope);
#pragma warning restore CA1416 // Validate platform compatibility
            EnsureDirectoryExists(_tokenFile);
            File.WriteAllBytes(_tokenFile, protectedData);
        }

        private List<Token> GetAllTokens()
        {
            if (File.Exists(_tokenFile))
            {
                try
                {
                    var data = File.ReadAllBytes(_tokenFile);
                    if (TryUnprotect(data, _protectionScope, out var json))
                    {
                        return DeserializeTokens(json);
                    }

                    var plainJson = System.Text.Encoding.UTF8.GetString(data);
                    return DeserializeTokens(plainJson);
                }
                catch (Exception)
                {
                    return [];
                }
            }
            return [];
        }

        private static string ResolveTokenFilePath(IConfig config)
        {
            var configuredPath = config.GetTokenStoragePath();
            if (string.IsNullOrWhiteSpace(configuredPath))
            {
                return Path.Combine(AppContext.BaseDirectory, "token.json");
            }

            var expandedPath = Environment.ExpandEnvironmentVariables(configuredPath);
            var rootedPath = Path.IsPathRooted(expandedPath)
                ? expandedPath
                : Path.Combine(AppContext.BaseDirectory, expandedPath);

            if (Path.HasExtension(rootedPath))
            {
                return rootedPath;
            }

            return Path.Combine(rootedPath, "token.json");
        }

        private static void EnsureDirectoryExists(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static bool TryUnprotect(byte[] data, DataProtectionScope scope, out string json)
        {
            try
            {
#pragma warning disable CA1416 // Validate platform compatibility
                var unprotected = ProtectedData.Unprotect(data, null, scope);
#pragma warning restore CA1416 // Validate platform compatibility
                json = System.Text.Encoding.UTF8.GetString(unprotected);
                return true;
            }
            catch (CryptographicException)
            {
                json = string.Empty;
                return false;
            }
        }

        private static DataProtectionScope MapProtectionScope(TokenProtectionScope scope)
        {
#pragma warning disable CA1416 // Validate platform compatibility
            return scope == TokenProtectionScope.LocalMachine
                ? DataProtectionScope.LocalMachine
                : DataProtectionScope.CurrentUser;
#pragma warning restore CA1416 // Validate platform compatibility
        }

        private static List<Token> DeserializeTokens(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<List<Token>>(json) ?? [];
        }
    }
}
