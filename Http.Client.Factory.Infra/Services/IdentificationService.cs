using Http.Client.Factory.Application.Domains;
using Http.Client.Factory.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Http.Client.Factory.Infra.Services
{
    public class IdentificationService : IIdentificationService
    {
        private readonly HttpClient _client;
        private readonly ILogger<IIdentificationService> _logger;
        public IdentificationService(HttpClient client, ILogger<IIdentificationService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<LoginContractOutput> CallUserApi(HttpContent httpContent)
        {
            try
            {                
                var response = await _client.PostAsync("v1/accounts/login", httpContent);

                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();

                var result = await JsonSerializer.DeserializeAsync<LoginContractOutput>(responseStream);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[IdentificationService][UserApi]");

                return null;
            }
        }
    }
}
