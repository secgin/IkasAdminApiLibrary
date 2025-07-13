namespace IkasAdminApiLibrary.Library.HttpRequest.Interfaces
{
    internal interface IHttpRequest
    {
        public Task<IHttpResult> GetAsync(string url, List<IHttpHeader>? headers = null);

        public Task<IHttpResult> PostAsync(string url, List<IHttpHeader>? headers = null, HttpContent? content = null);
    }
}
