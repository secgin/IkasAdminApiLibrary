using GraphQL.Query.Builder;
using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Authentication.Abstracts;
using IkasAdminApiLibrary.Library.HttpRequest;
using IkasAdminApiLibrary.Library.HttpRequest.Interfaces;
using IkasAdminApiLibrary.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace IkasAdminApiLibrary
{
    internal class GraphQLService(
        IConfig config, 
        IHttpRequest httpRequest, 
        IAuthenticationManager authenticationManager) : IGraphQLService
    {
        public IQuery<T> CreateQuery<T>(string name)
        {
            return new Query<T>(name, new QueryOptions
            {
                Formatter = CamelCasePropertyNameFormatter.Format
            });
        }

        public async Task<IResult<T>> MutationQueryAsync<T>(IQuery query, string path)
        {
            var result = await postAsync<T>(query, path, true);

            if (result.GetCode() == "LOGIN_REQUIRED")
            {
                _ = await authenticationManager.GetAccessToken();
                result = await postAsync<T>(query, path, true);
            }

            return result;
        }

        public async Task<IResult<T>> QueryAsync<T>(IQuery query, string path)
        {
            var result = await postAsync<T>(query, path);

            if (result.GetCode() == "LOGIN_REQUIRED")
            {
                await authenticationManager.GetAccessToken();
                result = await postAsync<T>(query, path);
            }

            return result;
        }

        protected async Task<IResult<T>> postAsync<T>(IQuery query, string path, bool mutable = false)
        {
            var payload = new
            {
                query = mutable ? "mutation { " + query.Build() + " }" : "{ " + query.Build() + " }"
            };
            string strPayload = JsonConvert.SerializeObject(payload);
            HttpContent httpContent = new StringContent(strPayload, Encoding.UTF8, "application/json");

            List<IHttpHeader> headers = [];
            if (authenticationManager.Token != null)
                headers.Add(new HttpHeader(
                    "Authorization",
                    authenticationManager.Token.TokenType + " " + authenticationManager.Token.AccessToken
                    ));

            IHttpResult httpResult = await httpRequest.PostAsync(config.GetServiceAddress(), headers, httpContent);
            var content = httpResult.GetContent() ?? "";

            if (httpResult.GetStatusCode() == 403)
            {
                dynamic res = JObject.Parse(content);
                var message = (string)res.message;
                return Result<T>.Fail("UNAUTHORIZED", message);
            }

            var response = JsonConvert.DeserializeObject<Response>(content);
            if (response == null)
                return Result<T>.Fail();

            if (!response.IsSuccess())
                return Result<T>.Fail(response.GetCode(), response.GetMessage());


            var jsonObject = JObject.Parse(content);
            var data = string.IsNullOrWhiteSpace(path)
                ? jsonObject["data"]
                : jsonObject["data"]?[path];

            if (data != null)
            {
               try
                {
                    var model = data.ToObject<T>(new JsonSerializer
                    {
                        DateParseHandling = DateParseHandling.None,
                        Converters = { new UnixDateTimeConverter() }
                    });
                    if (model == null)
                        return Result<T>.Fail();

                    return Result<T>.Success(model);
                }
                catch (Exception ex)
                {
                    return Result<T>.Fail(null, ex.Message);
                }
            }

            return Result<T>.Fail(null, "Not found " + httpResult.GetMessage()?.ToString() + " - " + httpResult.GetStatusCode().ToString());
        }

        private HttpContent prepareGraphqlHttpContent(string content, bool mutation = false)
        {
            var payload = new
            {
                query = mutation ? "mutation { " + content + " }" : "{ " + content + " }"
            };

            string data = JsonConvert.SerializeObject(payload);

            return new StringContent(data, Encoding.UTF8, "application/json");
        }
    }
}
