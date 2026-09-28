using IkasAdminApiLibrary.Library.HttpRequest.Interfaces;
using System.Net;

namespace IkasAdminApiLibrary.Library.HttpRequest
{
    internal class HttpRequest : IHttpRequest
    {
        private const int MaxTooManyRequestsRetryCount = 4;
        private static readonly HttpClient Client = new();
        private static readonly TimeSpan MaxRetryDelay = TimeSpan.FromMinutes(2);

        public Task<IHttpResult> GetAsync(string url, List<IHttpHeader>? headers = null)
        {
            return SendAsync(HttpMethod.Get, url, headers, null);
        }

        public Task<IHttpResult> PostAsync(string url, List<IHttpHeader>? headers = null, HttpContent? content = null)
        {
            return SendAsync(HttpMethod.Post, url, headers, content);
        }

        private static async Task<IHttpResult> SendAsync(
            HttpMethod method,
            string url,
            List<IHttpHeader>? headers,
            HttpContent? content)
        {
            try
            {
                var uri = new Uri(url);
                byte[]? contentBytes = content == null
                    ? null
                    : await content.ReadAsByteArrayAsync();
                var contentHeaders = content?.Headers
                    .ToDictionary(header => header.Key, header => header.Value.ToArray());

                for (var retryCount = 0; ; retryCount++)
                {
                    using var request = new HttpRequestMessage(method, uri);

                    if (headers != null)
                    {
                        foreach (var header in headers)
                            request.Headers.TryAddWithoutValidation(header.Name, header.Value);
                    }

                    if (contentBytes != null)
                    {
                        request.Content = new ByteArrayContent(contentBytes);

                        if (contentHeaders != null)
                        {
                            foreach (var header in contentHeaders)
                                request.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
                        }
                    }

                    using HttpResponseMessage response = await Client.SendAsync(request);
                    string responseContent = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == HttpStatusCode.TooManyRequests &&
                        retryCount < MaxTooManyRequestsRetryCount)
                    {
                        await Task.Delay(GetRetryDelay(response, retryCount));
                        continue;
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        return HttpResult.Error(
                            (int)response.StatusCode,
                            responseContent,
                            response.ReasonPhrase);
                    }

                    return HttpResult.Success((int)response.StatusCode, responseContent);
                }
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

        private static TimeSpan GetRetryDelay(HttpResponseMessage response, int retryCount)
        {
            var retryAfter = response.Headers.RetryAfter;
            TimeSpan delay;

            if (retryAfter?.Delta != null)
            {
                delay = retryAfter.Delta.Value;
            }
            else if (retryAfter?.Date != null)
            {
                delay = retryAfter.Date.Value - DateTimeOffset.UtcNow;
            }
            else
            {
                var exponentialDelay = TimeSpan.FromSeconds(Math.Pow(2, retryCount));
                var jitter = TimeSpan.FromMilliseconds(Random.Shared.Next(100, 501));
                delay = exponentialDelay + jitter;
            }

            if (delay < TimeSpan.Zero)
                return TimeSpan.Zero;

            return delay > MaxRetryDelay ? MaxRetryDelay : delay;
        }
    }
}
