using SystemInsight.API.Extensions;
using SystemInsight.API.Endpoints;
using SystemInsight.Application.DependencyInjection;
using SystemInsight.Infrastructure.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddEndpointsApiExplorer();   
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapSystemInfoEndpoints();
app.MapCpuEndpoints();

app.Run();