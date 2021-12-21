using Http.Client.Factory.Application.Interfaces;
using Http.Client.Factory.Infra.Services;

namespace http_client_factory.Configurations
{
    public class DependencyInjection
    {
        public static void Configurations(IServiceCollection services)
        {
            services.AddScoped<IHttpClientFactoryDirectlyService, HttpClientFactoryDirectlyService>();
            services.AddScoped<IHttpClientFactoryNamedClientService, HttpClientFactoryNamedClientService>();
        }
    }
}
