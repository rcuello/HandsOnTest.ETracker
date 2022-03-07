using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using HandsOnTest.ETracker.Domain.DealerTrack;
using HandsOnTest.ETracker.Domain.Validators;
using HandsOnTest.ETracker.CsvParser.Repository;
using HandsOnTest.ETracker.Domain.Mapping;
using FluentValidation.AspNetCore;
using HandsOnTest.ETracker.Services.WebApi.ErrorHandling;
using FluentValidation;

namespace HandsOnTest.ETracker.Services.WebApi
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

            services.AddCors();
            services.AddControllers();
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IDealerTrackDomain, DealerTrackDomain>();
            services.AddScoped<ICsvFileValidator, CsvFileValidator>();
            services.AddScoped<IDealerTrackCsvReaderRepository, DealerTrackCsvReaderRepository>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "E-CarShop Api",
                    Version = "v1",
                    Description = "A simple CSV parser in ASP.Net Core Web API",
                    TermsOfService = new Uri("https://dummysite.com"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Ronald Cuello",
                        Email = "ronaldcuello@gmail.com",
                        Url = new Uri("https://github.com/rcuello"),
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            services.AddMvc().AddFluentValidation();
            services.AddValidatorsFromAssemblyContaining<DealerTrackViewModelValidator>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //UnhandleError handling
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Carshop Api v1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
