using IkasAdminApiLibrary.Library.HttpRequest.Interfaces;

namespace IkasAdminApiLibrary.Library.HttpRequest
{
    internal class HttpResult : IHttpResult
    {
        private bool success;

        private string? message;

        private int statusCode;

        private string? content;

        private HttpResult(bool success, int statusCode, string? content, string? message)
        {
            this.success = success;
            this.statusCode = statusCode;
            this.content = content;
            this.message = message;
        }

        public static HttpResult Success(int statusCode, string? content = null)
        {
            return new HttpResult(true, statusCode, content, null);
        }

        public static HttpResult Error(int statusCode, string? content, string? errorMessage = null)
        {
            return new HttpResult(false, statusCode, content, null);
        }

        public bool IsSuccess() => success;

        public bool IsFail() => !success;

        public string? GetMessage() => message;

        public int GetStatusCode() => statusCode;

        public string? GetContent() => content;
    }
}
