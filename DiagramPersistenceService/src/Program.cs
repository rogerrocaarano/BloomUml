using FastEndpoints;
using FastEndpoints.Swagger;
using OpenDDD.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add OpenDDD services
builder.Services.AddOpenDDD(
    builder.Configuration,
    options =>
    {
        options.UseInMemoryDatabase().EnableAutoRegistration();
    }
);

// Add FastEndpoints services
builder.Services.AddFastEndpoints().SwaggerDocument();

var app = builder.Build();

// Use OpenDDD middleware
app.UseOpenDDD();

// Use FastEndpoints middleware
app.UseFastEndpoints().UseSwaggerGen();

app.Run();
