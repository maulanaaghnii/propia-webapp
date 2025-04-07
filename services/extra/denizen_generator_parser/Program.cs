using System;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using denizen_generator_parser.Data;
using denizen_generator_parser.Models;
using denizen_generator_parser.Services;
using System.IO;
using Microsoft.OpenApi.Models;
var port = 47002;
var serviceName = "Denizen Generator";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext
try 
{
    var connectionString = builder.Configuration.GetConnectionString("MySQL");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("Connection string 'MySQL' not found in configuration.");
    }
    
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySql(connectionString, serverVersion));
}
catch (Exception ex)
{
    Console.WriteLine($"Database configuration error: {ex.Message}");
    // Continue without database in development
    if (!builder.Environment.IsDevelopment())
    {
        throw; // Re-throw in production
    }
}

// Register Services
builder.Services.AddScoped<IBloodTypeService, BloodTypeService>();
builder.Services.AddScoped<IEyeColorService, EyeColorService>();
builder.Services.AddScoped<IHandednessService, HandednessService>();
builder.Services.AddScoped<IBirthTimeService, BirthTimeService>();
builder.Services.AddScoped<IDenizenService, DenizenService>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Loopback, port);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Comment out HTTPS redirection in development
// app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.MapGet($"/DenizenGenerator/ping", () => Results.Json(new { message = "pong", name = serviceName, port = $"{port}" }));
app.Run();