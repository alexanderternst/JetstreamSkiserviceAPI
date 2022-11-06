using JetstreamSkiserviceAPI.Models;
using JetstreamSkiserviceAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using JWTAuthentication.Services;
using JetstreamSkiserviceAPI.Controllers;
using Microsoft.OpenApi.Models;

// Add-Migration InitialCreate
// Update-Database

// Updates
// Add-Migration LimitStrings
// Update-Database

namespace AspNetCoreWebApi6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<RegistrationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RegistrationDB")));

            // Seri Logger mit appsettings.json Konfiguration
            var loggerFromSettings = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(loggerFromSettings);

            // configure DI for application services
            // alle services die wir wollen registrieren
            // AddScoped, AddSingleton, AddTransient (wie viele instanzen, soll es von service geben)
            builder.Services.AddScoped<IRegistrationService, RegistrationServiceSQL>();
            builder.Services.AddScoped<IStatusService, StatusServiceSQL>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jetstream Skiservice API", Version = "v1" });
            });

            //
            // JWT
            //       
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidateIssuer = false,
                    ValidateAudience = false
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT v1"));
            }

            app.UseHttpsRedirection();

            // Auth
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }

    }
}
