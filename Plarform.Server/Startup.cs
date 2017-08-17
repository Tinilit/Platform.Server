using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Platform.DataAccess;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;
using Platform.DataAccess.Repositories;

namespace Plarform.Server
{
    public class Startup
    {
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddDbContext<PlatformContext>(ServiceLifetime.Scoped);
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<ITestTypeRepository, TestTypeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<PlatformDbInitializer>();
            services.AddTransient<PlatformIdentityInitializer>();
            services.AddIdentity<User, IdentityRole>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;
                x.Password.RequiredLength = 4;
            }).AddEntityFrameworkStores<PlatformContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper();
            services.AddCors();

            // Add framework services.
            services
                .AddMvc(options =>
                {
                    //enables https
                    //options.Filters.Add(new RequireHttpsAttribute());
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            PlatformDbInitializer seeder,
            PlatformIdentityInitializer identitySeeder)
        {
            loggerFactory.AddConsole(_config.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(x =>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseIdentity();
            app.UseJwtBearerAuthentication(new JwtBearerOptions()
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidAudience = _config["Tokens:Audience"],
                    ValidIssuer = _config["Tokens:Issuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"])),
                    ValidateLifetime = true
                }
            });
            app.UseMvc();
            seeder.Seed().Wait();
            identitySeeder.Seed().Wait();
        }
    }
}
