using SystemInsight.API.Extensions;
using SystemInsight.Application.DependencyInjection;
using SystemInsight.Infrastructure.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddEndpointsApiExplorer();   
builder.Services.AddOpenApiDocument();

var app = builder.Build();


app.UseHttpsRedirection();
app.RegisterAllEndpoints();

app.MapGet("/docs", async context =>
{
    const string redocHtml = """
    <!DOCTYPE html>
    <html>
      <head>
        <title>System Insight API Docs</title>
        <script src="https://cdn.redoc.ly/redoc/latest/bundles/redoc.standalone.js"></script>
      </head>
      <body>
       <redoc spec-url='/swagger/swagger.json'></redoc>
      </body>
    </html>
    """;

    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(redocHtml);
});

app.UseOpenApi(); 
app.Run();