using System.Collections.Generic;
using System.IO;
using hateSpeach.Models;
using hateSpeach.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace hateSpeach
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
            services.AddDbContext<AppDbContext>(options =>
            {
                 options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "SafeMedia API",
                        Version = "v1",
                        Description = "Open Machine Learning API for sentiment analysis",
                        TermsOfService = "Knock yourself out",
                        Contact = new Contact
                        {
                            Name = "Team",
                            Email = "i@amansulaiman.me"
                        }, License = new License(){Name = "MIT", Url="https://github.com/amansulaiman/SafeMedia"}
                    }
                 );
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "hateSpeach.xml");
                c.IncludeXmlComments(filePath);
                //c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                //{
                //    In = "header",
                //    Description = "Please insert JWT with Bearer into field",
                //    Name = "Authorization",
                //    Type = "apiKey"
                //});

                //c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                //{
                //    { "Bearer", new string[] { } }
                //});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSwagger(c =>
           {
               c.RouteTemplate = "api-docs/{documentName}/swagger.json";


           });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-docs";
                //c.ShowRequestHeaders();
                c.SwaggerEndpoint("/api-docs/v1/swagger.json", "SafeMedia API v1");
                
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

        }
    }
}
