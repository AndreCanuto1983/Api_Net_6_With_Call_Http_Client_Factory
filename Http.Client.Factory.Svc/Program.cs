using http_client_factory.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.DependencyInjectionSettings();
builder.Services.ServiceExtensionSettings();
builder.HttpClientFactorySettings();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
