using BestStories.Api;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(e =>
{
    e.SwaggerDoc("v1", new OpenApiInfo { Title = "Best Stories Api", Version = "v1" });
});

builder.Services.AddHttpClient<HackerNewsService>(e =>
{
    e.BaseAddress = new Uri(builder.Configuration.GetSection("HackerNewsApi")["BaseAddress"]);
});

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(e =>
    {
        e.SwaggerEndpoint("/swagger/v1/swagger.json", "Best Stories Api");
    });
}

app.MapControllers();

app.Run();