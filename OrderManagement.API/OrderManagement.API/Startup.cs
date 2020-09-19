using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderManagement.API.StartupExtensions;

namespace OrderManagement.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        private static readonly string _allowOriginPolicy = "AllowOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            #region Register DB Context
            ConfigDbContext.Register(Configuration, services);
            #endregion

            #region CORS
            var allowedCors = Configuration.GetSection("CORS")
                                           .AsEnumerable()
                                           .Where(h => !string.IsNullOrEmpty(h.Value))
                                           .Select(h => h.Value).ToArray();

            services.AddCors(options =>
            {
                options.AddPolicy(_allowOriginPolicy,
                builder =>
                {
                    builder.WithOrigins(allowedCors)
                                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials();
                });
            });
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                             .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerServices();

            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
                

            #region Register Application Services
            ConfigServices.Register(services);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger

            var swaggerEndPoint = Configuration["SwaggerEndPoint"];
            if (string.IsNullOrEmpty(swaggerEndPoint))
                swaggerEndPoint = "/swagger/v1/swagger.json";

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerEndPoint, "Order Management API Version 1");
                c.ConfigObject.DocExpansion = Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List;
                c.ConfigObject.Filter = string.Empty;
                c.ConfigObject.ShowCommonExtensions = true;
                c.ConfigObject.DefaultModelRendering = Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Example;
                c.DisplayOperationId();
            });
            #endregion

            app.UseRouting();

            app.UseCors(_allowOriginPolicy);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
