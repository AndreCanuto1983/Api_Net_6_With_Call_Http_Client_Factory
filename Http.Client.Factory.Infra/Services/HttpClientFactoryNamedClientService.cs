using Http.Client.Factory.Application.Domains.Responses;
using Http.Client.Factory.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Http.Client.Factory.Infra.Services
{
    /// <summary>
    /// HttpClientFactory Named Client Example
    /// </summary>
    public class HttpClientFactoryNamedClientService : IHttpClientFactoryNamedClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HttpClientFactoryNamedClientService> _logger;

        public HttpClientFactoryNamedClientService(
            IHttpClientFactory httpClientFactory,
            ILogger<HttpClientFactoryNamedClientService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IEnumerable<UserContractOutput>> GetNamedClient(CancellationToken cancellationToken)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("NamedClient");

                var response = await client.GetAsync("v1/users");

                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var result = await JsonSerializer.DeserializeAsync<IEnumerable<UserContractOutput>>(
                    responseStream, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }, cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("[HttpClientFactoryNamedClientService][GetNamedClient] => EXCEPTION: {ex.Message}", ex.Message);
                throw;
            }
        }
    }
}
