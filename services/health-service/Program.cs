int port = 47000;
string serviceName = "Health Service";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var endpoints = new[]
{
    new ServiceEndpoint { Name = "Population Service - Denizen", Url = "http://127.0.0.1:47001/Denizen/ping", Port = 47001 },
    new ServiceEndpoint { Name = "Denizen Generator Parser", Url = "http://127.0.0.1:47002/DenizenGenerator/ping", Port = 47002 }
};

app.MapGet("/health", async (IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var results = new List<ServiceHealth>();

    foreach (var endpoint in endpoints)
    {
        try
        {
            var response = await client.GetFromJsonAsync<PingResponse>(endpoint.Url);
            Console.WriteLine(response);
            results.Add(new ServiceHealth
            {
                ServiceName = endpoint.Name,
                Url = endpoint.Url,
                Port = endpoint.Port,
                Status = response?.Message == "pong" ? "healthy" : "unhealthy"
            });
        }
        catch
        {
            var uri = new Uri(endpoint.Url);
            Console.WriteLine(uri);
            results.Add(new ServiceHealth
            {
                ServiceName = endpoint.Name,
                Url = endpoint.Url,
                Port = uri.Port,
                Status = "unhealthy"
            });
        }

    }

    return Results.Ok(results);
})
.WithName("GetHealth")
.WithOpenApi();

app.Urls.Add($"http://localhost:{port}");
app.Run();

record ServiceEndpoint
{
    public string Name { get; init; }
    public string Url { get; init; }
    public int Port { get; init; }
}

record ServiceHealth
{
    public string ServiceName { get; init; }
    public string Url { get; init; }
    public int Port { get; init; }
    public string Status { get; init; }
}

record PingResponse
{
    public string Name { get; init; }
    public int Port { get; init; }
    public string Message { get; init; }
}
