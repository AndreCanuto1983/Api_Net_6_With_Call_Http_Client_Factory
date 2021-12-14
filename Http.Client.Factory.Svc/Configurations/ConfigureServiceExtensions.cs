namespace http_client_factory.Configurations
{
    public class ConfigureServiceExtensions
    {
        public static void Configurations(IServiceCollection services)
        {
            services.AddControllers()
                    .AddJsonOptions(options =>
                        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true);            
        }
    }
}
