using SystemInsight.API.Extensions;
using SystemInsight.Application.DependencyInjection;
using SystemInsight.Infrastructure.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddEndpointsApiExplorer();   
builder.Services.AddOpenApiDocument();

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();
app.UseOpenApi();
app.RegisterAllEndpoints();

app.UseSwaggerUi(); 

app.Run();