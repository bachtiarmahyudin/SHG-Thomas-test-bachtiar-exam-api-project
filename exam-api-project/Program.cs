using ExamAPI.Context;
using ExamAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.Sources.Clear();

        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("serilog.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        if (args != null)
        {
            config.AddCommandLine(args);
        }
    })
    .UseSerilog((hostingContext, loggerConfig) =>
    {
        loggerConfig.ReadFrom.Configuration(hostingContext.Configuration, sectionName: "Serilog");
    });

// Add services to the container.

builder.Services.AddControllers();

ConfigureDatabase(builder.Services);
ConfigureRepositories(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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

void ConfigureDatabase(IServiceCollection services)
{
    services.AddDbContext<DatabaseContext>(option =>
    {
        option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
}

void ConfigureRepositories(IServiceCollection services)
{
    services.Scan(scan => scan
        .FromAssemblyOf<IDocumentRepository>()
        .AddClasses(classes => classes
            .Where(t => t.Name.EndsWith("Repository")))
        .AsImplementedInterfaces()
        .WithScopedLifetime());
}