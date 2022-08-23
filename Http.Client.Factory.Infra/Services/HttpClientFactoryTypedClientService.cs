using Http.Client.Factory.Application.Domains.Responses;
using Http.Client.Factory.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Http.Client.Factory.Infra.Services
{
    /// <summary>
    /// HttpClientFactory Typed Client Example
    /// </summary>
    public class HttpClientFactoryTypedClientService : IHttpClientFactoryTypedClientService
    {
        private readonly HttpClient _client;
        private readonly ILogger<HttpClientFactoryTypedClientService> _logger;
        public HttpClientFactoryTypedClientService(
            HttpClient client, 
            ILogger<HttpClientFactoryTypedClientService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<LoginContractOutput> CallLoginApi(HttpContent httpContent, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _client.PostAsync("v1/accounts/login", httpContent);

                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var result = await JsonSerializer.DeserializeAsync<LoginContractOutput>(responseStream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }, cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("[HttpClientFactoryTypedClientService][CallLoginApi] => EXCEPTION: {ex.Message}", ex.Message);

                throw;
            }
        }
    }
}
