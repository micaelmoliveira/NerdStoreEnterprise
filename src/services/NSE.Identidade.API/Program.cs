using NSE.Identidade.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration();
builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

builder.Configuration
    .SetBasePath(app.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{app.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

app.UseApiConfiguration(app.Environment);
app.UseSwaggerConfiguration(app.Environment);

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
