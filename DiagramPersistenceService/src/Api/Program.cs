using FastEndpoints.Swagger;

var bld = WebApplication.CreateBuilder();
bld.Services
.AddFastEndpoints()
.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "BloomUML: DiagramPersistenceService API";
        s.Version = "v1";
    };
});

var app = bld.Build();
app
.UseFastEndpoints()
.UseSwaggerGen();
app.Run();