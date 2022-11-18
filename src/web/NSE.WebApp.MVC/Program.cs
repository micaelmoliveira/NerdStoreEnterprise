using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();

builder.Services.AddMvcConfiguration(builder.Configuration);

builder.Services.RegisterServices();

var app = builder.Build();

builder.Configuration
    .SetBasePath(app.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{app.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

app.UseMvcConfiguration(app.Environment);

app.Run();
