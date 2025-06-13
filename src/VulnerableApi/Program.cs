using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Read secrets from configuration
var config = builder.Configuration;
string jwtSecret = config["ThirdPartyApi:JwtSecret"];
string apiKey = config["ThirdPartyApi:Key"];
string connectionString = config.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();

var app = builder.Build();

// Example usage in endpoint
app.MapGet("/", () => new
{
    status = "ok",
    jwtSecret,      // Just for demonstration – don't return secrets in real apps
    apiKey,
    connectionString
});

app.Run();
