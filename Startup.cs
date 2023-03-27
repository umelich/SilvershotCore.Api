using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using System.Net;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace SilvershotCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //
            //
            //
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            services.AddAuthentication(/*...*/);
            services.AddVersionedApiExplorer(options =>
            options.GroupNameFormat = "'v'VVV");
            //
            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>>();
            services.AddSwaggerGen();
            services.AddApiVersioning();
            //
            services.AddEndpointsApiExplorer();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI();//...


            // Configure the HTTP request pipeline.

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}