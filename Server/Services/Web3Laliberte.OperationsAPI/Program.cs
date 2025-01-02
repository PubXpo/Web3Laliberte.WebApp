using System;
using dotenv.net;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Web3Laliberte.OperationsAPI.Data;
using Web3Laliberte.OperationsAPI.Repositories;
using Web3Laliberte.OperationsAPI.Repository.ContactLog;
using Web3Laliberte.OperationsAPI.Repository.Orders;
using Web3Laliberte.OperationsAPI.Service.ContactLog;
using Web3Laliberte.OperationsAPI.Service.Orders;
using Web3Laliberte.OperationsAPI.Services;
using Web3Laliberte.OperationsAPI.Utility;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
DotEnv.Load();

// Determine environment and use appropriate settings
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true)
    .AddEnvironmentVariables();

var configuration = builder.Configuration;

// Get the connection string from configuration
var connectionStringTemplate = configuration.GetConnectionString("DefaultConnection");

// Replace placeholders with environment variables
var connectionString = connectionStringTemplate?
    .Replace("${DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST"))
    .Replace("${DB_DATABASE}", Environment.GetEnvironmentVariable("DB_DATABASE"))
    .Replace("${DB_USER}", Environment.GetEnvironmentVariable("DB_USER"))
    .Replace("${DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD"));

Console.WriteLine("Connection String: " + connectionString); // For debugging purposes

// Configure DbContext with the constructed connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString,
        new MySqlServerVersion(new Version(8, 0)),
        mysqlOptions => mysqlOptions.EnableRetryOnFailure()));

// Register dependencies
builder.Services.AddScoped<IContactLogRepository, ContactLogRepository>();
builder.Services.AddScoped<IContactLogService, ContactLogService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IFAQService, FAQService>();
builder.Services.AddScoped<IFAQRepository, FAQRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web3L v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.UseWebSockets();

app.MapControllers();

app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        await WebSocketHandler.HandleWebSocketAsync(webSocket);
    }
    else
    {
        context.Response.StatusCode = 400;
    }
});

app.Logger.LogInformation("Application started");
Console.WriteLine("Connection String: " + connectionString);

await app.RunAsync();