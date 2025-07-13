using IkasAdminApiLibrary.Library.HttpRequest.Interfaces;

namespace IkasAdminApiLibrary.Library.HttpRequest
{
    internal class HttpHeader(string name, string value) : IHttpHeader
    {
        public string Name { get; } = name;

        public string Value { get; } = value;
    }
}
