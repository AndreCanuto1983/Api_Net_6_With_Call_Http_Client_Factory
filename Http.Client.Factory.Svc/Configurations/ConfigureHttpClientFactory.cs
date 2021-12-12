using Http.Client.Factory.Application.Interfaces;
using Http.Client.Factory.Infra.Services;

namespace http_client_factory.Configurations
{
    public class ConfigureHttpClientFactory
    {

        //Typed Client Example for HttpClientFactory Injection
        public static void Configurations(IServiceCollection services)
        {
            services.AddHttpClient<IIdentificationService, IdentificationService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44310/");
                //For add headers
                //client.DefaultRequestHeaders.Add("varParameter", "dataParameter");
            });
        }
    }
}
