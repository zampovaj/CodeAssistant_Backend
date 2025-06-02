
using CodeAssistant.Infrastructure;
using System.Text.Json.Serialization;
using CodeAssistant.API.Formatters;
using Microsoft.Build.Locator;


// Create a new web application builder
var builder = WebApplication.CreateBuilder(args);

MSBuildLocator.RegisterDefaults();

// Add MVC controllers and customize JSON serialization
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Serialize enums as strings for readability and frontend compatibility
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Add a custom input formatter to support plain text input (for raw code snippets)
builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, new PlainTextInputFormatter());
});

// Configure CORS to allow unrestricted access (for development or public API)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Register Swagger/OpenAPI for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register infrastructure services
builder.Services.AddInfrastructure();
Analyzer.Core.Infrastructure.DependencyInjection.AddAnalyzerCore(builder.Services);

var app = builder.Build();

// Enable CORS
app.UseCors("AllowAll");

// Enable Swagger UI in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map HTTP routes to controllers
app.MapControllers();

app.Run();
