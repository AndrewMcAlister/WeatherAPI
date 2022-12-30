using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using WeatherAPI.BusinessLogic;
using WeatherTypes.Interfaces;
using WeatherAPI.Services;
using WeatherTypes.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.json")
    .AddEnvironmentVariables()
    .Build();

//Make the weather config available by injection
var wdc = configuration.GetRequiredSection("WeatherDataConfig").Get<WeatherDataConfig>();
if(wdc !=null)
{
    builder.Services.AddSingleton<IWeatherDataConfig>(wdc);
}

builder.Services.AddDistributedMemoryCache();
builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddTransient<IRateLimiter, RateLimiter>();

builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ApiVersionReader = new UrlSegmentApiVersionReader();
});

var app = builder.Build();

app.UseHttpLogging();
// Configure the HTTP request pipeline.Failed to load API definition
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
