using JetstreamSkiserviceAPI.Models;
using JetstreamSkiserviceAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using JWTAuthentication.Services;
using Microsoft.OpenApi.Models;

// --- Datenbank erstellen ---
// Add-Migration InitialCreate
// Update-Database

// --- Datenbank updaten ---
// Add-Migration LimitStrings
// Update-Database

namespace AspNetCoreWebApi6
{
    /// <summary>
    /// Klasse wo Programm startet
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // SQL verbindung herstellen
            builder.Services.AddDbContext<RegistrationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RegistrationDB")));

            // Seri Logger mit appsettings.json Konfiguration
            var loggerFromSettings = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            // Logger instanziieren
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(loggerFromSettings);

            // DI (Dependency Injection) konfigurieren
            builder.Services.AddScoped<IRegistrationService, RegistrationServiceSQL>();
            builder.Services.AddScoped<IStatusService, StatusServiceSQL>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            // Controller instanziieren
            builder.Services.AddControllers();

            // Swagger/OpenAPI konfigurieren
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jetstream Skiservice API", Version = "v1" });
            });

            // JWT konfigurieren
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

            // Swagger konfigurieren
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jetstream Skiservice API v1"));
            }

            app.UseHttpsRedirection();

            // Authentifikation instanziieren
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}