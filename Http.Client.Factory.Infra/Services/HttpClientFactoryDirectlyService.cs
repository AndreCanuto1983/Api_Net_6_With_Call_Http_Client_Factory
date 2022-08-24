using Http.Client.Factory.Application.Domains.Responses;
using Http.Client.Factory.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Http.Client.Factory.Infra.Services
{
    /// <summary>
    /// HttpClientFactory Directly Example
    /// </summary>
    public class HttpClientFactoryDirectlyService : IHttpClientFactoryDirectlyService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HttpClientFactoryDirectlyService> _logger;
        private readonly IConfiguration _configuration;

        private const string USERS_API = "v1/users";

        public HttpClientFactoryDirectlyService(
            IHttpClientFactory httpClientFactory,
            ILogger<HttpClientFactoryDirectlyService> logger,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserContractOutput>> GetDirectly(CancellationToken cancellationToken)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                client.BaseAddress = new Uri(_configuration.GetSection("http-client-factory").GetSection("Directly-Host").Value);
                
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _configuration.GetSection("ConfigurationApi").GetSection("AccessToken").Value);

                var response = await client.GetAsync(USERS_API);

                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var result = await JsonSerializer.DeserializeAsync<IEnumerable<UserContractOutput>>(responseStream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }, cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("[HttpClientFactoryDirectlyService][GetDirectly] => EXCEPTION: {ex.Message}", ex.Message);
                throw;
            }
        }
    }
}
