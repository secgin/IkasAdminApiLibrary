namespace IkasAdminApiLibrary.Library.HttpRequest.Interfaces
{
    internal interface IHttpResult
    {
        public bool IsSuccess();

        public bool IsFail();

        public string? GetMessage();

        public int GetStatusCode();

        public string? GetContent();
    }
}
