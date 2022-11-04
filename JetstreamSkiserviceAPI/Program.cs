using JetstreamSkiserviceAPI.Models;
using JetstreamSkiserviceAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddControllers();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
