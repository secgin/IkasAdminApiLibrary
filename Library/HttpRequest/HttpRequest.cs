using IkasAdminApiLibrary.Library.HttpRequest.Interfaces;

namespace IkasAdminApiLibrary.Library.HttpRequest
{
    internal class HttpRequest : IHttpRequest
    {
        public async Task<IHttpResult> GetAsync(string url, List<IHttpHeader>? headers = null)
        {
            try
            {
                using HttpClient client = new();

                headers?.ForEach(item => client.DefaultRequestHeaders.Add(item.Name, item.Value));

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode == false)
                {
                    return HttpResult.Error((int)response.StatusCode, response.Content.ToString(), response.RequestMessage?.ToString());
                }

                string stringContent = await response.Content.ReadAsStringAsync();
                return HttpResult.Success((int)response.StatusCode, stringContent);
            }
            catch (UriFormatException ex)
            {
                return HttpResult.Error(0, "", "Geçersiz URL formatı: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                return HttpResult.Error(0, "", "HTTP isteği sırasında hata oluştu: " + ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                return HttpResult.Error(0, "", "İstek zaman aşımına uğradı: " + ex.Message);
            }
            catch (Exception ex)
            {
                return HttpResult.Error(0, "", "Beklenmedik bir hata oluştu: " + ex.Message);
            }
        }

        public async Task<IHttpResult> PostAsync(string url, List<IHttpHeader>? headers = null, HttpContent? content = null)
        {
            try
            {
                using HttpClient httpClient = new();

                if (content != null)
                    headers?.ForEach(item => httpClient.DefaultRequestHeaders.Add(item.Name, item.Value));

                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), content);

                var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode == false)
                {
                    return HttpResult.Error((int)response.StatusCode, result, response.RequestMessage?.ToString());
                }

                return HttpResult.Success((int)response.StatusCode, result);
            }
            catch (UriFormatException ex)
            {
                return HttpResult.Error(0,"", "Geçersiz URL formatı: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                return HttpResult.Error(0, "", "HTTP isteği sırasında hata oluştu: " + ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                return HttpResult.Error(0, "", "İstek zaman aşımına uğradı: " + ex.Message);
            }
            catch (Exception ex)
            {
                return HttpResult.Error(0, "", "Beklenmedik bir hata oluştu: " + ex.Message);
            }
        }
    }
}
