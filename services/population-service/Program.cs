using population_service.Data;
using Microsoft.EntityFrameworkCore;

// init
int port = 47001;  // Sesuaikan dengan port di appsettings.json
string serviceName = "Population Service";

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Configuration["DatabaseProvider"] ?? "SQLServer";
var connectionString = builder.Configuration.GetConnectionString(provider);

switch (provider.ToLower())
{
    case "mysql":
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        break;
    case "postgresql":
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));
        break;
    default: // SQLServer
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        break;
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Loopback, port);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();


app.MapControllers();
app.MapGet($"/Denizen/ping", () => Results.Json(new { message = "pong", name = serviceName, port = $"{port}" }));
app.Run();
