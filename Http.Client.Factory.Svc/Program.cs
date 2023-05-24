using http_client_factory.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.DependencyInjection();
builder.Services.ConfigureJson();
builder.HttpClientFactory();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapHealthChecks("/healthcheck");
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();
