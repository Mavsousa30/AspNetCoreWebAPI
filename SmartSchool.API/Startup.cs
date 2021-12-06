using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartSchool.API.Data;
using Newtonsoft;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace SmartSchool.API
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

            services.AddDbContext<SmartContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("default"))
                );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepository, Repository>();

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            })
                .AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                });

            services.AddControllers()
                .AddNewtonsoftJson(
                opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var apiProviderDescription = services.BuildServiceProvider()
                .GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(options =>
                {

                    foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(
                            description.GroupName,
                            new Microsoft.OpenApi.Models.OpenApiInfo()
                            {
                                Title = "SmartSchool API",
                                Version = description.ApiVersion.ToString(),
                                TermsOfService = new Uri("http://TermosDeUso.com"),
                                Description = "Descrição da WebAPI do SmartSchool",
                                License = new Microsoft.OpenApi.Models.OpenApiLicense
                                {
                                    Name = "SmarSchool License",
                                    Url = new Uri("http://license.com")
                                },
                                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                                {
                                    Name = "Marco Sousa",
                                    Email = "bla@gmail.com",
                                    Url = new Uri("http://contato.com")
                                }
                            });
                    }

                    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);

                    options.IncludeXmlComments(xmlCommentFullPath);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiProviderDescription)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger()
                .UseSwaggerUI(options =>
                {

                    foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"swagger/{description.GroupName}/swagger.json", 
                            description.GroupName.ToUpperInvariant());
                    }

                    options.RoutePrefix = "";
                });

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
