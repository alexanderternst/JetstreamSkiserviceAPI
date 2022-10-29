using JetstreamServiceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;


var contextOptions = new DbContextOptionsBuilder<RegistrationContext>()
            .UseSqlServer(@"Server=ALEXANDERPC;Database=Registration;Trusted_Connection=True")
            .Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Seri Logger mit appsettings.json Konfiguration
var loggerFromSettings = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(loggerFromSettings);

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

// this is a test of a github branch
