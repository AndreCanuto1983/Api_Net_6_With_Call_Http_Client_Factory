using System.Text.Json.Serialization;

namespace http_client_factory.Configurations
{
    public static class ServiceExtension
    {
        public static void Configurations(IServiceCollection services)
        {
            services.AddControllers()
                    .AddJsonOptions(options =>
                        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true)
                    .AddJsonOptions(options =>
                        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault);
        }
    }
}
