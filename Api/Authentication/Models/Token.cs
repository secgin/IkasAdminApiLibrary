namespace IkasAdminApiLibrary.Api.Authentication.Models
{
    public record Token
    {
        public required string Key { get; set; }

        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public int ExpiresIn { get; set; }

        public Token()
        {
            AccessToken = string.Empty;
            TokenType = string.Empty;
            ExpiresIn = 0;  
        }
    }
}
