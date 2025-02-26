using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable middleware to serve generated Swagger as a JSON endpoint and the UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Health endpoint (GET /health)
app.MapGet("/health", () =>
{
    // Return HTTP 200 with a simple message
    return Results.Ok("Service is healthy and running.");
})
.Produces<string>(StatusCodes.Status200OK);

app.MapPost("/xml", async (HttpRequest request) =>
{
    // Read raw XML from the body
    using var reader = new StreamReader(request.Body);
    var xmlContent = await reader.ReadToEndAsync();

    Console.WriteLine($"Received {xmlContent.Length} characters.");

    // Here you can do anything with the XML, e.g., parse or transform, etc.
    // For simplicity, we just echo it back in this example.
    return Results.Content($"Received {xmlContent.Length} characters.", "application/text");
})
// Inform swagger about supported content types and response types
.Accepts<string>("application/xml")
.Produces<string>(StatusCodes.Status200OK);

app.Run();
