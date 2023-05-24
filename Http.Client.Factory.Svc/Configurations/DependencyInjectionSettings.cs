using Http.Client.Factory.Application.Interfaces;
using Http.Client.Factory.Infra.Services;

namespace http_client_factory.Configurations
{
    public static class DependencyInjectionSettings
    {
        public static void DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IHttpClientFactoryDirectlyService, HttpClientFactoryDirectlyService>();
            services.AddScoped<IHttpClientFactoryNamedClientService, HttpClientFactoryNamedClientService>();
        }
    }
}
