﻿namespace NSE.Identidade.API.Extensions
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment environment)
        {

            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseIdentityConfiguration();

            return app;

        }
    }
}
